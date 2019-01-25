using System;
using System.Collections.Generic;
using System.Linq;
using DPAWaiver.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using DPAWaiver.Models.WaiverSelection;
using DPAWaiver.Models.LOV;

namespace DPAWaiver.Models.Waivers
{
    public class EquipmentPrintA4Waiver : BaseWaiver
    {

        [Required]
        [Display(Name = "Please select from the printer drop down:")]
        public string printerType { get; set; }
        
        
        [Required]
        [Display(Name = "Number of equipment?")]
        public decimal NumberofEquipment {get; set;}
        
        [Required]
        [Display(Name = "Make:")]
        public string Make { get; set; }
        
        [Required]
        [Display(Name = "Model:")]
        public string Model { get; set; }

        [Required]
        [Display(Name = "Is this new addition or replacement?")]
        public string newOrReplace { get; set; }

        [Required]
        [Display(Name = "How do you currently receive this services?")]
        public string servicesReceived { get; set; }

        [Required]
        [Display(Name = "Current Average Monthly Volume")]
        public decimal currentMonthlyVolume {get; set;}

        [Required]
        [Display(Name = "Anticipated Monthly Volume")]
        public decimal anticipatedMonthlyVolume {get; set;}


        [Required]
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
        [Display(Name = "Monthly Lease Amount")]
        public decimal monthlyLeaseAmount {get; set;}

        [Required]
        [Display(Name = "Number of Months of Lease")]
        public decimal monthsOfLease { get; set; }
        
        [Required]
        [Display(Name = "Yearly Maintenance Amount")]
        public decimal yearlyMaintenanceAmount {get; set;}

        

        [Required]
        [Display(Name = "Overall Toner Cost")]
        public decimal tonerCost { get; set; }

        [Required]
        [Display(Name = "Expected useful life at anticipated volume:")]
        public decimal usefulLife { get; set; }

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


        
        public EquipmentPrintA4Waiver(DPAUser createdBy, string otherFirstName, string otherLastName,
                              Purpose purpose, PurposeType purposeType, PurposeSubtype purposeSubtype) : base(createdBy, otherFirstName, otherLastName, purpose, purposeType, purposeSubtype)
        {
        }

        public EquipmentPrintA4Waiver()
        {
        }

    }

}