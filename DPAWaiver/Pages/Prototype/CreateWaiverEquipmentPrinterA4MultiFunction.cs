using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DPAWaiver.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DPAWaiver.Pages {
    public class CreateWaiverEquipmentPrinterA4MultiFunctionModel : PageModel {
        public void OnGet () {

        }

        public IEnumerable<SelectListItem> PrinterListSelectList => iLOVService.GetAllMultiFunctionPrinterPreferencesAsSelectListBySortOrder();
        private readonly ILOVService iLOVService;

        public CreateWaiverEquipmentPrinterA4MultiFunctionModel (ILOVService iLOVService) {
            this.iLOVService = iLOVService;
        }
        public JsonResult OnPostPrinter (int printerId) {
            foreach (var printer in iLOVService.getMultiFunctionPrinterPreferences())
            {
                if (printer.ID == printerId) {
                    return new JsonResult(new object[] {printer});
                }
            }    
            return new JsonResult(new object[] {});
        }

    }
}