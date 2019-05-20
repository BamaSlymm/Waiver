using System;
using System.Collections.Generic;
using System.Linq;
using DPAWaiver.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using DPAWaiver.Models.WaiverSelection;
using System.ComponentModel.DataAnnotations.Schema;

namespace DPAWaiver.Models.Waivers
{
    public class ServiceScanningWaiverView
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
        public decimal? CostEstimate { get ; set;}

        [Required]
        [Display(Name = "Describe the current workflow process:")]
        public string WorkflowDescription { get; set; }
        
        

        [Required]
        [Display(Name = "What type of film are you needing converting?")]
        public decimal estimatedNumberOfDocuments {get; set;}
        
        [Required]
        [Display(Name = "Total estimated number of hours:")]
        public decimal EstimatedNumberOfHours {get; set;}
        
        [Required]
        [Display(Name = "Will the job require indexing")]
        public string indexingNeeded {get; set;}
        
        [Required]
        [Display(Name = "Estimated number of fields per document:")]
        public string EstimatedNumberOfFields {get; set;}
        
        [Required]
        [Display(Name = "Do you need a text searchable .pdf?")]
        public string textSearchablePDF {get; set;}


        [Required]
        [Display(Name = "What DPI would you like the images scanned at?")]
        public decimal imageDPI {get; set;}

        [Required]
        [Display (Name = "What color format do you need the images scanned in?")]
        public string colorFormat {get; set;}

        [Required]
        [Display(Name = "How do you need the receive the images?")]
        public string imageDelivery {get; set;}

        [Display(Name = "Please specify other delivery method:")]
        public string otherImageDelivery {get; set;}

        [Display(Name = "Please specify email address(es) seperated by semicolon:")]
        public string emailOtherImageDelivery {get; set;}

        [Required]
        [Display(Name = "Specify system requirements.")]
        public string systemRequirements {get; set;}

        
        [Display(Name = "What other alternative methods have you looked at? Please provide details.")]
        public string AlternativeMethods {get; set;}

        [Display(Name = "Have you looked at scanning on your MultiFunction printer?")]
        public string scanningInternally {get; set;}

        [Required]
        [Display(Name = "Can the data be scanned into an external system and imported into your department's application.")]
        public string importConversion {get; set;}

        [Display(Name = "Customer believes that this scanning function cannot be performed by the State's scanning unit. Please provide details as to why:")]
        public string NotInHouseReason {get; set;}
        
        [Display(Name = "Any additional comments:")]
        public string AdditionalComments { get; set; }

        public WaiverStatus Status {get;set;}

        public ServiceScanningWaiverView(ServiceScanningWaiver other)
        {
            this.CopyFromServiceScanningWaiver(other);
        }

public void CopyFromServiceScanningWaiver(ServiceScanningWaiver other) {
            this.OtherFirstName = other.OtherFirstName;
            this.OtherLastName = other.OtherLastName;
            this.projectName = other.projectName;
            this.SubmittedOn = other.SubmittedOn ;
            this.CostEstimate = other.CostEstimate ;
            this.WorkflowDescription = other.WorkflowDescription;
            this.estimatedNumberOfDocuments = other.estimatedNumberOfDocuments;
            this.EstimatedNumberOfHours = other.EstimatedNumberOfHours;
            this.indexingNeeded = other.indexingNeeded;
            this.EstimatedNumberOfFields = other.EstimatedNumberOfFields;
            this.textSearchablePDF = other.textSearchablePDF;
            this.imageDPI = other.imageDPI;
            this.colorFormat = other.colorFormat;
            this.imageDelivery = other.imageDelivery;
            this.otherImageDelivery = other.otherImageDelivery;
            this.emailOtherImageDelivery = other.emailOtherImageDelivery;
            this.systemRequirements = other.systemRequirements;
            this.AlternativeMethods = other.AlternativeMethods;
            this.scanningInternally = other.scanningInternally;
            this.importConversion = other.importConversion;
            this.NotInHouseReason = other.NotInHouseReason;
            this.AdditionalComments = other.AdditionalComments;
            


        }

        
        public ServiceScanningWaiverView()
        {
        }
        
    }

}