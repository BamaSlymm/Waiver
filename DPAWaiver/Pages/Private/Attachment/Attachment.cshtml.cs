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
using DPAWaiver.Models;
using Microsoft.EntityFrameworkCore;
using DPAWaiver.Services;
using Microsoft.AspNetCore.Http;
using Google;
using System.IO;

namespace DPAWaiver.Pages.Private.Attachment
{
    public class AttachmentModel : BaseWaiverPageModel
    {
        private IStorageUtil _storageUtil;

        public AttachmentModel(IStorageUtil storageUtil
                    , DPAWaiver.Areas.Identity.Data.DPAWaiverIdentityDbContext context
                    , ILOVService iLOVService
                    , UserManager<DPAUser> userManager) : base(context, iLOVService, userManager)
        {
            _storageUtil = storageUtil;
        }

        [BindProperty]
        public BaseWaiver BaseWaiver { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await SetBaseWaiverAsync(id);
            return Page();
        }

        private async Task SetBaseWaiverAsync(Guid? id)
        {
            BaseWaiver = await _context.BaseWaivers.Include(x => x.CreatedBy)
                .ThenInclude(x => x.Department)
                .Include(x=>x.Purpose).Include(x=>x.PurposeType)
                .Include(x=>x.PurposeSubtype)
                .Include(x => x.Attachments).ThenInclude(x => x.CreatedBy)
                .FirstOrDefaultAsync(m => m.ID == id);
        }

        public async Task<IActionResult> OnGetAsyncFileView(Guid? id,Guid? waiverId)
        {
            if (id == null)
            {
                return NotFound();
            }
            var UserWithDepartment = await GetUserWithDepartmentAsync();
            await SetBaseWaiverAsync(waiverId);
            var attachment = await _context.BaseWaiverAttachments.FirstOrDefaultAsync(x => x.ID == id);
            var stream = new MemoryStream();
            await _storageUtil.GetFileAsync(attachment.ObjectName, stream);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, attachment.ContentType, attachment.FileName);
        }



        public async Task<IActionResult> OnGetAsyncFileDelete(Guid? id, Guid? waiverId)
        {
            if (id == null)
            {
                return NotFound();
            }
            var UserWithDepartment = await GetUserWithDepartmentAsync();
            await SetBaseWaiverAsync(waiverId);
            
            var attachment = await _context.BaseWaiverAttachments.FirstOrDefaultAsync(x => x.ID == id);
            await _storageUtil.DeleteFileAsync(attachment.ObjectName);

            var baseWaiverAction = new BaseWaiverAction(BaseWaiver, UserWithDepartment, WaiverActions.AttachmentViewed, attachment);
            
            _context.BaseWaiverAttachments.Remove(attachment);
            _context.BaseWaiverActions.Add(baseWaiverAction);

            await _context.SaveChangesAsync();

            return RedirectToPage(PageList.Attachment, new { id = waiverId });
        }
        public async Task<IActionResult> OnPostAsync(Guid? id, IFormFile formFile)
        {
            if (id == null)
            {
                return NotFound();
            }

            await SetBaseWaiverAsync(id);
            UserWithDepartment = await GetUserWithDepartmentAsync();

            if (formFile == null) {
                TempData["StatusMessage"] = "No file is selected for upload";
                return Page();
            }


            if (formFile.Length > 0)
            {
                BaseWaiverAttachment attachment = null;
                try
                {
                    var createdObject = await _storageUtil.StoreFileAsync(formFile, id.ToString());
                    attachment = new BaseWaiverAttachment(BaseWaiver,
                        UserWithDepartment,
                        createdObject,
                        formFile.FileName
                    );
                    _context.BaseWaiverAttachments.Add(attachment);

                    var baseWaiverAction = new BaseWaiverAction(BaseWaiver, UserWithDepartment, WaiverActions.AttachmentAdded,
                    attachment);
                    _context.BaseWaiverActions.Add(baseWaiverAction);
                    await _context.SaveChangesAsync();
                }
                catch (GoogleApiException gae)
                {
                    TempData["StatusMessage"] = gae.Message;
                    if (attachment != null)
                    {
                        _context.BaseWaiverAttachments.Remove(attachment);
                        await _context.SaveChangesAsync();
                    }
                    return null;
                }
            }
            return RedirectToPage("./Attachment", new { id = id });
        }
    }
}