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

namespace DPAWaiver.Pages.Private.EquipmentPrint
{
    public class CreateModel : BaseWaiverPageModel
    {
        [BindProperty]
        public EquipmentPrintWaiverView EquipmentPrintWaiver { get; set; }

        public CreateModel(DPAWaiverIdentityDbContext context, ILOVService iLOVService, UserManager<DPAUser> userManager) : base(context, iLOVService, userManager)
        {
        }

        public async Task<IActionResult> OnGetAsync([FromQuery(Name = "otherFirstName")] string otherFirstName, [FromQuery(Name = "otherLastName")] string otherLastName)
        {
            UserWithDepartment = await GetUserWithDepartmentAsync();

            EquipmentPrintWaiver = new EquipmentPrintWaiverView();
            EquipmentPrintWaiver.OtherFirstName = otherFirstName;
            EquipmentPrintWaiver.OtherLastName = otherLastName;
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
            var designType = _ILOVService.GetDesignType(EquipmentPrintWaiver.DesignTypeID);
            EquipmentPrintWaiver emptyWaiver = new EquipmentPrintWaiver(UserWithDepartment, null, null, purpose, purposeType, null);

            if (await TryUpdateModelAsync<EquipmentPrintWaiver>(
               emptyWaiver,
               "EquipmentPrintwaiver",
               w => w.OtherFirstName,
               w => w.OtherLastName,
               w => w.projectName,
               w => w.SubmittedOn,
               w => w.CostEstimate,
               w => w.printerType,
               w => w.catalogLink,
               w => w.Make,
               w => w.Model,
               w => w.forGroupOfIndividuals,
               w => w.selectionReason,
               w => w.acquisitionType,
               w => w.solicitationSubType,
               w => w.statepriceSubType,
               w => w.numberofMonths,
               w => w.monthlyLeaseAmount,
               w => w.servicesReceived,
               w => w.numberOfEquipment,
               w => w.purchaseAmount,
               w => w.agreementOrWarrantyCost,
               w => w.printerReplacementCycle,
               w => w.otherReplacementCycle,
               w => w.monthlyCostWithoutToner,
               w => w.monthlyMonochromeVolume,
               w => w.monthlyColorVolume,
               w => w.blackTonerCost,
               w => w.pageYieldForBlackToner,
               w => w.blackInkCostPerPage,
               w => w.cyanTonerCost,
               w => w.pageYieldForCyanToner,
               w => w.cyanInkCostPerPage,
               w => w.MagentaTonerCost,
               w => w.pageYieldForMagentaToner,
               w => w.MagentaInkCostPerPage,
               w => w.YellowTonerCost,
               w => w.pageYieldForYellowToner,
               w => w.YellowInkCostPerPage,
               w => w.totalInkCostPerPage,
               w => w.complianceDescription,
               w => w.alternativesDescription,
               w => w.Status,
               w => w.AdditionalComments
               ))
            {
                _context.EquipmentPrintWaiver.Add(emptyWaiver);
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