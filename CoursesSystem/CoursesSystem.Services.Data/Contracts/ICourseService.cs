using CoursesSystem.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoursesSystem.Services.Data.Contracts
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDto>> GetAllAvailableCourses();

        void AddCourse(CourseDto course);

        void DeleteCourse(Guid courseId);

        void EditCourseName(Guid courseId, string courseNewName);

        void EditCourseCredits(Guid courseId, int courseNewCredits);

        void EditCourseLecturerName(Guid courseId, string courseNewLecturerName);
    }
}
