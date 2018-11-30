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

namespace DPAWaiver.Pages.Private.EquipmentPrintLargeFormat
{
    public class CreateModel : BaseWaiverPageModel
    {
        [BindProperty]
        public EquipmentPrintLargeFormatWaiverView EquipmentPrintLargeFormatWaiver { get; set; }

        public CreateModel(DPAWaiverIdentityDbContext context, ILOVService iLOVService, UserManager<DPAUser> userManager) : base(context, iLOVService, userManager)
        {
        }

        public async Task<IActionResult> OnGetAsync([FromQuery(Name = "otherFirstName")] string otherFirstName, [FromQuery(Name = "otherLastName")] string otherLastName)
        {
            UserWithDepartment = await GetUserWithDepartmentAsync();

            EquipmentPrintLargeFormatWaiver = new EquipmentPrintLargeFormatWaiverView();
            EquipmentPrintLargeFormatWaiver.OtherFirstName = otherFirstName;
            EquipmentPrintLargeFormatWaiver.OtherLastName = otherLastName;
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
            var designType = _ILOVService.GetDesignType(EquipmentPrintLargeFormatWaiver.DesignTypeID);
            EquipmentPrintLargeFormatWaiver emptyWaiver = new EquipmentPrintLargeFormatWaiver(UserWithDepartment, null, null, purpose, purposeType, null);

            if (await TryUpdateModelAsync<EquipmentPrintLargeFormatWaiver>(
               emptyWaiver,
               "EquipmentPrintLargeFormatwaiver",
               w => w.OtherFirstName,
               w => w.OtherLastName,
               w => w.ProjectName,
               w => w.SubmittedOn,
               w => w.CostEstimate,
               w => w.equipmentType,
               w => w.numberofEquipment,
               w => w.Make,
               w => w.Model,
               w => w.newOrReplace,
               w => w.servicesReceived,
               w => w.solicitationSubType,
               w => w.purchaseAmount,
               w => w.selectionReason,
               w => w.leaseDuration,
               w => w.numberOfMonths,
               w => w.monthlyLeaseAmount,
               w => w.makeAndModel,
               w => w.estimatedCost,
               w => w.productionCapacity,
               w => w.acquisitionType,
               w => w.leaseOrPurchase,
               w => w.numberOfYears,
               w => w.alternativesDescription,
               w => w.justificationDescription,
               w => w.Status,
               w => w.additionalComments
               ))
            {
                _context.EquipmentPrintLargeFormatWaiver.Add(emptyWaiver);
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