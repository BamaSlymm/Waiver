using System;
using System.Collections.Generic;
using System.Linq;
using DPAWaiver.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using DPAWaiver.Models.WaiverSelection;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace DPAWaiver.Pages.Private.Invoice
{
    public class BaseWaiverInvoiceView
    {

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
        [Column(TypeName = "DECIMAL(13,2)")]
        [Display(Name = "Invoice Amount")]
        [RegularExpression(@"^\d+(\.\d{0,2})?$")]
        [Range(0, 999999999999.99)]
        public decimal InvoiceAmount { get; set; }


        [Display(Name = "If Invoice total amount is greater than project budget/cost estimate, please explain the reason for difference")]
        public string ReasonForDifference { get; set; }

        public BaseWaiverInvoiceView()
        {
        }

    }

}