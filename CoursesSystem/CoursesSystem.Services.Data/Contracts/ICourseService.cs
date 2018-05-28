using CoursesSystem.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoursesSystem.Services.Data.Contracts
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDto>> GetAllAvailableCourses();

        Task<bool> AddCourse(CourseDto course);

        Task<bool> DeleteCourse(Guid courseId);

        Task<bool> EditCourseName(Guid courseId, string courseNewName);

        Task<bool> EditCourseCredits(Guid courseId, int courseNewCredits);

        Task<bool> EditCourseLecturerName(Guid courseId, string courseNewLecturerName);
    }
}
