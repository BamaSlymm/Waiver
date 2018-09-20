using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DPAWaiver.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DPAWaiver.Pages {
    public class CreateWaiverEquipmentPrinterLargeFormatModel : PageModel {
        public void OnGet () {

        }

        public IEnumerable<SelectListItem> SelectList => iLOVService.GetEquipmentAsSelectListBySortOrder();
        private readonly ILOVService iLOVService;

        public CreateWaiverEquipmentPrinterLargeFormatModel (ILOVService iLOVService) {
            this.iLOVService = iLOVService;
        }
        public JsonResult OnPostPrinter (int printerId) {
            foreach (var printer in iLOVService.getEquipment())
            {
                if (printer.ID == printerId) {
                    return new JsonResult(new object[] {printer});
                }
            }    
            return new JsonResult(new object[] {});
        }

    }
}