using System;
using System.Collections.Generic;
using System.Linq;
using DPAWaiver.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using DPAWaiver.Models.WaiverSelection;
using DPAWaiver.Models.LOV;

namespace DPAWaiver.Models.Waivers
{
    public class EquipmentPrintA3Waiver : BaseWaiver
    {
       
        [Required]
        [Display(Name = "Please select from the printer drop down:")]
        public string printerType { get; set; }

        [Required]
        [Display(Name = "Is this new addition or replacement?")]
        public string newOrReplace { get; set; }

        [Display(Name = "Make:")]
        public string Make { get; set; }
        
        [Display(Name = "Model:")]
        public string Model { get; set; }

        [Required]
        [Display(Name = "How do you currently receive this services?")]
        public string servicesReceived { get; set; }

        [Display(Name = "Reasons for selecting this particular equipment:")]
        public string selectionReason { get; set; }

        [Required]
        [Display(Name = "How do you plan to acquire this equipment?")]
        public string acquisitionType { get; set; }
        [Required]
        [Display(Name = "Solicitation SubType?")]
        public string solicitationSubType { get; set; }

        [Required]
        [Display(Name = "State Price SubType?")]
        public string statepriceSubType { get; set; }
        
        [Required]
        [Display(Name = "Purchase Amount:")]
        public decimal purchaseAmount { get; set; }
        
        [Required]
        [Display(Name = "Lease Duration")]
        public decimal leaseDuration { get; set; }
        
        [Required]
        [Display(Name = "Number of Months of Lease")]
        public decimal numberOfMonths {get; set;}
        
        [Required]
        [Display(Name = "Monthly Cost of Present Lease?")]
        public decimal monthlyLeaseAmount {get; set;}

        [Required]
        [Display(Name = "Monochrome/black cost per click associated with the lease?")]
        public decimal blackCostPerPage { get; set; }

        [Required]
        [Display(Name = "What is the Color cost per click associated with the Lease:")]
        public decimal colorCostPerPage { get; set; }

        [Required]
        [Display(Name = "Anticipated monochrome/black monthly volume:")]
        public decimal blackMonthlyVolume { get; set; }

        [Required]
        [Display(Name = "Anticipated average color monthly volume:")]
        public decimal colorMonthlyVolume { get; set; }
        
        [Required]
        [Display(Name = "List what accessories were added as part of your lease/rental agreement.")]
        public string leaseAccessories { get; set; }

        [Required]
        [Display(Name = "Please describe how OIT/DPA recommendations to consolidate printing assets are followed")]
        public string complianceDescription {get; set;}

        [Required]
        [Display(Name = "Please describe the alternatives you have examined before making the request")]
        public string alternativesDescription { get; set; }

        [Required]
        [Display(Name = "Justification For Request:")]
        public decimal justificationDescription { get; set; }       

        [Display(Name = "Any Additional Comments:")]
        public string AdditionalComments { get; set; }


        
        public EquipmentPrintA3Waiver(DPAUser createdBy, string otherFirstName, string otherLastName,
                              Purpose purpose, PurposeType purposeType, PurposeSubtype purposeSubtype) : base(createdBy, otherFirstName, otherLastName, purpose, purposeType, purposeSubtype)
        {
        }

        public EquipmentPrintA3Waiver()
        {
        }

    }

}