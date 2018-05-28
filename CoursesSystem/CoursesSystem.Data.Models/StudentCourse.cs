using CoursesSystem.Data.Models.Contracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace CoursesSystem.Data.Models
{
    public class StudentCourse : IAuditable, IDeletable
    {
        public string StudentId { get; set; }
        public Student Student { get; set; }

        public Guid CourseId { get; set; }
        public Course Course { get; set; }

        public bool IsDeleted { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeletedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }
    }
}
