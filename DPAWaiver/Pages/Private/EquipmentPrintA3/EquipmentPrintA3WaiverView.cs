using System;
using System.Collections.Generic;
using System.Linq;
using DPAWaiver.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using DPAWaiver.Models.WaiverSelection;
using System.ComponentModel.DataAnnotations.Schema;

namespace DPAWaiver.Models.Waivers
{
    public class EquipmentPrintA3WaiverView
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
        [Display(Name = "Is this new addition or replacement?")]
        public string newOrReplace { get; set; }

        [Display(Name = "Make:")]
        public string Make { get; set; }
        
        [Display(Name = "Model:")]
        public string Model { get; set; }

        [Required]
        [Display(Name = "How do you currently receive this services?")]
        public string servicesReceived { get; set; }

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
        [Display(Name = "Lease Duration")]
        public decimal leaseDuration { get; set; }
        

        [Required]
        [Display(Name = "Number of Months of Lease")]
        public decimal numberOfMonths {get; set;}
        
        [Required]
        [Display(Name = "Monthly Cost of Present Lease?")]
        public decimal monthlyLeaseAmount {get; set;}

        

        [Required]
        [Display(Name = "Monochrome/black cost per click associated with the lease?")]
        public decimal blackCostPerPage { get; set; }

        [Required]
        [Display(Name = "What is the Color cost per click associated with the Lease:")]
        public decimal colorCostPerPage { get; set; }

        [Required]
        [Display(Name = "Anticipated monochrome/black monthly volume:")]
        public decimal blackMonthlyVolume { get; set; }

        [Required]
        [Display(Name = "Anticipated average color monthly volume:")]
        public decimal colorMonthlyVolume { get; set; }


        [Required]
        [Display(Name = "List what accessories were added as part of your lease/rental agreement.")]
        public string leaseAccessories { get; set; }

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
        public string AdditionalComments { get; set; }

        public WaiverStatus Status {get;set;}

        public EquipmentPrintA3WaiverView(EquipmentPrintA3Waiver other)
        {
            this.CopyFromEquipmentPrintA3Waiver(other);
        }

public void CopyFromEquipmentPrintA3Waiver(EquipmentPrintA3Waiver other) {
            this.OtherFirstName = other.OtherFirstName;
            this.OtherLastName = other.OtherLastName;
            this.projectName = other.projectName;
            this.SubmittedOn = other.SubmittedOn ;
            this.CostEstimate = other.CostEstimate ;
            this.printerType = other.printerType;
            this.newOrReplace = other.newOrReplace;
            this.Make = other.Make;
            this.Model = other.Model;
            this.selectionReason = other.selectionReason;
            this.acquisitionType = other.acquisitionType;
            this.solicitationSubType = other.solicitationSubType;
            this.statepriceSubType = other.statepriceSubType;
            this.numberOfMonths = other.numberOfMonths;
            this.monthlyLeaseAmount = other.monthlyLeaseAmount;
            this.servicesReceived = other.servicesReceived;
            this.leaseDuration = other.leaseDuration;
            this.purchaseAmount = other.purchaseAmount;
            this.blackCostPerPage = other.blackCostPerPage;
            this.colorCostPerPage = other.colorCostPerPage;
            this.blackMonthlyVolume = other.blackMonthlyVolume;
            this.colorMonthlyVolume = other.colorMonthlyVolume;
            this.leaseAccessories = other.leaseAccessories;
            this.complianceDescription = other.complianceDescription;
            this.alternativesDescription = other.alternativesDescription;
            this.justificationDescription = other.justificationDescription;            
            this.Status = other.Status;
            this.AdditionalComments = other.AdditionalComments;
        }

        
        public EquipmentPrintA3WaiverView()
        {
        }

        [Required]
        [Display(Name = "Type of Design:")]
        public int? DesignTypeID{get; set;}
        
    }

}