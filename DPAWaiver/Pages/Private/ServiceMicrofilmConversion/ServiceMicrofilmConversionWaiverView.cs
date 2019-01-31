using System;
using System.Collections.Generic;
using System.Linq;
using DPAWaiver.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using DPAWaiver.Models.WaiverSelection;
using System.ComponentModel.DataAnnotations.Schema;

namespace DPAWaiver.Models.Waivers
{
    public class ServiceMicrofilmConversionWaiverView
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
        [Display(Name = "Describe the current workflow process:")]
        public string WorkflowDescription { get; set; }

        [Required]
        [Display(Name = "What type of film are you needing converting?")]
        public string typeofFilm {get; set;}

        [Required]
        [Display(Name = "Specify number of rolls:")]
        public decimal NumberofRolls {get; set;}

        [Required]
        [Display (Name = "Estimated number of cards/sheets:")]
        public decimal numberofCards {get; set;}

        [Required]
        [Display(Name = "Total estimated number of hours:")]
        public decimal EstimatedNumberofHours {get; set;}

        [Required]
        [Display(Name = "Esimtated Number of FTE:")]
        public decimal EstimatedNumberofFTE {get; set;}

        [Required]
        [Display(Name = "Will the job require indexing")]
        public string indexingNeeded {get; set;}

        [Required]
        [Display(Name = "Do you need a text searchable .pdf?")]
        public string textSearchablePDF {get; set;}

        [Required]
        [Display(Name = "Estimated number of fields per document:")]
        public string EstimatedNumberOfFields {get; set;}

        

        [Required]
        [Display(Name = "How do you need the receive the images?")]
        public string imageDelivery {get; set;}

        [Display(Name = "Please specify other delivery method:")]
        public string otherImageDelivery {get; set;}

        [Display(Name = "Please specify email address(es) seperated by semicolon:")]
        public string emailOtherImageDelivery {get; set;}

        [Required]
        [Display(Name = "Specify system requirements.")]
        public string systemRequirements {get; set;}

        [Required]
        [Display(Name = "Can the data be converted and imported into your department's internal database.")]
        public string keyedIntoSystem {get; set;}

        [Display(Name = "Please explain why")]
        public string ReasonForNotKeyedIntoSystem {get; set;}

        [Required]
        [Display(Name = "Can the microfilm function be provided by the State's scanning unit.")]
        public string doneInHouse {get; set;}

        [Display(Name = "Please explain why")]
        public string NotInHouseReason {get; set;}
        
        [Display(Name = "Additional Waiver Comments:")]
        public string AdditionalComments { get; set; }

        public WaiverStatus Status {get;set;}

        public ServiceMicrofilmConversionWaiverView(ServiceMicrofilmConversionWaiver other)
        {
            this.CopyFromServiceMicrofilmConversionWaiver(other);
        }

public void CopyFromServiceMicrofilmConversionWaiver(ServiceMicrofilmConversionWaiver other) {
            this.OtherFirstName = other.OtherFirstName;
            this.OtherLastName = other.OtherLastName;
            this.projectName = other.projectName;
            this.SubmittedOn = other.SubmittedOn ;
            this.CostEstimate = other.CostEstimate ;
            this.WorkflowDescription = other.WorkflowDescription;
            this.typeofFilm = other.typeofFilm;
            this.NumberofRolls = other.NumberofRolls;
            this.numberofCards = other.numberofCards;
            this.EstimatedNumberofHours = other.EstimatedNumberofHours;
            this.EstimatedNumberofFTE = other.EstimatedNumberofFTE;
            this.indexingNeeded = other.indexingNeeded;
            this.textSearchablePDF = other.textSearchablePDF;
            this.EstimatedNumberOfFields = other.EstimatedNumberOfFields;
            this.imageDelivery = other.imageDelivery;
            this.otherImageDelivery = other.otherImageDelivery;
            this.emailOtherImageDelivery = other.emailOtherImageDelivery;
            this.systemRequirements = other.systemRequirements;
            this.keyedIntoSystem = other.keyedIntoSystem;
            this.ReasonForNotKeyedIntoSystem = other.ReasonForNotKeyedIntoSystem;
            this.doneInHouse = other.doneInHouse;
            this.NotInHouseReason = other.NotInHouseReason;
            this.AdditionalComments = other.AdditionalComments;
            


        }

        
        public ServiceMicrofilmConversionWaiverView()
        {
        }

        [Required]
        [Display(Name = "Type of Design:")]
        public int? DesignTypeID{get; set;}
        
    }

}