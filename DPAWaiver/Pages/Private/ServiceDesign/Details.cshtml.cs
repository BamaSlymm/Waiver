using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DPAWaiver.Areas.Identity.Data;
using DPAWaiver.Models.Waivers;

namespace DPAWaiver.Pages.Private.ServiceDesign
{
    public class DetailsModel : PageModel
    {
        private readonly DPAWaiver.Areas.Identity.Data.DPAWaiverIdentityDbContext _context;

        public DetailsModel(DPAWaiver.Areas.Identity.Data.DPAWaiverIdentityDbContext context)
        {
            _context = context;
        }

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
    }
}
