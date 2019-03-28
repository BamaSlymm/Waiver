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
                Where(x => x.CreatedBy == UserWithDepartment).ToListAsync();
            return Page();
        }
        public async Task<IActionResult> OnGetDetailsAsync(Guid? id)
        {
            UserWithDepartment = await GetUserWithDepartmentAsync();
            var baseWaiver = await _context.BaseWaivers.
                FirstAsync(x => x.ID == id);
            if (baseWaiver is DataEntryWaiver)
            {
                return RedirectToPage(PageList.ServiceDataEntryDetails, new { id = id });
            }
            if (baseWaiver is ServiceDesignWaiver)
            {
                return RedirectToPage(PageList.ServiceDesignDetails, new {id =id});
            }
             if (baseWaiver is ServiceMailWaiver)
            {
                return RedirectToPage(PageList.ServiceMailDetails, new {id =id});
            }
             if (baseWaiver is ServicePrintWaiver)
            {
                return RedirectToPage(PageList.ServicePrintDetails, new {id =id});
            }
             if (baseWaiver is ServiceMicrofilmWaiver)
            {
                return RedirectToPage(PageList.ServiceMicrofilmDetails, new {id =id});
            }
             if (baseWaiver is ServiceMicrofilmConversionWaiver)
            {
                return RedirectToPage(PageList.ServiceMicrofilmConversionDetails, new {id =id});
            }
             if (baseWaiver is ServiceScanningWaiver)
            {
                return RedirectToPage(PageList.ServiceScanningDetails, new {id =id});
            }
             if (baseWaiver is PersonnelRequestWaiver)
            {
                return RedirectToPage(PageList.PersonnelDetails, new {id =id});
            }
            if (baseWaiver is PersonnelContractorWaiver)
            {
                return RedirectToPage(PageList.ContractorDetails, new {id =id});
            }
             if (baseWaiver is EquipmentMailWaiver)
            {
                return RedirectToPage(PageList.EquipmentMailDetails, new {id =id});
            }
            if (baseWaiver is EquipmentScanningWaiver)
            {
                return RedirectToPage(PageList.EquipmentScanningDetails, new {id =id});
            }
            if (baseWaiver is EquipmentPrintWaiver)
            {
                return RedirectToPage(PageList.EquipmentPrintDetails, new {id =id});
            }
            if (baseWaiver is EquipmentPrintA4Waiver)
            {
                return RedirectToPage(PageList.EquipmentA4Details, new {id =id});
            }
            if (baseWaiver is EquipmentPrintA3Waiver)
            {
                return RedirectToPage(PageList.EquipmentA3Details, new {id =id});
            }
            if (baseWaiver is EquipmentPrintPressWaiver)
            {
                return RedirectToPage(PageList.EquipmentPressDetails, new {id =id});
            }
            if (baseWaiver is EquipmentPrintLargeFormatWaiver)
            {
                return RedirectToPage(PageList.EquipmentLargeDetails, new {id =id});
            }
            if (baseWaiver is EquipmentPrintLabelWaiver)
            {
                return RedirectToPage(PageList.EquipmentLargeDetails, new {id =id});
            }
            if (baseWaiver is SoftwareDataEntryWaiver)
            {
                return RedirectToPage(PageList.SoftwareDataEntryDetails, new { id = id });
            }
            if (baseWaiver is SoftwareDesignWaiver)
            {
                return RedirectToPage(PageList.SoftwareDesignDetails, new {id =id});
            }
             if (baseWaiver is SoftwareMailProcessingWaiver)
            {
                return RedirectToPage(PageList.SoftwareMailDetails, new {id =id});
            }
             if (baseWaiver is SoftwarePrintWaiver)
            {
                return RedirectToPage(PageList.SoftwarePrintDetails, new {id =id});
            }
             if (baseWaiver is SoftwareScanningWaiver)
            {
                return RedirectToPage(PageList.SoftwareScanningDetails, new {id =id});
            }
            return RedirectToPage(pageName: "./WaiverList");
        }
         public async Task<IActionResult> OnGetDeleteAsync(Guid? id)
        {
            UserWithDepartment = await GetUserWithDepartmentAsync();
            var baseWaiver = await _context.BaseWaivers.
                FirstAsync(x => x.ID == id);
            if (baseWaiver is DataEntryWaiver)
            {
                return RedirectToPage(PageList.ServiceDataEntryDelete, new { id = id });
            }
            if (baseWaiver is ServiceDesignWaiver)
            {
                return RedirectToPage(PageList.ServiceDesignDelete, new {id =id});
            }
             if (baseWaiver is ServiceMailWaiver)
            {
                return RedirectToPage(PageList.ServiceMailDelete, new {id =id});
            }
             if (baseWaiver is ServicePrintWaiver)
            {
                return RedirectToPage(PageList.ServicePrintDelete, new {id =id});
            }
             if (baseWaiver is ServiceMicrofilmWaiver)
            {
                return RedirectToPage(PageList.ServiceMicrofilmDelete, new {id =id});
            }
             if (baseWaiver is ServiceMicrofilmConversionWaiver)
            {
                return RedirectToPage(PageList.ServiceMicrofilmConversionDelete, new {id =id});
            }
             if (baseWaiver is ServiceScanningWaiver)
            {
                return RedirectToPage(PageList.ServiceScanningDelete, new {id =id});
            }
             if (baseWaiver is PersonnelRequestWaiver)
            {
                return RedirectToPage(PageList.PersonnelDelete, new {id =id});
            }
            if (baseWaiver is PersonnelContractorWaiver)
            {
                return RedirectToPage(PageList.ContractorDelete, new {id =id});
            }
             if (baseWaiver is EquipmentMailWaiver)
            {
                return RedirectToPage(PageList.EquipmentMailDelete, new {id =id});
            }
            if (baseWaiver is EquipmentScanningWaiver)
            {
                return RedirectToPage(PageList.EquipmentScanningDelete, new {id =id});
            }
            if (baseWaiver is EquipmentPrintWaiver)
            {
                return RedirectToPage(PageList.EquipmentPrintDelete, new {id =id});
            }
            if (baseWaiver is EquipmentPrintA4Waiver)
            {
                return RedirectToPage(PageList.EquipmentA4Delete, new {id =id});
            }
            if (baseWaiver is EquipmentPrintA3Waiver)
            {
                return RedirectToPage(PageList.EquipmentA3Delete, new {id =id});
            }
            if (baseWaiver is EquipmentPrintPressWaiver)
            {
                return RedirectToPage(PageList.EquipmentPressDelete, new {id =id});
            }
            if (baseWaiver is EquipmentPrintLargeFormatWaiver)
            {
                return RedirectToPage(PageList.EquipmentLargeDelete, new {id =id});
            }
            if (baseWaiver is EquipmentPrintLabelWaiver)
            {
                return RedirectToPage(PageList.EquipmentLargeDelete, new {id =id});
            }
            if (baseWaiver is SoftwareDataEntryWaiver)
            {
                return RedirectToPage(PageList.SoftwareDataEntryDelete, new { id = id });
            }
            if (baseWaiver is SoftwareDesignWaiver)
            {
                return RedirectToPage(PageList.SoftwareDesignDelete, new {id =id});
            }
             if (baseWaiver is SoftwareMailProcessingWaiver)
            {
                return RedirectToPage(PageList.SoftwareMailDelete, new {id =id});
            }
             if (baseWaiver is SoftwarePrintWaiver)
            {
                return RedirectToPage(PageList.SoftwarePrintDelete, new {id =id});
            }
             if (baseWaiver is SoftwareScanningWaiver)
            {
                return RedirectToPage(PageList.SoftwareScanningDelete, new {id =id});
            }
            return RedirectToPage(pageName: "./WaiverList");
        }
         public async Task<IActionResult> OnGetEditAsync(Guid? id)
        {
            UserWithDepartment = await GetUserWithDepartmentAsync();
            var baseWaiver = await _context.BaseWaivers.
                FirstAsync(x => x.ID == id);
            if (baseWaiver is DataEntryWaiver)
            {
                return RedirectToPage(PageList.ServiceDataEntryEdit, new { id = id });
            }
            if (baseWaiver is ServiceDesignWaiver)
            {
                return RedirectToPage(PageList.ServiceDesignEdit, new {id =id});
            }
             if (baseWaiver is ServiceMailWaiver)
            {
                return RedirectToPage(PageList.ServiceMailEdit, new {id =id});
            }
             if (baseWaiver is ServicePrintWaiver)
            {
                return RedirectToPage(PageList.ServicePrintEdit, new {id =id});
            }
            if (baseWaiver is ServiceMicrofilmWaiver)
            {
                return RedirectToPage(PageList.ServiceMicrofilmEdit, new {id =id});
            }
            if (baseWaiver is ServiceMicrofilmConversionWaiver)
            {
                return RedirectToPage(PageList.ServiceMicrofilmConversionEdit, new {id =id});
            }
            if (baseWaiver is ServiceScanningWaiver)
            {
                return RedirectToPage(PageList.ServiceScanningEdit, new {id =id});
            }
            if (baseWaiver is PersonnelRequestWaiver)
            {
                return RedirectToPage(PageList.PersonnelEdit, new {id =id});
            }
            if (baseWaiver is PersonnelContractorWaiver)
            {
                return RedirectToPage(PageList.ContractorEdit, new {id =id});
            }
             if (baseWaiver is EquipmentMailWaiver)
            {
                return RedirectToPage(PageList.EquipmentMailEdit, new {id =id});
            }
            if (baseWaiver is EquipmentScanningWaiver)
            {
                return RedirectToPage(PageList.EquipmentScanningEdit, new {id =id});
            }
            if (baseWaiver is EquipmentPrintWaiver)
            {
                return RedirectToPage(PageList.EquipmentPrintEdit, new {id =id});
            }
            if (baseWaiver is EquipmentPrintA4Waiver)
            {
                return RedirectToPage(PageList.EquipmentA4Edit, new {id =id});
            }
            if (baseWaiver is EquipmentPrintA3Waiver)
            {
                return RedirectToPage(PageList.EquipmentA3Edit, new {id =id});
            }
            if (baseWaiver is EquipmentPrintPressWaiver)
            {
                return RedirectToPage(PageList.EquipmentPressEdit, new {id =id});
            }
            if (baseWaiver is EquipmentPrintLargeFormatWaiver)
            {
                return RedirectToPage(PageList.EquipmentLargeEdit, new {id =id});
            }
            if (baseWaiver is EquipmentPrintLabelWaiver)
            {
                return RedirectToPage(PageList.EquipmentLargeEdit, new {id =id});
            }
            if (baseWaiver is SoftwareDataEntryWaiver)
            {
                return RedirectToPage(PageList.SoftwareDataEntryEdit, new { id = id });
            }
            if (baseWaiver is SoftwareDesignWaiver)
            {
                return RedirectToPage(PageList.SoftwareDesignEdit, new {id =id});
            }
            if (baseWaiver is SoftwareMailProcessingWaiver)
            {
                return RedirectToPage(PageList.SoftwareMailEdit, new {id =id});
            }
            if (baseWaiver is SoftwarePrintWaiver)
            {
                return RedirectToPage(PageList.SoftwarePrintEdit, new {id =id});
            }
            if (baseWaiver is SoftwareScanningWaiver)
            {
                return RedirectToPage(PageList.SoftwareScanningEdit, new {id =id});
            }
            return RedirectToPage(pageName: "./WaiverList");
        }
       
    }
}
