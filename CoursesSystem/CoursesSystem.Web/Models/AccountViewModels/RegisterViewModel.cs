using System;
using System.ComponentModel.DataAnnotations;

namespace CoursesSystem.Web.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "First name")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Invalid FirstName format!")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Invalid LastName format!")]
        public string LastName { get; set; }

        [Display(Name = "Faculty Number")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Faculty number must contain 32 alphanumeric characters and four hyphens!")]
        public Guid? FacultyNumber { get; set; }
    }
}
