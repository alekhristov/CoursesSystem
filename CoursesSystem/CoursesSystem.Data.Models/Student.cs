using CoursesSystem.Data.Models.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoursesSystem.Data.Models
{
    public class Student : IdentityUser, IAuditable, IDeletable
    {
        public Student()
        {
            this.Courses = new HashSet<StudentCourse>();
        }

        [StringLength(20, MinimumLength = 2, ErrorMessage = "Invalid FirstName format!")]
        public string FirstName { get; set; }

        [StringLength(20, MinimumLength = 2, ErrorMessage = "Invalid LastName format!")]
        public string LastName { get; set; }

        public Guid FacultyNumber { get; set; }

        public bool IsDeleted { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeletedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }

        /// <summary>
        /// Navigation property - represents related entity
        /// </summary>
        public ICollection<StudentCourse> Courses { get; set; }
    }
}
