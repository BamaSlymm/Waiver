using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DPAWaiver.Pages
{
    public class CreateWaiverStep1Model : PageModel
    {
        public List<SelectListItem> types { set; get; }

        [BindProperty]
        [Range(1, int.MaxValue)]
        public int selectedType { set; get; }
        public void OnGet()
        {
            types = new List<SelectListItem> {
                new SelectListItem {Text = "Data Entry", Value = "1"},
                new SelectListItem {Text = "Design Services", Value = "2"},
                new SelectListItem {Text = "Mail Service", Value = "3"},
                new SelectListItem {Text = "Print / Copy", Value = "4"},
                new SelectListItem {Text = "Scanning / Imaging / Microfilm", Value = "5"},
            };
        }

        public  IActionResult  OnPost()
        {
            if (!ModelState.IsValid)
            {
                types = new List<SelectListItem> {
                new SelectListItem {Text = "Data Entry", Value = "1"},
                new SelectListItem {Text = "Design Services", Value = "2"},
                new SelectListItem {Text = "Mail Service", Value = "3"},
                new SelectListItem {Text = "Print / Copy", Value = "4"},
                new SelectListItem {Text = "Scanning / Imaging / Microfilm", Value = "5"},
                };
                return Page();
            }
            if (selectedType == 1)
            {
                return RedirectToPage("./CreateWaiverServiceDataEntry");
            } else if (selectedType == 2) {
                return RedirectToPage("./CreateWaiverServiceDesign");
            }
            return RedirectToPage("./CreateWaiverServiceMail");

        }


    }
}
