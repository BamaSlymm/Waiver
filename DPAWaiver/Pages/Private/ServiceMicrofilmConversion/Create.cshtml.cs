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

namespace DPAWaiver.Pages.Private.ServiceMicrofilmConversion
{
    public class CreateModel : BaseWaiverPageModel
    {
        [BindProperty]
        public ServiceMicrofilmConversionWaiverView ServiceMicrofilmConversionWaiver { get; set; }

        public CreateModel(DPAWaiverIdentityDbContext context, ILOVService iLOVService, UserManager<DPAUser> userManager) : base(context, iLOVService, userManager)
        {
        }

        public async Task<IActionResult> OnGetAsync([FromQuery(Name = "otherFirstName")] string otherFirstName, [FromQuery(Name = "otherLastName")] string otherLastName)
        {
            UserWithDepartment = await GetUserWithDepartmentAsync();

            ServiceMicrofilmConversionWaiver = new ServiceMicrofilmConversionWaiverView();
            ServiceMicrofilmConversionWaiver.OtherFirstName = otherFirstName;
            ServiceMicrofilmConversionWaiver.OtherLastName = otherLastName;
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
            var purposeType = _ILOVService.getServiceTypes().Single(x => x.ID == ServiceTypes.Microfilm);
            ServiceMicrofilmConversionWaiver emptyWaiver = new ServiceMicrofilmConversionWaiver(UserWithDepartment, null, null, purpose, purposeType, null);

            if (await TryUpdateModelAsync<ServiceMicrofilmConversionWaiver>(
               emptyWaiver,
               "ServiceMicrofilmConversionwaiver",
               w => w.OtherFirstName,
               w => w.OtherLastName,
               w => w.projectName,
               w => w.SubmittedOn,
               w => w.CostEstimate,
               w => w.WorkflowDescription,
               w => w.typeofFilm,
               w => w.NumberofRolls,
               w => w.numberOfCards,
               w => w.EstimatedNumberOfHours,
               w => w.EstimatedNumberofFTE,
               w => w.indexingNeeded,
               w => w.textSearchablePDF,
               w => w.EstimatedNumberOfFields,
               w => w.imageDelivery,
               w => w.otherImageDelivery,
               w => w.emailOtherImageDelivery,
               w => w.systemRequirements,
               w => w.keyedIntoSystem,
               w => w.ReasonForNotKeyedIntoSystem,
               w => w.doneInHouse,
               w => w.NotInHouseReason,
               w => w.AdditionalComments
               ))
            {
                _context.ServiceMicrofilmConversionWaiver.Add(emptyWaiver);
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