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

namespace DPAWaiver.Pages.Private.EquipmentPrintA3
{
    public class EditModel : BaseWaiverPageModel
    {
        [BindProperty]
        public EquipmentPrintA3WaiverView EquipmentPrintA3Waiver { get; set; }

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
            var equipmentPrintWaiver = await _context.EquipmentPrintA3Waiver.
            FirstOrDefaultAsync(m => m.ID == id);
            EquipmentPrintA3Waiver = new EquipmentPrintA3WaiverView(equipmentPrintWaiver);
            Invoices = await GetInvoicesAsync(id) ;
            Attachments = await GetAttachmentsAsync(id) ;

            if (EquipmentPrintA3Waiver == null || !equipmentPrintWaiver.Editable)
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

            var waiverToUpdate = await _context.EquipmentPrintA3Waiver.Include(w => w.Purpose).
            Include(w => w.PurposeType).
            Include(w => w.PurposeSubtype).
            Include(w => w.CreatedBy).FirstAsync(x => x.ID == id);

            if (!waiverToUpdate.Editable || waiverToUpdate.CreatedBy.Id != UserWithDepartment.Id) {
                return NotFound();
            }

            if (await TryUpdateModelAsync<EquipmentPrintA3Waiver>(
               waiverToUpdate,
              "EquipmentPrintA3waiver",
               w => w.OtherFirstName,
               w => w.OtherLastName,
               w => w.projectName,
               w => w.SubmittedOn,
               w => w.CostEstimate,
               w => w.printerType,
               w => w.newOrReplace,
               w => w.Make,
               w => w.Model,
               w => w.selectionReason,
               w => w.acquisitionType,
               w => w.solicitationSubType,
               w => w.statepriceSubType,
               w => w.numberOfMonths,
               w => w.monthlyLeaseAmount,
               w => w.servicesReceived,
               w => w.leaseDuration,
               w => w.purchaseAmount,
               w => w.blackCostPerPage,
               w => w.colorCostPerPage,
               w => w.blackMonthlyVolume,
               w => w.colorMonthlyVolume,
               w => w.leaseAccessories,
               w => w.complianceDescription,
               w => w.alternativesDescription,
               w => w.justificationDescription,
               w => w.Status,
               w => w.AdditionalComments
               ))
            {
                try
                {
                    BaseWaiverAction baseWaiverAction = new BaseWaiverAction(waiverToUpdate, UserWithDepartment,
                                        WaiverActions.Updated, EquipmentPrintA3Waiver);
                    _context.BaseWaiverActions.Add(baseWaiverAction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipmentPrintA3WaiverExists(id))
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

        private bool EquipmentPrintA3WaiverExists(Guid? id)
        {
            return _context.EquipmentPrintA3Waiver.Any(e => e.ID == id);
        }
    }
}
