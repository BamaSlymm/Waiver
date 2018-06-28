using System;
using System.Collections.Generic;

namespace DPAWaiver.Models
{
    public class SingleFunctionPrinterPreferences : BaseLOV
    {
        public decimal equipmentPurchaseCost { get; set; }

        public int monthlyColorVolume {get; set;}
        public decimal blackTonerCost { get; set; } 
        public int pageYieldForBlackToner { get; set; }

        public decimal cyanTonerCost { get; set; } = 0m;
        public int pageYieldForCyanToner { get; set; } = 0;

        public bool cyanReadOnly {get; set; } = true ;

        public decimal magentaTonerCost { get; set; } = 0m; 
        public int pageYieldForMagentaToner { get; set; } = 0;

        public bool magentaReadOnly {get; set;} = true ;

        public decimal yellowTonerCost { get; set; } = 0m;
        public int pageYieldForYellowToner { get; set; } = 0;

        public bool yellowReadOnly { get ; set;} = true ;
        
        public SingleFunctionPrinterPreferences(int ID, string name, int sortOrder, bool isDeletable, bool isDisabled, decimal equipmentPurchaseCost, decimal blackTonerCost,
                                                int pageYieldForBlackToner) 
            : base(ID, name, sortOrder, isDeletable, isDisabled)
        {
            this.equipmentPurchaseCost = equipmentPurchaseCost ;
            this.blackTonerCost = blackTonerCost;
            this.pageYieldForBlackToner = pageYieldForBlackToner;
        }

        public void enableColorToners(){
            this.cyanReadOnly = false;
            this.magentaReadOnly = false;
            this.yellowReadOnly = false;
        }
    }
}