using System;
using System.Collections.Generic;
using System.Linq;
using DPAWaiver.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using DPAWaiver.Models.WaiverSelection;
using DPAWaiver.Models.LOV;

namespace DPAWaiver.Models.Waivers
{
    public class ServicePrintWaiver : BaseWaiver
    {
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

        [Required]
        [Display(Name = "Type of Finishing")]
        public string FinishingType {get; set;}

        [Required]
        [Display(Name = "Is this a reprint:")]
        public string Reprint {get; set;}

        [Required]
        [Display(Name = "If it is a reprint, who was the previous printer")]
        public string previousPrinter {get; set;}

        [Required]
        [Display(Name = "Number of Originals:")]
        public decimal numberOfOriginals {get; set;}
        
        [Display(Name = "Upload the recieved estimate:")]
        public string estimateFile {get; set;}

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



        
        public ServicePrintWaiver(DPAUser createdBy, string otherFirstName, string otherLastName,
                              Purpose purpose, PurposeType purposeType, PurposeSubtype purposeSubtype) : base(createdBy, otherFirstName, otherLastName, purpose, purposeType, purposeSubtype)
        {
        }

        public ServicePrintWaiver()
        {
        }

    }

}