using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DPAWaiver.Areas.Identity.Data;
using DPAWaiver.Models.Waivers;

namespace DPAWaiver.Pages.Private.ServiceMicrofilmConversion
{
    public class DeleteModel : PageModel
    {
        private readonly DPAWaiver.Areas.Identity.Data.DPAWaiverIdentityDbContext _context;

        public DeleteModel(DPAWaiver.Areas.Identity.Data.DPAWaiverIdentityDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ServiceMicrofilmConversionWaiver ServiceMicrofilmConversionWaiver { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ServiceMicrofilmConversionWaiver = await _context.ServiceMicrofilmConversionWaiver.FirstOrDefaultAsync(m => m.ID == id);

            if (ServiceMicrofilmConversionWaiver == null)
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

            ServiceMicrofilmConversionWaiver = await _context.ServiceMicrofilmConversionWaiver.FindAsync(id);

            if (ServiceMicrofilmConversionWaiver != null)
            {
                _context.ServiceMicrofilmConversionWaiver.Remove(ServiceMicrofilmConversionWaiver);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
