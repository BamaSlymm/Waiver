using System;
using System.Collections.Generic;

namespace DPAWaiver.Models
{
    public class BaseLOV : IComparable<BaseLOV>
    {
        public BaseLOV(int ID, string name, int sortOrder, bool isDeletable, bool isDisabled)
        {
            this.ID = ID ;
            this.name = name ;
            this.sortOrder = sortOrder;
            this.isDeletable = isDeletable;
            this.isDisabled = isDisabled;
        }

        public int ID { get; set; }
        public string name { get; set; }
        public int sortOrder { get; set; }

        public bool isDeletable { get; set; }

        public bool isDisabled {get; set;}

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

      public static IComparer<BaseLOV> sortBasedOnName()
      {      
         return (IComparer<BaseLOV>) new sortBasedOnNameHelper();
      }

        public override string ToString() => ID + ":" + name + ":" + sortOrder;

    }
}