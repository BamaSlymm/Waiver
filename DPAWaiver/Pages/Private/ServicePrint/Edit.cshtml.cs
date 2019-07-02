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

namespace DPAWaiver.Pages.Private.ServicePrint
{
    public class EditModel : BaseWaiverPageModel
    {
        [BindProperty]
        public ServicePrintWaiverView ServicePrintWaiver { get; set; }

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
            var servicePrintWaiver = await _context.ServicePrintWaiver.
            FirstOrDefaultAsync(m => m.ID == id);
            ServicePrintWaiver = new ServicePrintWaiverView(servicePrintWaiver);
            Invoices = await GetInvoicesAsync(id) ;
            Attachments = await GetAttachmentsAsync(id) ;

            if (ServicePrintWaiver == null || !servicePrintWaiver.Editable)
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

            var waiverToUpdate = await _context.ServicePrintWaiver.Include(w => w.Purpose).
            Include(w => w.PurposeType).
            Include(w => w.PurposeSubtype).
            Include(w => w.CreatedBy).FirstAsync(x => x.ID == id);

            if (!waiverToUpdate.Editable || waiverToUpdate.CreatedBy.Id != UserWithDepartment.Id) {
                return NotFound();
            }

            
            if (await TryUpdateModelAsync<ServicePrintWaiver>(
               waiverToUpdate,
               "ServicePrintwaiver",
               w => w.OtherFirstName,
               w => w.OtherLastName,
               w => w.projectName,
               w => w.SubmittedOn,
               w => w.CostEstimate,
               w => w.ItemDescription,
               w => w.EstimateObtained,
               w => w.PaperStockType,
               w => w.otherPaperStockReason,
               w => w.estimateFile,
               w => w.FinishingType,
               w => w.Reprint,
               w => w.previousPrinter,
               w => w.numberOfOriginals,
               w => w.Quantity,
               w => w.FourColorJob,
               w => w.numberOfInks,
               w => w.projectDueDate,
               w => w.FinishedSize,
               w => w.AdditionalComments,
               w => w.ID,
               w => w.Status,
               w => w.CreatedOn,
               w => w.approvedOn
               ))
            {
                try
                {
                    BaseWaiverAction baseWaiverAction = new BaseWaiverAction(waiverToUpdate, UserWithDepartment,
                                        WaiverActions.Updated, ServicePrintWaiver);
                    _context.BaseWaiverActions.Add(baseWaiverAction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicePrintWaiverExists(id))
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

        private bool ServicePrintWaiverExists(Guid? id)
        {
            return _context.ServicePrintWaiver.Any(e => e.ID == id);
        }
    }
}
