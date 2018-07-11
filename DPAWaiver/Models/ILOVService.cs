using System.Collections.Generic;
using DPAWaiver.Models.WaiverSelection;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DPAWaiver.Models
{
    public interface ILOVService
    {
        List<SingleFunctionPrinterPreferences> getSingleFunctionPrinterPreferences();
        IEnumerable<SelectListItem> GetAllSingleFunctionPrinterPreferencesAsSelectListBySortOrder();


        List<MultiFunctionPrinter> getMultiFunctionPrinterPreferences();
        IEnumerable<SelectListItem> GetAllMultiFunctionPrinterPreferencesAsSelectListBySortOrder();
        IEnumerable<SelectListItem> GetPurposesAsSelectListBySortOrder();
        List<Purpose> getPurposes();

        List<PurposeType> getServiceTypes();
        IEnumerable<SelectListItem> GetServiceTypesAsSelectListBySortOrder();

        List<PurposeType> getPersonnelServiceTypes();
        IEnumerable<SelectListItem> GetPersonnelServiceTypesAsSelectListBySortOrder();
        List<PurposeType> getEquipmentTypes();
        IEnumerable<SelectListItem> GetEquipmentTypesAsSelectListBySortOrder();

        IEnumerable<SelectListItem> GetSoftwareTypesAsSelectListBySortOrder();
        List<PurposeType> getSoftwareTypes();

        IEnumerable<SelectListItem> GetPrinterSubtypesAsSelectListBySortOrder();
        List<PurposeSubtype> getPrinterSubtypes();

        IEnumerable<SelectListItem> GetMicrofilmSubtypesAsSelectListBySortOrder();
        List<PurposeSubtype> getMicrofilmSubtypes();

        IEnumerable<SelectListItem> GetEquipmentAsSelectListBySortOrder();
        List<Equipment> getEquipment();
        
    }
}