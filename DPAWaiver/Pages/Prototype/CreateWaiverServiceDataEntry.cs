using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DPAWaiver.Areas.Identity.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DPAWaiver.Pages
{
    public class CreateWaiverServiceDataEntryModel : PageModel
    {

      
        public CreateWaiverServiceDataEntryModel()
        {           
        }

        public IActionResult OnGetAsync()
        {
            return Page();
        }
    }
}
