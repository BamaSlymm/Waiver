using System;
using System.Collections.Generic;
using System.Linq;
using DPAWaiver.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using DPAWaiver.Models.WaiverSelection;
using DPAWaiver.Models.LOV;

namespace DPAWaiver.Models.Waivers
{
    public class SoftwareDataEntryWaiver : BaseWaiver
    {
        [Required]
        [Display(Name = "Type of software being requested")]
        public string typeOfSoftware { get; set; }  

        [Required]
        [Display(Name = "Number of software licenses being requested")]
        public decimal numberOfLicenses { get; set; }


        [Required]
        [Display(Name = "Is this new addition or replacement?")]
        public string newOrReplace { get; set; }        
        
        [Required]
        [Display(Name = "Describe software version and acquisition date:")]
        public string softwareVersion { get; set; }

        [Required]
        [Display(Name = "Cost of Present Service")]
        public decimal costOfPresentService { get; set; }

        
        [Required]
        [Display(Name = "Current Average Monthly Volume")]
        public decimal currentMonthlyVolume {get; set;}


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

        [Required]
        [Display(Name = "Software Provider:")]
        public string softwareProvider { get; set; }
        
        [Required]
        [Display(Name = "Software Version:")]
        public string softwareVolume { get; set; }
                

        [Required]
        [Display(Name = "Reasons for selecting this particular software:")]
        public string selectionReason { get; set; }

       
        
        [Required]
        [Display(Name = "Expected duration of use of software")]
        public string expectedDuration {get; set;}

        [Required]
        [Display(Name = "Solicitation SubType?")]
        public string solicitationSubType { get; set; }

        [Required]
        [Display(Name = "State Price SubType?")]
        public string statepriceSubType { get; set; }

        [Required]
        [Display(Name= "Purchase Amount")]
        public decimal purchaseAmount {get; set; }

        [Required]
        [Display(Name = "Annual Maintenance Renewal Cost")]
        public decimal annualMaintenanceCost {get; set;}

        [Required]
        [Display(Name = "Cost of Supplies")]
        public string suppliesCost {get; set;}

        [Required]
        [Display(Name = "Operator Classification")]
        public string operatorClassification {get; set;}

        [Required]
        [Display(Name = "Grade")]
        public decimal Grade {get; set;}

       
        [Display(Name = "Estimated Number of FTE")]
        public decimal numberOfFTE {get; set;}

        [Required]
        [Display(Name = "Hours Per FTE Per Week")]
        public decimal hoursPerFTEPerWeek {get; set;}

       
    
        [Required]
        [Display(Name = "Total Weekly Salary")]
        public decimal totalWeeklySalary {get; set;}

        [Required]
        [Display(Name = "Total Space Required In SQFT")]
        public decimal totalSpaceInSQFT {get; set;}

        [Required]
        [Display(Name = "Monthly Supervision Amount")]
        public decimal monthlySupervisionAmount {get; set;}

        [Required]
        [Display(Name = "Monthly Management Amount")]
        public decimal monthlyManagementAmount {get; set;}

        [Required]
        [Display(Name = "Monthly Utilities Amount")]
        public string monthlyUtilitiesAmount {get; set;}

        [Required]
        [Display(Name = "Monthly Indirect Costs")]
        public decimal monthlyIndirectCosts {get; set;}

        [Required]
        [Display(Name = "Monthly Overhead Costs")]
        public decimal monthlyOverheadCosts {get; set;}

        [Required]
        [Display(Name = "Please describe the alternatives you examined before making this request")]
        public string alternativesConsidered { get; set; }

        [Display(Name = "Any Additional Comments:")]
        public string additionalComments { get; set; }



        
        public SoftwareDataEntryWaiver(DPAUser createdBy, string otherFirstName, string otherLastName,
                              Purpose purpose, PurposeType purposeType, PurposeSubtype purposeSubtype) : base(createdBy, otherFirstName, otherLastName, purpose, purposeType, purposeSubtype)
        {
        }

        public SoftwareDataEntryWaiver()
        {
        }

    }

}