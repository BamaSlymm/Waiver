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

namespace DPAWaiver.Pages.Private.EquipmentScanning
{
    public class CreateModel : BaseWaiverPageModel
    {
        [BindProperty]
        public EquipmentScanningWaiverView EquipmentScanningWaiver { get; set; }

        public CreateModel(DPAWaiverIdentityDbContext context, ILOVService iLOVService, UserManager<DPAUser> userManager) : base(context, iLOVService, userManager)
        {
        }

        public async Task<IActionResult> OnGetAsync([FromQuery(Name = "otherFirstName")] string otherFirstName, [FromQuery(Name = "otherLastName")] string otherLastName)
        {
            UserWithDepartment = await GetUserWithDepartmentAsync();

            EquipmentScanningWaiver = new EquipmentScanningWaiverView();
            EquipmentScanningWaiver.OtherFirstName = otherFirstName;
            EquipmentScanningWaiver.OtherLastName = otherLastName;
            return Page();
        }

        public IEnumerable<SelectListItem> softwaretype => _ILOVService.GetSoftwareTypesAsSelectListBySortOrder();

        public async Task<IActionResult> OnPostAsync()
        {
            UserWithDepartment = await GetUserWithDepartmentAsync();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var purpose = _ILOVService.getPurposes().Single(x => x.ID == Purposes.Software);
            var purposeType = _ILOVService.getSoftwareTypes().Single(x => x.ID == SoftwareTypes.Design);
            EquipmentScanningWaiver emptyWaiver = new EquipmentScanningWaiver(UserWithDepartment, null, null, purpose, purposeType, null);

            if (await TryUpdateModelAsync<EquipmentScanningWaiver>(
               emptyWaiver,
               "EquipmentScanningwaiver",
                w => w.OtherFirstName,
               w => w.OtherLastName,
               w => w.projectName,
               w => w.SubmittedOn,
               w => w.CostEstimate,
               w => w.justificationDescription,
                w => w.currentSystemDescription,
                w => w.newOrReplace,
                w => w.monthlyCost,
                w => w.averageMonthlyVolume,
                w => w.firstYearVolume,
                w => w.secondYearVolume,
                w => w.thirdYearVolume,
                w => w.fourthYearVolume,
                w => w.fifthYearVolume,
                w => w.scannerType,
                w => w.NumberofEquipment,
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
                w => w.numberOfYears,
                w => w.costOfLeasePerYear,
                w => w.expectedUsefulLife,
                w => w.depreciationCostPerYear,
                w => w.annualMaintenanceCostPerYear,
                w => w.suppliesCost,
                w => w.totalEquipmentCost,
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
                w => w.AdditionalComments,
               w => w.ID,
               w => w.CreatedOn,
               w => w.approvedOn
               ))
            {
                _context.EquipmentScanningWaiver.Add(emptyWaiver);
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