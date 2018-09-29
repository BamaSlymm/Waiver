using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DPAWaiver.Areas.Identity.Data;
using DPAWaiver.Models.Waivers;
using Microsoft.AspNetCore.Identity;
using DPAWaiver.Models;
using Microsoft.EntityFrameworkCore;
using DPAWaiver.Services;
using Microsoft.AspNetCore.Http;
using Google;
using System.IO;

namespace DPAWaiver.Pages.Private.Invoice
{
    public class InvoiceModel : BaseWaiverPageModel
    {

        public InvoiceModel(DPAWaiver.Areas.Identity.Data.DPAWaiverIdentityDbContext context
                    , ILOVService iLOVService
                    , UserManager<DPAUser> userManager) : base(context, iLOVService, userManager)
        {
        }

        public BaseWaiver BaseWaiver { get; set; }

        [BindProperty]
        public BaseWaiverInvoiceView BaseWaiverInvoice { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await SetBaseWaiverAsync(id);
            return Page();
        }

        private async Task SetBaseWaiverAsync(Guid? id)
        {
            BaseWaiver = await _context.BaseWaivers.Include(x => x.CreatedBy)
                .ThenInclude(x => x.Department)
                .Include(x => x.Purpose).Include(x => x.PurposeType)
                .Include(x => x.PurposeSubtype)
                .Include(x => x.Invoices).ThenInclude(x => x.CreatedBy)
                .FirstOrDefaultAsync(m => m.ID == id);
        }


        public async Task<IActionResult> OnGetAsyncInvoiceDelete(Guid? id, Guid? waiverId)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Invoice = await _context.BaseWaiverInvoice.FirstOrDefaultAsync(x => x.ID == id);
            UserWithDepartment = await GetUserWithDepartmentAsync();
            await SetBaseWaiverAsync(waiverId);
            _context.BaseWaiverInvoice.Remove(Invoice);
            BaseWaiverAction baseWaiverAction = new BaseWaiverAction(BaseWaiver, UserWithDepartment,
                                                                    WaiverActions.InvoiceDeleted, Invoice);
            _context.BaseWaiverActions.Add(baseWaiverAction);
            await _context.SaveChangesAsync();
            return RedirectToPage(PageList.Invoice, new { id = waiverId });
        }
        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            UserWithDepartment = await GetUserWithDepartmentAsync();

            if (id == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            await SetBaseWaiverAsync(id);
            BaseWaiverInvoice emptyObject = new BaseWaiverInvoice(UserWithDepartment, BaseWaiver);

            if (await TryUpdateModelAsync<BaseWaiverInvoice>(
                emptyObject,
                "basewaiverinvoice",
                w => w.VendorName,
                w => w.InvoiceAmount,
                w => w.InvoiceDate,
                w => w.InvoiceNumber,
                w => w.ReasonForDifference
                ))
            {
                _context.BaseWaiverInvoice.Add(emptyObject);
                BaseWaiverAction baseWaiverAction = new BaseWaiverAction(BaseWaiver, UserWithDepartment,
                                                WaiverActions.InvoiceAdded, emptyObject);
                _context.BaseWaiverActions.Add(baseWaiverAction);
                await _context.SaveChangesAsync();
                return RedirectToPage(PageList.Invoice, new { id = BaseWaiver.ID });
            }
            return null;
        }
    }
}