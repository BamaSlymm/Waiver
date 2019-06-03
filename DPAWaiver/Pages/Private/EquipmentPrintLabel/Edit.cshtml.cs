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

namespace DPAWaiver.Pages.Private.EquipmentPrintLabel
{
    public class EditModel : BaseWaiverPageModel
    {
        [BindProperty]
        public EquipmentPrintLabelWaiverView EquipmentPrintLabelWaiver { get; set; }

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
            var equipmentPrintWaiver = await _context.EquipmentPrintLabelWaiver.
            FirstOrDefaultAsync(m => m.ID == id);
            EquipmentPrintLabelWaiver = new EquipmentPrintLabelWaiverView(equipmentPrintWaiver);
            Invoices = await GetInvoicesAsync(id) ;
            Attachments = await GetAttachmentsAsync(id) ;

            if (EquipmentPrintLabelWaiver == null || !equipmentPrintWaiver.Editable)
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

            var waiverToUpdate = await _context.EquipmentPrintLabelWaiver.Include(w => w.Purpose).
            Include(w => w.PurposeType).
            Include(w => w.PurposeSubtype).
            Include(w => w.CreatedBy).FirstAsync(x => x.ID == id);

            if (!waiverToUpdate.Editable || waiverToUpdate.CreatedBy.Id != UserWithDepartment.Id) {
                return NotFound();
            }

            if (await TryUpdateModelAsync<EquipmentPrintLabelWaiver>(
               waiverToUpdate,
              "EquipmentPrintLabelwaiver",
               w => w.OtherFirstName,
               w => w.OtherLastName,
               w => w.projectName,
               w => w.SubmittedOn,
               w => w.CostEstimate,
               w => w.printerType,
               w => w.NumberofEquipment,
               w => w.Make,
               w => w.Model,
               w => w.vendorChoice,
               w => w.servicesReceived,
               w => w.agreementOrWarrantyCost,
               w => w.printerReplacementCycle,
               w => w.selectionReason,
               w => w.otherReplacementCycle,
               w => w.monthlyCostWithoutToner,
               w => w.monthlyMonochromeVolume,
               w => w.monthlyColorVolume,
               w => w.cyanTonerCost,
               w => w.blackTonerCost,
               w => w.purchaseAmount,
               w => w.MagentaTonerCost,
               w => w.YellowTonerCost,
               w => w.alternativesDescription,
               w => w.justificationDescription,
               w => w.Status,
               w => w.AdditionalComments
               ))
            {
                try
                {
                    BaseWaiverAction baseWaiverAction = new BaseWaiverAction(waiverToUpdate, UserWithDepartment,
                                        WaiverActions.Updated, EquipmentPrintLabelWaiver);
                    _context.BaseWaiverActions.Add(baseWaiverAction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipmentPrintLabelWaiverExists(id))
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

        private bool EquipmentPrintLabelWaiverExists(Guid? id)
        {
            return _context.EquipmentPrintLabelWaiver.Any(e => e.ID == id);
        }
    }
}
