using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DPAWaiver.Areas.Identity.Data;
using DPAWaiver.Models.Waivers;

namespace DPAWaiver.Pages.Private.EquipmentPrintA3
{
    public class DeleteModel : PageModel
    {
        private readonly DPAWaiver.Areas.Identity.Data.DPAWaiverIdentityDbContext _context;

        public DeleteModel(DPAWaiver.Areas.Identity.Data.DPAWaiverIdentityDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EquipmentPrintA3Waiver EquipmentPrintA3Waiver { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EquipmentPrintA3Waiver = await _context.EquipmentPrintA3Waiver.FirstOrDefaultAsync(m => m.ID == id);

            if (EquipmentPrintA3Waiver == null)
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

            EquipmentPrintA3Waiver = await _context.EquipmentPrintA3Waiver.FindAsync(id);

            if (EquipmentPrintA3Waiver != null)
            {
                _context.EquipmentPrintA3Waiver.Remove(EquipmentPrintA3Waiver);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
