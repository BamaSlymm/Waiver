using System;
using System.Collections.Generic;

namespace DPAWaiver.Models
{
    public class Equipment : BaseLOV
    {
        public Equipment(int ID, string name, int sortOrder, bool isDeletable, bool isDisabled) : base(ID, name, sortOrder, isDeletable, isDisabled)
        {
        }
    }
}