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
using DPAWaiver.Models;
using Microsoft.AspNetCore.Authorization;

namespace DPAWaiver.Pages.Private.Review
{
    public class ReviewListModel : BaseWaiverPageModel
    {
        public IList<BaseWaiver> BaseWaiver { get; set; }

        public ReviewListModel(DPAWaiverIdentityDbContext context,
                              ILOVService iLOVService,
                              UserManager<DPAUser> userManager) : base(context, iLOVService, userManager)
        {
        }

        public async Task<IActionResult> OnGetAsync()
        {
            UserWithDepartment = await GetUserWithDepartmentAsync();
            BaseWaiver = await _context.BaseWaivers.
                Include(x => x.Purpose).Include(x => x.PurposeType).
                Include(x => x.CreatedBy).
                Where(x => x.Status == WaiverStatus.Pending || x.Status == WaiverStatus.UnderReview).
                ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnGetAsyncWaiverDetail(Guid? id)
        {
            UserWithDepartment = await GetUserWithDepartmentAsync();
            var baseWaiver = await _context.BaseWaivers.
                FirstAsync(x => x.ID == id);
            if (baseWaiver is DataEntryWaiver)
            {
                return RedirectToPage(PageList.ServiceDataEntryDetails, new { id = id });
            }
            return Page();
        }

        public async Task<IActionResult> OnPostUnderReview(Guid? id, string UnderReviewReason)
        {
            UserWithDepartment = await GetUserWithDepartmentAsync();
            var baseWaiver = await _context.BaseWaivers.
                FirstAsync(x => x.ID == id);
            if (baseWaiver.Status == WaiverStatus.Accepted)
            {
                return NotFound();
            }
            var baseWaiverAction = new BaseWaiverAction(baseWaiver, UserWithDepartment, 
            WaiverActions.UnderReview, baseWaiver, UnderReviewReason);
            _context.BaseWaiverActions.Add(baseWaiverAction);
            baseWaiver.Status = WaiverStatus.UnderReview ;
            await _context.SaveChangesAsync();
            return RedirectToPage(PageList.ReviewList);
        }

    }
}
