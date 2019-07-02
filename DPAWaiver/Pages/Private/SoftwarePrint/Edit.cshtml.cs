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

namespace DPAWaiver.Pages.Private.SoftwarePrint
{
    public class EditModel : BaseWaiverPageModel
    {
        [BindProperty]
        public SoftwarePrintWaiverView SoftwarePrintWaiver { get; set; }

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
            var softwarePrintWaiver = await _context.SoftwarePrintWaiver.
            FirstOrDefaultAsync(m => m.ID == id);
            SoftwarePrintWaiver = new SoftwarePrintWaiverView(softwarePrintWaiver);
            Invoices = await GetInvoicesAsync(id) ;
            Attachments = await GetAttachmentsAsync(id) ;

            if (SoftwarePrintWaiver == null || !softwarePrintWaiver.Editable)
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

            var waiverToUpdate = await _context.SoftwarePrintWaiver.Include(w => w.Purpose).
            Include(w => w.PurposeType).
            Include(w => w.PurposeSubtype).
            Include(w => w.CreatedBy).FirstAsync(x => x.ID == id);

            if (!waiverToUpdate.Editable || waiverToUpdate.CreatedBy.Id != UserWithDepartment.Id) {
                return NotFound();
            }

            
            if (await TryUpdateModelAsync<SoftwarePrintWaiver>(
               waiverToUpdate,
               "SoftwarePrintwaiver",
               w => w.OtherFirstName,
               w => w.OtherLastName,
               w => w.projectName,
               w => w.SubmittedOn,
               w => w.CostEstimate,
               w => w.typeOfSoftware,
                w => w.numberOfLicenses,
                w => w.newOrReplace,
				w => w.costOfPresentService,
				w => w.servicesReceived,
				w => w.softwareProvider,
                w => w.softwareVersion,
                w => w.selectionReason,
                w => w.expectedDuration,
                w => w.acquisitionType,
                w => w.subscriptionOrPurchase,
				w => w.purchaseAmount,
                w => w.monthlySubscriptionAmount,
                w => w.numberOfMonths,
                w => w.annualMaintenanceCost,
                w => w.operatorClassification,
                w => w.Grade,
                w => w.numberOfFTE,
                w => w.hoursPerFTEPerWeek,
				w => w.totalWeeklySalary,
                w => w.monthlySupervisionAmount,
                w => w.monthlyManagementAmount,
                w => w.justificationDescription,
                w => w.alternativesConsidered,
                w => w.Status,
                w => w.AdditionalComments
               ))
            {
                try
                {
                    BaseWaiverAction baseWaiverAction = new BaseWaiverAction(waiverToUpdate, UserWithDepartment,
                                        WaiverActions.Updated, SoftwarePrintWaiver);
                    _context.BaseWaiverActions.Add(baseWaiverAction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoftwarePrintWaiverExists(id))
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

        private bool SoftwarePrintWaiverExists(Guid? id)
        {
            return _context.SoftwarePrintWaiver.Any(e => e.ID == id);
        }
    }
}
