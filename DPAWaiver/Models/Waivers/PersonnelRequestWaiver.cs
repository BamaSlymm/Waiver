using System;
using System.Collections.Generic;
using System.Linq;
using DPAWaiver.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using DPAWaiver.Models.WaiverSelection;
using DPAWaiver.Models.LOV;

namespace DPAWaiver.Models.Waivers
{
    public class PersonnelRequestWaiver : BaseWaiver
    {
        [Required]
        [Display(Name= "Employee Type")]
        public string employeeType {get; set;}
        
        [Display(Name = "Describe the job duties:")]
        public string JobDuties {get;set;}

        [Required]
        [Display(Name = "Total estimated number of FTE:")]
        public decimal? EstimatedNumberofFTE {get;set;}

        [Required]
        [Display(Name = "Upload State Position Description:")]
        public string positionFile {get; set;}

        [Required]
        [Display(Name = "Total estimated number of Staff:")]
        public decimal? EstimatedNumberofStaff {get;set;}


        [Required]
        [Display(Name = "Requested Classification (One waiver request per classification)")]
        public string RequestedClassification {get;set;}
        
        [Required]
        [Display(Name = "Requested Loaded Salary (complete state benefit package)")]
        public decimal? RequestedSalary {get;set;}

        [Display(Name = "Please detail justification for request.")]
        public string DetailJustification {get;set;}

       [Display(Name = "Additional Comments")]
        public string AdditionalComments {get;set;}

        [Required]
        [Display(Name = "Total estimated number of hours:")]
        public decimal? EstimatedNumberofHours {get;set;}
    
        
        public PersonnelRequestWaiver(DPAUser createdBy, string otherFirstName, string otherLastName,
                              Purpose purpose, PurposeType purposeType, PurposeSubtype purposeSubtype) : base(createdBy, otherFirstName, otherLastName, purpose, purposeType, purposeSubtype)
        {
        }

        
        public PersonnelRequestWaiver()
        {
        }

    }

}