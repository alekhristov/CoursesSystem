using System;
using System.ComponentModel.DataAnnotations;

namespace CoursesSystem.Web.Models.CoursesViewModels
{
    public class CourseViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Invalid Name format!")]
        public string Name { get; set; }

        public int Credits { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Invalid LecturerName format!")]
        public string LecturerName { get; set; }

        public bool IsRegistered { get; set; }
    }
}
