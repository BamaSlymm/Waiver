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

namespace DPAWaiver.Pages.Private.SoftwareDataEntry
{
    public class CreateModel : BaseWaiverPageModel
    {
        [BindProperty]
        public SoftwareDataEntryWaiverView SoftwareDataEntryWaiver { get; set; }

        public CreateModel(DPAWaiverIdentityDbContext context, ILOVService iLOVService, UserManager<DPAUser> userManager) : base(context, iLOVService, userManager)
        {
        }

        public async Task<IActionResult> OnGetAsync([FromQuery(Name = "otherFirstName")] string otherFirstName, [FromQuery(Name = "otherLastName")] string otherLastName)
        {
            UserWithDepartment = await GetUserWithDepartmentAsync();

            SoftwareDataEntryWaiver = new SoftwareDataEntryWaiverView();
            SoftwareDataEntryWaiver.OtherFirstName = otherFirstName;
            SoftwareDataEntryWaiver.OtherLastName = otherLastName;
            return Page();
        }

        public IEnumerable<SelectListItem> softwaretype => _ILOVService.GetSoftwareTypesAsSelectListBySortOrder();

        public async Task<IActionResult> OnPostAsync()
        {
            UserWithDepartment = await GetUserWithDepartmentAsync();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var purpose = _ILOVService.getPurposes().Single(x => x.ID == Purposes.Software);
            var purposeType = _ILOVService.getSoftwareTypes().Single(x => x.ID == SoftwareTypes.DataEntry);
            SoftwareDataEntryWaiver emptyWaiver = new SoftwareDataEntryWaiver(UserWithDepartment, null, null, purpose, purposeType, null);

            if (await TryUpdateModelAsync<SoftwareDataEntryWaiver>(
               emptyWaiver,
               "SoftwareDataEntrywaiver",
               w => w.OtherFirstName,
               w => w.OtherLastName,
               w => w.projectName,
               w => w.SubmittedOn,
               w => w.CostEstimate,
               w => w.typeOfSoftware,
                w => w.numberOfLicenses,
                w => w.newOrReplace,
                w => w.softwareVersion,
                w => w.costOfPresentService,        
                w => w.currentMonthlyVolume,
                w => w.firstYearVolume,
                w => w.secondYearVolume,
                w => w.thirdYearVolume,
                w => w.fourthYearVolume,
                w => w.fifthYearVolume,
                w => w.softwareProvider,
                w => w.softwareVolume,
                w => w.solicitationSubType,
                w => w.purchaseAmount,
                w => w.selectionReason,
                w => w.expectedDuration,
                w => w.solicitationSubType,
                w => w.statepriceSubType,
                w => w.purchaseAmount,
                w => w.annualMaintenanceCost,
                w => w.suppliesCost,
                w => w.operatorClassification,
                w => w.Grade,
                w => w.numberOfFTE,
                w => w.numberOfLicenses,
                w => w.hoursPerFTEPerWeek,
                w => w.annualMaintenanceCost,
                w => w.operatorClassification,
                w => w.hoursPerFTEPerWeek,
                w => w.totalWeeklySalary,
                w => w.totalSpaceInSQFT,
                w => w.monthlySupervisionAmount,
                w => w.monthlySupervisionAmount,
                w => w.monthlyManagementAmount,
                w => w.monthlyUtilitiesAmount,
                w => w.monthlyIndirectCosts,
                w => w.monthlyOverheadCosts,
                w => w.alternativesConsidered,
                w => w.Status,
                w => w.AdditionalComments
               ))
            {
                _context.SoftwareDataEntryWaiver.Add(emptyWaiver);
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