using System;
using System.Collections.Generic;
using System.Linq;
using DPAWaiver.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using DPAWaiver.Models.WaiverSelection;
using DPAWaiver.Models.LOV;

namespace DPAWaiver.Models.Waivers
{
    public class ServiceMicrofilmConversionWaiver : BaseWaiver
    {
       
        [Required]
        [Display(Name = "Describe the current workflow process:")]
        public string workflowDescription { get; set; }

        [Required]
        [Display(Name = "What type of film are you needing converting?")]
        public string typeofFilm {get; set;}

        [Required]
        [Display(Name = "Specify number of rolls:")]
        public decimal NumberofRolls {get; set;}

        [Required]
        [Display (Name = "Estimated number of cards/sheets:")]
        public decimal numberofCards {get; set;}

        [Required]
        [Display(Name = "Total estimated number of hours:")]
        public decimal EstimatedNumberofHours {get; set;}

        [Required]
        [Display(Name = "Esimtated Number of FTE:")]
        public decimal EstimatedNumberofFTE {get; set;}

        [Required]
        [Display(Name = "Will the job require indexing")]
        public string indexingNeeded {get; set;}

        [Required]
        [Display(Name = "Do you need a text searchable .pdf?")]
        public string textSearchablePDF {get; set;}

        [Required]
        [Display(Name = "Estimated number of fields per document:")]
        public string estimatedNumberOfFields {get; set;}

        

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
        [Display(Name = "Can the data be converted and imported into your department's internal database.")]
        public string keyedIntoSystem {get; set;}

        [Display(Name = "Please explain why")]
        public string reasonForNotKeyedIntoSystem {get; set;}

        [Required]
        [Display(Name = "Can the microfilm function be provided by the State's scanning unit.")]
        public string doneInHouse {get; set;}

        [Display(Name = "Please explain why")]
        public string notInHouseReason {get; set;}
        
        [Display(Name = "Additional Waiver Comments:")]
        public string AdditionalComments { get; set; }


        
        public ServiceMicrofilmConversionWaiver(DPAUser createdBy, string otherFirstName, string otherLastName,
                              Purpose purpose, PurposeType purposeType, PurposeSubtype purposeSubtype) : base(createdBy, otherFirstName, otherLastName, purpose, purposeType, purposeSubtype)
        {
        }

        public ServiceMicrofilmConversionWaiver()
        {
        }

    }

}