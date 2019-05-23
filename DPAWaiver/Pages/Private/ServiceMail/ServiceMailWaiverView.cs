using System;
using System.Collections.Generic;
using System.Linq;
using DPAWaiver.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using DPAWaiver.Models.WaiverSelection;
using System.ComponentModel.DataAnnotations.Schema;

namespace DPAWaiver.Models.Waivers
{
    public class ServiceMailWaiverView
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
        [Display(Name = "Describe the item to be mailed:")]
        public string ItemDescription { get; set; }

        
        [Required]
        [Display(Name = "Describe the job and services required:")]
        public string JobDescription { get; set; }

        [Required]
        [Display(Name = "What stock is the item to be mailed and/or printed on:")]
        public decimal TypeofStock { get; set; }

        [Required]
        [Display(Name = "Number of packets to be mailed:")]
        public decimal NumberofPackets { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Mailing Date")]
        public DateTime MailingDate { get; set; }


        [Required]
        [Display(Name = "Mail Rate:")]
        public decimal MailRate {get; set;}

        [Required]
        [Display(Name = "Enter the mail rate. This is a numeric field; decimal can be used (i.e. 0.44)")]
        public string MailPermit {get; set;}


        [Display(Name = "If other please explain:")]
        public string OtherDescription { get; set; }

        public WaiverStatus Status {get;set;}

        public ServiceMailWaiverView(ServiceMailWaiver other)
        {
            this.CopyFromServiceMailWaiver(other);
        }

public void CopyFromServiceMailWaiver(ServiceMailWaiver other) {
            this.OtherFirstName = other.OtherFirstName;
            this.OtherLastName = other.OtherLastName;
            this.projectName = other.projectName;
            this.SubmittedOn = other.SubmittedOn ;
            this.CostEstimate = other.CostEstimate ;
            this.ItemDescription = other.ItemDescription;
            this.JobDescription = other.JobDescription;
            this.TypeofStock = other.TypeofStock;
            this.NumberofPackets = other.NumberofPackets;
            this.MailingDate = other.MailingDate;
            this.MailRate = other.MailRate;
            this.MailPermit = other.MailPermit;
            this.Status = other.Status;
            this.OtherDescription = other.OtherDescription;
        }

        
        public ServiceMailWaiverView()
        {
        }

    
        
    }

}