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

namespace DPAWaiver.Pages.Private.SoftwareDataEntry
{
    public class EditModel : BaseWaiverPageModel
    {
        [BindProperty]
        public SoftwareDataEntryWaiverView SoftwareDataEntryWaiver { get; set; }

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
            var softwareDataEntryWaiver = await _context.SoftwareDataEntryWaiver.
            FirstOrDefaultAsync(m => m.ID == id);
            SoftwareDataEntryWaiver = new SoftwareDataEntryWaiverView(softwareDataEntryWaiver);
            Invoices = await GetInvoicesAsync(id) ;
            Attachments = await GetAttachmentsAsync(id) ;

            if (SoftwareDataEntryWaiver == null || !softwareDataEntryWaiver.Editable)
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

            var waiverToUpdate = await _context.SoftwareDataEntryWaiver.Include(w => w.Purpose).
            Include(w => w.PurposeType).
            Include(w => w.PurposeSubtype).
            Include(w => w.CreatedBy).FirstAsync(x => x.ID == id);

            if (!waiverToUpdate.Editable || waiverToUpdate.CreatedBy.Id != UserWithDepartment.Id) {
                return NotFound();
            }

            if (await TryUpdateModelAsync<SoftwareDataEntryWaiver>(
               waiverToUpdate,
              "SoftwareDataEntrywaiver",
               w => w.OtherFirstName,
               w => w.OtherLastName,
               w => w.projectName,
               w => w.SubmittedOn,
               w => w.CostEstimate,
               w => w.typeOfSoftware,
                w => w.numberOfLicenses,
                w => w.newOrReplace,
                w => w.softwareVersion,
                w => w.costOfPresentService,        
                w => w.currentMonthlyVolume,
                w => w.firstYearVolume,
                w => w.secondYearVolume,
                w => w.thirdYearVolume,
                w => w.fourthYearVolume,
                w => w.fifthYearVolume,
                w => w.softwareProvider,
                w => w.softwareVolume,
                w => w.solicitationSubType,
                w => w.purchaseAmount,
                w => w.selectionReason,
                w => w.expectedDuration,
                w => w.solicitationSubType,
                w => w.statepriceSubType,
                w => w.purchaseAmount,
                w => w.annualMaintenanceCost,
                w => w.operatorClassification,
                w => w.Grade,
                w => w.numberOfFTE,
                w => w.numberOfLicenses,
                w => w.hoursPerFTEPerWeek,
                w => w.annualMaintenanceCost,
                w => w.operatorClassification,
                w => w.hoursPerFTEPerWeek,
                w => w.totalWeeklySalary,
                w => w.totalSpaceInSQFT,
                w => w.monthlySupervisionAmount,
                w => w.monthlySupervisionAmount,
                w => w.monthlyManagementAmount,
                w => w.monthlyUtilitiesAmount,
                w => w.monthlyIndirectCosts,
                w => w.monthlyOverheadCosts,
                w => w.alternativesConsidered,
                w => w.Status,
                w => w.AdditionalComments,
                w => w.CreatedBy
               ))
            {
                try
                {
                    BaseWaiverAction baseWaiverAction = new BaseWaiverAction(waiverToUpdate, UserWithDepartment,
                                        WaiverActions.Updated, SoftwareDataEntryWaiver);
                    _context.BaseWaiverActions.Add(baseWaiverAction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoftwareDataEntryWaiverExists(id))
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

        private bool SoftwareDataEntryWaiverExists(Guid? id)
        {
            return _context.SoftwareDataEntryWaiver.Any(e => e.ID == id);
        }
    }
}
