using System;
using System.Collections.Generic;
using System.Linq;
using DPAWaiver.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using DPAWaiver.Models.WaiverSelection;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using DPAWaiver.Pages.Private.Invoice;

namespace DPAWaiver.Models.Waivers
{
    public class BaseWaiverInvoice
    {
        
        [JsonIgnore]
        public Guid ID {get;set;}

        [Required]
        [JsonIgnore]
        public DPAUser CreatedBy { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }
        
        [Required]
        [Display(Name = "Vendor Name")]
        public string VendorName { get; set; }

        [Required]
        [Display(Name = "Invoice Number")]
        public string InvoiceNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Invoice Date")]
        public DateTime InvoiceDate { get; set; }

        [Required]
        [Column(TypeName="DECIMAL(13,2)")]
        [Display(Name = "Cost Estimate")]
        [RegularExpression(@"^\d+(\.\d{0,2})?$")]
        [Range(0, 999999999999.99)]
        public decimal InvoiceAmount { get ; set;}
        
        [Display(Name = "If Invoice total amount is greater than project budget/cost estimate, please explain the reason for difference")]
        public string ReasonForDifference { get; set;}

        [Required]
        [JsonIgnore]
        public BaseWaiver BaseWaiver {get;set;}

        public BaseWaiverInvoice() {
        }

        public BaseWaiverInvoice(DPAUser createdBy, BaseWaiver baseWaiver, BaseWaiverInvoiceView view) {
            this.CreatedBy = createdBy;
            this.CreatedOn = DateTime.Now;
            this.InvoiceAmount = view.InvoiceAmount;
            this.InvoiceDate = view.InvoiceDate ;
            this.InvoiceNumber = view.InvoiceNumber ;
            this.ReasonForDifference = view.ReasonForDifference ;
            this.BaseWaiver = baseWaiver ;
        }

        public BaseWaiverInvoice(DPAUser createdBy, BaseWaiver baseWaiver) {
            this.CreatedBy = createdBy;
            this.CreatedOn = DateTime.Now;
            this.BaseWaiver = baseWaiver;
        }

    }

}