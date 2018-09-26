using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DPAWaiver.Areas.Identity.Data;
using DPAWaiver.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace DPAWaiver.Pages.Private.Confirmation
{
    public class ConfirmationModel : BaseWaiverPageModel
    {
        public ConfirmationModel(DPAWaiverIdentityDbContext context, ILOVService iLOVService, UserManager<DPAUser> userManager) : base(context, iLOVService, userManager)
        {
        }

        public Guid? id {get;set;}

        public void OnGet(Guid? id)
        {
            this.id = id ;
        }

    }
}
