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

namespace DPAWaiver.Pages.Private.ServiceDesign
{
    public class EditModel : PageModel
    {
        private readonly DPAWaiver.Areas.Identity.Data.DPAWaiverIdentityDbContext _context;

        public EditModel(DPAWaiver.Areas.Identity.Data.DPAWaiverIdentityDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ServiceDesignWaiver ServiceDesignWaiver { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ServiceDesignWaiver = await _context.ServiceDesignWaiver.FirstOrDefaultAsync(m => m.ID == id);

            if (ServiceDesignWaiver == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ServiceDesignWaiver).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceDesignWaiverExists(ServiceDesignWaiver.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ServiceDesignWaiverExists(Guid id)
        {
            return _context.ServiceDesignWaiver.Any(e => e.ID == id);
        }
    }
}
