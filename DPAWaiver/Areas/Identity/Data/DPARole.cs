using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DPAWaiver.Models.LOV;
using Microsoft.AspNetCore.Identity;

namespace DPAWaiver.Areas.Identity.Data
{

    public class DPARole : IdentityRole<Guid>
    {
        public DPARole(string roleName) : base(roleName)
        {
        }

        public DPARole() : base()
        {
        }

    }
}
