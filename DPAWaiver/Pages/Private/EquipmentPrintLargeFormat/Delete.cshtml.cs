using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DPAWaiver.Areas.Identity.Data;
using DPAWaiver.Models.Waivers;

namespace DPAWaiver.Pages.Private.EquipmentPrintLargeFormat
{
    public class DeleteModel : PageModel
    {
        private readonly DPAWaiver.Areas.Identity.Data.DPAWaiverIdentityDbContext _context;

        public DeleteModel(DPAWaiver.Areas.Identity.Data.DPAWaiverIdentityDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EquipmentPrintLargeFormatWaiver EquipmentPrintLargeFormatWaiver { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EquipmentPrintLargeFormatWaiver = await _context.EquipmentPrintLargeFormatWaiver.FirstOrDefaultAsync(m => m.ID == id);

            if (EquipmentPrintLargeFormatWaiver == null)
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

            EquipmentPrintLargeFormatWaiver = await _context.EquipmentPrintLargeFormatWaiver.FindAsync(id);

            if (EquipmentPrintLargeFormatWaiver != null)
            {
                _context.EquipmentPrintLargeFormatWaiver.Remove(EquipmentPrintLargeFormatWaiver);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
