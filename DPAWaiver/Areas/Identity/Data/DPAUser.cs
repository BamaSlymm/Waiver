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
        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [PersonalData]
        [Display(Name="Last Name")]
        public string LastName { get; set; }

        [PersonalData]
        [Display(Name="Ext")]
        public string PhoneNumberExtension { get; set; }

        [PersonalData]
        [Required]
        [Display(Name="Department")]
        public Department Department { get; set; }

        [PersonalData]
        [Required]
        [Display(Name="Division")]
        public string Division { get; set; }

        [Display(Name="User Name")]
        public string FullName { get {return FirstName + " " + LastName ; } } 
    }
}
