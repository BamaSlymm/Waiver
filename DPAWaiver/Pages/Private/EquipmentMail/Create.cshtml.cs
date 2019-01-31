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

namespace DPAWaiver.Pages.Private.EquipmentMail
{
    public class CreateModel : BaseWaiverPageModel
    {
        [BindProperty]
        public EquipmentMailWaiverView EquipmentMailWaiver { get; set; }

        public CreateModel(DPAWaiverIdentityDbContext context, ILOVService iLOVService, UserManager<DPAUser> userManager) : base(context, iLOVService, userManager)
        {
        }

        public async Task<IActionResult> OnGetAsync([FromQuery(Name = "otherFirstName")] string otherFirstName, [FromQuery(Name = "otherLastName")] string otherLastName)
        {
            UserWithDepartment = await GetUserWithDepartmentAsync();

            EquipmentMailWaiver = new EquipmentMailWaiverView();
            EquipmentMailWaiver.OtherFirstName = otherFirstName;
            EquipmentMailWaiver.OtherLastName = otherLastName;
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
            var designType = _ILOVService.GetDesignType(EquipmentMailWaiver.DesignTypeID);
            EquipmentMailWaiver emptyWaiver = new EquipmentMailWaiver(UserWithDepartment, null, null, purpose, purposeType, null);

            if (await TryUpdateModelAsync<EquipmentMailWaiver>(
               emptyWaiver,
               "EquipmentMailwaiver",
               w => w.OtherFirstName,
               w => w.OtherLastName,
               w => w.projectName,
               w => w.SubmittedOn,
               w => w.CostEstimate,
               w => w.justificationDescription,
               w => w.equipmentDescription,
               w => w.NumberofEquipment,
               w => w.newOrReplace,
               w => w.servicesReceived,
               w => w.monthlyLeaseAmount,
               w => w.monthlyVolume,
               w => w.firstYearVolume,
               w => w.secondYearVolume,
               w => w.thirdYearVolume,
               w => w.fourthYearVolume,
               w => w.fifthYearVolume,
               w => w.Make,
               w => w.Model,
               w => w.selectionReason,
               w => w.usefulLife,
               w => w.purchaseAmount,
               w => w.monthlyLease,
               w => w.monthsRental,
               w => w.acquisitionType,
               w => w.solicitationSubType,
               w => w.statepriceSubType,
               w => w.totalLeaseAmount,
               w => w.EstimatedNumberofFTE,
               w => w.estimatedNumberofHoursPerFTE,
               w => w.weeklySalaryCost,
               w => w.totalSpaceRequired,
               w => w.monthlySupervisionAmount,
               w => w.monthlyManagementAmount,
               w => w.monthlyUtilitiesAmount,
               w => w.monthlyIndirectCosts,
               w => w.miscellaneousCosts,
               w => w.overheadCostDescription,
               w => w.overheadDescription,
               w => w.Status,
               w => w.AdditionalComments
               ))
            {
                _context.EquipmentMailWaiver.Add(emptyWaiver);
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