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
    public class BaseWaiverAction
    {
        
        [JsonIgnore]
        public Guid ID {get;set;}

        [Required]
        public DPAUser CreatedBy { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "When")]
        public DateTime CreatedOn { get; set; }
        
        [Required]
        [Display(Name = "Action Taken")]
        public WaiverActions ActionTaken { get; set; }

        [Display(Name = "Audit Data")]
        public string ActionData { get; set; }

        [Required]
        public BaseWaiver BaseWaiver {get;set;}

        public BaseWaiverAction() {
        }

        public BaseWaiverAction(BaseWaiver baseWaiver, DPAUser createdBy, WaiverActions actionTaken, Object actionData) {
            this.BaseWaiver = baseWaiver;
            this.CreatedBy = createdBy ;
            this.CreatedOn = DateTime.Now;
            this.ActionTaken = actionTaken;
            this.ActionData = JsonConvert.SerializeObject(actionData);
        }

    }

    public enum WaiverActions
    {
        Created,
        Updated,
        Accepted,
        Rejected,
        AttachmentAdded,
        AttachmentDeleted,
        AttachmentViewed,
        InvoiceAdded,
        InvoiceDeleted,
        Other,
    }
}