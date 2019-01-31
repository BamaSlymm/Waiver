using System;
using System.Collections.Generic;
using System.Linq;
using DPAWaiver.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using DPAWaiver.Models.WaiverSelection;
using System.ComponentModel.DataAnnotations.Schema;

namespace DPAWaiver.Models.Waivers
{
    public class EquipmentPrintLabelWaiverView
    {  [Display(Name = "Waiver Owner First Name")]
        public string OtherFirstName { get; set; }

        [Display(Name = "Waiver Owner Last Name")]
        public string OtherLastName { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public string projectName {get;set;}

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Submitted Date")]
        public DateTime? SubmittedOn { get; set; }

         [Required]
        [Column(TypeName="DECIMAL(13,2)")]
        [Display(Name = "Cost Estimate")]
        [RegularExpression(@"^\d+(\.\d{0,2})?$")]
        [Range(0, 9999999999999999.99)]
        public decimal CostEstimate { get ; set;}
        
        
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
        public decimal MagentaTonerCost { get; set; }

        [Required]
        [Display(Name = "Yellow Toner Cartridge Cost (if applicable)")]
        public decimal YellowTonerCost { get; set; }

        [Required]
        [Display(Name = "Please describe the alternatives you have examined before making the request")]
        public string alternativesDescription { get; set; }

        [Required]
        [Display(Name = "Justification For Request:")]
        public decimal justificationDescription { get; set; }       

        [Display(Name = "Any Additional Comments:")]
        public string AdditionalComments { get; set; }

        public WaiverStatus Status {get;set;}

        public EquipmentPrintLabelWaiverView(EquipmentPrintLabelWaiver other)
        {
            this.CopyFromEquipmentPrintLabelWaiver(other);
        }

public void CopyFromEquipmentPrintLabelWaiver(EquipmentPrintLabelWaiver other) {
            this.OtherFirstName = other.OtherFirstName;
            this.OtherLastName = other.OtherLastName;
            this.projectName = other.projectName;
            this.SubmittedOn = other.SubmittedOn ;
            this.CostEstimate = other.CostEstimate ;
            this.printerType = other.printerType;
            this.NumberofEquipment = other.NumberofEquipment;
            this.Make = other.Make;
            this.Model = other.Model;
            this.vendorChoice = other.vendorChoice;
            this.servicesReceived = other.servicesReceived;
            this.agreementOrWarrantyCost = other.agreementOrWarrantyCost;
            this.printerReplacementCycle = other.printerReplacementCycle;
            this.selectionReason = other.selectionReason;
            this.otherReplacementCycle = other.otherReplacementCycle;
            this.monthlyCostWithoutToner = other.monthlyCostWithoutToner;
            this.monthlyMonochromeVolume = other.monthlyMonochromeVolume;
            this.monthlyColorVolume = other.monthlyColorVolume;
            this.cyanTonerCost = other.cyanTonerCost;
            this.blackTonerCost = other.blackTonerCost;
            this.purchaseAmount = other.purchaseAmount;
            this.MagentaTonerCost = other.MagentaTonerCost;
            this.YellowTonerCost = other.YellowTonerCost;
            this.alternativesDescription = other.alternativesDescription;
            this.justificationDescription = other.justificationDescription;            
            this.Status = other.Status;
            this.AdditionalComments = other.AdditionalComments;
        }

        
        public EquipmentPrintLabelWaiverView()
        {
        }

        [Required]
        [Display(Name = "Type of Design:")]
        public int? DesignTypeID{get; set;}
        
    }

}