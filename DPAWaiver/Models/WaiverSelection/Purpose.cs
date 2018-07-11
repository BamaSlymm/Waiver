using System;
using System.Collections.Generic;

namespace DPAWaiver.Models.WaiverSelection
{
    public class Purpose
    {

        public int ID { get; set; }
        public string name { get; set; }
        public int sortOrder { get; set; }
        public bool isDeletable { get; set; }
        public bool isDisabled { get; set; }


        public Purpose(int ID, string name, int sortOrder, bool isDeletable, bool isDisabled)
        {
            this.ID = ID;
            this.name = name;
            this.sortOrder = sortOrder;
            this.isDeletable = isDeletable;
            this.isDisabled = isDisabled;

        }

        public Purpose()
        {
        }

        public void Update(Purpose other)
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

        public ICollection<PurposeType> purposeTypes { get; set; }
    }
}