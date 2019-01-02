using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DPAWaiver.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace DPAWaiver.Pages.Private
{
    public class CreateWaiverStep1Model : PageModel
    {

        private readonly ILOVService _ILOVService;

        public CreateWaiverStep1Model (ILOVService iLOVService, ILogger<CreateWaiverStep1Model> logger) {
            _logger = logger;
            _ILOVService = iLOVService;
        }

        public IEnumerable<SelectListItem> purposes => _ILOVService.GetPurposesAsSelectListBySortOrder();
        public IEnumerable<SelectListItem> serviceTypes => _ILOVService.GetServiceTypesAsSelectListBySortOrder();
            
        public IEnumerable<SelectListItem> personalServiceTypes => _ILOVService.GetPersonnelServiceTypesAsSelectListBySortOrder();
        public IEnumerable<SelectListItem> microfilmSubtypes => _ILOVService.GetMicrofilmSubtypesAsSelectListBySortOrder();

        public IEnumerable<SelectListItem> printerSubtypes => _ILOVService.GetPrinterSubtypesAsSelectListBySortOrder();

        public IEnumerable<SelectListItem> equipmentTypes => _ILOVService.GetEquipmentTypesAsSelectListBySortOrder(); 

        public IEnumerable<SelectListItem> softwareTypes => _ILOVService.GetSoftwareTypesAsSelectListBySortOrder(); 

        [BindProperty]
        public int selectedPurpose { set; get; }

        [BindProperty]
        public int selectedType { set; get; }
        [BindProperty]
        public int selectedSubtype { set; get; }
        private readonly ILogger _logger;


        [BindProperty]
        [Display(Name = "Waiver Owner First Name")]
        public string OtherFirstName {set;get;}

        [BindProperty]
        [Display(Name = "Waiver Owner Last Name")]
        public string OtherLastName {set;get;}

        public void OnGet()
        {
        }

        public JsonResult OnPostPurpose(int purposeId)
        {
            switch (purposeId)
            {
                case 1: return new JsonResult(serviceTypes);
                case 2: return new JsonResult(personalServiceTypes);
                case 3: return new JsonResult(equipmentTypes);
                case 4: return new JsonResult(softwareTypes);
            }
            return new JsonResult(new object[] { });
        }

        public JsonResult OnPostType(int typeId)
        {
            switch (typeId)
            {
                case 5: return new JsonResult(microfilmSubtypes);
                case 11: return new JsonResult(printerSubtypes);
            }
            return new JsonResult(new object[] { });
        }

        public IActionResult OnPost([FromQuery(Name = "otherFirstName")] string otherFirstName,[FromQuery(Name = "otherLastName")] string otherLastName)
        {
            // _otherFirstName = otherFirstName ;
            // _otherLastName = otherLastName ;
            _logger.LogInformation("Selected purpose {1} Selected type {2}, subtype {3}", selectedPurpose, selectedType, selectedSubtype);
            if (!ModelState.IsValid)
            {
                return Page();
            }
            switch (selectedPurpose)
            {
                case 1:
                    switch (selectedType)
                    {
                        case 1: return RedirectToPage("./DataEntry/Create", new{otherFirstName= OtherFirstName, otherLastName= OtherLastName});
                        case 2: return RedirectToPage("./ServiceDesign/Create");
                        case 3: return RedirectToPage("./ServiceMail/Create");
                        case 4: return RedirectToPage("./ServicePrint/Create");
                        case 5:
                            switch (selectedSubtype)
                            {
                                case 7: return RedirectToPage("./ServiceMicrofilm/Create");
                                case 8: return RedirectToPage("./ServiceMicrofilmConversion/Create");
                            }
                            break;
                        case 6: return RedirectToPage("./ServiceScanning/Create");
                    }
                    break;
                case 2:
                    switch (selectedType) /* see LOVPopulator.getPersonnelServiceTypes */
                    {
                        case 7: return RedirectToPage("./PersonnelRequest/Create");
                        case 8: return RedirectToPage("./PersonnelContractor/Create");
                    }
                    break;
                case 3:
                    switch (selectedType)
                    {
                        case 9: return RedirectToPage("./EquipmentMail/Create");
                        case 10: return RedirectToPage("./EquipmentScanning/Create");
                        case 11:
                            switch (selectedSubtype)
                            {
                                case 1: return RedirectToPage("./EquipmentPrint/Create");
                                case 2: return RedirectToPage("./EquipmentPrintA4/Create");
                                case 3: return RedirectToPage("./EquipmentPrintA3/Create");
                                case 4: return RedirectToPage("./EquipmentPrintPress/Create");
                                case 5: return RedirectToPage("./EquipmentPrintLargeFormat/Create");
                                case 6: return RedirectToPage("./EquipmentPrintLabel/Create");
                            }
                            break;
                    }
                    break;
                case 4:
                    switch (selectedType)
                    {
                        case 12: return RedirectToPage("./SoftwareDataEntry/Create");
                        case 13: return RedirectToPage("./SoftwareDesign/Create");
                        case 14: return RedirectToPage("./SoftwareMailProcessing/Create");
                        case 15: return RedirectToPage("./SoftwarePrint/Create");
                        case 16: return RedirectToPage("./SoftwareScanning/Create");
                    }
                    break;

            }
            return RedirectToPage(pageName: "./CreateWaiverStep1");
        }
    }
}
