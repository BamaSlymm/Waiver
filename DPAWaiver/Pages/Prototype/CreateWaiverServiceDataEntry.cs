using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DPAWaiver.Areas.Identity.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DPAWaiver.Pages
{
    public class CreateWaiverServiceDataEntryModel : PageModel
    {

        private Task<DPAUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        public DPAUser signedInUser {get;set;}

       private readonly UserManager<DPAUser> _userManager;

        public CreateWaiverServiceDataEntryModel(UserManager<DPAUser> userManager)
        {
            _userManager = userManager;
            
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            signedInUser = _userManager.Users.Include(x=>x.Department).Single(x=>x.Id == user.Id);
            return Page();
        }
    }
}
