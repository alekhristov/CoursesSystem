using System;
using System.ComponentModel.DataAnnotations;

namespace CoursesSystem.Web.Models
{
    public class StudentViewModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Invalid FirstName format!")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Invalid LastName format!")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public Guid FacultyNumber { get; set; }
    }
}
