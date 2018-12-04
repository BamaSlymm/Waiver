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

namespace DPAWaiver.Pages.Private.SoftwarePrint
{
    public class CreateModel : BaseWaiverPageModel
    {
        [BindProperty]
        public SoftwarePrintWaiverView SoftwarePrintWaiver { get; set; }

        public CreateModel(DPAWaiverIdentityDbContext context, ILOVService iLOVService, UserManager<DPAUser> userManager) : base(context, iLOVService, userManager)
        {
        }

        public async Task<IActionResult> OnGetAsync([FromQuery(Name = "otherFirstName")] string otherFirstName, [FromQuery(Name = "otherLastName")] string otherLastName)
        {
            UserWithDepartment = await GetUserWithDepartmentAsync();

            SoftwarePrintWaiver = new SoftwarePrintWaiverView();
            SoftwarePrintWaiver.OtherFirstName = otherFirstName;
            SoftwarePrintWaiver.OtherLastName = otherLastName;
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
            var designType = _ILOVService.GetDesignType(SoftwarePrintWaiver.DesignTypeID);
            SoftwarePrintWaiver emptyWaiver = new SoftwarePrintWaiver(UserWithDepartment, null, null, purpose, purposeType, null);

            if (await TryUpdateModelAsync<SoftwarePrintWaiver>(
               emptyWaiver,
               "SoftwarePrintwaiver",
               w => w.OtherFirstName,
               w => w.OtherLastName,
               w => w.ProjectName,
               w => w.SubmittedOn,
               w => w.CostEstimate,
               w => w.typeOfSoftware,
                w => w.numberOfLicenses,
                w => w.newOrReplace,
				w => w.costOfPresentService,
				w => w.servicesReceived,
				w => w.softwareProvider,
                w => w.softwareVersion,
                w => w.selectionReason,
                w => w.expectedDuration,
                w => w.acquisitionType,
                w => w.subscriptionOrPurchase,
				w => w.purchaseAmount,
                w => w.monthlySubscriptionAmount,
                w => w.numberOfMonths,
                w => w.annualMaintenanceCost,
                w => w.operatorClassification,
                w => w.Grade,
                w => w.numberOfFTE,
                w => w.hoursPerFTEPerWeek,
				w => w.totalWeeklySalary,
                w => w.monthlySupervisionAmount,
                w => w.monthlyManagementAmount,
                w => w.justificationDescription,
                w => w.alternativesConsidered,
                w => w.Status,
                w => w.additionalComments
               ))
            {
                _context.SoftwarePrintWaiver.Add(emptyWaiver);
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