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

namespace DPAWaiver.Pages.Private.ServicePrint
{
    public class CreateModel : BaseWaiverPageModel
    {
        [BindProperty]
        public ServicePrintWaiverView ServicePrintWaiver { get; set; }

        public CreateModel(DPAWaiverIdentityDbContext context, ILOVService iLOVService, UserManager<DPAUser> userManager) : base(context, iLOVService, userManager)
        {
        }

        public async Task<IActionResult> OnGetAsync([FromQuery(Name = "otherFirstName")] string otherFirstName, [FromQuery(Name = "otherLastName")] string otherLastName)
        {
            UserWithDepartment = await GetUserWithDepartmentAsync();

            ServicePrintWaiver = new ServicePrintWaiverView();
            ServicePrintWaiver.OtherFirstName = otherFirstName;
            ServicePrintWaiver.OtherLastName = otherLastName;
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
            var designType = _ILOVService.GetDesignType(ServicePrintWaiver.DesignTypeID);
            ServicePrintWaiver emptyWaiver = new ServicePrintWaiver(UserWithDepartment, null, null, purpose, purposeType, null);

            if (await TryUpdateModelAsync<ServicePrintWaiver>(
               emptyWaiver,
               "ServicePrintwaiver",
               w => w.OtherFirstName,
               w => w.OtherLastName,
               w => w.projectName,
               w => w.SubmittedOn,
               w => w.CostEstimate,
               w => w.ItemDescription,
               w => w.EstimateObtained,
               w => w.PaperStockType,
               w => w.otherPaperStockReason,
               w => w.estimateFile,
               w => w.FinishingType,
               w => w.Reprint,
               w => w.previousPrinter,
               w => w.numberOfOriginals,
               w => w.Quantity,
               w => w.FourColorJob,
               w => w.numberOfInks,
               w => w.projectDueDate,
               w => w.FinishedSize,
               w => w.AdditionalComments
               ))
            {
                _context.ServicePrintWaiver.Add(emptyWaiver);
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