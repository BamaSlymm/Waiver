using System;
using System.Collections.Generic;
using System.Linq;
using DPAWaiver.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using DPAWaiver.Models.WaiverSelection;
using System.ComponentModel.DataAnnotations.Schema;

namespace DPAWaiver.Models.Waivers
{
    public class EquipmentMailWaiverView
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
        [Display(Name = "Justification for the request:")]
        public string justificationDescription { get; set; }

        
        [Required]
        [Display(Name = "The type of equipment being requested:")]
        public string equipmentDescription { get; set; }

        [Required]
        [Display(Name = "Number of equipment?")]
        public decimal NumberofEquipment { get; set; }

        [Required]
        [Display(Name = "Is this new addition or replacement?")]
        public string newOrReplace { get; set; }

        [Required]
        [Display(Name = "How do you currently receive this services?")]
        public string servicesReceived { get; set; }


        [Required]
        [Display(Name = "Monthly Cost of Present Lease?")]
        public decimal monthlyLeaseAmount {get; set;}
        
        [Required]
        [Display(Name = "Enter the mail rate. This is a numeric field; decimal can be used (i.e. 0.44)")]
        public decimal monthlyVolume {get; set;}

        [Required]
        [Display(Name = "Enter the anticipated volume for first year. This is a numeric field")]
        public decimal firstYearVolume {get; set;}

        [Required]
        [Display(Name = "Enter the anticipated volume for second year. This is a numeric field")]
        public decimal secondYearVolume {get; set;}

        [Required]
        [Display(Name = "Enter the anticipated volume for third year. This is a numeric field")]
        public decimal thirdYearVolume {get; set;}

        [Required]
        [Display(Name = "Enter the anticipated volume for fourth year. This is a numeric field")]
        public decimal fourthYearVolume {get; set;}

        [Required]
        [Display(Name = "Enter the anticipated volume for fifth year. This is a numeric field")]
        public decimal fifthYearVolume {get; set;}        

        [Display(Name = "Make:")]
        public string Make { get; set; }
        
        [Display(Name = "Model:")]
        public string Model { get; set; }

        [Display(Name = "Reasons for selecting this particular equipment:")]
        public string selectionReason { get; set; }

        [Required]
        [Display(Name = "Expected useful life at anticipated volume:")]
        public string usefulLife { get; set; }

        [Required]
        [Display(Name = "Purchase Amount:")]
        public decimal purchaseAmount { get; set; }

        [Required]
        [Display(Name = "Monthly Lease Purchase Amount:")]
        public decimal monthlyLease { get; set; }

        [Required]
        [Display(Name = "Number of Months Rental or Lease:")]
        public decimal monthsRental { get; set; } 

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
        [Display(Name = "Total Lease Amount:")]
        public decimal totalLeaseAmount { get; set; }

        [Required]
        [Display(Name = "Estimated number of FTE:")]
        public decimal EstimatedNumberofFTE { get; set; }

        [Required]
        [Display(Name = "Estimated number of hours Per FTE:")]
        public decimal estimatedNumberofHoursPerFTE { get; set; }

        [Required]
        [Display(Name = "Total Weekly Salary Cost for FTE:")]
        public decimal weeklySalaryCost { get; set; }
        
        [Required]
        [Display(Name = "Total Space Required In Square Feet:")]
        public decimal totalSpaceRequired { get; set; }

        [Required]
        [Display(Name = "Monthly Supervision Amount:")]
        public decimal monthlySupervisionAmount { get; set; }
        [Required]
        [Display(Name = "Monthly Management Amount:")]
        public decimal monthlyManagementAmount { get; set; }

        [Required]
        [Display(Name = "Monthly Utilities Amount:")]
        public decimal monthlyUtilitiesAmount { get; set; }

        [Required]
        [Display(Name = "Monthly Indirect Costs:")]
        public decimal monthlyIndirectCosts { get; set; }

        [Required]
        [Display(Name = "Miscellaneous Overhead Costs:")]
        public decimal miscellaneousCosts { get; set; }

        [Required]
        [Display(Name = "Overhead Costs Description:")]
        public string overheadCostDescription { get; set; }

        [Required]
        [Display(Name = "Please describe the alternatives you have examined before making the request:")]
        public string overheadDescription { get; set; }

        [Display(Name = "Any Additional Comments:")]
        public string AdditionalComments { get; set; }

        public WaiverStatus Status {get;set;}

        public EquipmentMailWaiverView(EquipmentMailWaiver other)
        {
            this.CopyFromEquipmentMailWaiver(other);
        }

public void CopyFromEquipmentMailWaiver(EquipmentMailWaiver other) {
            this.OtherFirstName = other.OtherFirstName;
            this.OtherLastName = other.OtherLastName;
            this.projectName = other.projectName;
            this.SubmittedOn = other.SubmittedOn ;
            this.CostEstimate = other.CostEstimate ;
            this.justificationDescription = other.justificationDescription;
            this.equipmentDescription = other.equipmentDescription;
            this.NumberofEquipment = other.NumberofEquipment;
            this.newOrReplace = other.newOrReplace;
            this.servicesReceived = other.servicesReceived;
            this.monthlyLeaseAmount = other.monthlyLeaseAmount;
            this.monthlyVolume = other.monthlyVolume;
            this.firstYearVolume = other.firstYearVolume;
            this.secondYearVolume = other.secondYearVolume;
            this.thirdYearVolume = other.thirdYearVolume;
            this.fourthYearVolume = other.fourthYearVolume;
            this.fifthYearVolume = other.fifthYearVolume;
            this.Make = other.Make;
            this.Model = other.Model;
            this.selectionReason = other.selectionReason;
            this.usefulLife = other.usefulLife;
            this.purchaseAmount = other.purchaseAmount;
            this.monthlyLease = other.monthlyLease;
            this.monthsRental = other.monthsRental;
            this.acquisitionType = other.acquisitionType;
            this.solicitationSubType = other.solicitationSubType;
            this.statepriceSubType = other.statepriceSubType;
            this.totalLeaseAmount = other.totalLeaseAmount;
            this.EstimatedNumberofFTE = other.EstimatedNumberofFTE;
            this.estimatedNumberofHoursPerFTE = other.estimatedNumberofHoursPerFTE;
            this.weeklySalaryCost = other.weeklySalaryCost;
            this.totalSpaceRequired = other.totalSpaceRequired;
            this.monthlySupervisionAmount = other.monthlySupervisionAmount;
            this.monthlyManagementAmount = other.monthlyManagementAmount;
            this.monthlyUtilitiesAmount = other.monthlyUtilitiesAmount;
            this.monthlyIndirectCosts = other.monthlyIndirectCosts;
            this.miscellaneousCosts = other.miscellaneousCosts;
            this.overheadCostDescription = other.overheadCostDescription;
            this.overheadDescription = other.overheadDescription;
            this.Status = other.Status;
            this.AdditionalComments = other.AdditionalComments;
        }

        
        public EquipmentMailWaiverView()
        {
        }

        [Required]
        [Display(Name = "Type of Design:")]
        public int? DesignTypeID{get; set;}
        
    }

}