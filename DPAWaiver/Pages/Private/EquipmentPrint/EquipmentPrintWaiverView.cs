using System;
using System.Collections.Generic;
using System.Linq;
using DPAWaiver.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using DPAWaiver.Models.WaiverSelection;
using System.ComponentModel.DataAnnotations.Schema;

namespace DPAWaiver.Models.Waivers
{
    public class EquipmentPrintWaiverView
    {  [Display(Name = "Waiver Owner First Name")]
        public string OtherFirstName { get; set; }

        [Display(Name = "Waiver Owner Last Name")]
        public string OtherLastName { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public string projectName {get;set;}

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Submitted Date")]
        public DateTime? SubmittedOn { get; set; }

         [Required]
        [Column(TypeName="DECIMAL(13,2)")]
        [Display(Name = "Cost Estimate")]
        [RegularExpression(@"^\d+(\.\d{0,2})?$")]
        [Range(0, 9999999999999999.99)]
        public decimal CostEstimate { get ; set;}

        [Required]
        [Display(Name = "Please select from the printer drop down:")]
        public string printerType { get; set; }

        
        [Required]
        [Display(Name = "Please select from the catalog link:")]
        public string catalogLink { get; set; }

        [Display(Name = "Make:")]
        public string Make { get; set; }
        
        [Display(Name = "Model:")]
        public string Model { get; set; }

        [Required]
        [Display(Name = "Are you ordering for a group of individuals?")]
        public string forGroupOfIndividuals { get; set; }

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
        [Display(Name = "Number of Months of Lease")]
        public decimal numberofMonths {get; set;}
        
        [Required]
        [Display(Name = "Monthly Cost of Present Lease?")]
        public decimal monthlyLeaseAmount {get; set;}

        [Required]
        [Display(Name = "How do you currently receive this services?")]
        public string servicesReceived { get; set; }

        [Required]
        [Display(Name = "Number of equipment?")]
        public decimal numberOfEquipment { get; set; }
        
        [Required]
        [Display(Name = "Purchase Amount:")]
        public decimal purchaseAmount { get; set; }

        [Required]
        [Display(Name = "Maintenance or Extended Warranty Cost:")]
        public decimal agreementOrWarrantyCost { get; set; }

        [Required]
        [Display(Name = "Printer Replacement Cycle:")]
        public decimal printerReplacementCycle { get; set; }

        [Required]
        [Display(Name = "Please enter replacement cycle in months:")]
        public decimal otherReplacementCycle { get; set; }

        [Required]
        [Display(Name = "Monthly Cost Without Toner:")]
        public decimal monthlyCostWithoutToner { get; set; }
        [Required]
        [Display(Name = "Anticipated Monochrome(black) monthly volume:")]
        public decimal monthlyMonochromeVolume { get; set; }
        [Required]
        [Display(Name = "Average color monthly volume:")]
        public decimal monthlyColorVolume { get; set; }
        
        [Required]
        [Display(Name = "Black Toner Cartridge Cost:")]
        public decimal blackTonerCost { get; set; }

        [Required]
        [Display(Name = "Page Yield @@ 10%:")]
        public decimal pageYieldForBlackToner { get; set; }

        [Required]
        [Display(Name = "Black Ink Cost Per Page:")]
        public decimal blackInkCostPerPage { get; set; }

        [Required]
        [Display(Name = "Cyan Toner Cartridge Cost (if applicable):")]
        public decimal cyanTonerCost { get; set; }

        [Required]
        [Display(Name = "Page Yield @@ 10%:")]
        public decimal pageYieldForCyanToner { get; set; }

        [Required]
        [Display(Name = "Cyan Ink Cost Per Page:")]
        public decimal cyanInkCostPerPage { get; set; }


        [Required]
        [Display(Name = "Magenta Toner Cartridge Cost (if applicable):")]
        public decimal MagentaTonerCost { get; set; }

        [Required]
        [Display(Name = "Page Yield @@ 10%:")]
        public decimal pageYieldForMagentaToner { get; set; }

        [Required]
        [Display(Name = "Magenta Ink Cost Per Page:")]
        public decimal MagentaInkCostPerPage { get; set; }


        [Required]
        [Display(Name = "Yellow Toner Cartridge Cost (if applicable):")]
        public decimal YellowTonerCost { get; set; }

        [Required]
        [Display(Name = "Page Yield @@ 10%:")]
        public decimal pageYieldForYellowToner { get; set; }

        [Required]
        [Display(Name = "Yellow Ink Cost Per Page:")]
        public decimal YellowInkCostPerPage { get; set; }

        [Required]
        [Display(Name = "Total Ink Cost Per Page:")]
        public decimal totalInkCostPerPage { get; set; }

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
        public string additionalComments { get; set; }

        public WaiverStatus Status {get;set;}

        public EquipmentPrintWaiverView(EquipmentPrintWaiver other)
        {
            this.CopyFromEquipmentPrintWaiver(other);
        }

public void CopyFromEquipmentPrintWaiver(EquipmentPrintWaiver other) {
            this.OtherFirstName = other.OtherFirstName;
            this.OtherLastName = other.OtherLastName;
            this.projectName = other.projectName;
            this.SubmittedOn = other.SubmittedOn ;
            this.CostEstimate = other.CostEstimate ;
            this.printerType = other.printerType;
            this.catalogLink = other.catalogLink;
            this.Make = other.Make;
            this.Model = other.Model;
            this.forGroupOfIndividuals = other.forGroupOfIndividuals;
            this.selectionReason = other.selectionReason;
            this.acquisitionType = other.acquisitionType;
            this.solicitationSubType = other.solicitationSubType;
            this.statepriceSubType = other.statepriceSubType;
            this.numberofMonths = other.numberofMonths;
            this.monthlyLeaseAmount = other.monthlyLeaseAmount;
            this.servicesReceived = other.servicesReceived;
            this.numberOfEquipment = other.numberOfEquipment;
            this.purchaseAmount = other.purchaseAmount;
            this.agreementOrWarrantyCost = other.agreementOrWarrantyCost;
            this.printerReplacementCycle = other.printerReplacementCycle;
            this.otherReplacementCycle = other.otherReplacementCycle;
            this.monthlyCostWithoutToner = other.monthlyCostWithoutToner;
            this.monthlyMonochromeVolume = other.monthlyMonochromeVolume;
            this.monthlyColorVolume = other.monthlyColorVolume;
            this.blackTonerCost = other.blackTonerCost;
            this.pageYieldForBlackToner = other.pageYieldForBlackToner;
            this.blackInkCostPerPage = other.blackInkCostPerPage;
            this.cyanTonerCost = other.cyanTonerCost;
            this.pageYieldForCyanToner = other.pageYieldForCyanToner;
            this.cyanInkCostPerPage = other.cyanInkCostPerPage;
            this.MagentaTonerCost = other.MagentaTonerCost;
            this.pageYieldForMagentaToner = other.pageYieldForMagentaToner;
            this.MagentaInkCostPerPage = other.MagentaInkCostPerPage;
            this.YellowTonerCost = other.YellowTonerCost;
            this.pageYieldForYellowToner = other.pageYieldForYellowToner;
            this.YellowInkCostPerPage = other.YellowInkCostPerPage;
            this.totalInkCostPerPage = other.totalInkCostPerPage;
            this.complianceDescription = other.complianceDescription;
            this.alternativesDescription = other.alternativesDescription;
            this.justificationDescription = other.justificationDescription;            
            this.Status = other.Status;
            this.additionalComments = other.additionalComments;
        }

        
        public EquipmentPrintWaiverView()
        {
        }

        [Required]
        [Display(Name = "Type of Design:")]
        public int? DesignTypeID{get; set;}
        
    }

}