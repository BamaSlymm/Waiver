using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DPAWaiver.Areas.Identity.Data;
using DPAWaiver.Models.Waivers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DPAWaiver.Models;
using DPAWaiver.Models.WaiverSelection;

namespace DPAWaiver.Pages.Private
{
    public class BaseWaiverModel : PageModel
    {
        public readonly DPAWaiver.Areas.Identity.Data.DPAWaiverIdentityDbContext _context;

        public readonly UserManager<DPAUser> _userManager;

        public readonly ILOVService _ILOVService;

        //        [BindProperty]
        public DPAUser UserWithDepartment { get; set; }

        public BaseWaiverModel(DPAWaiver.Areas.Identity.Data.DPAWaiverIdentityDbContext context
                            , ILOVService iLOVService
                            , UserManager<DPAUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _ILOVService = iLOVService;
        }

        public async Task<DPAUser> GetUserWithDepartment(UserManager<DPAUser> userManager)
        {
            var userId = userManager.GetUserId(User);
            if (userId != null)
            {
                return await userManager.Users.Include(x => x.Department).SingleAsync(x => x.Id.ToString() == userId);
            }
            return null;
        }

    }
}