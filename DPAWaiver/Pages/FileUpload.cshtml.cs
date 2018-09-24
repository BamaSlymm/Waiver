using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DPAWaiver.Services;
using Google;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPAWaiver.Pages
{
    public class FileUploadModel : PageModel
    {
        private IStorageUtil _storageUtil;

        public FileUploadModel(IStorageUtil storageUtil)
        {
            _storageUtil = storageUtil;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            // full path to file in temp location
            var filePath = Path.GetTempFileName();

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    try {
                    await _storageUtil.StoreFileAsync(formFile, "siktigiminDunyasi");
                    } catch(GoogleApiException gae) {
                        TempData["StatusMessage"] = gae.Message;
                        return null ;
                    }
                }
            }

            return null ;
        }
    }
}
