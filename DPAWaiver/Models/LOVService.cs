using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DPAWaiver.Models
{
    public class LOVService : ILOVService
    {

        public List<SingleFunctionPrinterPreferences> getSingleFunctionPrinterPreferences()
        {
            var printerList = new List<SingleFunctionPrinterPreferences>();
            var other =
                new SingleFunctionPrinterPreferences(1, "Other", 9999, false, false, 0m, 0m, 4500);
            other.colorTonerDisabled = false ;

            var m402dn =
                 new SingleFunctionPrinterPreferences(2, "M402dn", 1, true, false, 229.0m, 206.99m, 4500);
            var m608dn =
                new SingleFunctionPrinterPreferences(3, "M608dn", 2, true, false, 867.0m, 292.99m, 12500);
            var m506dn =
                new SingleFunctionPrinterPreferences(4, "M506dn", 3, true, false, 574.0m, 305.99m, 9000);
            var m609dn =
                new SingleFunctionPrinterPreferences(5, "M609dn", 4, true, false, 1316.0m, 292.99m, 12500);
            var officeJet200 =
                new SingleFunctionPrinterPreferences(6, "OfficeJet 200", 5, true, false, 232.0m, 37.99m, 300);
            var m553dn =
                new SingleFunctionPrinterPreferences(7, "M553dn", 6, true, false, 610.0m, 221.99m, 6250);

            m553dn.cyanTonerCost = 306.99m;
            m553dn.pageYieldForCyanToner = 4750;
            m553dn.magentaTonerCost = 306.99m;
            m553dn.pageYieldForMagentaToner = 4750;
            m553dn.yellowTonerCost = 306.99m;
            m553dn.pageYieldForYellowToner = 4750;
            m553dn.colorTonerDisabled = false ;

            printerList.Add(m402dn);
            printerList.Add(m608dn);
            printerList.Add(m506dn);
            printerList.Add(m609dn);
            printerList.Add(officeJet200);
            printerList.Add(m553dn);
            printerList.Add(other);
            printerList.Sort();
            return printerList;
        }
        IEnumerable<SelectListItem> ILOVService.GetAllSingleFunctionPrinterPreferencesAsSelectListBySortOrder()
        {
            return convertToSelectListBySortOrder(getSingleFunctionPrinterPreferences());
        }

        public List<MultiFunctionPrinter> getMultiFunctionPrinterPreferences()
        {

            var aList = new List<MultiFunctionPrinter>();
            aList.Add(new MultiFunctionPrinter(1, "Other", 9999, false, false));
            aList.Add(new MultiFunctionPrinter(2, "Canon", 1, true, false));
            aList.Add(new MultiFunctionPrinter(3, "HP", 2, true, false));
            aList.Add(new MultiFunctionPrinter(4, "Konica", 3, true, false));
            aList.Add(new MultiFunctionPrinter(5, "Minolta", 4, true, false));
            aList.Add(new MultiFunctionPrinter(6, "Ricoh", 5, true, false));
            aList.Add(new MultiFunctionPrinter(7, "Xerox", 6, true, false));

            return aList;
        }


        IEnumerable<SelectListItem> ILOVService.GetAllMultiFunctionPrinterPreferencesAsSelectListBySortOrder()
        {
            return convertToSelectListBySortOrder(getMultiFunctionPrinterPreferences());
        }

        public List<Equipment> getEquipment()
        {
            var aList = new List<Equipment>();
            aList.Add(new Equipment(1, "Other", 9999, false, false));
            aList.Add(new Equipment(2, "Canon", 1, true, false));
            aList.Add(new Equipment(4, "Konica", 3, true, false));
            aList.Add(new Equipment(5, "Minolta", 4, true, false));
            aList.Add(new Equipment(6, "Ricoh", 5, true, false));
            aList.Add(new Equipment(7, "Xerox", 6, true, false));

            return aList;
        }

        public IEnumerable<SelectListItem> GetEquipmentAsSelectListBySortOrder()
        {
            return convertToSelectListBySortOrder(getEquipment());
        }

        private IEnumerable<SelectListItem> convertToSelectListBySortOrder(IEnumerable<BaseLOV> enumerableList)
        {

            var selectList = new List<SelectListItem>();
            var bySortOrderList = enumerableList.OrderBy(item => item.sortOrder);
            foreach (var record in bySortOrderList)
            {
                selectList.Add(new SelectListItem { Text = record.name, Value = record.ID.ToString(), Disabled = record.isDisabled });
            }

            return selectList;
        }
    }
}