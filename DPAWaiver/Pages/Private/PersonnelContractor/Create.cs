using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DPAWaiver.Areas.Identity.Data;
using DPAWaiver.Models.Waivers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DPAWaiver.Models;
using DPAWaiver.Pages.Private;
using DPAWaiver.Models.WaiverSelection;


namespace DPAWaiver.Pages.Private.PersonnelContractor
{
    public class CreateModel : BaseWaiverPageModel
    {
        [BindProperty]
        public PersonnelContractorWaiverView PersonnelContractorWaiver { get; set; }

        public CreateModel(DPAWaiverIdentityDbContext context, ILOVService iLOVService, UserManager<DPAUser> userManager) : base(context, iLOVService, userManager)
        {
        }

        public async Task<IActionResult> OnGetAsync([FromQuery(Name = "otherFirstName")] string otherFirstName, [FromQuery(Name = "otherLastName")] string otherLastName)
        {
            UserWithDepartment = await GetUserWithDepartmentAsync();

            PersonnelContractorWaiver = new PersonnelContractorWaiverView();
            PersonnelContractorWaiver.OtherFirstName = otherFirstName;
            PersonnelContractorWaiver.OtherLastName = otherLastName;
            return Page();
        }

        public IEnumerable<SelectListItem> servicetype => _ILOVService.GetPersonnelServiceTypesAsSelectListBySortOrder();

        public async Task<IActionResult> OnPostAsync()
        {
            UserWithDepartment = await GetUserWithDepartmentAsync();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var purpose = _ILOVService.getPurposes().Single(x => x.ID == Purposes.Personnel);
            var purposeType = _ILOVService.getPersonnelServiceTypes().Single(x => x.ID == PersonnelServiceTypes.ThirdPartyContractor);
            PersonnelContractorWaiver emptyWaiver = new PersonnelContractorWaiver(UserWithDepartment, null, null, purpose, purposeType, null);

            if (await TryUpdateModelAsync<PersonnelContractorWaiver>(
               emptyWaiver,
               "PersonnelContractorwaiver",
               w => w.OtherFirstName,
               w => w.OtherLastName,
               w => w.projectName,
               w => w.SubmittedOn,
               w => w.ScopeofWork,
               w => w.ContractorType,
               w => w.HourlyRate,
               w => w.CostEstimate,
               w => w.EstimatedNumberOfHours,
               w => w.SPAnumber,
               w => w.SPAtype,
               w => w.SPAotherDescription,
               w => w.EstimatedNumberofFTE,
               w => w.ContractDuration,
               w => w.AnticipatedExpediture,
               w => w.DetailJustification,
               w => w.AdditionalComments,
               w => w.Status
               ))
            {
                _context.PersonnelContractorWaiver.Add(emptyWaiver);
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