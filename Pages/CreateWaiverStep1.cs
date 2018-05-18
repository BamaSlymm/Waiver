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
                new SelectListItem {Text = "Equipment and/or Software Related To The Equipment", Value = "3"},
                new SelectListItem {Text = "Equipment (includes related software) And Personal Services", Value = "4"},
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


        }
        public void OnGet()
        {
            setSelects();
        }

        public JsonResult OnPostType(int purposeId)
        {
            setSelects();
            switch(purposeId) {
                case 1: return new JsonResult(serviceTypes);
                case 2: return new JsonResult(personalServiceTypes);
            }
            return new JsonResult(new object[]{new object()}) ;
        }
        public IActionResult OnPost()
        {
            _logger.LogInformation("Selected type {1}, subtype {2}", selectedType, selectedSubtype);
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
                        case 4: return RedirectToPage("./CreateWaiverServicePrint");
                        case 5:
                            switch (selectedSubtype)
                            {
                                case 1: return RedirectToPage("./CreateWaiverServiceMicrofilm");
                                case 2: return RedirectToPage("./CreateWaiverServiceMicrofilmConversion");
                            }
                            return RedirectToPage("./CreateWaiverServiceDataEntry");
                        case 6: return RedirectToPage("./CreateWaiverServiceScanning"); ;
                    }
                    break;
                case 2:
                    switch (selectedType)
                    {
                        case 1: return RedirectToPage("./CreateWaiverPersonnelState");
                        case 2: return RedirectToPage("./CreateWaiverPersonnelContractor");
                    }
                    break;
            }
            return RedirectToPage(pageName: "./CreateWaiverStep1");

        }
    }
}
