using System;
using System.Collections.Generic;
using System.Linq;
using DPAWaiver.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using DPAWaiver.Models.WaiverSelection;

namespace DPAWaiver.Models.Waivers 
{
    public class DataEntryWaiver : BaseWaiver
    {
        [Required]
        [Display(Name = "Describe the current workflow process:")]
        public string WorkflowDescription {get;set;}

        [Required]
        [Display(Name = "Total estimated number of FTE:")]
        public decimal EstimatedNumberofFTE {get;set;}
        
        [Required]
        [Display(Name = "Total estimated number of hours:")]
        public decimal EstimatedNumberOfHours {get;set;}

        [Required]
        [Display(Name = "Estimated number of documents:")]
        public int EstimatedNumberOfDocuments {get;set;}

        [Required]
        [Display(Name = "Estimated number of fields per document:")]
        public string EstimatedNumberOfFields {get;set;}

        [Required]
        [Display(Name = "Specify system requirements:")]
        public string SystemRequirementsDescription { get; set;}

        [Required]
        [Display(Name = "Can the data be keyed into an internal data system and be imported into the department's internal database?")]
        public bool? keyedIntoSystem  {get; set;}
        
        [Display(Name = "Please explain why")]
        public string ReasonForNotKeyedIntoSystem {get;set;}

        [Required]
        [Display(Name = "Customer believes that the data entry cannot be performed by the State's data entry center because:")]
        public string ReasonDataEntryCenter {get;set;}

       [Display(Name = "Additional Comments")]
        public string AdditionalComments {get;set;}
        public DataEntryWaiver(DPAUser createdBy, string otherFirstName, string otherLastName,
                              Purpose purpose, PurposeType purposeType, PurposeSubtype purposeSubtype) : base(createdBy, otherFirstName, otherLastName, purpose, purposeType, purposeSubtype)
        {
        }

        public DataEntryWaiver()
        {
        }

    }

}