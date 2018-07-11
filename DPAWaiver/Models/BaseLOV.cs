using System;
using System.Collections.Generic;
using System.Linq;

namespace DPAWaiver.Models
{
    public class BaseLOV : IComparable<BaseLOV>
    {

        public BaseLOV() { }
        public BaseLOV(int ID, string name, int sortOrder, bool isDeletable, bool isDisabled)
        {
            this.ID = ID;
            this.name = name;
            this.sortOrder = sortOrder;
            this.isDeletable = isDeletable;
            this.isDisabled = isDisabled;
        }

        public BaseLOV(int ID, string name, int sortOrder, bool isDeletable, bool isDisabled, string LOVType)
        {
            this.ID = ID;
            this.name = name;
            this.sortOrder = sortOrder;
            this.isDeletable = isDeletable;
            this.isDisabled = isDisabled;
            this.LOVType = LOVType;
        }


        public int ID { get; set; }
        public string name { get; set; }
        public int sortOrder { get; set; }

        public bool isDeletable { get; set; }

        public bool isDisabled { get; set; }

        public string LOVType {get; set;}

        int IComparable<BaseLOV>.CompareTo(BaseLOV other)
        {
            return this.sortOrder.CompareTo(other.sortOrder);
        }

        private class sortBasedOnNameHelper : IComparer<BaseLOV>
        {
            int IComparer<BaseLOV>.Compare(BaseLOV a, BaseLOV b)
            {
                return a.name.CompareTo(b.name);
            }
        }

        private class sortBasedOnIDHelper : IComparer<BaseLOV>
        {
            int IComparer<BaseLOV>.Compare(BaseLOV a, BaseLOV b)
            {
                return a.ID.CompareTo(b.ID);
            }
        }

        public static IComparer<BaseLOV> sortBasedOnName()
        {
            return (IComparer<BaseLOV>)new sortBasedOnNameHelper();
        }


        public static IComparer<BaseLOV> sortBasedOnID()
        {
            return (IComparer<BaseLOV>)new sortBasedOnIDHelper();
        }

        public override string ToString() => ID + ":" + name + ":" + sortOrder;

        public void Update(BaseLOV other)
        {
            if (other == null) {
                return  ;
            }
            if (this.ID != other.ID)
            {
                throw new ArgumentException("This.ID " + this.ID + " does not match passed in Copy Id " + other.ID);
            }
            this.name = other.name;
            this.sortOrder = other.sortOrder;
            this.isDeletable = other.isDeletable;
            this.isDisabled = other.isDisabled;
            return ;
        }

   }
}