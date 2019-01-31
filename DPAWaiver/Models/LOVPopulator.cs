using System;
using System.Collections.Generic;
using System.Linq;
using DPAWaiver.Models.LOV;
using DPAWaiver.Models.WaiverSelection;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DPAWaiver.Models
{
    public class LOVPopulator : ILOVPopulator
    {

        public List<SingleFunctionPrinterPreferences> getSingleFunctionPrinterPreferences()
        {
            var printerList = new List<SingleFunctionPrinterPreferences>();
            var other =
                new SingleFunctionPrinterPreferences(1, "Other", 9999, false, false, 0m, 0m, 4500);
            other.colorTonerDisabled = false;

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
            m553dn.MagentaTonerCost = 306.99m;
            m553dn.pageYieldForMagentaToner = 4750;
            m553dn.YellowTonerCost = 306.99m;
            m553dn.pageYieldForYellowToner = 4750;
            m553dn.colorTonerDisabled = false;

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

        public List<MicrofilmOutputType> getMicrofilmOutputTypes()
        {

            return new List<MicrofilmOutputType>() {
                new MicrofilmOutputType(ID: 1, name:"16 mm diazo film",  sortOrder: 1, isDeletable:true, isDisabled:false),
                new MicrofilmOutputType(ID: 2, name:"16 mm silver film", sortOrder: 2, isDeletable:true, isDisabled:false),
                new MicrofilmOutputType(ID: 3, name:"35 mm diazo film",  sortOrder: 3, isDeletable:true, isDisabled:false),
                new MicrofilmOutputType(ID: 4, name:"35 mm silver film", sortOrder: 4, isDeletable:true, isDisabled:false)
            };

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

        public List<Department> getDepartments()
        {

            return new List<Department>() {
                new Department(ID: Departments.OIT,  name:"Office of Innovation and Technology",  sortOrder: 1, isDeletable:false, isDisabled:false),
                new Department(ID: Departments.Agriculture,  name:"Agriculture", sortOrder: 2, isDeletable:false, isDisabled:false),
                new Department(ID: Departments.Corrections,  name:"Corrections",  sortOrder: 3, isDeletable:false, isDisabled:false),
                new Department(ID: Departments.Education,  name:"Education", sortOrder: 4, isDeletable:false, isDisabled:false),
                new Department(ID: Departments.GeneralAssembly,  name:"General Assembly",  sortOrder: 5, isDeletable:false, isDisabled:false),
                new Department(ID: Departments.GovernorsOffice,  name:"Governors Office", sortOrder: 6, isDeletable:false, isDisabled:false),
                new Department(ID: Departments.HCPF,  name:"Health Care Policy and Financing",  sortOrder: 7, isDeletable:false, isDisabled:false),
                new Department(ID: Departments.HigherEducation,  name:"Higher Education", sortOrder: 8, isDeletable:false, isDisabled:false),
                new Department(ID: Departments.HumanServices,  name:"Human Services",  sortOrder: 9, isDeletable:false, isDisabled:false),
                new Department(ID: Departments.Judicial, name:"Judicial", sortOrder: 10, isDeletable:false, isDisabled:false),
                new Department(ID: Departments.LaborAndEmployment, name:"Labor and Employment",  sortOrder: 11, isDeletable:false, isDisabled:false),
                new Department(ID: Departments.Law, name:"Law", sortOrder: 12, isDeletable:false, isDisabled:false),
                new Department(ID: Departments.LocalAffairs, name:"Local Affairs",  sortOrder: 13, isDeletable:false, isDisabled:false),
                new Department(ID: Departments.LocalGovernment, name:"Local Government", sortOrder: 14, isDeletable:false, isDisabled:false),
                new Department(ID: Departments.DMVA, name:"Military and Veterans Affairs",  sortOrder: 15, isDeletable:false, isDisabled:false),
                new Department(ID: Departments.NaturalResources, name:"Natural Resources", sortOrder: 16, isDeletable:false, isDisabled:false),
                new Department(ID: Departments.NonStateAgencyContacts, name:"Non-State Agency Contacts", sortOrder: 17, isDeletable:false, isDisabled:false),
                new Department(ID: Departments.DPA, name:"Personnel and Administration", sortOrder: 19, isDeletable:false, isDisabled:false),
                new Department(ID: Departments.PrivateNonProfitEntity, name:"Private non-profit entity",  sortOrder: 20, isDeletable:false, isDisabled:false),
                new Department(ID: Departments.CDPHE, name:"Public Health and Environment", sortOrder: 21, isDeletable:false, isDisabled:false),
                new Department(ID: Departments.PublicSafety, name:"Public Safety",  sortOrder: 22, isDeletable:false, isDisabled:false),
                new Department(ID: Departments.RegulatoryAgencies, name:"Regulatory Agencies", sortOrder: 23, isDeletable:false, isDisabled:false),
                new Department(ID: Departments.Revenue, name:"Revenue", sortOrder: 24, isDeletable:false, isDisabled:false),
                new Department(ID: Departments.State, name:"State",  sortOrder: 25, isDeletable:false, isDisabled:false),
                new Department(ID: Departments.Transportation, name:"Transportation", sortOrder: 26, isDeletable:false, isDisabled:false),
                new Department(ID: Departments.Treasury, name:"Treasury", sortOrder: 27, isDeletable:false, isDisabled:false),
                new Department(ID: Departments.Other, name:"Other",  sortOrder: 28, isDeletable:false, isDisabled:false),
            };

        }

        public List<DesignType> getDesignType()
        {

            return new List<DesignType>() {
                new DesignType(ID: 1,  name:"Forms",  sortOrder: 1, isDeletable:false, isDisabled:false),
                new DesignType(ID: 2,  name:"Graphic Art", sortOrder: 2, isDeletable:false, isDisabled:false),
                new DesignType(ID: 3,  name:"Other",  sortOrder: 9999, isDeletable:false, isDisabled:false),
                new DesignType(ID: 4,  name:"Publications", sortOrder: 4, isDeletable:false, isDisabled:false),
                new DesignType(ID: 5,  name:"Web",  sortOrder: 5, isDeletable:false, isDisabled:false)
            };

        }
        public List<Purpose> getPurposes()
        {
            var purposes = new List<Purpose> {
                new Purpose(1,name: "Service",sortOrder:1,isDeletable:false,isDisabled:false),
                new Purpose(2,name: "Personnel Request",sortOrder:2,isDeletable:false,isDisabled:false),
                new Purpose(3,name: "Equipment",sortOrder:3,isDeletable:false,isDisabled:false),
                new Purpose(4,name: "Software Related To Services",sortOrder:4,isDeletable:false,isDisabled:false),
            };
            return purposes;
        }

        public List<PurposeType> getServiceTypes() {
            var aList = new List<PurposeType> {
                new PurposeType(1,name: "Data Entry",sortOrder:1,isDeletable:false,isDisabled:false),
                new PurposeType(2,name: "Design Services",sortOrder:2,isDeletable:false,isDisabled:false),
                new PurposeType(3,name: "Mail Service",sortOrder:3,isDeletable:false,isDisabled:false),
                new PurposeType(4,name: "Print / Copy",sortOrder:4,isDeletable:false,isDisabled:false),
                new PurposeType(5,name: "Microfilm / Microfilm Conversion",sortOrder:5,isDeletable:false,isDisabled:false),
                new PurposeType(6,name: "Scanning / Imaging",sortOrder:6,isDeletable:false,isDisabled:false),
            };
            return aList;
        }

        public List<PurposeType> getPersonnelServiceTypes()
        {
            var aList = new List<PurposeType> {
                new PurposeType(7,name: "State Employee",sortOrder:1,isDeletable:false,isDisabled:false),
                new PurposeType(8,name: "Third Party Contractor",sortOrder:2,isDeletable:false,isDisabled:false),
            };
            return aList;
        }

        public List<PurposeType> getEquipmentTypes()
        {
            var aList = new List<PurposeType> {
                new PurposeType(9,name: "Mail Processing",sortOrder:1,isDeletable:false,isDisabled:false),
                new PurposeType(10,name: "Scanning/Imaging/Microfilm",sortOrder:2,isDeletable:false,isDisabled:false),
                new PurposeType(11,name: "Print/Copy",sortOrder:3,isDeletable:false,isDisabled:false),
            };
            return aList;
        }

        public List<PurposeType> getSoftwareTypes()
        {
            var aList = new List<PurposeType> {
                new PurposeType(12,name: "Data Entry",sortOrder:1,isDeletable:false,isDisabled:false),
                new PurposeType(13,name: "Design",sortOrder:2,isDeletable:false,isDisabled:false),
                new PurposeType(14,name: "Mail Processing",sortOrder:3,isDeletable:false,isDisabled:false),
                new PurposeType(15,name: "Print - Copy",sortOrder:4,isDeletable:false,isDisabled:false),
                new PurposeType(16,name: "Scanning/Imaging/Microfilm",sortOrder:5,isDeletable:false,isDisabled:false),
            };
            return aList;
        }


        public List<PurposeSubtype> getPrinterSubtypes()
        {
            var aList = new List<PurposeSubtype> {
                new PurposeSubtype(1,name: "A4 Single Function Printer",sortOrder:1,isDeletable:false,isDisabled:false),
                new PurposeSubtype(2,name: "A4 Multi Function Printer",sortOrder:2,isDeletable:false,isDisabled:false),
                new PurposeSubtype(3,name: "A3 Multi  Function Printer",sortOrder:3,isDeletable:false,isDisabled:false),
                new PurposeSubtype(4,name: "Production Copier Press",sortOrder:4,isDeletable:false,isDisabled:false),
                new PurposeSubtype(5,name: "Large Format Printer",sortOrder:5,isDeletable:false,isDisabled:false),
                new PurposeSubtype(6,name: "Label Printers",sortOrder:6,isDeletable:false,isDisabled:false),
            };
            return aList;
        }

        public List<PurposeSubtype> getMicrofilmSubtypes()
        {
            var aList = new List<PurposeSubtype> {
                new PurposeSubtype(7,name: "Microfilm",sortOrder:1,isDeletable:false,isDisabled:false),
                new PurposeSubtype(8,name: "Microfilm Conversion",sortOrder:2,isDeletable:false,isDisabled:false),
            };
            return aList;
        }

    }
}