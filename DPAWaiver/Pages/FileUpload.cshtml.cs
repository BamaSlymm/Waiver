using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DPAWaiver.Areas.Identity.Data;
using DPAWaiver.Models;
using DPAWaiver.Pages.Private;
using DPAWaiver.Services;
using Google;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPAWaiver.Pages
{
    public class FileUploadModel : BaseWaiverPageModel
    {
        private IStorageUtil _storageUtil;

        public FileUploadModel(IStorageUtil storageUtil
                            , DPAWaiver.Areas.Identity.Data.DPAWaiverIdentityDbContext context
                            , ILOVService iLOVService
                            , UserManager<DPAUser> userManager) : base(context, iLOVService, userManager)
        {
            _storageUtil = storageUtil;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost(IFormFile formFile)
        {

            if (formFile.Length > 0)
            {
                try
                {
                    var createdObject = await _storageUtil.StoreFileAsync(formFile, "siktigiminDunyasi");
                    UserWithDepartment = await GetUserWithDepartment();

                }
                catch (GoogleApiException gae)
                {
                    TempData["StatusMessage"] = gae.Message;
                    return null;
                }
            }
            return null;
        }

    }
}
