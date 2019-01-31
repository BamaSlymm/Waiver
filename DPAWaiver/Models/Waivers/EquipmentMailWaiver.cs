using System;
using System.Collections.Generic;
using System.Linq;
using DPAWaiver.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using DPAWaiver.Models.WaiverSelection;
using DPAWaiver.Models.LOV;

namespace DPAWaiver.Models.Waivers
{
    public class EquipmentMailWaiver : BaseWaiver
    {
       
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


        
        public EquipmentMailWaiver(DPAUser createdBy, string otherFirstName, string otherLastName,
                              Purpose purpose, PurposeType purposeType, PurposeSubtype purposeSubtype) : base(createdBy, otherFirstName, otherLastName, purpose, purposeType, purposeSubtype)
        {
        }

        public EquipmentMailWaiver()
        {
        }

    }

}