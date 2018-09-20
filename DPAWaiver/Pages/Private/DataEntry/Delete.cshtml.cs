using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DPAWaiver.Areas.Identity.Data;
using DPAWaiver.Models.Waivers;
using DPAWaiver.Models;
using Microsoft.AspNetCore.Identity;

namespace DPAWaiver.Pages.Private.DataEntry
{
    public class DeleteModel : BaseWaiverModel
    {

        public DeleteModel(DPAWaiver.Areas.Identity.Data.DPAWaiverIdentityDbContext context
        , ILOVService iLOVService
                            , UserManager<DPAUser> userManager) : base(context, iLOVService, userManager)
        {
        }

        [BindProperty]
        public DataEntryWaiver DataEntryWaiver { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DataEntryWaiver = await _context.DataEntryWaiver.FirstOrDefaultAsync(m => m.ID == id);

            if (DataEntryWaiver == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DataEntryWaiver = await _context.DataEntryWaiver.FindAsync(id);

            if (DataEntryWaiver != null)
            {
                _context.DataEntryWaiver.Remove(DataEntryWaiver);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
