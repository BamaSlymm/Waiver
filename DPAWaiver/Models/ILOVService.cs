using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DPAWaiver.Models
{
    public interface ILOVService
    {
        List<SingleFunctionPrinterPreferences> getSingleFunctionPrinterPreferences();
        IEnumerable<SelectListItem> GetAllSingleFunctionPrinterPreferencesAsSelectList();


        List<MultiFunctionPrinter> getMultiFunctionPrinterPreferences();
        IEnumerable<SelectListItem> GetAllMultiFunctionPrinterPreferencesAsSelectList();
    }
}