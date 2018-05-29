using System.Collections.Generic;

namespace CoursesSystem.Web.Models.CoursesViewModels
{
    public class CoursesViewModel
    {
        public IEnumerable<CourseViewModel> Courses { get; set; }
    }
}
