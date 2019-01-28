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
using DPAWaiver.Pages.Private;
using DPAWaiver.Models.WaiverSelection;

namespace DPAWaiver.Pages.Private.DataEntry
{
    public class CreateModel : BaseWaiverPageModel
    {

        [BindProperty]
        public DataEntryWaiverView DataEntryWaiver { get; set; }

        public CreateModel(DPAWaiver.Areas.Identity.Data.DPAWaiverIdentityDbContext context
                            , ILOVService iLOVService
                            , UserManager<DPAUser> userManager): base(context, iLOVService, userManager)
        {
        }

        public async Task<IActionResult> OnGetAsync([FromQuery(Name = "otherFirstName")] string otherFirstName, [FromQuery(Name = "otherLastName")] string otherLastName)
        {
            UserWithDepartment = await GetUserWithDepartmentAsync();

            DataEntryWaiver = new DataEntryWaiverView();
            DataEntryWaiver.OtherFirstName = otherFirstName;
            DataEntryWaiver.OtherLastName = otherLastName;
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
            var purposeType = _ILOVService.getServiceTypes().Single(x => x.ID == ServiceTypes.DataEntry);
            DataEntryWaiver emptyWaiver = new DataEntryWaiver(UserWithDepartment, null, null, purpose, purposeType, null);

            if (await TryUpdateModelAsync<DataEntryWaiver>(
                emptyWaiver,
                "dataentrywaiver",
                w => w.OtherFirstName,
                w => w.OtherLastName,
                w => w.projectName,
                w => w.SubmittedOn,
                w => w.CostEstimate,
                w => w.WorkflowDescription,
                w => w.EstimatedNumberofFTE,
                w => w.EstimatedNumberofHours,
                w => w.EstimatedNumberofDocuments,
                w => w.EstimatedNumberofFields,
                w => w.SystemRequirementsDescription,
                w => w.KeyedIntoSystem,
                w => w.ReasonForNotKeyedIntoSystem,
                w => w.ReasonDataEntryCenter,
                w => w.AdditionalComments,
                w => w.Status
                ))
            {
                _context.DataEntryWaiver.Add(emptyWaiver);
                BaseWaiverAction baseWaiverAction = new BaseWaiverAction(emptyWaiver, UserWithDepartment,
                                                WaiverActions.Created, emptyWaiver);
                _context.BaseWaiverActions.Add(baseWaiverAction);
                await _context.SaveChangesAsync();
                return RedirectToPage(PageList.Confirmation, new {id = emptyWaiver.ID});
            }
            return null;
        }
    }
}