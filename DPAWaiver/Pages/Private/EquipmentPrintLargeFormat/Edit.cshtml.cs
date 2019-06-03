using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DPAWaiver.Areas.Identity.Data;
using DPAWaiver.Models.Waivers;
using Microsoft.AspNetCore.Identity;
using DPAWaiver.Models;
using DPAWaiver.Models.WaiverSelection;

namespace DPAWaiver.Pages.Private.EquipmentPrintLargeFormat
{
    public class EditModel : BaseWaiverPageModel
    {
        [BindProperty]
        public EquipmentPrintLargeFormatWaiverView EquipmentPrintLargeFormatWaiver { get; set; }

        public Guid? ID {get;set;}


        public EditModel(DPAWaiver.Areas.Identity.Data.DPAWaiverIdentityDbContext context
                       , ILOVService iLOVService
                       , UserManager<DPAUser> userManager): base(context, iLOVService, userManager)
        {
        }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ID = id ;
            UserWithDepartment = await GetUserWithDepartmentAsync();
            var equipmentPrintWaiver = await _context.EquipmentPrintLargeFormatWaiver.
            FirstOrDefaultAsync(m => m.ID == id);
            EquipmentPrintLargeFormatWaiver = new EquipmentPrintLargeFormatWaiverView(equipmentPrintWaiver);
            Invoices = await GetInvoicesAsync(id) ;
            Attachments = await GetAttachmentsAsync(id) ;

            if (EquipmentPrintLargeFormatWaiver == null || !equipmentPrintWaiver.Editable)
            {
                return NotFound();
            }

            UserWithDepartment = await GetUserWithDepartmentAsync();
            return Page();

        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            UserWithDepartment = await GetUserWithDepartmentAsync();

            if (id == null)
            {
                return NotFound();
            }

            ID = id ;
            Invoices = await GetInvoicesAsync(id);
            Attachments = await GetAttachmentsAsync(id);

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var waiverToUpdate = await _context.EquipmentPrintLargeFormatWaiver.Include(w => w.Purpose).
            Include(w => w.PurposeType).
            Include(w => w.PurposeSubtype).
            Include(w => w.CreatedBy).FirstAsync(x => x.ID == id);

            if (!waiverToUpdate.Editable || waiverToUpdate.CreatedBy.Id != UserWithDepartment.Id) {
                return NotFound();
            }

            if (await TryUpdateModelAsync<EquipmentPrintLargeFormatWaiver>(
               waiverToUpdate,
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
                try
                {
                    BaseWaiverAction baseWaiverAction = new BaseWaiverAction(waiverToUpdate, UserWithDepartment,
                                        WaiverActions.Updated, EquipmentPrintLargeFormatWaiver);
                    _context.BaseWaiverActions.Add(baseWaiverAction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipmentPrintLargeFormatWaiverExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["StatusMessage"] = "Your waiver has been updated";
                return RedirectToPage(PageList.WaiverList);
            }
            return Page();
        }

        private bool EquipmentPrintLargeFormatWaiverExists(Guid? id)
        {
            return _context.EquipmentPrintLargeFormatWaiver.Any(e => e.ID == id);
        }
    }
}
