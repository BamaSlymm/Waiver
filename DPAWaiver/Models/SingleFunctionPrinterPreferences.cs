using System;
using System.Collections.Generic;

namespace DPAWaiver.Models
{
    public class SingleFunctionPrinterPreferences 
    {

        public int ID { get; set; }
        public string name { get; set; }
        public int sortOrder { get; set; }

        public bool isDeletable { get; set; }

        public bool isDisabled { get; set; }


        public decimal equipmentPurchaseCost { get; set; }

        public int monthlyColorVolume { get; set; }
        public decimal blackTonerCost { get; set; }
        public int pageYieldForBlackToner { get; set; }

        public bool colorTonerDisabled { get; set; } = true;

        public decimal cyanTonerCost { get; set; } = 0m;
        public int pageYieldForCyanToner { get; set; } = 0;

        public decimal MagentaTonerCost { get; set; } = 0m;
        public int pageYieldForMagentaToner { get; set; } = 0;


        public decimal YellowTonerCost { get; set; } = 0m;
        public int pageYieldForYellowToner { get; set; } = 0;


        public SingleFunctionPrinterPreferences(int ID, string name, int sortOrder, bool isDeletable, bool isDisabled, decimal equipmentPurchaseCost, decimal blackTonerCost,
                                                int pageYieldForBlackToner)
        {
            this.ID = ID;
            this.name = name;
            this.sortOrder = sortOrder;
            this.isDeletable = isDeletable;
            this.isDisabled = isDisabled;
            this.equipmentPurchaseCost = equipmentPurchaseCost;
            this.blackTonerCost = blackTonerCost;
            this.pageYieldForBlackToner = pageYieldForBlackToner;
        }

        public void Update(SingleFunctionPrinterPreferences other)
        {
            if (other == null) {
                return  ;
            }

            this.ID = other.ID;
            this.name = other.name;
            this.sortOrder = other.sortOrder;
            this.isDeletable = other.isDeletable;
            this.isDisabled = other.isDisabled;
            this.equipmentPurchaseCost = other.equipmentPurchaseCost ;
            this.monthlyColorVolume = other.monthlyColorVolume ;
            this.blackTonerCost = other.blackTonerCost ;
            this.pageYieldForBlackToner = other.pageYieldForBlackToner ;
            this.colorTonerDisabled = other.colorTonerDisabled ;
            this.cyanTonerCost = other.cyanTonerCost ;
            this.pageYieldForCyanToner = other.pageYieldForCyanToner ;
            this.MagentaTonerCost = other.MagentaTonerCost ;
            this.pageYieldForMagentaToner = other.pageYieldForMagentaToner ;
            this.YellowTonerCost = other.YellowTonerCost ;
            this.pageYieldForYellowToner = other.pageYieldForYellowToner ;
            return;
        }
    }
}