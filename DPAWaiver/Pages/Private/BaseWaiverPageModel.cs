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
    public class BaseWaiverPageModel : PageModel
    {
        public readonly DPAWaiver.Areas.Identity.Data.DPAWaiverIdentityDbContext _context;

        public readonly UserManager<DPAUser> _userManager;

        public readonly ILOVService _ILOVService;

        //        [BindProperty]
        public DPAUser UserWithDepartment { get; set; }

        public List<BaseWaiverInvoice> Invoices { get; set; }

        public List<BaseWaiverAttachment> Attachments { get; set; }

        public List<BaseWaiverAction> Actions { get; set; }

        public BaseWaiverPageModel(DPAWaiver.Areas.Identity.Data.DPAWaiverIdentityDbContext context
                            , ILOVService iLOVService
                            , UserManager<DPAUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _ILOVService = iLOVService;
        }

        public async Task<DPAUser> GetUserWithDepartmentAsync()
        {
            var userId = _userManager.GetUserId(User);
            if (userId != null)
            {
                return await _userManager.Users.Include(x => x.Department).SingleAsync(x => x.Id.ToString() == userId);
            }
            return null;
        }

        public async Task<List<BaseWaiverAttachment>> GetAttachmentsAsync(Guid? id)
        {
            return await _context.BaseWaiverAttachments.Include(x=>x.CreatedBy).Where(x => x.BaseWaiver.ID == id).ToListAsync();
        }

        public async Task<List<BaseWaiverInvoice>> GetInvoicesAsync(Guid? id)
        {
            return await _context.BaseWaiverInvoice.Include(x=>x.CreatedBy).Where(x => x.BaseWaiver.ID == id).ToListAsync();
        }

        public async Task<List<BaseWaiverAction>> GetActionsAsync(Guid? id)
        {
            return await _context.BaseWaiverActions.Include(x=>x.CreatedBy).Where(x => x.BaseWaiver.ID == id).ToListAsync();
        }

    }
}