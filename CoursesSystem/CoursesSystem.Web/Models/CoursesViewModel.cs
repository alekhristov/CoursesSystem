using System.Collections.Generic;

namespace CoursesSystem.Web.Models
{
    public class CoursesViewModel
    {
        public IEnumerable<CourseViewModel> Courses { get; set; }
    }
}
