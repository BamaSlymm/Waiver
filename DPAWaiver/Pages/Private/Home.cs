using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DPAWaiver.Areas.Identity.Data;
using DPAWaiver.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;

namespace DPAWaiver.Pages.Private
{
    public class HomeModel : PageModel
    {
        private readonly UserManager<DPAUser> _userManager;
        private readonly SignInManager<DPAUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILOVService _ILOVService;

        public HomeModel(
                ILOVService iLOVService,
                UserManager<DPAUser> userManager,
                SignInManager<DPAUser> signInManager,
                IEmailSender emailSender)
        {
            _ILOVService = iLOVService;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public IEnumerable<SelectListItem> departments => _ILOVService.GetDepartmentsAsSelectListBySortOrder();

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Required]
            [Display(Name = "First Name")]
            [DataType(DataType.Text)]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            [DataType(DataType.Text)]
            public string LastName { get; set; }

            [Display(Name = "Extension")]
            public string PhoneNumberExtension { get; set; }

            [Required]
            [Display(Name = "Department")]
            public int DepartmentId { get; set; }

            [Display(Name = "Division")]
            public string Division { get; set; }

        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var userWithDepartment = _userManager.Users.Include(x => x.Department).Single(x => x.Id == user.Id);
            var userName = await _userManager.GetUserNameAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                Email = email,
                PhoneNumber = phoneNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DepartmentId = userWithDepartment.Department.ID,
                Division = user.Division,
                PhoneNumberExtension = user.PhoneNumberExtension
            };

            IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            Username = await _userManager.GetUserNameAsync(user);
            var userWithDepartment = _userManager.Users.Include(x => x.Department).Single(x => x.Id == user.Id);
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var email = await _userManager.GetEmailAsync(user);
            if (Input.Email != email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, Input.Email);
                if (!setEmailResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting email for user with ID '{userId}'.");
                }
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
                }
            }
            userWithDepartment.FirstName = Input.FirstName;
            userWithDepartment.LastName = Input.LastName;
            userWithDepartment.Division = Input.Division;
            userWithDepartment.PhoneNumberExtension = Input.PhoneNumberExtension;
            userWithDepartment.Department = _ILOVService.GetDepartment(Input.DepartmentId);
            await _userManager.UpdateAsync(userWithDepartment);
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }


            var userId = await _userManager.GetUserIdAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var parametersToAdd = new System.Collections.Generic.Dictionary<string, string>() { { "userId", userId }, { "code", code} };
            var initialUrl = string.Concat(
                            Request.Scheme,
                            "://",
                            Request.Host.ToUriComponent(),
                            Request.PathBase.ToUriComponent(),
                            "/Identity/Account/ConfirmEmail");
            var newUri = Microsoft.AspNetCore.WebUtilities.QueryHelpers.AddQueryString(initialUrl, parametersToAdd);
            
            await _emailSender.SendEmailAsync(
                email,
                "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(newUri)}'>clicking here</a>.");

            StatusMessage = "Verification email sent. Please check your email.";
            return RedirectToPage();
        }



    }
}
