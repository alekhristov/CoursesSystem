using CoursesSystem.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoursesSystem.Services.Data.Contracts
{
    public interface IStudentService
    {
        Task<IEnumerable<CourseDto>> GetAllRegisteredCourses(string studentId);

        Task<IEnumerable<CourseDto>> GetAllNonRegisteredCourses(string studentId);
    }
}
