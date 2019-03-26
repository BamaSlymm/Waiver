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
using DPAWaiver.Models.WaiverSelection;

namespace DPAWaiver.Pages.Private
{
    public class WaiverListModel : BaseWaiverPageModel
    {
        public IList<BaseWaiver> BaseWaiver { get; set; }
        public string selectedPurpose  {get; set; }
        public string selectedType {get; set; }
        public string selectedSubtype {get; set; }
        
        selectedPurpose = BaseWaiver.Purpose;
        selectedType = BaseWaiver.PurposeType;
        selectedSubtype = BaseWaiver.SubType;
        

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
                Where(x => x.EditedBy == UserWithDepartment).ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnGetEditAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            UserWithDepartment = await GetUserWithDepartmentAsync();
            var BaseEntryWaiver = await _context.BaseWaiver.
            FirstOrDefaultAsync(m => m.ID == id);
            switch (BaseEntryWaiver.Purpose.ID)
            {
                case Purposes.Service:
                    switch (BaseEntryWaiver.PurposeType.ID)
                    {
                        case ServiceTypes.DataEntry: return RedirectToPage("./DataEntry/Edit");
                    }
                    break;
                    default: return RedirectToPage(pageName: "./WaiverList");

            }
            return RedirectToPage(pageName: "./WaiverList");
        }
         public IActionResult EditButton()
        {
            
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            switch (selectedPurpose)
            {
                case "Service":
                    switch (selectedType)
                    {
                        case "Data Entry": return RedirectToPage("./DataEntry/Edit");
                        case "Design Services": return RedirectToPage("./ServiceDesign/Edit");
                        case "Mail": return RedirectToPage("./ServiceMail/Edit");
                        case "Print": return RedirectToPage("./ServicePrint/Edit");
                        case "Microfilm":
                            switch (selectedSubtype)
                            {
                                case "Microfilm": return RedirectToPage("./ServiceMicrofilm/Edit");
                                case "Conversion": return RedirectToPage("./ServiceMicrofilmConversion/Edit");
                            }
                            break;
                        case "Scanning": return RedirectToPage("./ServiceScanning/Edit");
                    }
                    break;
                case "Personnel":
                    switch (selectedType) /* see LOVPopulator.getPersonnelServiceTypes */
                    {
                        case "Request": return RedirectToPage("./PersonnelRequest/Edit");
                        case "Contractor": return RedirectToPage("./PersonnelContractor/Edit");
                    }
                    break;
                case "Equipment":
                    switch (selectedType)
                    {
                        case "Mail": return RedirectToPage("./EquipmentMail/Edit");
                        case "Scanning": return RedirectToPage("./EquipmentScanning/Edit");
                        case "Print":
                            switch (selectedSubtype)
                            {
                                case "Print": return RedirectToPage("./EquipmentPrint/Edit");
                                case "A4": return RedirectToPage("./EquipmentPrintA4/Edit");
                                case "A3": return RedirectToPage("./EquipmentPrintA3/Edit");
                                case "Press": return RedirectToPage("./EquipmentPrintPress/Edit");
                                case "Large Format": return RedirectToPage("./EquipmentPrintLargeFormat/Edit");
                                case "Label": return RedirectToPage("./EquipmentPrintLabel/Edit");
                            }
                            break;
                    }
                    break;
                case "Software":
                    switch (selectedType)
                    {
                        case "Data Entry": return RedirectToPage("./SoftwareDataEntry/Edit");
                        case "Design": return RedirectToPage("./SoftwareDesign/Edit");
                        case "Processing": return RedirectToPage("./SoftwareMailProcessing/Edit");
                        case "Print": return RedirectToPage("./SoftwarePrint/Edit");
                        case "Scanning": return RedirectToPage("./SoftwareScanning/Edit");
                    }
                    break;

            }
            return RedirectToPage(pageName: "./WaiverList");
        }
    }
}
