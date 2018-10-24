using System;
using System.Collections.Generic;
using System.Linq;
using DPAWaiver.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using DPAWaiver.Models.WaiverSelection;
using DPAWaiver.Models.LOV;

namespace DPAWaiver.Models.Waivers
{
    public class ServiceDesignWaiver : BaseWaiver
    {
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
        [Display(Name = "Total estimated number of hours:")]
        public decimal EstimatedNumberofHours { get; set; }
        
        [Display(Name = "If other please explain:")]
        public string OtherDescription { get; set; }

        public DesignType DesignType {get; set;}


        
        public ServiceDesignWaiver(DPAUser createdBy, string otherFirstName, string otherLastName,
                              Purpose purpose, PurposeType purposeType, PurposeSubtype purposeSubtype) : base(createdBy, otherFirstName, otherLastName, purpose, purposeType, purposeSubtype)
        {
        }

        public ServiceDesignWaiver()
        {
        }

    }

}