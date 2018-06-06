using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DPAWaiver.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DPAWaiver.Pages {
    public class CreateWaiverEquipmentPrinterModel : PageModel {
        public void OnGet () {

        }

        private readonly List<SingleFunctionPrinterPreferences> printerList = new List<SingleFunctionPrinterPreferences> ();
        public IEnumerable<SelectListItem> PrinterListSelectList => iLOVService.GetAllSingleFunctionPrinterPreferencesAsSelectList();
        private readonly ILOVService iLOVService;

        public CreateWaiverEquipmentPrinterModel (ILOVService iLOVService) {
            this.iLOVService = iLOVService;
        }
        public JsonResult OnPostPrinter (int printerId) {
            foreach (var printer in iLOVService.getSingleFunctionPrinterPreferences())
            {
                if (printer.ID == printerId) {
                    return new JsonResult(new object[] {printer});
                }
            }    
            return new JsonResult(new object[] {});
        }

    }
}