using System;
using System.ComponentModel.DataAnnotations;

namespace CoursesSystem.Web.Models
{
    public class StudentViewModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 20 characters.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 20 characters.")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public Guid FacultyNumber { get; set; }
    }
}
