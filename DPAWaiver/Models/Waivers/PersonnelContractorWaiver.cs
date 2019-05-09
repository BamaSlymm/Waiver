using System;
using System.Collections.Generic;
using System.Linq;
using DPAWaiver.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using DPAWaiver.Models.WaiverSelection;
using DPAWaiver.Models.LOV;

namespace DPAWaiver.Models.Waivers
{
    public class PersonnelContractorWaiver : BaseWaiver
    {

        [Required]
        [Display(Name = "Descibe the scope of work to be performed:")]
        public string ScopeofWork {get; set;}

        [Required]
        [Display(Name = "Contractor Type:")]
        public string ContractorType {get; set;}

        [Required]
        [Display(Name = "Hourly Rate")]
        public decimal HourlyRate {get; set;}


        [Required]
        [Display(Name = "Describe the job duties:")]
        public string JobDuties {get;set;}
        
        [Required]
        [Display(Name = "Total estimated number of hours:")]
        public decimal? EstimatedNumberOfHours {get;set;}

        [Required]
        [Display(Name = "How do you currently receive this service?")]
        public string SPAtype { get; set; }

        [Required]
        [Display(Name = "Enter State Price Agreement Number:")]
        public decimal? SPAnumber {get; set;}

        [Required]
        [Display(Name = "How do you currently receive this service?")]
        public string SPAType {get; set;}

        [Display(Name = "Please Describe Other for SPA:")]
        public string SPAotherDescription {get; set;}

        [Required]
        [Display(Name = "Total estimated number of FTE:")]
        public decimal? EstimatedNumberofFTE {get;set;}

        [Required]
        [Display(Name = "Expected duration of contract (numeric in months):")]
        public decimal? ContractDuration {get; set;}

        [Required]
        [Display(Name = "Anticipated Expenditure (must include mark up rate)")]
        public decimal? AnticipatedExpediture {get; set;}

        [Display(Name = "Please detail justification for request.")]
        public string DetailJustification {get;set;}

       [Display(Name = "Additional Comments")]
        public string AdditionalComments {get;set;}
    
        
        public PersonnelContractorWaiver(DPAUser createdBy, string otherFirstName, string otherLastName,
                              Purpose purpose, PurposeType purposeType, PurposeSubtype purposeSubtype) : base(createdBy, otherFirstName, otherLastName, purpose, purposeType, purposeSubtype)
        {
        }

        
        public PersonnelContractorWaiver()
        {
        }

    }

}