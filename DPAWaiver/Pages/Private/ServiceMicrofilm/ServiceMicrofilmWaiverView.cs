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
        [Display(Name = "Describe the item to be mailed:")]
        public string ItemDescription { get; set; }

        [Required]
        [Display(Name = "Are you requesting only microfilm duplication:")]
        public string MicrofilmDuplication {get; set;}

        [Required]
        [Display(Name = "How many rolls are you requesting:")]
        public decimal? RequestedRolls {get; set;}

        [Required]
        [Display (Name = "Estimated number of FTE:")]
        public decimal? EstimatedNumberofFTE {get; set;}

        [Required]
        [Display(Name = "Total estimated number of hours:")]
        public decimal? EstimatedNumberOfHours {get; set;}

        [Required]
        [Display(Name = "Esimtated Number of Documents:")]
        public decimal? estimatedNumberOfDocuments {get; set;}

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
        public decimal? NumberofRolls {get; set;}

        [Required]
        [Display(Name = "Specify Microfilm Job Requirements:")]
        public string JobRequirements {get; set;}

        [Display(Name = "What other alternative methods have you looked at? Please provide details.")]
        public string AlternativeMethods {get; set;}

        [Display(Name = "Can the microfilm function be provided by the State's scanning unit.")]
        public string doneInHouse {get; set;}

        [Display(Name = "Customer believes that this microfilm function cannot be performed by the State's scanning unit. Please provide details as to why:")]
        public string NotInHouseReason {get; set;}
        
        [Display(Name = "Additional Waiver Comments:")]
        public string AdditionalComments { get; set; }

        public WaiverStatus Status {get;set;}
        
        public ServiceMicrofilmWaiverView()
        {
        }

        public ServiceMicrofilmWaiverView(ServiceMicrofilmWaiver other)
        {
            this.CopyFromServiceMicrofilmWaiver(other);
        }

public void CopyFromServiceMicrofilmWaiver(ServiceMicrofilmWaiver other) {
            this.OtherFirstName = other.OtherFirstName;
            this.OtherLastName = other.OtherLastName;
            this.projectName = other.projectName;
            this.SubmittedOn = other.SubmittedOn ;
            this.CostEstimate = other.CostEstimate ;
            this.ItemDescription = other.ItemDescription;
            this.MicrofilmDuplication = other.MicrofilmDuplication;
            this.RequestedRolls = other.RequestedRolls;
            this.EstimatedNumberofFTE = other.EstimatedNumberofFTE;
            this.EstimatedNumberOfHours = other.EstimatedNumberOfHours;
            this.estimatedNumberOfDocuments = other.estimatedNumberOfDocuments;
            this.outputType = other.outputType;
            this.RollsLabeled = other.RollsLabeled;
            this.duplicateRolls = other.duplicateRolls;
            this.NumberofRolls = other.NumberofRolls;
            this.JobRequirements = other.JobRequirements;
            this.AlternativeMethods = other.AlternativeMethods;
            this.doneInHouse = other.doneInHouse;
            this.NotInHouseReason = other.NotInHouseReason;
            this.AdditionalComments = other.AdditionalComments;

        }

        
    }

}