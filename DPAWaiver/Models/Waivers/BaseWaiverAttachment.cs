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
    public class BaseWaiverAttachment
    {
        
        public Guid ID {get;set;}

        [Required]
        [JsonIgnore]
        public DPAUser CreatedBy { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }
        
        [Required]
        [Display(Name = "File Name")]
        public string FileName { get; set; }

        [Required]
        [Display(Name = "Google Name")]
        public string ObjectName { get; set; }

        [Required]
        [Display(Name = "Content Type")]
        public string ContentType { get; set; }
        
        [Required]
        public string Md5Hash { get; set;}

        [Required]
        public string GoogleId {get; set;}

        [Required]
        [JsonIgnore]
        public BaseWaiver BaseWaiver {get;set;}

        public BaseWaiverAttachment() {
        }

        public BaseWaiverAttachment(BaseWaiver baseWaiver, DPAUser createdBy, 
                                    Google.Apis.Storage.v1.Data.Object attachment,
                                    string filename) {
            this.BaseWaiver = baseWaiver;
            this.CreatedBy = createdBy ;
            this.CreatedOn = DateTime.Now;
            this.FileName = filename ;
            this.ObjectName = attachment.Name;
            this.ContentType = attachment.ContentType;
            this.Md5Hash = attachment.Md5Hash ;
            this.GoogleId = attachment.Id;
        }

    }

}