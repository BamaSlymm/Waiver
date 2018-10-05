using System;
using System.Collections.Generic;
using System.Linq;
using DPAWaiver.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using DPAWaiver.Models.WaiverSelection;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace DPAWaiver.Models.Waivers
{
    public class BaseWaiver
    {
        
        public Guid ID {get;set;}

        [Required]
        [JsonIgnore]
        public DPAUser CreatedBy { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }
        [JsonIgnore]
        public DPAUser approvedBy { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? approvedOn { get; set; }

        [Display(Name = "Waiver Owner First Name")]
        public string OtherFirstName { get; set; }

        [Display(Name = "Waiver Owner Last Name")]
        public string OtherLastName { get; set; }

        [Required]
        [Display(Name = "Status Code")]
        public WaiverStatus Status { get; set;}

        [Required]
        [Display(Name = "Purpose Code")]
        [JsonIgnore]
        public Purpose Purpose {get; set ; }

        [Required]
        [Display(Name = "Type Code")]
        [JsonIgnore]
        public PurposeType PurposeType {get; set ; }

        [JsonIgnore]
        public PurposeSubtype PurposeSubtype {get; set ; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Waiver Number")]
        public int WaiverNumber {get;set;}

        [Required]
        [Display(Name = "Project Name")]
        public string ProjectName {get;set;}

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Submitted Date")]
        public DateTime SubmittedOn { get; set; }

        [Required]
        [Column(TypeName="DECIMAL(13,2)")]
        [Display(Name = "Cost Estimate")]
        [RegularExpression(@"^\d+(\.\d{0,2})?$")]
        [Range(0, 999999999999.99)]
        public decimal CostEstimate { get ; set;}

        public BaseWaiver() {
        }

        public BaseWaiver(DPAUser createdBy, string otherFirstName, string otherLastName,
                          Purpose purpose, PurposeType purposeType, PurposeSubtype purposeSubtype)
        {
            this.CreatedBy = createdBy;
            this.CreatedOn = DateTime.Now ;
            this.OtherFirstName = otherFirstName;
            this.OtherLastName = otherLastName;
            this.Status = WaiverStatus.Pending;
            this.Purpose = purpose ;
            this.PurposeType = purposeType ;
            this.PurposeSubtype = purposeSubtype ;
        }

        public void SetBaseInformation(DPAUser createdBy, string otherFirstName, string otherLastName,
                          Purpose purpose, PurposeType purposeType, PurposeSubtype purposeSubtype)
        {
            this.CreatedBy = createdBy;
            this.CreatedOn = DateTime.Now ;
            this.OtherFirstName = otherFirstName;
            this.OtherLastName = otherLastName;
            this.Status = WaiverStatus.Pending;
            this.Purpose = purpose ;
            this.PurposeType = purposeType ;
            this.PurposeSubtype = purposeSubtype ;
        }

        public void SetWaiverInformation(string projectName, DateTime submittedOn, decimal costEstimate) {
            this.ProjectName = projectName ;
            this.SubmittedOn = submittedOn ;
            this.CostEstimate = costEstimate;
        }

        [JsonIgnore] 
        public List<BaseWaiverAction> Actions {get;set;}
        [JsonIgnore] 
        public List<BaseWaiverAttachment> Attachments {get;set;}
        [JsonIgnore] 
        public List<BaseWaiverInvoice> Invoices {get;set;}

    }

    public enum WaiverStatus
    {
        Pending,
        Denied,
        UnderReview,
        Accepted
    }
}