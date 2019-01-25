using System;
using System.Collections.Generic;
using System.Linq;
using DPAWaiver.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using DPAWaiver.Models.WaiverSelection;
using System.ComponentModel.DataAnnotations.Schema;

namespace DPAWaiver.Models.Waivers
{
    public class EquipmentScanningWaiverView
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
        [Display(Name = "Justification For Request:")]
        public decimal justificationDescription { get; set; }  

        [Required]
        [Display(Name = "How do you currently meet this need?")]
        public string currentSystemDescription { get; set; }


        [Required]
        [Display(Name = "Is this new addition or replacement?")]
        public string newOrReplace { get; set; }        
        
        [Required]
        [Display(Name = "Current Make:")]
        public string currentMake { get; set; }

        [Required]
        [Display(Name = "Current Model:")]
        public string currentModel { get; set; }

        [Required]
        [Display(Name = "Acquisition Date")]
        public DateTime? acquisitionDate {get; set;}

         [Required]
        [Display(Name = "Monthly Cost of Current Service")]
        public decimal monthlyCost {get; set;}
        
        [Required]
        [Display(Name = "Current Average Monthly Volume")]
        public decimal averageMonthlyVolume {get; set;}

        [Required]
        [Display(Name = "Did you consider Multifunction device for scanning?")]
        public string multiFunctionConsidered {get; set;}

        [Display(Name = "If no, please explain")]
        public string multiFunctionReason {get; set;}

        [Required]
        [Display(Name = "Enter the anticipated volume for first year. This is a numeric field")]
        public decimal firstYearVolume {get; set;}

        [Required]
        [Display(Name = "Enter the anticipated volume for second year. This is a numeric field")]
        public decimal secondYearVolume {get; set;}

        [Required]
        [Display(Name = "Enter the anticipated volume for third year. This is a numeric field")]
        public decimal thirdYearVolume {get; set;}

        [Required]
        [Display(Name = "Enter the anticipated volume for fourth year. This is a numeric field")]
        public decimal fourthYearVolume {get; set;}

        [Required]
        [Display(Name = "Enter the anticipated volume for fifth year. This is a numeric field")]
        public decimal fifthYearVolume {get; set;}

        [Required]
        [Display(Name = "Type?")]
        public string scannerType { get; set; }

        [Display(Name = "Please explain other")]
        public string otherScannerType { get; set; }

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
        [Display(Name = "How do you plan to acquire this equipment?")]
        public string acquisitionType { get; set; }

        [Required]
        [Display(Name = "Solicitation SubType?")]
        public string solicitationSubType {get; set;}

        [Display(Name = "State Price SubType?")]
        public string statepriceSubType { get; set; }

        [Required]
        [Display(Name = "Purchase Amount")]
        public decimal purchaseAmount {get; set;}

        [Required]
        [Display(Name = "Lease Duration")]
        public decimal leaseDuration { get; set; }

        [Required]
        [Display(Name = "Number of Months of Lease")]
        public decimal numberOfMonths { get; set; }
        
        [Required]
        [Display(Name = "Monthly Lease Amount")]
        public decimal monthlyLeaseAmount { get; set; }
        
        [Required]
        [Display(Name = "Make and Model")]
        public string makeAndModel {get; set;}

        [Required]
        [Display(Name = "Reasons for selecting this particular equipment:")]
        public string selectionReason { get; set; }

        [Required]
        [Display(Name = "Production Capacity (throughput)")]
        public decimal productionCapacity { get; set; }
        
        [Required]
        [Display(Name = "Estimated Cost of Equipment")]
        public decimal estimatedCost {get; set;}

        [Required]
        [Display(Name = "Lease or purchase")]
        public string leaseOrPurchase { get; set; }

        [Required]
        [Display(Name = "Number of Years")]
        public decimal numberOfYears { get; set; }

        [Required]
        [Display(Name= "Cost of lease per year")]
        public decimal costOfLeasePerYear {get; set; }

        [Required]
        [Display(Name= "Expected useful life of this equipment")]
        public decimal expectedUsefulLife {get; set;}

        [Required]
        [Display(Name = "Depreciation Cost Per Year")]
        public decimal depreciationCostPerYear {get; set;}

        [Required]
        [Display(Name = "Cost of Annual Maintenance Per Year")]
        public decimal annualMaintenanceCostPerYear {get; set;}

        [Required]
        [Display(Name = "Cost of Supplies")]
        public string suppliesCost {get; set;}

        [Required]
        [Display(Name = "Name of Software")]
        public string softwareName {get; set;}

        [Required]
        [Display(Name = "Cost of Software")]
        public decimal softwareCost {get; set;}

       
        [Display(Name = "Annual License Fee if any")]
        public decimal annualLicenseFee {get; set;}

        [Required]
        [Display(Name = "Number of Licenses Required")]
        public decimal numberOfLicenses {get; set;}

        [Required]
        [Display(Name = "Total Annual License Cost")]
        public decimal totalAnnualLicenseCost {get; set;}

        [Required]
        [Display(Name = "Annual Maintenance Cost")]
        public decimal annualMaintenanceCost {get; set;}

        [Required]
        [Display(Name = "Total Software Costs")]
        public decimal totalSoftwareCosts {get; set;}

        [Required]
        [Display(Name = "Operator Classification/Grade")]
        public string operatorClassification {get; set;}

        [Required]
        [Display(Name = "Production FTE Required")]
        public decimal productionFTE {get; set;}

        [Required]
        [Display(Name = "Hours Per FTE Per week")]
        public decimal hoursPerFTEPerWeek {get; set;}

        [Required]
        [Display(Name = "Base Hourly Rate Per FTE")]
        public decimal baseHourlyRatePerFTE {get; set;}

        [Required]
        [Display(Name = "Fully Loaded Hourly Rate Per FTE")]
        public decimal fullyLoadedHourlyRatePerFTE {get; set;}

        [Required]
        [Display(Name = "Total Annual Personnel Cost")]
        public decimal totalAnnualPersonnelCost {get; set;}

        [Required]
        [Display(Name = "Monthly Supervision Amount")]
        public decimal monthlySupervisionAmount {get; set;}

        [Required]
        [Display(Name = "Monthly Management Amount")]
        public decimal monthlyManagementAmount {get; set;}

        [Required]
        [Display(Name = "Is additional workspace required?")]
        public string additionalWorkspaceRequired {get; set;}

        [Required]
        [Display(Name = "Total Space Required in Square Feet")]
        public decimal totalSpaceRequiredInSQFT {get; set;}

        [Required]
        [Display(Name = "Cost Per Square Foot")]
        public decimal costPerSQFT {get; set;}

        [Required]
        [Display(Name = "Annual Utilies Amount for Additional SQFT")]
        public decimal annualAmountForUtilities {get; set;}

        [Required]
        [Display(Name = "Total Space Cost")]
        public decimal totalSpaceCost {get; set;}

        [Required]
        [Display(Name = "Computer Costs")]
        public decimal computerCosts {get; set;}

        [Required]
        [Display(Name = "Furniture Costs")]
        public decimal furnitureCosts {get; set;}

        [Required]
        [Display(Name = "Cubicle Partition Costs")]
        public decimal cubiclePartitionCosts {get; set;}

        [Required]
        [Display(Name = "Construction and Electrical Work Costs")]
        public decimal constructionCosts {get; set;}

        [Required]
        [Display(Name = "Miscellaneous Costs")]
        public decimal miscellaneousCosts {get; set;}

        [Required]
        [Display(Name = "Description of Miscellaneous Costs")]
        public decimal descriptionMiscellaneousCosts {get; set;}

        [Required]
        [Display(Name = "Total Additional One Time Costs")]
        public decimal totalAdditionalOneTimeCosts {get; set;}

        [Required]
        [Display(Name = "Total Cost of Ownership")]
        public decimal totalCostOfOwnership {get; set;}

        [Required]
        [Display(Name = "Please describe the alternatives you have examined before making the request")]
        public string alternativesDescription { get; set; }

        [Display(Name = "Any Additional Comments:")]
        public string AdditionalComments { get; set; }

        public WaiverStatus Status {get;set;}

        public EquipmentScanningWaiverView(EquipmentScanningWaiver other)
        {
            this.CopyFromEquipmentScanningWaiver(other);
        }

public void CopyFromEquipmentScanningWaiver(EquipmentScanningWaiver other) {
            this.OtherFirstName = other.OtherFirstName;
            this.OtherLastName = other.OtherLastName;
            this.projectName = other.projectName;
            this.SubmittedOn = other.SubmittedOn ;
            this.CostEstimate = other.CostEstimate ;
            this.justificationDescription = other.justificationDescription;
            this.currentSystemDescription = other.currentSystemDescription;
            this.newOrReplace = other.newOrReplace;
            this.currentMake = other.currentMake;
            this.currentModel = other.currentModel;
            this.acquisitionDate = other.acquisitionDate;
            this.monthlyCost = other.monthlyCost;
            this.averageMonthlyVolume = other.averageMonthlyVolume;
            this.multiFunctionConsidered = other.multiFunctionConsidered;
            this.multiFunctionReason = other.multiFunctionReason;
            this.firstYearVolume = other.firstYearVolume;
            this.secondYearVolume = other.secondYearVolume;
            this.thirdYearVolume = other.thirdYearVolume;
            this.fourthYearVolume = other.fourthYearVolume;
            this.fifthYearVolume = other.fifthYearVolume;
            this.scannerType = other.scannerType;
            this.NumberofEquipment = other.NumberofEquipment;
            this.Make = other.Make;
            this.Model = other.Model;
            this.scannerType = other.scannerType;
            this.otherScannerType = other.otherScannerType;
            this.acquisitionType = other.acquisitionType;
            this.solicitationSubType = other.solicitationSubType;
            this.statepriceSubType = other.statepriceSubType;
            this.purchaseAmount = other.purchaseAmount;
            this.leaseDuration = other.leaseDuration;
            this.numberOfMonths = other.numberOfMonths;
            this.monthlyLeaseAmount = other.monthlyLeaseAmount;
            this.makeAndModel = other.makeAndModel;
            this.selectionReason = other.selectionReason;
            this.productionCapacity = other.productionCapacity;
            this.estimatedCost = other.estimatedCost;
            this.productionCapacity = other.productionCapacity;
            this.leaseOrPurchase = other.leaseOrPurchase;
            this.numberOfYears = other.numberOfYears;
            this.costOfLeasePerYear = other.costOfLeasePerYear;
            this.expectedUsefulLife = other.expectedUsefulLife;
            this.depreciationCostPerYear = other.depreciationCostPerYear;
            this.annualMaintenanceCostPerYear = other.annualMaintenanceCostPerYear;
            this.suppliesCost = other.suppliesCost;
            this.softwareName = other.softwareName;
            this.softwareCost = other.softwareCost;
            this.annualLicenseFee = other.annualLicenseFee;
            this.numberOfLicenses = other.numberOfLicenses;
            this.totalAnnualLicenseCost = other.totalAnnualLicenseCost;
            this.annualMaintenanceCost = other.annualMaintenanceCost;
            this.totalSoftwareCosts = other.totalSoftwareCosts;
            this.operatorClassification = other.operatorClassification;
            this.productionFTE = other.productionFTE;
            this.hoursPerFTEPerWeek = other.hoursPerFTEPerWeek;
            this.baseHourlyRatePerFTE = other.baseHourlyRatePerFTE;
            this.fullyLoadedHourlyRatePerFTE = other.fullyLoadedHourlyRatePerFTE;
            this.totalAnnualPersonnelCost = other.totalAnnualPersonnelCost;
            this.monthlySupervisionAmount = other.monthlySupervisionAmount;
            this.monthlyManagementAmount = other.monthlyManagementAmount;
            this.additionalWorkspaceRequired = other.additionalWorkspaceRequired;
            this.totalSpaceRequiredInSQFT = other.totalSpaceRequiredInSQFT;
            this.costPerSQFT = other.costPerSQFT;
            this.annualAmountForUtilities = other.annualAmountForUtilities;
            this.totalSpaceCost = other.totalSpaceCost;
            this.computerCosts = other.computerCosts;
            this.furnitureCosts = other.furnitureCosts;
            this.cubiclePartitionCosts = other.cubiclePartitionCosts;
            this.constructionCosts = other.constructionCosts;
            this.miscellaneousCosts = other.miscellaneousCosts;
            this.descriptionMiscellaneousCosts = other.descriptionMiscellaneousCosts;
            this.totalAdditionalOneTimeCosts = other.totalAdditionalOneTimeCosts;
            this.totalCostOfOwnership = other.totalCostOfOwnership;
            this.alternativesDescription = other.alternativesDescription;
            this.Status = other.Status;
            this.AdditionalComments = other.AdditionalComments;
        }

        
        public EquipmentScanningWaiverView()
        {
        }

        [Required]
        [Display(Name = "Type of Design:")]
        public int? DesignTypeID{get; set;}
        
    }

}