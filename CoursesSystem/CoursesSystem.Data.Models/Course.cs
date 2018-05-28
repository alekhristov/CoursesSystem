using CoursesSystem.Data.Models.Abstracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoursesSystem.Data.Models
{
    public class Course : DataModel
    {

        public Course()
        {
            this.Students = new HashSet<StudentCourse>();
        }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "Invalid Name format!")]
        public string Name { get; set; }

        public int Credits { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "Invalid LecturerName format!")]
        public string LecturerName { get; set; }

        /// <summary>
        /// Navigation property - represents related entity
        /// </summary>
        public ICollection<StudentCourse> Students { get; set; }
    }
}
