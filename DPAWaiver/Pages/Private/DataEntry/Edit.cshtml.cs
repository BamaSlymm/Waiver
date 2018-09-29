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

namespace DPAWaiver.Pages.Private.DataEntry
{
    public class EditModel : BaseWaiverPageModel
    {
        [BindProperty]
        public DataEntryWaiverView DataEntryWaiver { get; set; }

        public Purpose Purpose { get; set; }


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


            var dataEntryWaiver = await _context.DataEntryWaiver.FirstOrDefaultAsync(m => m.ID == id);
            DataEntryWaiver = new DataEntryWaiverView(dataEntryWaiver);



            if (DataEntryWaiver == null)
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

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var waiverToUpdate = await _context.DataEntryWaiver.Include(w => w.Purpose).Include(w => w.PurposeType)
            .Include(w => w.PurposeSubtype).Include(w => w.CreatedBy).FirstOrDefaultAsync(x => x.ID == id);

            if (await TryUpdateModelAsync<DataEntryWaiver>(
               waiverToUpdate,
               "dataentrywaiver",
               w => w.OtherFirstName,
               w => w.OtherLastName,
               w => w.ProjectName,
               w => w.SubmittedOn,
               w => w.CostEstimate,
               w => w.WorkflowDescription,
               w => w.EstimatedNumberofFTE,
               w => w.EstimatedNumberofHours,
               w => w.EstimatedNumberofDocuments,
               w => w.EstimatedNumberofFields,
               w => w.SystemRequirementsDescription,
               w => w.KeyedIntoSystem,
               w => w.ReasonForNotKeyedIntoSystem,
               w => w.ReasonDataEntryCenter,
               w => w.AdditionalComments
               ))
            {
                try
                {
                    BaseWaiverAction baseWaiverAction = new BaseWaiverAction(waiverToUpdate, UserWithDepartment,
                                        WaiverActions.Updated, DataEntryWaiver);
                    _context.BaseWaiverActions.Add(baseWaiverAction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DataEntryWaiverExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["StatusMessage"] = "Your waiver has been updated";
                return RedirectToPage("../WaiverList");
            }
            return Page();
        }

        private bool DataEntryWaiverExists(Guid? id)
        {
            return _context.DataEntryWaiver.Any(e => e.ID == id);
        }
    }
}
