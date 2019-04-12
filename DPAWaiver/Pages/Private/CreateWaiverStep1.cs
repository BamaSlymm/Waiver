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
                        case 2: return RedirectToPage("./ServiceDesign/Create", new{otherFirstName= OtherFirstName, otherLastName= OtherLastName});
                        case 3: return RedirectToPage("./ServiceMail/Create", new{otherFirstName= OtherFirstName, otherLastName= OtherLastName});
                        case 4: return RedirectToPage("./ServicePrint/Create", new{otherFirstName= OtherFirstName, otherLastName= OtherLastName});
                        case 5:
                            switch (selectedSubtype)
                            {
                                case 7: return RedirectToPage("./ServiceMicrofilm/Create", new{otherFirstName= OtherFirstName, otherLastName= OtherLastName});
                                case 8: return RedirectToPage("./ServiceMicrofilmConversion/Create", new{otherFirstName= OtherFirstName, otherLastName= OtherLastName});
                            }
                            break;
                        case 6: return RedirectToPage("./ServiceScanning/Create", new{otherFirstName= OtherFirstName, otherLastName= OtherLastName});
                    }
                    break;
                case 2:
                    switch (selectedType) /* see LOVPopulator.getPersonnelServiceTypes */
                    {
                        case 7: return RedirectToPage("./PersonnelRequest/Create", new{otherFirstName= OtherFirstName, otherLastName= OtherLastName});
                        case 8: return RedirectToPage("./PersonnelContractor/Create", new{otherFirstName= OtherFirstName, otherLastName= OtherLastName});
                    }
                    break;
                case 3:
                    switch (selectedType)
                    {
                        case 9: return RedirectToPage("./EquipmentMail/Create", new{otherFirstName= OtherFirstName, otherLastName= OtherLastName});
                        case 10: return RedirectToPage("./EquipmentScanning/Create", new{otherFirstName= OtherFirstName, otherLastName= OtherLastName});
                        case 11:
                            switch (selectedSubtype)
                            {
                                case 1: return RedirectToPage("./EquipmentPrint/Create", new{otherFirstName= OtherFirstName, otherLastName= OtherLastName});
                                case 2: return RedirectToPage("./EquipmentPrintA4/Create", new{otherFirstName= OtherFirstName, otherLastName= OtherLastName});
                                case 3: return RedirectToPage("./EquipmentPrintA3/Create", new{otherFirstName= OtherFirstName, otherLastName= OtherLastName});
                                case 4: return RedirectToPage("./EquipmentPrintPress/Create", new{otherFirstName= OtherFirstName, otherLastName= OtherLastName});
                                case 5: return RedirectToPage("./EquipmentPrintLargeFormat/Create", new{otherFirstName= OtherFirstName, otherLastName= OtherLastName});
                                case 6: return RedirectToPage("./EquipmentPrintLabel/Create", new{otherFirstName= OtherFirstName, otherLastName= OtherLastName});
                            }
                            break;
                    }
                    break;
                case 4:
                    switch (selectedType)
                    {
                        case 12: return RedirectToPage("./SoftwareDataEntry/Create", new{otherFirstName= OtherFirstName, otherLastName= OtherLastName});
                        case 13: return RedirectToPage("./SoftwareDesign/Create", new{otherFirstName= OtherFirstName, otherLastName= OtherLastName});
                        case 14: return RedirectToPage("./SoftwareMailProcessing/Create", new{otherFirstName= OtherFirstName, otherLastName= OtherLastName});
                        case 15: return RedirectToPage("./SoftwarePrint/Create", new{otherFirstName= OtherFirstName, otherLastName= OtherLastName});
                        case 16: return RedirectToPage("./SoftwareScanning/Create", new{otherFirstName= OtherFirstName, otherLastName= OtherLastName});
                    }
                    break;

            }
            return RedirectToPage(pageName: "./CreateWaiverStep1");
        }
    }
}
