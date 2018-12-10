using System;
using System.Collections.Generic;
using System.Linq;
using DPAWaiver.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using DPAWaiver.Models.WaiverSelection;
using DPAWaiver.Models.LOV;

namespace DPAWaiver.Models.Waivers
{
    public class SoftwareMailProcessingWaiver : BaseWaiver
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
        [Display(Name = "Cost of Present Service")]
        public decimal costOfPresentService { get; set; }

        [Required]
        [Display(Name = "How do you currently receive this services?")]
        public string servicesReceived { get; set; }

        [Required]
        [Display(Name = "Software Provider:")]
        public string softwareProvider { get; set; }       
        
        [Required]
        [Display(Name = "Describe software version and acquisition date:")]
        public string softwareVersion { get; set; }

        [Required]
        [Display(Name = "Reasons for selecting this particular software:")]
        public string selectionReason { get; set; }

        [Required]
        [Display(Name = "Expected duration of use of software")]
        public string expectedDuration {get; set;}

        [Required]
        [Display(Name = "How do you plan to acquire this equipment?")]
        public string acquisitionType { get; set; }

        [Required]
        [Display(Name ="Is this a subscription or purchase?")]
        public string subscriptionOrPurchase {get; set;}
        
        [Required]
        [Display(Name= "Purchase Amount")]
        public decimal purchaseAmount {get; set; }

        [Required]
        [Display(Name = "Monthly Subscription Amount")]
        public decimal monthlySubscriptionAmount {get; set;}

        [Required]
        [Display(Name = "Estimated Number of Months")]
        public decimal numberOfMonths {get; set;}

        [Required]
        [Display(Name = "Annual Maintenance Renewal Cost")]
        public decimal annualMaintenanceCost {get; set;}
  
        [Required]
        [Display(Name = "Operator Classification")]
        public string operatorClassification {get; set;}

        [Required]
        [Display(Name = "Grade")]
        public decimal Grade {get; set;}

        [Required]
        [Display(Name = "Estimated Number of FTE")]
        public decimal numberOfFTE {get; set;}

        [Required]
        [Display(Name = "Hours Per FTE Per Week")]
        public decimal hoursPerFTEPerWeek {get; set;}
    
        [Required]
        [Display(Name = "Total Weekly Salary")]
        public decimal totalWeeklySalary {get; set;}        

        [Required]
        [Display(Name = "Monthly Management Amount")]
        public decimal monthlyManagementAmount {get; set;}

        [Required]
        [Display(Name = "Monthly Supervision Amount")]
        public string monthlySupervisionAmount {get; set;}

        [Required]
        [Display(Name = "Justification For Request:")]
        public decimal justificationDescription { get; set; }  

        [Required]
        [Display(Name = "Please describe the alternatives you examined before making this request")]
        public string alternativesConsidered { get; set; }

        [Display(Name = "Any Additional Comments:")]
        public string AdditionalComments { get; set; }



        
        public SoftwareMailProcessingWaiver(DPAUser createdBy, string otherFirstName, string otherLastName,
                              Purpose purpose, PurposeType purposeType, PurposeSubtype purposeSubtype) : base(createdBy, otherFirstName, otherLastName, purpose, purposeType, purposeSubtype)
        {
        }

        public SoftwareMailProcessingWaiver()
        {
        }

    }

}