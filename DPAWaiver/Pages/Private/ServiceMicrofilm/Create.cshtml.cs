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

namespace DPAWaiver.Pages.Private.ServiceMicrofilm
{
    public class CreateModel : BaseWaiverPageModel
    {
        private readonly ILOVService _ILOVService;
        
        [BindProperty]
        public ServiceMicrofilmWaiverView ServiceMicrofilmWaiver { get; set; }

        public CreateModel(DPAWaiverIdentityDbContext context, ILOVService iLOVService, UserManager<DPAUser> userManager) : base(context, iLOVService, userManager)
        {
            _ILOVService = iLOVService;
        }

        public IEnumerable<SelectListItem> MicrofilmOutputTypes => _ILOVService.GetMicrofilmOutputTypeAsSelectListBySortOrder();
        
        public async Task<IActionResult> OnGetAsync([FromQuery(Name = "otherFirstName")] string otherFirstName, [FromQuery(Name = "otherLastName")] string otherLastName)
        {
            UserWithDepartment = await GetUserWithDepartmentAsync();

            ServiceMicrofilmWaiver = new ServiceMicrofilmWaiverView();
            ServiceMicrofilmWaiver.OtherFirstName = otherFirstName;
            ServiceMicrofilmWaiver.OtherLastName = otherLastName;
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
            var designType = _ILOVService.GetDesignType(ServiceMicrofilmWaiver.DesignTypeID);
            ServiceMicrofilmWaiver emptyWaiver = new ServiceMicrofilmWaiver(UserWithDepartment, null, null, purpose, purposeType, null);

            if (await TryUpdateModelAsync<ServiceMicrofilmWaiver>(
               emptyWaiver,
               "ServiceMicrofilmwaiver",
               w => w.OtherFirstName,
               w => w.OtherLastName,
               w => w.projectName,
               w => w.SubmittedOn,
               w => w.CostEstimate,
               w => w.ItemDescription,
               w => w.MicrofilmDuplication,
               w => w.RequestedRolls,
               w => w.EstimatedNumberofFTE,
               w => w.EstimatedNumberofHours,
               w => w.outputType,
               w => w.RollsLabeled,
               w => w.duplicateRolls,
               w => w.NumberofRolls,
               w => w.JobRequirements,
               w => w.AlternativeMethods,
               w => w.NotInHouseReason,
               w => w.AdditionalComments
               ))
            {
                _context.ServiceMicrofilmWaiver.Add(emptyWaiver);
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