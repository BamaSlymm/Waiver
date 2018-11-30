using System;
using System.Collections.Generic;
using System.Linq;
using DPAWaiver.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using DPAWaiver.Models.WaiverSelection;
using DPAWaiver.Models.LOV;

namespace DPAWaiver.Models.Waivers
{
    public class ServiceMailWaiver : BaseWaiver
    {
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

        [Display(Name = "Additional Comments")]
        public string AdditionalComments {get;set;}



        
        public ServiceMailWaiver(DPAUser createdBy, string otherFirstName, string otherLastName,
                              Purpose purpose, PurposeType purposeType, PurposeSubtype purposeSubtype) : base(createdBy, otherFirstName, otherLastName, purpose, purposeType, purposeSubtype)
        {
        }

        public ServiceMailWaiver()
        {
        }

    }

}