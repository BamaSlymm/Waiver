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

namespace DPAWaiver.Pages.Private.EquipmentPrintA4
{
    public class CreateModel : BaseWaiverPageModel
    {
        [BindProperty]
        public EquipmentPrintA4WaiverView EquipmentPrintA4Waiver { get; set; }

        public CreateModel(DPAWaiverIdentityDbContext context, ILOVService iLOVService, UserManager<DPAUser> userManager) : base(context, iLOVService, userManager)
        {
        }

        public async Task<IActionResult> OnGetAsync([FromQuery(Name = "otherFirstName")] string otherFirstName, [FromQuery(Name = "otherLastName")] string otherLastName)
        {
            UserWithDepartment = await GetUserWithDepartmentAsync();

            EquipmentPrintA4Waiver = new EquipmentPrintA4WaiverView();
            EquipmentPrintA4Waiver.OtherFirstName = otherFirstName;
            EquipmentPrintA4Waiver.OtherLastName = otherLastName;
            return Page();
        }

        public IEnumerable<SelectListItem> equipmenttype => _ILOVService.GetEquipmentTypesAsSelectListBySortOrder();

        public async Task<IActionResult> OnPostAsync()
        {
            UserWithDepartment = await GetUserWithDepartmentAsync();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var purpose = _ILOVService.getPurposes().Single(x => x.ID == Purposes.Equipment);
            var purposeType = _ILOVService.getEquipmentTypes().Single(x => x.ID == EquipmentTypes.Print);
            EquipmentPrintA4Waiver emptyWaiver = new EquipmentPrintA4Waiver(UserWithDepartment, null, null, purpose, purposeType, null);

            if (await TryUpdateModelAsync<EquipmentPrintA4Waiver>(
               emptyWaiver,
               "EquipmentPrintA4waiver",
               w => w.OtherFirstName,
               w => w.OtherLastName,
               w => w.projectName,
               w => w.SubmittedOn,
               w => w.CostEstimate,
               w => w.printerType,
               w => w.NumberofEquipment,
               w => w.Make,
               w => w.Model,
               w => w.newOrReplace,
               w => w.servicesReceived,
               w => w.currentMonthlyVolume,
               w => w.anticipatedMonthlyVolume,
               w => w.selectionReason,
               w => w.acquisitionType,
               w => w.solicitationSubType,
               w => w.statepriceSubType,
               w => w.monthlyLeaseAmount,
               w => w.yearlyMaintenanceAmount,
               w => w.monthsOfLease,
               w => w.purchaseAmount,
               w => w.tonerCost,
               w => w.usefulLife,
               w => w.complianceDescription,
               w => w.alternativesDescription,
               w => w.justificationDescription,
               w => w.Status,
               w => w.AdditionalComments
               ))
            {
                _context.EquipmentPrintA4Waiver.Add(emptyWaiver);
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