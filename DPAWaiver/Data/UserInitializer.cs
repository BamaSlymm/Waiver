using DPAWaiver.Areas.Identity.Data;
using DPAWaiver.Models;
using DPAWaiver.Models.LOV;
using DPAWaiver.Models.WaiverSelection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DPAWaiver.Data
{
    public class UserInitializer
    {
        private const string regularUserEmail = "regularUser@state.co.us";
        private const string reviewerUserEmail = "reviewerUser@state.co.us";
        IServiceProvider _IServiceProvider;
        DPAWaiverIdentityDbContext _context;

        public UserInitializer(IServiceProvider iServiceProvider)
        {
            _IServiceProvider = iServiceProvider;
            _context = _IServiceProvider.GetRequiredService<DPAWaiverIdentityDbContext>();
        }

        public async Task InitializeAsync()
        {
            _context.Database.EnsureCreated();
            await CreateApplicationRolesAsync();
            await CreateUsersAsync();
            await TieUsersToRoles();
            _context.SaveChanges();
        }


        public async Task CreateApplicationRolesAsync()
        {
            await CreateRoleIfNeeded(Constants.Administrator);
            await CreateRoleIfNeeded(Constants.Reviewer);
            await CreateRoleIfNeeded(Constants.User);
        }


        public async Task CreateUsersAsync()
        {
            await CreateUserIfNeeded(userEmail: regularUserEmail, FirstName: "I Submit", LastName: "Waivers",
                                     departmentId: 5, PhoneNumber: "303-3949-339", Division: "my division");
            await CreateUserIfNeeded(userEmail: reviewerUserEmail, FirstName: "I Reviewer", LastName: "Waivers",
                                     departmentId: 5, PhoneNumber: "303-3949-339", Division: "my division");
        }

        public async Task TieUsersToRoles()
        {
            var userManager = _IServiceProvider.GetService<UserManager<DPAUser>>();
            var regularUser = await userManager.FindByEmailAsync(regularUserEmail);
            var reviewerUser = await userManager.FindByEmailAsync(reviewerUserEmail);
            await userManager.AddToRoleAsync(regularUser,Constants.User);
            await userManager.AddToRoleAsync(reviewerUser, Constants.Reviewer);
        }


        public async Task<IdentityResult> CreateRoleIfNeeded(string role)
        {
            IdentityResult IR = null;
            var roleManager = _IServiceProvider.GetService<RoleManager<DPARole>>();

            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new DPARole(role));
            }
            return IR;
        }

        public async Task<IdentityResult> CreateUserIfNeeded(string userEmail, int departmentId, string FirstName, string LastName, string PhoneNumber, string Division)
        {
            IdentityResult IR = null;
            var userManager = _IServiceProvider.GetService<UserManager<DPAUser>>();
            var ILOVService = _IServiceProvider.GetService<ILOVService>();
            DPAUser locatedUser = await userManager.FindByEmailAsync(userEmail);
            if (locatedUser == null)
            {
                var aDepartment = ILOVService.GetDepartment(departmentId);
                var user = new DPAUser
                {
                    UserName = userEmail,
                    Email = userEmail,
                    FirstName = FirstName,
                    LastName = LastName,
                    PhoneNumber = PhoneNumber,
                    PhoneNumberExtension = null,
                    Department = aDepartment,
                    Division = Division
                };
                IR = await userManager.CreateAsync(user, "Passw0rd....");
            }
            return IR;
        }


    }
}