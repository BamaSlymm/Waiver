using System.Collections.Generic;
using DPAWaiver.Models.LOV;
using DPAWaiver.Models.WaiverSelection;

namespace DPAWaiver.Models
{
    public interface ILOVPopulator
    {
        List<SingleFunctionPrinterPreferences> getSingleFunctionPrinterPreferences();
        List<MultiFunctionPrinter> getMultiFunctionPrinterPreferences();
        List<Equipment> getEquipment();
        List<DesignType> getDesignType();
        List<Purpose> getPurposes();
        List<PurposeType> getServiceTypes();
        List<PurposeType> getPersonnelServiceTypes();
        List<PurposeType> getEquipmentTypes();
        List<PurposeType> getSoftwareTypes();
        List<PurposeSubtype> getPrinterSubtypes();
        List<PurposeSubtype> getMicrofilmSubtypes();
        List<MicrofilmOutputType> getMicrofilmOutputTypes();
        List<Department> getDepartments();

    }
}