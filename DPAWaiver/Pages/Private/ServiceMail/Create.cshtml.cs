using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DPAWaiver.Areas.Identity.Data;
using DPAWaiver.Models.Waivers;
using DPAWaiver.Models;
using Microsoft.AspNetCore.Identity;
using DPAWaiver.Models.WaiverSelection;

namespace DPAWaiver.Pages.Private.ServiceMail
{
    public class CreateModel : BaseWaiverPageModel
    {
        [BindProperty]
        public ServiceMailWaiverView ServiceMailWaiver { get; set; }

        public CreateModel(DPAWaiverIdentityDbContext context, ILOVService iLOVService, UserManager<DPAUser> userManager) : base(context, iLOVService, userManager)
        {
        }

        public async Task<IActionResult> OnGetAsync([FromQuery(Name = "otherFirstName")] string otherFirstName, [FromQuery(Name = "otherLastName")] string otherLastName)
        {
            UserWithDepartment = await GetUserWithDepartmentAsync();

            ServiceMailWaiver = new ServiceMailWaiverView();
            ServiceMailWaiver.OtherFirstName = otherFirstName;
            ServiceMailWaiver.OtherLastName = otherLastName;
            ServiceMailWaiver.MailingDate = DateTime.Today;
            return Page();
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            UserWithDepartment = await GetUserWithDepartmentAsync();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var purpose = _ILOVService.getPurposes().Single(x => x.ID == Purposes.Service);
            var purposeType = _ILOVService.getServiceTypes().Single(x => x.ID == ServiceTypes.Mail);
            ServiceMailWaiver emptyWaiver = new ServiceMailWaiver(UserWithDepartment, null, null, purpose, purposeType, null);

            if (await TryUpdateModelAsync<ServiceMailWaiver>(
               emptyWaiver,
               "ServiceMailwaiver",
               w => w.OtherFirstName,
               w => w.OtherLastName,
               w => w.projectName,
               w => w.SubmittedOn,
               w => w.CostEstimate,
               w => w.JobDescription,
               w => w.NumberofPackets,
               w => w.MailingDate,
               w => w.MailPermit,
               w => w.MailRate,
               w => w.TypeofStock,
               w => w.SubmittedOn,
               w => w.ItemDescription,
               w => w.OtherDescription,
               w => w.Status,
               w => w.AdditionalComments,
               w => w.ID,
               w => w.CreatedOn,
               w => w.approvedOn
               ))
            {
                _context.ServiceMailWaiver.Add(emptyWaiver);
                BaseWaiverAction baseWaiverAction = new BaseWaiverAction(emptyWaiver, UserWithDepartment,
                                                WaiverActions.Created, emptyWaiver);
                _context.BaseWaiverActions.Add(baseWaiverAction);
                await _context.SaveChangesAsync();
                return RedirectToPage(PageList.Confirmation, new { id = emptyWaiver.ID });
            }

            return null;
        }
    }
}