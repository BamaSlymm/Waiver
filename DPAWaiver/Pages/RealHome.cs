using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DPAWaiver.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPAWaiver.Pages
{
    public class RealHomeModel : PageModel
    {
        private readonly SignInManager<DPAUser> _signInManager;
        public RealHomeModel(SignInManager<DPAUser> signInManager)
        {
            _signInManager =signInManager;
        }

        public IActionResult OnGet()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return LocalRedirect(PageList.HomeSignedIn);
            }
            return LocalRedirect(PageList.HomeSignedOut);
        }
    }
}
