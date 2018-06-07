using System;
using System.Collections.Generic;

namespace DPAWaiver.Models
{
    public class MultiFunctionPrinter : BaseLOV
    {
        
        public MultiFunctionPrinter(int ID, string name, int sortOrder, bool isDeletable, bool isDisabled) : base(ID, name, sortOrder, isDeletable, isDisabled)
        {
        }
    }
}