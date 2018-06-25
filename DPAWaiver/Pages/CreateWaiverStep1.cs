using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace DPAWaiver.Pages
{
    public class CreateWaiverStep1Model : PageModel
    {
        public List<SelectListItem> purposes { set; get; }
        public List<SelectListItem> serviceTypes { set; get; }
        public List<SelectListItem> personalServiceTypes { set; get; }
        public List<SelectListItem> microfilmSubtypes { set; get; }

        public List<SelectListItem> printerSubtypes;

        public List<SelectListItem> equipmentTypes { set; get; }

        [BindProperty]
        public int selectedPurpose { set; get; }

        [BindProperty]
        public int selectedType { set; get; }
        [BindProperty]
        public int selectedSubtype { set; get; }
        private readonly ILogger _logger;

        public CreateWaiverStep1Model(ILogger<CreateWaiverStep1Model> logger)
        {
            _logger = logger;

        }

        private void setSelects()
        {
            purposes = new List<SelectListItem> {
                new SelectListItem {Text = "Service", Value = "1"},
                new SelectListItem {Text = "Personal Request", Value = "2"},
                new SelectListItem {Text = "Equipment", Value = "3"},
                new SelectListItem {Text = "Equipment (includes related software) And Personal Services", Value = "4"},
            };

            equipmentTypes = new List<SelectListItem> {
                new SelectListItem {Text = "Mail Processing", Value = "1"},
                new SelectListItem {Text = "Scanning/Imaging/Microfilm", Value = "2"},
                new SelectListItem {Text = "Print/Copy", Value = "3"}
            };

            personalServiceTypes = new List<SelectListItem> {
                new SelectListItem {Text = "State Employee", Value = "1"},
                new SelectListItem {Text = "Third Party Contractor", Value = "2"},
            };


            serviceTypes = new List<SelectListItem> {
                new SelectListItem {Text = "Data Entry", Value = "1"},
                new SelectListItem {Text = "Design Services", Value = "2"},
                new SelectListItem {Text = "Mail Service", Value = "3"},
                new SelectListItem {Text = "Print / Copy", Value = "4"},
                new SelectListItem {Text = "Microfilm / Microfilm Conversion", Value = "5"},
                new SelectListItem {Text = "Scanning", Value = "6"},
            };

            microfilmSubtypes = new List<SelectListItem> {
                new SelectListItem {Text = "Microfilm", Value = "1"},
                new SelectListItem {Text = "Microfilm Conversion", Value = "2"},
            };

            printerSubtypes = new List<SelectListItem> {
                new SelectListItem {Text = "A4 Single Function Printer", Value = "1"},
                new SelectListItem {Text = "A4 Multi  Function Printer", Value = "2"},
                new SelectListItem {Text = "A3 Multi  Function Printer", Value = "3"},
                new SelectListItem {Text = "Production Copier Press", Value = "4"},
                new SelectListItem {Text = "Large Format Printer", Value = "5"},
                new SelectListItem {Text = "Label Printers", Value = "6"},
            };

        }
        public void OnGet()
        {
            setSelects();
        }

        public JsonResult OnPostPurpose(int purposeId)
        {
            setSelects();
            switch (purposeId)
            {
                case 1: return new JsonResult(serviceTypes);
                case 2: return new JsonResult(personalServiceTypes);
                case 3: return new JsonResult(equipmentTypes);
            }
            return new JsonResult(new object[] {});
        }

        public JsonResult OnPostType(int typeId)
        {
            setSelects();
            switch (typeId)
            {
                case 5: return new JsonResult(microfilmSubtypes);
                case 3: return new JsonResult(printerSubtypes);
            }
            return new JsonResult(new object[] {});
        }

        public IActionResult OnPost()
        {
            _logger.LogInformation("Selected purpose {1} Selected type {2}, subtype {3}", selectedPurpose, selectedType, selectedSubtype);
            if (!ModelState.IsValid)
            {
                setSelects();
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
                                case 1: return RedirectToPage("./CreateWaiverServiceMicrofilm");
                                case 2: return RedirectToPage("./CreateWaiverServiceMicrofilmConversion");
                            }
                            break;
                        case 6: return RedirectToPage("./CreateWaiverServiceScanning");
                    }
                    break;
                case 2:
                    switch (selectedType)
                    {
                        case 1: return RedirectToPage("./CreateWaiverPersonnelState");
                        case 2: return RedirectToPage("./CreateWaiverPersonnelContractor");
                    }
                    break;
                case 3:
                    switch (selectedType)
                    {
                        case 1: return RedirectToPage("./CreateWaiverEquipmentMail");
                        case 2: return RedirectToPage("./CreateWaiverEquipmentScanning");
                        case 3:
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
            }
            return RedirectToPage(pageName: "./CreateWaiverStep1");

        }
    }
}
