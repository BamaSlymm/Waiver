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

namespace DPAWaiver.Pages.Private
{
    public class WaiverListModel : PageModel
    {
        private readonly DPAWaiver.Areas.Identity.Data.DPAWaiverIdentityDbContext _context;
        private readonly UserManager<DPAUser> _userManager;

        public IList<BaseWaiver> BaseWaiver { get; set; }

        public DPAUser UserWithDepartment { get; set; }

        public WaiverListModel(DPAWaiver.Areas.Identity.Data.DPAWaiverIdentityDbContext context
                               , UserManager<DPAUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private async Task<IActionResult> GetUserWithDepartment()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("../Index");
            }

            UserWithDepartment = _userManager.Users.Include(x => x.Department).Single(x => x.Id == user.Id);
            return null;
        }



        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await GetUserWithDepartment();
            if (result != null)
            {
                return result;
            }

            BaseWaiver = await _context.BaseWaivers.
                Include(x => x.Purpose).Include(x => x.PurposeType).
                Where(x => x.Status == WaiverStatus.Pending).
                Where(x => x.CreatedBy == user).ToListAsync();
            return Page();
        }
    }
}
