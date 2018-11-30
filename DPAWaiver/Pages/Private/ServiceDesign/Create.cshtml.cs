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

namespace DPAWaiver.Pages.Private.ServiceDesign
{
    public class CreateModel : BaseWaiverPageModel
    {
        [BindProperty]
        public ServiceDesignWaiverView ServiceDesignWaiver { get; set; }

        public CreateModel(DPAWaiverIdentityDbContext context, ILOVService iLOVService, UserManager<DPAUser> userManager) : base(context, iLOVService, userManager)
        {
        }

        public async Task<IActionResult> OnGetAsync([FromQuery(Name = "otherFirstName")] string otherFirstName, [FromQuery(Name = "otherLastName")] string otherLastName)
        {
            UserWithDepartment = await GetUserWithDepartmentAsync();

            ServiceDesignWaiver = new ServiceDesignWaiverView();
            ServiceDesignWaiver.OtherFirstName = otherFirstName;
            ServiceDesignWaiver.OtherLastName = otherLastName;
            return Page();
        }

        public IEnumerable<SelectListItem> designtype => _ILOVService.GetDesignTypesAsSelectListBySortOrder();

        public async Task<IActionResult> OnPostAsync()
        {
            UserWithDepartment = await GetUserWithDepartmentAsync();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var purpose = _ILOVService.getPurposes().Single(x => x.ID == Purposes.Service);
            var purposeType = _ILOVService.getServiceTypes().Single(x => x.ID == ServiceTypes.Design);
            var designType = _ILOVService.GetDesignType(ServiceDesignWaiver.DesignTypeID);
            ServiceDesignWaiver emptyWaiver = new ServiceDesignWaiver(UserWithDepartment, null, null, purpose, purposeType, null);

            if (await TryUpdateModelAsync<ServiceDesignWaiver>(
               emptyWaiver,
               "servicedesignwaiver",
               w => w.OtherFirstName,
               w => w.OtherLastName,
               w => w.ProjectName,
               w => w.SubmittedOn,
               w => w.CostEstimate,
               w => w.EstimatedNumberofHours,
               w => w.DueDate,
               w => w.StartedOn,
               w => w.ItemToBeDesigned,
               w => w.OtherDescription,
               w => w.Status,
               w => w.AdditionalComments
               ))
            {
                _context.ServiceDesignWaiver.Add(emptyWaiver);
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