using System;
using System.Collections.Generic;
using System.Linq;
using DPAWaiver.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using DPAWaiver.Models.WaiverSelection;
using System.ComponentModel.DataAnnotations.Schema;

namespace DPAWaiver.Models.Waivers
{
    public class ServiceDesignWaiverView
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
        [Display(Name = "Describe the item to be designed:")]
        public string ItemToBeDesigned { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Project Start Date")]
        public DateTime StartedOn { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Project Due Date")]
        public DateTime DueDate { get; set; }

        [Required]
        [Column(TypeName="DECIMAL(13,2)")]
        [Display(Name = "Cost Estimate")]
        [RegularExpression(@"^\d+(\.\d{0,2})?$")]
        [Range(0, 9999999999999999.99)]

        public decimal CostEstimate { get ; set;}

        [Required]
        [Display(Name = "Total estimated number of hours:")]
        public decimal EstimatedNumberofHours { get; set; }

        [Display(Name = "If other please explain:")]
        public string OtherDescription { get; set; }

        public WaiverStatus Status {get;set;}

        public ServiceDesignWaiverView(ServiceDesignWaiver other)
        {
            this.CopyFromServiceDesignWaiver(other);
        }

public void CopyFromServiceDesignWaiver(ServiceDesignWaiver other) {
            this.CostEstimate = other.CostEstimate ;
            this.EstimatedNumberofHours = other.EstimatedNumberofHours ;
            this.OtherFirstName = other.OtherFirstName ;
            this.OtherLastName = other.OtherLastName ;
            this.ProjectName = other.ProjectName ;
            this.SubmittedOn = other.SubmittedOn ;
            this.Status = other.Status;
            this.ProjectName = other.ProjectName;
            this.DueDate = other.DueDate;
            this.StartedOn = other.StartedOn;
            this.ItemToBeDesigned = other.ItemToBeDesigned;
            this.OtherDescription = other.OtherDescription;
        }

        
        public ServiceDesignWaiverView()
        {
        }

        [Required]
        [Display(Name = "Type of Design:")]
        public int? DesignTypeID{get; set;}
        
    }

}