using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DPAWaiver.Models.LOV;
using Microsoft.AspNetCore.Identity;

namespace DPAWaiver.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the DPAUser class
    public class DPAUser : IdentityUser<Guid>
    {
        [PersonalData]
        public string FirstName { get; set; }

        [PersonalData]
        public string LastName { get; set; }

        [PersonalData]
        public string PhoneNumberExtension { get; set; }

        [PersonalData]
        [Required]
        public Department Department { get; set; }

        [PersonalData]
        public string Division { get; set; }

    }
}
