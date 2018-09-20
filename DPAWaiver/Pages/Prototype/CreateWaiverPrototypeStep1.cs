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

namespace DPAWaiver.Pages
{
    public class CreateWaiverPrototypeStep1Model : PageModel
    {

        private readonly ILOVService _ILOVService;

        public CreateWaiverPrototypeStep1Model (ILOVService iLOVService, ILogger<CreateWaiverPrototypeStep1Model> logger) {
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

        public string _otherFirstName {set;get;}
        public string _otherLastName {set;get;}

        public void OnGet([FromQuery(Name = "otherFirstName")] string otherFirstName,[FromQuery(Name = "otherLastName")] string otherLastName)
        {
            _otherFirstName = otherFirstName ;
            _otherLastName = otherLastName;
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
                        case 1: return RedirectToPage("/Prototype/CreateWaiverServiceDataEntry", new{otherFirstName= otherFirstName, otherLastName= otherLastName});
                        case 2: return RedirectToPage("/Prototype/CreateWaiverServiceDesign");
                        case 3: return RedirectToPage("/Prototype/CreateWaiverServiceMail");
                        case 4: return RedirectToPage("/Prototype/CreateWaiverServicePrinter");
                        case 5:
                            switch (selectedSubtype)
                            {
                                case 7: return RedirectToPage("/Prototype/CreateWaiverServiceMicrofilm");
                                case 8: return RedirectToPage("/Prototype/CreateWaiverServiceMicrofilmConversion");
                            }
                            break;
                        case 6: return RedirectToPage("/Prototype/CreateWaiverServiceScanning");
                    }
                    break;
                case 2:
                    switch (selectedType) /* see LOVPopulator.getPersonnelServiceTypes */
                    {
                        case 7: return RedirectToPage("/Prototype/CreateWaiverPersonnelState");
                        case 8: return RedirectToPage("/Prototype/CreateWaiverPersonnelContractor");
                    }
                    break;
                case 3:
                    switch (selectedType)
                    {
                        case 9: return RedirectToPage("/Prototype/CreateWaiverEquipmentMail");
                        case 10: return RedirectToPage("/Prototype/CreateWaiverEquipmentScanning");
                        case 11:
                            switch (selectedSubtype)
                            {
                                case 1: return RedirectToPage("/Prototype/CreateWaiverEquipmentPrinter");
                                case 2: return RedirectToPage("/Prototype/CreateWaiverEquipmentPrinterA4MultiFunction");
                                case 3: return RedirectToPage("/Prototype/CreateWaiverEquipmentPrinterA3MultiFunction");
                                case 4: return RedirectToPage("/Prototype/CreateWaiverEquipmentPrinterProductionCopierPress");
                                case 5: return RedirectToPage("/Prototype/CreateWaiverEquipmentPrinterLargeFormat");
                                case 6: return RedirectToPage("/Prototype/CreateWaiverEquipmentPrinterLabel");
                            }
                            break;
                    }
                    break;
                case 4:
                    switch (selectedType)
                    {
                        case 12: return RedirectToPage("/Prototype/CreateWaiverSoftwareDataEntry");
                        case 13: return RedirectToPage("/Prototype/CreateWaiverSoftwareDesign");
                        case 14: return RedirectToPage("/Prototype/CreateWaiverSoftwareMailProcessing");
                        case 15: return RedirectToPage("/Prototype/CreateWaiverSoftwarePrintCopy");
                        case 16: return RedirectToPage("/Prototype/CreateWaiverSoftwareScanningImaging");
                    }
                    break;

            }
            return RedirectToPage(pageName: "/Prototype/CreateWaiverProtypeStep1");
        }
    }
}
