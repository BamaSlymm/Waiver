using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DPAWaiver.Areas.Identity.Data;
using DPAWaiver.Models.Waivers;
using Microsoft.AspNetCore.Identity;
using DPAWaiver.Models;

namespace DPAWaiver.Pages.Private
{
    public class WaiverListModel : BaseWaiverPageModel
    {
        public IList<BaseWaiver> BaseWaiver { get; set; }

        public WaiverListModel(DPAWaiverIdentityDbContext context,
                              ILOVService iLOVService,
                              UserManager<DPAUser> userManager) : base(context, iLOVService, userManager)
        {
        }

        public async Task<IActionResult> OnGetAsync()
        {
            UserWithDepartment = await GetUserWithDepartmentAsync();
            BaseWaiver = await _context.BaseWaivers.
                Include(x => x.Purpose).Include(x => x.PurposeType).
                Where(x => x.EditdBy == UserWithDepartment).ToListAsync();
            return Page();
        }

         public IActionResult OnPost([FromQuery(Name = "otherFirstName")] string otherFirstName,[FromQuery(Name = "otherLastName")] string otherLastName)
        {
            
            if (!ModelState.IsValid)
            {
                return Page();
            }
            String selectedPurpose = BaseWaiver.Purpose;
            String selectedType = BaseWaiver.PurposeType;
            String selectedSubtype = BaseWaiver.SubType
            switch (selectedPurpose)
            {
                case "Service":
                    switch (selectedType)
                    {
                        case 1: return RedirectToPage("./DataEntry/Edit", new{otherFirstName= OtherFirstName, otherLastName= OtherLastName});
                        case "Design Services": return RedirectToPage("./ServiceDesign/Edit", new{otherFirstName= OtherFirstName, otherLastName= OtherLastName});
                        case 3: return RedirectToPage("./ServiceMail/Edit");
                        case 4: return RedirectToPage("./ServicePrint/Edit");
                        case 5:
                            switch (selectedSubtype)
                            {
                                case 7: return RedirectToPage("./ServiceMicrofilm/Edit");
                                case 8: return RedirectToPage("./ServiceMicrofilmConversion/Edit");
                            }
                            break;
                        case 6: return RedirectToPage("./ServiceScanning/Edit");
                    }
                    break;
                case "Personnel":
                    switch (selectedType) /* see LOVPopulator.getPersonnelServiceTypes */
                    {
                        case 7: return RedirectToPage("./PersonnelRequest/Edit");
                        case 8: return RedirectToPage("./PersonnelContractor/Edit");
                    }
                    break;
                case "Equipment":
                    switch (selectedType)
                    {
                        case 9: return RedirectToPage("./EquipmentMail/Edit");
                        case 10: return RedirectToPage("./EquipmentScanning/Edit");
                        case 11:
                            switch (selectedSubtype)
                            {
                                case 1: return RedirectToPage("./EquipmentPrint/Edit");
                                case 2: return RedirectToPage("./EquipmentPrintA4/Edit");
                                case 3: return RedirectToPage("./EquipmentPrintA3/Edit");
                                case 4: return RedirectToPage("./EquipmentPrintPress/Edit");
                                case 5: return RedirectToPage("./EquipmentPrintLargeFormat/Edit");
                                case 6: return RedirectToPage("./EquipmentPrintLabel/Edit");
                            }
                            break;
                    }
                    break;
                case "Software":
                    switch (selectedType)
                    {
                        case 12: return RedirectToPage("./SoftwareDataEntry/Edit");
                        case 13: return RedirectToPage("./SoftwareDesign/Edit");
                        case 14: return RedirectToPage("./SoftwareMailProcessing/Edit");
                        case 15: return RedirectToPage("./SoftwarePrint/Edit");
                        case 16: return RedirectToPage("./SoftwareScanning/Edit");
                    }
                    break;

            }
            return RedirectToPage(pageName: "./CreateWaiverStep1");
        }
    }
}
