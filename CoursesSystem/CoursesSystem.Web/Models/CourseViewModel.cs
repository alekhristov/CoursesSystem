using System;

namespace CoursesSystem.Web.Models
{
    public class CourseViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Credits { get; set; }

        public string LecturerName { get; set; }

        public bool IsRegistered { get; set; }
    }
}
