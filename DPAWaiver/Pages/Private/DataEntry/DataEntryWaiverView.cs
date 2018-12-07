using System;
using System.Collections.Generic;
using System.Linq;
using DPAWaiver.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using DPAWaiver.Models.WaiverSelection;
using System.ComponentModel.DataAnnotations.Schema;

namespace DPAWaiver.Models.Waivers 
{
    public class DataEntryWaiverView
    {

        
        [Display(Name = "Waiver Owner First Name")]
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
        public string WorkflowDescription {get;set;}

        [Required]
        [Display(Name = "Total estimated number of FTE:")]
        public decimal? EstimatedNumberofFTE {get;set;}
        
        [Required]
        [Display(Name = "Total estimated number of hours:")]
        public decimal? EstimatedNumberofHours {get;set;}

        [Required]
        [Display(Name = "Estimated number of documents:")]
        public int? EstimatedNumberofDocuments {get;set;}

        [Required]
        [Display(Name = "Estimated number of fields per document:")]
        public int? EstimatedNumberofFields {get;set;}

        [Required]
        [Display(Name = "Specify system requirements:")]
        public string SystemRequirementsDescription { get; set;}

        [Required]
        [Display(Name = "Can the data be keyed into an internal data system and be imported into the department's internal database?")]
        public bool? KeyedIntoSystem  {get; set;}
        
        [Display(Name = "Please explain why")]
        public string ReasonForNotKeyedIntoSystem {get;set;}

        [Required]
        [Display(Name = "Customer believes that the data entry cannot be performed by the State's data entry center because:")]
        public string ReasonDataEntryCenter {get;set;}

       [Display(Name = "Additional Comments")]
        public string AdditionalComments {get;set;}

        public WaiverStatus Status {get;set;}

        public DataEntryWaiverView()
        {
        }

        public DataEntryWaiverView(DataEntryWaiver other)
        {
            this.CopyFromDataEntryWaiver(other);
        }
        
        public void CopyFromDataEntryWaiver(DataEntryWaiver other) {
            this.AdditionalComments = other.AdditionalComments;
            this.CostEstimate = other.CostEstimate ;
            this.EstimatedNumberofDocuments = other.EstimatedNumberofDocuments ;
            this.EstimatedNumberofFields = other.EstimatedNumberofFields;
            this.EstimatedNumberofFTE = other.EstimatedNumberofFTE ;
            this.EstimatedNumberofHours = other.EstimatedNumberofHours ;
            this.KeyedIntoSystem = other.KeyedIntoSystem ;
            this.OtherFirstName = other.OtherFirstName ;
            this.OtherLastName = other.OtherLastName ;
            this.projectName = other.projectName ;
            this.ReasonDataEntryCenter = other.ReasonDataEntryCenter;
            this.ReasonForNotKeyedIntoSystem = other.ReasonForNotKeyedIntoSystem ;
            this.SubmittedOn = other.SubmittedOn ;
            this.SystemRequirementsDescription = other.SystemRequirementsDescription;
            this.WorkflowDescription = other.WorkflowDescription ;
            this.Status = other.Status;
        }

    }

}