using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DPAWaiver.Areas.Identity.Data;
using DPAWaiver.Models.Waivers;

namespace DPAWaiver.Pages.Private.SoftwareDesign
{
    public class IndexModel : PageModel
    {
        private readonly DPAWaiver.Areas.Identity.Data.DPAWaiverIdentityDbContext _context;

        public IndexModel(DPAWaiver.Areas.Identity.Data.DPAWaiverIdentityDbContext context)
        {
            _context = context;
        }

        public IList<SoftwareDesignWaiver> SoftwareDesignWaiver { get;set; }

        public async Task OnGetAsync()
        {
            SoftwareDesignWaiver = await _context.SoftwareDesignWaiver.ToListAsync();
        }
    }
}
