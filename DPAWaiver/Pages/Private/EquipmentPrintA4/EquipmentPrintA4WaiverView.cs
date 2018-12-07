using System;
using System.Collections.Generic;
using System.Linq;
using DPAWaiver.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using DPAWaiver.Models.WaiverSelection;
using System.ComponentModel.DataAnnotations.Schema;

namespace DPAWaiver.Models.Waivers
{
    public class EquipmentPrintA4WaiverView
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
        [Display(Name = "Please select from the printer drop down:")]
        public string printerType { get; set; }
        
        
        [Required]
        [Display(Name = "Number of equipment?")]
        public decimal numberofEquipment {get; set;}
        
        [Required]
        [Display(Name = "Make:")]
        public string Make { get; set; }
        
        [Required]
        [Display(Name = "Model:")]
        public string Model { get; set; }

        [Required]
        [Display(Name = "Is this new addition or replacement?")]
        public string newOrReplace { get; set; }

        [Required]
        [Display(Name = "How do you currently receive this services?")]
        public string servicesReceived { get; set; }

        [Required]
        [Display(Name = "Current Average Monthly Volume")]
        public decimal currentMonthlyVolume {get; set;}

        [Required]
        [Display(Name = "Anticipated Monthly Volume")]
        public decimal anticipatedMonthlyVolume {get; set;}


        [Required]
        [Display(Name = "Reasons for selecting this particular equipment:")]
        public string selectionReason { get; set; }

        [Required]
        [Display(Name = "How do you plan to acquire this equipment?")]
        public string acquisitionType { get; set; }
        [Required]
        [Display(Name = "Solicitation SubType?")]
        public string solicitationSubType { get; set; }

        [Required]
        [Display(Name = "State Price SubType?")]
        public string statepriceSubType { get; set; }
        
        [Required]
        [Display(Name = "Purchase Amount:")]
        public decimal purchaseAmount { get; set; }
        
        
        [Required]
        [Display(Name = "Monthly Lease Amount")]
        public decimal monthlyLeaseAmount {get; set;}

        [Required]
        [Display(Name = "Number of Months of Lease")]
        public decimal monthsOfLease { get; set; }
        
        [Required]
        [Display(Name = "Yearly Maintenance Amount")]
        public decimal yearlyMaintenanceAmount {get; set;}

        [Required]
        [Display(Name = "Overall Toner Cost")]
        public decimal tonerCost { get; set; }

        [Required]
        [Display(Name = "Expected useful life at anticipated volume:")]
        public decimal usefulLife { get; set; }

        [Required]
        [Display(Name = "Please describe how OIT/DPA recommendations to consolidate printing assets are followed")]
        public string complianceDescription {get; set;}

        [Required]
        [Display(Name = "Please describe the alternatives you have examined before making the request")]
        public string alternativesDescription { get; set; }

        [Required]
        [Display(Name = "Justification For Request:")]
        public decimal justificationDescription { get; set; }       

        [Display(Name = "Any Additional Comments:")]
        public string additionalComments { get; set; }

        public WaiverStatus Status {get;set;}

        public EquipmentPrintA4WaiverView(EquipmentPrintA4Waiver other)
        {
            this.CopyFromEquipmentPrintA4Waiver(other);
        }

public void CopyFromEquipmentPrintA4Waiver(EquipmentPrintA4Waiver other) {
            this.OtherFirstName = other.OtherFirstName;
            this.OtherLastName = other.OtherLastName;
            this.projectName = other.projectName;
            this.SubmittedOn = other.SubmittedOn ;
            this.CostEstimate = other.CostEstimate ;
            this.printerType = other.printerType;
            this.numberofEquipment = other.numberofEquipment;
            this.Make = other.Make;
            this.Model = other.Model;
            this.newOrReplace = other.newOrReplace;
            this.servicesReceived = other.servicesReceived;
            this.currentMonthlyVolume = other.currentMonthlyVolume;
            this.anticipatedMonthlyVolume = other.anticipatedMonthlyVolume;
            this.selectionReason = other.selectionReason;
            this.acquisitionType = other.acquisitionType;
            this.solicitationSubType = other.solicitationSubType;
            this.statepriceSubType = other.statepriceSubType;
            this.monthlyLeaseAmount = other.monthlyLeaseAmount;
            this.yearlyMaintenanceAmount = other.yearlyMaintenanceAmount;
            this.monthsOfLease = other.monthsOfLease;
            this.purchaseAmount = other.purchaseAmount;
            this.tonerCost = other.tonerCost;
            this.usefulLife = other.usefulLife;
            this.complianceDescription = other.complianceDescription;
            this.alternativesDescription = other.alternativesDescription;
            this.justificationDescription = other.justificationDescription;            
            this.Status = other.Status;
            this.additionalComments = other.additionalComments;
        }

        
        public EquipmentPrintA4WaiverView()
        {
        }

        [Required]
        [Display(Name = "Type of Design:")]
        public int? DesignTypeID{get; set;}
        
    }

}