using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DPAWaiver.Models
{
    public interface ILOVService
    {
         IEnumerable<SelectListItem> GetAllSingleFunctionPrinterPreferencesAsSelectList();
         List<SingleFunctionPrinterPreferences> getSingleFunctionPrinterPreferences() ;
    }
}