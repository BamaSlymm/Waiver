using System;
using System.Collections.Generic;

namespace DPAWaiver.Models.WaiverSelection
{
    public class PurposeSubtype
    {
        public int ID { get; set; }
        public string name { get; set; }
        public int sortOrder { get; set; }
        public bool isDeletable { get; set; }
        public bool isDisabled { get; set; }
        public PurposeType purposeType { get; set; }

        public PurposeSubtype(int ID, string name, int sortOrder, bool isDeletable, bool isDisabled) 
        {
            this.ID = ID;
            this.name = name;
            this.sortOrder = sortOrder;
            this.isDeletable = isDeletable;
            this.isDisabled = isDisabled;
        }

        public PurposeSubtype()
        {
        }

        public void Update(PurposeSubtype other)
        {
            if (other == null)
            {
                return;
            }
            this.ID = other.ID;
            this.name = other.name;
            this.sortOrder = other.sortOrder;
            this.isDeletable = other.isDeletable;
            this.isDisabled = other.isDisabled;
        }
        
        public static class PrintSubType
        {
            public const int SingleA4 = 1;
            public const int MultiA4 = 2;
            public const int A3 = 3;
            public const int Press = 4;
            public const int Label = 5;
            public const int Large = 6;

        }

        public static class MicrofilmSubType
        {
            public const int Microfilm = 7;
            public const int Conversion = 8;

        }


    }
}