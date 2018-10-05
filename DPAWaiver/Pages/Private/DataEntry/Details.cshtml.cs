using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DPAWaiver.Areas.Identity.Data;
using DPAWaiver.Models.Waivers;
using Microsoft.AspNetCore.Identity;
using DPAWaiver.Models;


namespace DPAWaiver.Pages.Private.DataEntry
{
    public class DetailsModel : BaseWaiverPageModel
    {


        public DetailsModel(DPAWaiver.Areas.Identity.Data.DPAWaiverIdentityDbContext context
                            , ILOVService iLOVService
                            , UserManager<DPAUser> userManager) : base(context, iLOVService, userManager)

        {
        }

        public DataEntryWaiver DataEntryWaiver { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            UserWithDepartment = await GetUserWithDepartmentAsync();
            if (id == null)
            {
                return NotFound();
            }

            DataEntryWaiver = await _context.DataEntryWaiver.Include(x => x.CreatedBy)
            .ThenInclude(x => x.Department)
            .Include(x=>x.Purpose)
            .Include(x=>x.PurposeType)
            .Include(x=>x.PurposeSubtype)
            .FirstAsync(m => m.ID == id);

            if (DataEntryWaiver == null)
            {
                return NotFound();
            }
            Invoices = await GetInvoicesAsync(id);
            Attachments = await GetAttachmentsAsync(id);
            return Page();
        }
    }
}