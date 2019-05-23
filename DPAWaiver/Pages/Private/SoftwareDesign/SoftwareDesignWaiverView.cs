using System;
using System.Collections.Generic;
using System.Linq;
using DPAWaiver.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using DPAWaiver.Models.WaiverSelection;
using System.ComponentModel.DataAnnotations.Schema;

namespace DPAWaiver.Models.Waivers
{
    public class SoftwareDesignWaiverView
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

        public WaiverStatus Status {get;set;}

        public SoftwareDesignWaiverView(SoftwareDesignWaiver other)
        {
            this.CopyFromSoftwareDesignWaiver(other);
        }

public void CopyFromSoftwareDesignWaiver(SoftwareDesignWaiver other) {
            this.OtherFirstName = other.OtherFirstName;
            this.OtherLastName = other.OtherLastName;
            this.projectName = other.projectName;
            this.SubmittedOn = other.SubmittedOn ;
            this.CostEstimate = other.CostEstimate ;
            this.typeOfSoftware = other.typeOfSoftware;
            this.numberOfLicenses = other.numberOfLicenses;
            this.newOrReplace = other.newOrReplace;
            this.softwareVersion = other.softwareVersion;
            this.costOfPresentService = other.costOfPresentService;
            this.servicesReceived = other.servicesReceived;
            this.softwareProvider = other.softwareProvider;
            this.selectionReason = other.selectionReason;
            this.expectedDuration = other.expectedDuration;
            this.acquisitionType = other.acquisitionType;
            this.subscriptionOrPurchase = other.subscriptionOrPurchase ;
            this.monthlySubscriptionAmount = other.monthlySubscriptionAmount ;
            this.numberOfMonths = other.numberOfMonths ;
            this.purchaseAmount = other.purchaseAmount;
            this.annualMaintenanceCost = other.annualMaintenanceCost;
            this.operatorClassification = other.operatorClassification;
            this.Grade = other.Grade;
            this.numberOfFTE = other.numberOfFTE;
            this.numberOfLicenses = other.numberOfLicenses;
            this.hoursPerFTEPerWeek = other.hoursPerFTEPerWeek;
            this.annualMaintenanceCost = other.annualMaintenanceCost;
            this.hoursPerFTEPerWeek = other.hoursPerFTEPerWeek;
            this.totalWeeklySalary = other.totalWeeklySalary;
            this.monthlySupervisionAmount = other.monthlySupervisionAmount;
            this.monthlyManagementAmount = other.monthlyManagementAmount;
            this.justificationDescription = other.justificationDescription ;
            this.alternativesConsidered = other.alternativesConsidered;
            this.Status = other.Status;
            this.AdditionalComments = other.AdditionalComments;
        }

        
        public SoftwareDesignWaiverView()
        {
        }


    }

}