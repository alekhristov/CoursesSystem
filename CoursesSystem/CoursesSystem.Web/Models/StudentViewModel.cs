using System;

namespace CoursesSystem.Web.Models
{
    public class StudentViewModel
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public Guid FacultyNumber { get; set; }
    }
}
