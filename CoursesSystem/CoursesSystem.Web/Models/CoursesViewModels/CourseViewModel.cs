using System;
using System.ComponentModel.DataAnnotations;

namespace CoursesSystem.Web.Models.CoursesViewModels
{
    public class CourseViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Course name must be between 2 and 100 characters.")]
        public string Name { get; set; }

        public int Credits { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "Lecturer name must be between 2 and 80 characters.")]
        public string LecturerName { get; set; }

        public bool IsRegistered { get; set; }
    }
}
