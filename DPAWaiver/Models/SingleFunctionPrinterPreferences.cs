using System;
using System.Collections.Generic;

namespace DPAWaiver.Models
{
    public class SingleFunctionPrinterPreferences : BaseLOV
    {
        public decimal equipmentPurchaseCost { get; set; }
        public decimal blackTonerCost { get; set; }
        public int pageYieldForBlackToner { get; set; }

        public decimal cyanTonerCost { get; set; }
        public int pageYieldForCyanToner { get; set; }

        public decimal magentaTonerCost { get; set; }
        public int pageYieldForMagentaToner { get; set; }

        public decimal yellowTonerCost { get; set; }
        public int pageYieldForYellowToner { get; set; }
        
        public SingleFunctionPrinterPreferences(int ID, string name, int sortOrder, bool isDeletable, bool isDisabled,
                                                decimal equipmentPurchaseCost, decimal blackTonerCost, int pageYieldForBlackToner,
                                                decimal cyanTonerCost, int pageYieldForCyanToner,
                                                decimal magentaTonerCost, int pageYieldForMagentaToner,
                                                decimal yellowTonerCost, int pageYieldForYellowToner
        ) : base(ID, name, sortOrder, isDeletable, isDisabled)
        {
            this.equipmentPurchaseCost = equipmentPurchaseCost;
            this.blackTonerCost = blackTonerCost;
            this.pageYieldForBlackToner = pageYieldForBlackToner;
            this.cyanTonerCost = cyanTonerCost;
            this.pageYieldForCyanToner = pageYieldForCyanToner;
            this.magentaTonerCost = magentaTonerCost;
            this.pageYieldForMagentaToner = pageYieldForMagentaToner;
            this.yellowTonerCost = yellowTonerCost;
            this.pageYieldForYellowToner = pageYieldForYellowToner;
        }
    }
}