using System;

namespace CoursesSystem.DTO
{
    public class CourseDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Credits { get; set; }

        public string LecturerName { get; set; }
    }
}
