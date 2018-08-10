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

        public IActionResult OnPost()
        {
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
                        case 1: return RedirectToPage("./CreateWaiverServiceDataEntry");
                        case 2: return RedirectToPage("./CreateWaiverServiceDesign");
                        case 3: return RedirectToPage("./CreateWaiverServiceMail");
                        case 4: return RedirectToPage("./CreateWaiverServicePrinter");
                        case 5:
                            switch (selectedSubtype)
                            {
                                case 7: return RedirectToPage("./CreateWaiverServiceMicrofilm");
                                case 8: return RedirectToPage("./CreateWaiverServiceMicrofilmConversion");
                            }
                            break;
                        case 6: return RedirectToPage("./CreateWaiverServiceScanning");
                    }
                    break;
                case 2:
                    switch (selectedType) /* see LOVPopulator.getPersonnelServiceTypes */
                    {
                        case 7: return RedirectToPage("./CreateWaiverPersonnelState");
                        case 8: return RedirectToPage("./CreateWaiverPersonnelContractor");
                    }
                    break;
                case 3:
                    switch (selectedType)
                    {
                        case 9: return RedirectToPage("./CreateWaiverEquipmentMail");
                        case 10: return RedirectToPage("./CreateWaiverEquipmentScanning");
                        case 11:
                            switch (selectedSubtype)
                            {
                                case 1: return RedirectToPage("./CreateWaiverEquipmentPrinter");
                                case 2: return RedirectToPage("./CreateWaiverEquipmentPrinterA4MultiFunction");
                                case 3: return RedirectToPage("./CreateWaiverEquipmentPrinterA3MultiFunction");
                                case 4: return RedirectToPage("./CreateWaiverEquipmentPrinterProductionCopierPress");
                                case 5: return RedirectToPage("./CreateWaiverEquipmentPrinterLargeFormat");
                                case 6: return RedirectToPage("./CreateWaiverEquipmentPrinterLabel");
                            }
                            break;
                    }
                    break;
                case 4:
                    switch (selectedType)
                    {
                        case 12: return RedirectToPage("./CreateWaiverSoftwareDataEntry");
                        case 13: return RedirectToPage("./CreateWaiverSoftwareDesign");
                        case 14: return RedirectToPage("./CreateWaiverSoftwareMailProcessing");
                    }
                    break;

            }
            return RedirectToPage(pageName: "./CreateWaiverStep1");
        }
    }
}
