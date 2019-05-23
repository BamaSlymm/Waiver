using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DPAWaiver.Areas.Identity.Data;
using DPAWaiver.Models.Waivers;
using DPAWaiver.Models;
using Microsoft.AspNetCore.Identity;
using DPAWaiver.Models.WaiverSelection;

namespace DPAWaiver.Pages.Private.EquipmentPrintLargeFormat
{
    public class CreateModel : BaseWaiverPageModel
    {
        [BindProperty]
        public EquipmentPrintLargeFormatWaiverView EquipmentPrintLargeFormatWaiver { get; set; }

        public CreateModel(DPAWaiverIdentityDbContext context, ILOVService iLOVService, UserManager<DPAUser> userManager) : base(context, iLOVService, userManager)
        {
        }

        public async Task<IActionResult> OnGetAsync([FromQuery(Name = "otherFirstName")] string otherFirstName, [FromQuery(Name = "otherLastName")] string otherLastName)
        {
            UserWithDepartment = await GetUserWithDepartmentAsync();

            EquipmentPrintLargeFormatWaiver = new EquipmentPrintLargeFormatWaiverView();
            EquipmentPrintLargeFormatWaiver.OtherFirstName = otherFirstName;
            EquipmentPrintLargeFormatWaiver.OtherLastName = otherLastName;
            return Page();
        }

        public IEnumerable<SelectListItem> equipmenttype => _ILOVService.GetEquipmentTypesAsSelectListBySortOrder();

        public async Task<IActionResult> OnPostAsync()
        {
            UserWithDepartment = await GetUserWithDepartmentAsync();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var purpose = _ILOVService.getPurposes().Single(x => x.ID == Purposes.Equipment);
            var purposeType = _ILOVService.getEquipmentTypes().Single(x => x.ID == EquipmentTypes.Print);
            EquipmentPrintLargeFormatWaiver emptyWaiver = new EquipmentPrintLargeFormatWaiver(UserWithDepartment, null, null, purpose, purposeType, null);

            if (await TryUpdateModelAsync<EquipmentPrintLargeFormatWaiver>(
               emptyWaiver,
               "EquipmentPrintLargeFormatwaiver",
               w => w.OtherFirstName,
               w => w.OtherLastName,
               w => w.projectName,
               w => w.SubmittedOn,
               w => w.CostEstimate,
               w => w.justificationDescription,
                w => w.servicesReceived,
                w => w.newOrReplace,
                w => w.currentMake,
                w => w.currentModel,
                w => w.acquisitionDate,
                w => w.monthlyCost,
                w => w.averageMonthlyVolume,
                w => w.firstYearVolume,
                w => w.secondYearVolume,
                w => w.thirdYearVolume,
                w => w.fourthYearVolume,
                w => w.fifthYearVolume,
                w => w.equipmentType,
                w => w.NumberofEquipment,
                w => w.Make,
                w => w.Model,
                w => w.acquisitionType,
                w => w.solicitationSubType,
                w => w.purchaseAmount,
                w => w.leaseDuration,
                w => w.numberOfMonths,
                w => w.monthlyLeaseAmount,
                w => w.makeAndModel,
                w => w.selectionReason,
                w => w.productionCapacity,
                w => w.estimatedCost,
                w => w.productionCapacity,
                w => w.leaseOrPurchase,
                w => w.numberOfYears,
                w => w.costOfLeasePerYear,
                w => w.expectedUsefulLife,
                w => w.depreciationCostPerYear,
                w => w.annualMaintenanceCostPerYear,
                w => w.suppliesCost,
                w => w.softwareName,
                w => w.softwareCost,
                w => w.annualLicenseFee,
                w => w.numberOfLicenses,
                w => w.totalAnnualLicenseCost,
                w => w.annualMaintenanceCost,
                w => w.totalSoftwareCosts,
                w => w.operatorClassification,
                w => w.productionFTE,
                w => w.hoursPerFTEPerWeek,
                w => w.baseHourlyRatePerFTE,
                w => w.fullyLoadedHourlyRatePerFTE,
                w => w.totalAnnualPersonnelCost,
                w => w.monthlySupervisionAmount,
                w => w.monthlyManagementAmount,
                w => w.additionalWorkspaceRequired,
                w => w.totalSpaceRequiredInSQFT,
                w => w.costPerSQFT,
                w => w.annualAmountForUtilities,
                w => w.totalSpaceCost,
                w => w.computerCosts,
                w => w.furnitureCosts,
                w => w.cubiclePartitionCosts,
                w => w.constructionCosts,
                w => w.miscellaneousCosts,
                w => w.descriptionMiscellaneousCosts,
                w => w.totalAdditionalOneTimeCosts,
                w => w.totalCostOfOwnership,
                w => w.alternativesDescription,
                w => w.Status,
                w => w.AdditionalComments
               ))
            {
                _context.EquipmentPrintLargeFormatWaiver.Add(emptyWaiver);
                BaseWaiverAction baseWaiverAction = new BaseWaiverAction(emptyWaiver, UserWithDepartment,
                                                WaiverActions.Created, emptyWaiver);
                _context.BaseWaiverActions.Add(baseWaiverAction);
                await _context.SaveChangesAsync();
                return RedirectToPage(PageList.Confirmation, new { id = emptyWaiver.ID });
            }

            return null;
        }
    }
}