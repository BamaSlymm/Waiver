using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DPAWaiver.Models
{
    public interface ILOVService
    {
        List<SingleFunctionPrinterPreferences> getSingleFunctionPrinterPreferences();
        IEnumerable<SelectListItem> GetAllSingleFunctionPrinterPreferencesAsSelectListBySortOrder();


        List<MultiFunctionPrinter> getMultiFunctionPrinterPreferences();
        IEnumerable<SelectListItem> GetAllMultiFunctionPrinterPreferencesAsSelectListBySortOrder();

        List<Equipment> getEquipment();
        IEnumerable<SelectListItem> GetEquipmentAsSelectListBySortOrder();

    }
}