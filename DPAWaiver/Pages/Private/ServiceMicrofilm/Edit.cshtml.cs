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

namespace DPAWaiver.Pages.Private.ServiceMicrofilm
{
    public class EditModel : BaseWaiverPageModel
    {
        [BindProperty]
        public ServiceMicrofilmWaiverView ServiceMicrofilmWaiver { get; set; }

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
            var serviceMicrofilmWaiver = await _context.ServiceMicrofilmWaiver.
            FirstOrDefaultAsync(m => m.ID == id);
            ServiceMicrofilmWaiver = new ServiceMicrofilmWaiverView(serviceMicrofilmWaiver);
            Invoices = await GetInvoicesAsync(id) ;
            Attachments = await GetAttachmentsAsync(id) ;

            if (ServiceMicrofilmWaiver == null || !serviceMicrofilmWaiver.Editable)
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

            var waiverToUpdate = await _context.ServiceMicrofilmWaiver.Include(w => w.Purpose).
            Include(w => w.PurposeType).
            Include(w => w.PurposeSubtype).
            Include(w => w.CreatedBy).FirstAsync(x => x.ID == id);

            if (!waiverToUpdate.Editable || waiverToUpdate.CreatedBy.Id != UserWithDepartment.Id) {
                return NotFound();
            }

            
            if (await TryUpdateModelAsync<ServiceMicrofilmWaiver>(
               waiverToUpdate,
               "ServiceMicrofilmwaiver",
               w => w.OtherFirstName,
               w => w.OtherLastName,
               w => w.projectName,
               w => w.SubmittedOn,
               w => w.CostEstimate,
               w => w.ItemDescription,
               w => w.MicrofilmDuplication,
               w => w.RequestedRolls,
               w => w.EstimatedNumberofFTE,
               w => w.EstimatedNumberOfHours,
               w => w.outputType,
               w => w.RollsLabeled,
               w => w.duplicateRolls,
               w => w.NumberofRolls,
               w => w.JobRequirements,
               w => w.AlternativeMethods,
               w => w.NotInHouseReason,
               w => w.AdditionalComments,
               w => w.ID,
               w => w.CreatedOn,
               w => w.approvedOn
               ))
            {
                try
                {
                    BaseWaiverAction baseWaiverAction = new BaseWaiverAction(waiverToUpdate, UserWithDepartment,
                                        WaiverActions.Updated, ServiceMicrofilmWaiver);
                    _context.BaseWaiverActions.Add(baseWaiverAction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceMicrofilmWaiverExists(id))
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

        private bool ServiceMicrofilmWaiverExists(Guid? id)
        {
            return _context.ServiceMicrofilmWaiver.Any(e => e.ID == id);
        }
    }
}
