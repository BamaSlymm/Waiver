using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DPAWaiver.Models.LOV;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace DPAWaiver.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the DPAUser class
    public class DPAUser : IdentityUser<Guid>
    {
        public DPAUser()
        {
            UserRoles = new List<string>();
        }

        [PersonalData]
        [Display(Name="First Name")]
        [JsonIgnore]
        public string FirstName { get; set; }

        [PersonalData]
        [Display(Name="Last Name")]
        [JsonIgnore]
        public string LastName { get; set; }

        [PersonalData]
        [Display(Name="Ext")]
        [JsonIgnore]
        public string PhoneNumberExtension { get; set; }

        [PersonalData]
        [Required]
        [Display(Name="Department")]
        [JsonIgnore]
        public Department Department { get; set; }

        [PersonalData]
        [Required]
        [Display(Name="Division")]
        [JsonIgnore]
        public string Division { get; set; }

        [NotMapped]
        [Display(Name="User Name")]
        public string FullName { get {return FirstName + " " + LastName ; } } 

        [NotMapped]
        public List<string> UserRoles { get; set; }

        public bool IsReviewer() {
            return UserRoles.Contains(GroupNames.Reviewer);
        }

        public bool IsUser() {
            return UserRoles.Contains(GroupNames.User);
        }

        public bool IsAdmin() {
            return UserRoles.Contains(GroupNames.Administrator);
        }

    }
}
