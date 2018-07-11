using System;
using System.Collections.Generic;

namespace DPAWaiver.Models
{
    public class MultiFunctionPrinter
    {
        public int ID { get; set; }
        public string name { get; set; }
        public int sortOrder { get; set; }

        public bool isDeletable { get; set; }

        public bool isDisabled { get; set; }


        public MultiFunctionPrinter(int ID, string name, int sortOrder, bool isDeletable, bool isDisabled)
        {
            this.ID = ID;
            this.name = name;
            this.sortOrder = sortOrder;
            this.isDeletable = isDeletable;
            this.isDisabled = isDisabled;
        }
    }
}