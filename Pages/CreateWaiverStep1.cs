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
        public List<SelectListItem> types { set; get; }
        public List<SelectListItem> microfilmSubtypes { set; get; }

        [BindProperty]
        [Range(1, int.MaxValue)]
        public int selectedType { set; get; }
        [BindProperty]
        public int selectedSubtype { set; get; }

        public CreateWaiverStep1Model(ILogger<CreateWaiverStep1Model> logger)
        {
            _logger = logger;

        }
        private readonly ILogger _logger;


        private void setSelects()
        {
            types = new List<SelectListItem> {
                new SelectListItem {Text = "Data Entry", Value = "1"},
                new SelectListItem {Text = "Design Services", Value = "2"},
                new SelectListItem {Text = "Mail Service", Value = "3"},
                new SelectListItem {Text = "Print / Copy", Value = "4"},
                new SelectListItem {Text = "Microfilm / Microfilm Conversion", Value = "5"},
            };

            microfilmSubtypes = new List<SelectListItem> {
                new SelectListItem {Text = "Microfilm ", Value = "1"},
                new SelectListItem {Text = "Microfilm Conversion", Value = "2"},
            };


        }
        public void OnGet()
        {
            setSelects();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                setSelects();
                return Page();
            }
            _logger.LogInformation("Selected Type {selectedType} ",selectedType);
            if (selectedType == 1)
            {
                return RedirectToPage("./CreateWaiverServiceDataEntry");
            }
            else if (selectedType == 2)
            {
                return RedirectToPage("./CreateWaiverServiceDesign");
            }
            else if (selectedType == 3)
            {
                return RedirectToPage("./CreateWaiverServiceMail");
            }
            else if (selectedType == 4)
            {
                return RedirectToPage("./CreateWaiverServicePrint");
            }
            else if (selectedType == 5)
            {
                if (selectedSubtype == 1)
                {
                    return RedirectToPage("./CreateWaiverServiceMicrofilm");
                }
                else if (selectedSubtype == 2)
                {
                    return RedirectToPage("./CreateWaiverServiceMicrofilmConversion");
                }
            }
            return RedirectToPage("./CreateWaiverServiceMicrofilm");

        }


    }
}
