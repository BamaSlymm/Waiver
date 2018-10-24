using System;
using System.Collections.Generic;

namespace DPAWaiver.Models.LOV
{
    public class DesignType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int sortOrder { get; set; }

        public bool isDeletable { get; set; }

        public bool isDisabled { get; set; }


        public DesignType(int ID, string name, int sortOrder, bool isDeletable, bool isDisabled)
        {
            this.ID = ID;
            this.Name = name;
            this.sortOrder = sortOrder;
            this.isDeletable = isDeletable;
            this.isDisabled = isDisabled;
        }

        public DesignType()
        {
        }

        public void Update(DesignType other)
        {
            if (other == null)
            {
                return;
            }
            this.ID = other.ID;
            this.Name = other.Name;
            this.sortOrder = other.sortOrder;
            this.isDeletable = other.isDeletable;
            this.isDisabled = other.isDisabled;
        }

    }
    public static class DesignTypes
    {
        public const int OIT = 1;
        public const int Agriculture = 2;
        public const int Corrections = 3;
        public const int Education = 4;

        public const int GeneralAssembly = 5;
        public const int GovernorsOffice = 6;
        public const int HCPF = 7;
        public const int HigherEducation = 8;

        public const int HumanServices = 9;
        public const int Judicial = 10;
        public const int LaborAndEmployment = 11;
        public const int Law = 12;

        public const int LocalAffairs = 13;
        public const int LocalGovernment = 14;
        public const int DMVA = 15;
        public const int NaturalResources = 16;
        public const int NonStateAgencyContacts = 17;
        public const int DPA = 18;
        public const int PrivateNonProfitEntity = 19;
        public const int CDPHE = 20;

        public const int PublicSafety = 21;
        public const int RegulatoryAgencies = 22;
        public const int Revenue = 23;
        public const int State = 24;
        public const int Transportation = 25;
        public const int Treasury = 26;
        public const int Other = 27;

    }
}