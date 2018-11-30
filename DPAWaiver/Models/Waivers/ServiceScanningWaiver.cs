using System;
using System.Collections.Generic;
using System.Linq;
using DPAWaiver.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using DPAWaiver.Models.WaiverSelection;
using DPAWaiver.Models.LOV;

namespace DPAWaiver.Models.Waivers
{
    public class ServiceScanningWaiver : BaseWaiver
    {
        [Required]
        [Display(Name = "Describe the current workflow process:")]
        public string workflowDescription { get; set; }
        
        

        [Required]
        [Display(Name = "What type of film are you needing converting?")]
        public decimal estimatedNumberofDocuments {get; set;}
        
        [Required]
        [Display(Name = "Total estimated number of hours:")]
        public decimal EstimatedNumberofHours {get; set;}
        
        [Required]
        [Display(Name = "Will the job require indexing")]
        public string indexingNeeded {get; set;}
        
        [Required]
        [Display(Name = "Estimated number of fields per document:")]
        public decimal estimatedNumberOfFields {get; set;}
        
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

        [Required]
        [Display(Name = "What other alternative methods have you looked at? Please provide details.")]
        public string alternativeMethods {get; set;}

        [Display(Name = "Have you looked at scanning on your MultiFunction printer?")]
        public string scanningInternally {get; set;}

        [Required]
        [Display(Name = "Can the data be scanned into an external system and imported into your department's application.")]
        public string importConversion {get; set;}

        [Display(Name = "Customer believes that this scanning function cannot be performed by the State's scanning unit. Please provide details as to why:")]
        public string notInHouseReason {get; set;}
        
        [Display(Name = "Any additional comments:")]
        public string AdditionalComments { get; set; }


        
        public ServiceScanningWaiver(DPAUser createdBy, string otherFirstName, string otherLastName,
                              Purpose purpose, PurposeType purposeType, PurposeSubtype purposeSubtype) : base(createdBy, otherFirstName, otherLastName, purpose, purposeType, purposeSubtype)
        {
        }

        public ServiceScanningWaiver()
        {
        }

    }

}