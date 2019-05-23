using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DPAWaiver.Areas.Identity.Data;
using DPAWaiver.Models.Waivers;
using Microsoft.AspNetCore.Identity;
using DPAWaiver.Models;
using DPAWaiver.Models.WaiverSelection;

namespace DPAWaiver.Pages.Private.EquipmentMail
{
    public class EditModel : BaseWaiverPageModel
    {
        [BindProperty]
        public EquipmentMailWaiverView EquipmentMailWaiver { get; set; }

        public Guid? ID {get;set;}


        public EditModel(DPAWaiver.Areas.Identity.Data.DPAWaiverIdentityDbContext context
                       , ILOVService iLOVService
                       , UserManager<DPAUser> userManager): base(context, iLOVService, userManager)
        {
        }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ID = id ;
            UserWithDepartment = await GetUserWithDepartmentAsync();
            var equipmentMailWaiver = await _context.EquipmentMailWaiver.
            FirstOrDefaultAsync(m => m.ID == id);
            EquipmentMailWaiver = new EquipmentMailWaiverView(equipmentMailWaiver);
            Invoices = await GetInvoicesAsync(id) ;
            Attachments = await GetAttachmentsAsync(id) ;

            if (EquipmentMailWaiver == null || !equipmentMailWaiver.Editable)
            {
                return NotFound();
            }

            UserWithDepartment = await GetUserWithDepartmentAsync();
            return Page();

        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            UserWithDepartment = await GetUserWithDepartmentAsync();

            if (id == null)
            {
                return NotFound();
            }

            ID = id ;
            Invoices = await GetInvoicesAsync(id);
            Attachments = await GetAttachmentsAsync(id);

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var waiverToUpdate = await _context.EquipmentMailWaiver.Include(w => w.Purpose).
            Include(w => w.PurposeType).
            Include(w => w.PurposeSubtype).
            Include(w => w.CreatedBy).FirstAsync(x => x.ID == id);

            if (!waiverToUpdate.Editable || waiverToUpdate.CreatedBy.Id != UserWithDepartment.Id) {
                return NotFound();
            }

            if (await TryUpdateModelAsync<EquipmentMailWaiver>(
               waiverToUpdate,
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
               w => w.EstimatedNumberOfHoursPerFTE,
               w => w.weeklySalaryCost,
               w => w.totalSpaceRequired,
               w => w.monthlySupervisionAmount,
               w => w.monthlyManagementAmount,
               w => w.monthlyUtilitiesAmount,
               w => w.monthlyIndirectCosts,
               w => w.miscellaneousCosts,
               w => w.overheadCostDescription,
               w => w.alternativesDescription,
               w => w.Status,
               w => w.AdditionalComments
               ))
            {
                try
                {
                    BaseWaiverAction baseWaiverAction = new BaseWaiverAction(waiverToUpdate, UserWithDepartment,
                                        WaiverActions.Updated, EquipmentMailWaiver);
                    _context.BaseWaiverActions.Add(baseWaiverAction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipmentMailWaiverExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["StatusMessage"] = "Your waiver has been updated";
                return RedirectToPage(PageList.WaiverList);
            }
            return Page();
        }

        private bool EquipmentMailWaiverExists(Guid? id)
        {
            return _context.EquipmentMailWaiver.Any(e => e.ID == id);
        }
    }
}
