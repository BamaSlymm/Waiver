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

namespace DPAWaiver.Pages.Private.ServiceMicrofilmConversion
{
    public class EditModel : BaseWaiverPageModel
    {
        [BindProperty]
        public ServiceMicrofilmConversionWaiverView ServiceMicrofilmConversionWaiver { get; set; }

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
            var serviceMicrofilmConversionWaiver = await _context.ServiceMicrofilmConversionWaiver.
            FirstOrDefaultAsync(m => m.ID == id);
            ServiceMicrofilmConversionWaiver = new ServiceMicrofilmConversionWaiverView(serviceMicrofilmConversionWaiver);
            Invoices = await GetInvoicesAsync(id) ;
            Attachments = await GetAttachmentsAsync(id) ;

            if (ServiceMicrofilmConversionWaiver == null || !serviceMicrofilmConversionWaiver.Editable)
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

            var waiverToUpdate = await _context.ServiceMicrofilmConversionWaiver.Include(w => w.Purpose).
            Include(w => w.PurposeType).
            Include(w => w.PurposeSubtype).
            Include(w => w.CreatedBy).FirstAsync(x => x.ID == id);

            if (!waiverToUpdate.Editable || waiverToUpdate.CreatedBy.Id != UserWithDepartment.Id) {
                return NotFound();
            }

            
            if (await TryUpdateModelAsync<ServiceMicrofilmConversionWaiver>(
               waiverToUpdate,
               "ServiceMicrofilmConversionwaiver",
               w => w.OtherFirstName,
               w => w.OtherLastName,
               w => w.projectName,
               w => w.SubmittedOn,
               w => w.CostEstimate,
               w => w.WorkflowDescription,
               w => w.typeofFilm,
               w => w.NumberofRolls,
               w => w.numberOfCards,
               w => w.EstimatedNumberOfHours,
               w => w.EstimatedNumberofFTE,
               w => w.indexingNeeded,
               w => w.textSearchablePDF,
               w => w.EstimatedNumberOfFields,
               w => w.imageDelivery,
               w => w.otherImageDelivery,
               w => w.emailOtherImageDelivery,
               w => w.systemRequirements,
               w => w.keyedIntoSystem,
               w => w.ReasonForNotKeyedIntoSystem,
               w => w.doneInHouse,
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
                                        WaiverActions.Updated, ServiceMicrofilmConversionWaiver);
                    _context.BaseWaiverActions.Add(baseWaiverAction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceMicrofilmConversionWaiverExists(id))
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

        private bool ServiceMicrofilmConversionWaiverExists(Guid? id)
        {
            return _context.ServiceMicrofilmConversionWaiver.Any(e => e.ID == id);
        }
    }
}
