using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DPAWaiver.Pages
{
    public class Status402Model : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
        }
    }
}
