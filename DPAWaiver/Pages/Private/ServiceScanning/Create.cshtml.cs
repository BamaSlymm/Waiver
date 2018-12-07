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

namespace DPAWaiver.Pages.Private.ServiceScanning
{
    public class CreateModel : BaseWaiverPageModel
    {
        [BindProperty]
        public ServiceScanningWaiverView ServiceScanningWaiver { get; set; }

        public CreateModel(DPAWaiverIdentityDbContext context, ILOVService iLOVService, UserManager<DPAUser> userManager) : base(context, iLOVService, userManager)
        {
        }

        public async Task<IActionResult> OnGetAsync([FromQuery(Name = "otherFirstName")] string otherFirstName, [FromQuery(Name = "otherLastName")] string otherLastName)
        {
            UserWithDepartment = await GetUserWithDepartmentAsync();

            ServiceScanningWaiver = new ServiceScanningWaiverView();
            ServiceScanningWaiver.OtherFirstName = otherFirstName;
            ServiceScanningWaiver.OtherLastName = otherLastName;
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
            var designType = _ILOVService.GetDesignType(ServiceScanningWaiver.DesignTypeID);
            ServiceScanningWaiver emptyWaiver = new ServiceScanningWaiver(UserWithDepartment, null, null, purpose, purposeType, null);

            if (await TryUpdateModelAsync<ServiceScanningWaiver>(
               emptyWaiver,
               "ServiceScanningwaiver",
               w => w.OtherFirstName,
               w => w.OtherLastName,
               w => w.projectName,
               w => w.SubmittedOn,
               w => w.CostEstimate,
               w => w.workflowDescription,
               w => w.estimatedNumberofDocuments,
               w => w.EstimatedNumberofHours,
               w => w.indexingNeeded,
               w => w.estimatedNumberOfFields,
               w => w.textSearchablePDF,
               w => w.imageDPI,
               w => w.colorFormat,
               w => w.imageDelivery,
               w => w.otherImageDelivery,
               w => w.emailOtherImageDelivery,
               w => w.systemRequirements,
               w => w.alternativeMethods,
               w => w.scanningInternally,
               w => w.importConversion,
               w => w.notInHouseReason,
               w => w.AdditionalComments
               ))
            {
                _context.ServiceScanningWaiver.Add(emptyWaiver);
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