using CoursesSystem.Data.Models;
using CoursesSystem.DTO;
using System;

namespace CoursesSystem.Services.Data.Contracts
{
    public interface IStudentCourseService
    {
        StudentCourse GetStudentCourseByIds(Guid courseId, string studentId);

        void AddCourseToStudent(Guid courseId, string studentId);

        void DeleteCourseFromStudent(Guid courseId, string studentId);
    }
}
