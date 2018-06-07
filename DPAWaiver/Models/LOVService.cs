using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DPAWaiver.Models {
    public class LOVService : ILOVService {

        public List<SingleFunctionPrinterPreferences> getSingleFunctionPrinterPreferences() {
            var printerList = new List<SingleFunctionPrinterPreferences> ();
            var other =
                new SingleFunctionPrinterPreferences(1, "Other", 9999, false, false, 0m, 0m, 4500, 0, 0, 0, 0, 0, 0);
            var m402dn =
                new SingleFunctionPrinterPreferences (2, "M402dn", 1, true, false, 229.0m, 206.99m, 4500, 0, 0, 0, 0, 0, 0);
            var m608dn =
                new SingleFunctionPrinterPreferences (3, "M608dn", 2, true, false, 867.0m, 292.99m, 12500, 0, 0, 0, 0, 0, 0);
            var m506dn =
                new SingleFunctionPrinterPreferences (4, "M506dn", 3, true, false, 574.0m, 305.99m, 9000, 0, 0, 0, 0, 0, 0);
            var m609dn =
                new SingleFunctionPrinterPreferences (5, "M609dn", 4, true, false, 1316.0m, 292.99m, 12500, 0, 0, 0, 0, 0, 0);
            var officeJet200 =
                new SingleFunctionPrinterPreferences (6, "OfficeJet 200", 5, true, false, 232.0m, 37.99m, 300, 0, 0, 0, 0, 0, 0);
            var m553dn =
                new SingleFunctionPrinterPreferences (7, "M553dn", 6, true, false, 610.0m, 221.99m, 6250, cyanTonerCost : 306.99m,
                    pageYieldForCyanToner : 4750, magentaTonerCost : 306.99m, pageYieldForMagentaToner : 4750,
                    yellowTonerCost : 306.99m, pageYieldForYellowToner : 4750);

            printerList.Add (m402dn);
            printerList.Add (m608dn);
            printerList.Add (m506dn);
            printerList.Add (m609dn);
            printerList.Add (officeJet200);
            printerList.Add (m553dn);
            printerList.Add (other);
            printerList.Sort ();
            return printerList ;
        }
        IEnumerable<SelectListItem> ILOVService.GetAllSingleFunctionPrinterPreferencesAsSelectList () {
            var printerListSelectList = new List<SelectListItem>();

            foreach (var printer in getSingleFunctionPrinterPreferences()) {
                printerListSelectList.Add (new SelectListItem { Text = printer.name, Value = printer.ID.ToString () });
            }
            
            return printerListSelectList;
        }
    }
}