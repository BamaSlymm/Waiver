using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DPAWaiver.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DPAWaiver.Pages
{
    public class CreateWaiverServiceMicrofilmModel : PageModel
    {
        public IEnumerable<SelectListItem> OutputTypes => iLOVService.GetMicrofilmOutputTypeAsSelectListBySortOrder();
        private readonly ILOVService iLOVService;

        public CreateWaiverServiceMicrofilmModel (ILOVService iLOVService) {
            this.iLOVService = iLOVService;
        }

        public void OnGet()
        {

        }
    }
}
