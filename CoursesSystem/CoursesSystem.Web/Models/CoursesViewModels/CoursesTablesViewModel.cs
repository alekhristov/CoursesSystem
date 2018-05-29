using System.Collections.Generic;

namespace CoursesSystem.Web.Models.CoursesViewModels
{
    public class CoursesTablesViewModel
    {
        public IEnumerable<CourseViewModel> RegisteredCourses { get; set; }

        public IEnumerable<CourseViewModel> NotRegisteredCourses { get; set; }
    }
}
