using System;
using System.Collections.Generic;

namespace DPAWaiver.Models.LOV
{
    public class MicrofilmOutputType
    {

        public int ID { get; set; }
        public string name { get; set; }
        public int sortOrder { get; set; }
        public bool isDeletable { get; set; }
        public bool isDisabled { get; set; }



        public MicrofilmOutputType(int ID, string name, int sortOrder, bool isDeletable, bool isDisabled)
        {
            this.ID = ID;
            this.name = name;
            this.sortOrder = sortOrder;
            this.isDeletable = isDeletable;
            this.isDisabled = isDisabled;

        }

        public MicrofilmOutputType()
        {

        }

        public void Update(MicrofilmOutputType other)
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

      
    }  
    public static class MicrofilmOutputTypes 
         {

            public const int diazofilm16mm = 1;
            public const int silverfilm16mm = 2;
            public const int diazofilm35mm = 3;
            public const int silverfilm35mm = 4;
        }

}