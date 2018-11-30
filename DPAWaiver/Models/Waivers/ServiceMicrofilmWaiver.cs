using System;
using System.Collections.Generic;
using System.Linq;
using DPAWaiver.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using DPAWaiver.Models.WaiverSelection;
using DPAWaiver.Models.LOV;

namespace DPAWaiver.Models.Waivers
{
    public class ServiceMicrofilmWaiver : BaseWaiver
    {
       
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


        
        public ServiceMicrofilmWaiver(DPAUser createdBy, string otherFirstName, string otherLastName,
                              Purpose purpose, PurposeType purposeType, PurposeSubtype purposeSubtype) : base(createdBy, otherFirstName, otherLastName, purpose, purposeType, purposeSubtype)
        {
        }

        public ServiceMicrofilmWaiver()
        {
        }

    }

}