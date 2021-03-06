using System;
using System.Collections.Generic;
using System.Linq;
using DPAWaiver.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using DPAWaiver.Models.WaiverSelection;
using System.ComponentModel.DataAnnotations.Schema;

namespace DPAWaiver.Models.Waivers
{
    public class ServicePrintWaiverView
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
        [Display(Name = "Have you acquired estimate from vendor?")]
        public string EstimateObtained {get; set;}

        [Required]
        [Display(Name = "Type of Paper Stock:")]
        public string PaperStockType {get; set;}

        [Display (Name = "If Other, please explain")]
        public string otherPaperStockReason {get; set;}

        [Display(Name = "Upload the recieved estimate:")]
        public string estimateFile {get; set;}

        [Required]
        [Display(Name = "Type of Finishing")]
        public string FinishingType {get; set;}

        [Required]
        [Display(Name = "Is this a reprint:")]
        public string Reprint {get; set;}

        [Display(Name = "If it is a reprint, who was the previous printer")]
        public string previousPrinter {get; set;}

        [Required]
        [Display(Name = "Number of Originals:")]
        public decimal numberOfOriginals {get; set;}

        [Required]
        [Display(Name = "Quantity:")]
        public decimal Quantity {get; set;}

        [Required]
        [Display(Name = "Is this a 4 color print job:")]
        public string FourColorJob {get; set;}

        [Required]
        [Display(Name = "Number of Inks:")]
        public decimal numberOfInks {get; set;}

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Due Date of Project:")]
        public DateTime? projectDueDate {get; set;}

        [Required]
        [Display(Name = "Finished Size:")]
        public string FinishedSize {get; set;}
        
        [Display(Name = "Additional Waiver Comments:")]
        public string AdditionalComments { get; set; }

        public WaiverStatus Status {get;set;}

        public ServicePrintWaiverView(ServicePrintWaiver other)
        {
            this.CopyFromServicePrintWaiver(other);
        }

public void CopyFromServicePrintWaiver(ServicePrintWaiver other) {
            this.OtherFirstName = other.OtherFirstName;
            this.OtherLastName = other.OtherLastName;
            this.projectName = other.projectName;
            this.SubmittedOn = other.SubmittedOn ;
            this.CostEstimate = other.CostEstimate ;
            this.ItemDescription = other.ItemDescription;
            this.EstimateObtained = other.EstimateObtained;
            this.PaperStockType = other.PaperStockType;
            this.otherPaperStockReason = other.otherPaperStockReason;
            this.FinishingType = other.FinishingType;
            this.Reprint = other.Reprint;
            this.estimateFile = other.estimateFile;
            this.previousPrinter = other.previousPrinter;
            this.numberOfOriginals = other.numberOfOriginals;
            this.Quantity = other.Quantity;
            this.FourColorJob = other.FourColorJob;
            this.numberOfInks = other.numberOfInks;
            this.projectDueDate = other.projectDueDate;
            this.FinishedSize = other.FinishedSize;
            this.AdditionalComments = other.AdditionalComments;

        }

        
        public ServicePrintWaiverView()
        {
        }

    }

}