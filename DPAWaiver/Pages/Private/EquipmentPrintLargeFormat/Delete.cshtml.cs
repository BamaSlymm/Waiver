using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DPAWaiver.Areas.Identity.Data;
using DPAWaiver.Models;
using DPAWaiver.Models.Waivers;
using Microsoft.AspNetCore.Identity;

namespace DPAWaiver.Pages.Private.EquipmentPrintLargeFormat
{
    public class DeleteModel : BaseWaiverPageModel
    {

        public DeleteModel(DPAWaiver.Areas.Identity.Data.DPAWaiverIdentityDbContext context
        , ILOVService iLOVService
                            , UserManager<DPAUser> userManager) : base(context, iLOVService, userManager)
        {
        }

        [BindProperty]
        public EquipmentPrintLargeFormatWaiver EquipmentPrintLargeFormatWaiver { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserWithDepartment = await GetUserWithDepartmentAsync();

            EquipmentPrintLargeFormatWaiver = await _context.EquipmentPrintLargeFormatWaiver.Include(x => x.CreatedBy)
            .ThenInclude(x => x.Department)
            .Include(x => x.Purpose)
            .Include(x => x.PurposeType)
            .Include(x => x.PurposeSubtype)
            .FirstAsync(m => m.ID == id);

            if (EquipmentPrintLargeFormatWaiver == null || !EquipmentPrintLargeFormatWaiver.Editable)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EquipmentPrintLargeFormatWaiver = await _context.EquipmentPrintLargeFormatWaiver.FindAsync(id);

            if (EquipmentPrintLargeFormatWaiver != null && EquipmentPrintLargeFormatWaiver.Editable)
            {
                _context.EquipmentPrintLargeFormatWaiver.Remove(EquipmentPrintLargeFormatWaiver);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage(PageList.WaiverList);
        }
    }
}
