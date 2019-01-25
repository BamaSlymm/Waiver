using System;
using System.Collections.Generic;
using System.Linq;
using DPAWaiver.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using DPAWaiver.Models.WaiverSelection;
using DPAWaiver.Models.LOV;

namespace DPAWaiver.Models.Waivers
{
    public class EquipmentPrintLabelWaiver : BaseWaiver
    {

        [Required]
        [Display(Name = "Please indicate vendor of choice:")]
        public string vendorChoice { get; set; }        
        
        [Required]
        [Display(Name = "Make:")]
        public string Make { get; set; }
        
        [Required]
        [Display(Name = "Model:")]
        public string Model { get; set; }
        
        [Required]
        [Display(Name = "Number of equipment?")]
        public decimal NumberofEquipment {get; set;}

        [Required]
        [Display(Name = "Reasons for selecting this particular equipment:")]
        public string selectionReason { get; set; }

        [Required]
        [Display(Name = "How do you currently receive this services?")]
        public string servicesReceived { get; set; }
        
        [Required]
        [Display(Name = "Purchase Amount:")]
        public decimal purchaseAmount { get; set; }

        [Required]
        [Display(Name = "Maintenance or Extended Warranty Cost")]
        public string agreementOrWarrantyCost {get; set;}

        [Required]
        [Display(Name = "Printer Replacement Cycle")]
        public decimal printerReplacementCycle {get; set;}
        
        [Required]
        [Display(Name = "Please enter replacement cycle in months")]
        public decimal otherReplacementCycle { get; set; }
        [Required]
        [Display(Name = "Monthly Cost Without Toner")]
        public string monthlyCostWithoutToner { get; set; }
        
        [Required]
        [Display(Name = "Please select from the printer drop down:")]
        public string printerType { get; set; }
        
        [Required]
        [Display(Name = "Anticipated Monochrome(black) Labels Per Month")]
        public decimal monthlyMonochromeVolume { get; set; }
        
        
        
        
        [Required]
        [Display(Name = "Anticipated Color Labels Per Month")]
        public decimal monthlyColorVolume {get; set;}

        [Required]
        [Display(Name = "Black Toner Cartridge Cost")]
        public decimal blackTonerCost { get; set; }
        
        [Required]
        [Display(Name = "Cyan Toner Cartridge Cost (if applicable)")]
        public decimal cyanTonerCost {get; set;}

        [Required]
        [Display(Name = "Magenta Toner Cartridge Cost (if applicable)")]
        public decimal magentaTonerCost { get; set; }

        [Required]
        [Display(Name = "Yellow Toner Cartridge Cost (if applicable)")]
        public decimal yellowTonerCost { get; set; }

        [Required]
        [Display(Name = "Please describe the alternatives you have examined before making the request")]
        public string alternativesDescription { get; set; }

        [Required]
        [Display(Name = "Justification For Request:")]
        public decimal justificationDescription { get; set; }       

        [Display(Name = "Any Additional Comments:")]
        public string AdditionalComments { get; set; }

        
        public EquipmentPrintLabelWaiver(DPAUser createdBy, string otherFirstName, string otherLastName,
                              Purpose purpose, PurposeType purposeType, PurposeSubtype purposeSubtype) : base(createdBy, otherFirstName, otherLastName, purpose, purposeType, purposeSubtype)
        {
        }

        public EquipmentPrintLabelWaiver()
        {
        }

    }

}