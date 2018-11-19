using System;
using System.Collections.Generic;
using System.Linq;
using DPAWaiver.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using DPAWaiver.Models.WaiverSelection;
using System.ComponentModel.DataAnnotations.Schema;

namespace DPAWaiver.Models.Waivers
{
    public class ServiceMicrofilmWaiverView
    {  [Display(Name = "Waiver Owner First Name")]
        public string OtherFirstName { get; set; }

        [Display(Name = "Waiver Owner Last Name")]
        public string OtherLastName { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public string ProjectName {get;set;}

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
        [Display(Name = "Describe the item to be mailed:")]
        public string ItemDescription { get; set; }

        [Required]
        [Display(Name = "Are you requesting only microfilm duplication:")]
        public string MicroFilmDuplication {get; set;}

        [Required]
        [Display(Name = "How many rolls are you requesting:")]
        public decimal? RequestedRolls {get; set;}

        [Required]
        [Display (Name = "Estimated number of FTE:")]
        public decimal EstimatedNumberofFTE {get; set;}

        [Required]
        [Display(Name = "Total estimated number of hours:")]
        public decimal EstimatedNumberofHours {get; set;}

        [Required]
        [Display(Name = "Esimtated Number of Documents:")]
        public decimal EstimatedNumberofDocuments {get; set;}

        [Required]
        [Display(Name = "What output type is needed:")]
        public string outputType {get; set;}

        [Required]
        [Display(Name = "Do you need the rolls labeled?")]
        public string RollsLabeled {get; set;}

        [Required]
        [Display(Name = "Do you need duplicate rolls?")]
        public string duplicateRolls {get; set;}

        [Required]
        [Display(Name = "Specify number of rolls:")]
        public decimal NumberofRolls {get; set;}

        [Required]
        [Display(Name = "Specify Microfilm Job Requirements:")]
        public string JobRequirements {get; set;}

        [Display(Name = "What other alternative methods have you looked at? Please provide details.")]
        public string AlternativeMethods {get; set;}

        [Display(Name = "Customer believes that this microfilm function cannot be performed by the State's scanning unit. Please provide details as to why:")]
        public string NotInHouseReason {get; set;}
        
        [Display(Name = "Additional Waiver Comments:")]
        public string AdditionalComments { get; set; }

        public WaiverStatus Status {get;set;}

        public ServiceMicrofilmWaiverView(ServiceMicrofilmWaiver other)
        {
            this.CopyFromServiceMicrofilmWaiver(other);
        }

public void CopyFromServiceMicrofilmWaiver(ServiceMicrofilmWaiver other) {
            this.OtherFirstName = other.OtherFirstName;
            this.OtherLastName = other.OtherLastName;
            this.ProjectName = other.ProjectName;
            this.SubmittedOn = other.SubmittedOn ;
            this.CostEstimate = other.CostEstimate ;
            this.ItemDescription = other.ItemDescription;
            this.MicroFilmDuplication = other.MicroFilmDuplication;
            this.RequestedRolls = other.RequestedRolls;
            this.EstimatedNumberofFTE = other.EstimatedNumberofFTE;
            this.EstimatedNumberofHours = other.EstimatedNumberofHours;
            this.EstimatedNumberofDocuments = other.EstimatedNumberofDocuments;
            this.outputType = other.outputType;
            this.RollsLabeled = other.RollsLabeled;
            this.duplicateRolls = other.duplicateRolls;
            this.NumberofRolls = other.NumberofRolls;
            this.JobRequirements = other.JobRequirements;
            this.AlternativeMethods = other.AlternativeMethods;
            this.NotInHouseReason = other.NotInHouseReason;
            this.AdditionalComments = other.AdditionalComments;

        }

        
        public ServiceMicrofilmWaiverView()
        {
        }

        [Required]
        [Display(Name = "Type of Design:")]
        public int? DesignTypeID{get; set;}
        
    }

}