using Bytes2you.Validation;
using CoursesSystem.Data.Models;
using CoursesSystem.Data.Repository.Contracts;
using CoursesSystem.Data.Saver.Contracts;
using CoursesSystem.DTO;
using CoursesSystem.Services.Data.Contracts;
using CoursesSystem.Utils.Contracts;
using System;
using System.Linq;

namespace CoursesSystem.Services.Data
{
    public class StudentCourseService : IStudentCourseService
    {
        private readonly IRepository<StudentCourse> studentCourses;
        private readonly IMappingProvider mapper;
        private readonly ISaver saver;

        public StudentCourseService(
          IRepository<StudentCourse> studentCourses,
          IMappingProvider mapper,
          ISaver saver)
        {
            Guard.WhenArgument(studentCourses, "Courses can not be null!").IsNull().Throw();
            Guard.WhenArgument(mapper, "Mapper can not be null!").IsNull().Throw();
            Guard.WhenArgument(saver, "Saver can not be null!").IsNull().Throw();

            this.studentCourses = studentCourses;
            this.mapper = mapper;
            this.saver = saver;
        }

        public StudentCourseDto GetStudentCourseByIds(Guid courseId, string studentId)
        {
            Guard.WhenArgument(studentId, "Student Course can not be null!").IsNullOrEmpty().Throw();

            var studentCourse = this.studentCourses.All
                .FirstOrDefault(sc => sc.CourseId == courseId && sc.StudentId == studentId);
            Guard.WhenArgument(studentCourse, "Student Course can not be null!").IsNull().Throw();

            var studentCourseDto = this.mapper.MapTo<StudentCourseDto>(studentCourse);
            Guard.WhenArgument(studentCourseDto, "Student Course Dto can not be null!").IsNull().Throw();

            return studentCourseDto;
        }

        public void AddCourseToStudent(Guid courseId, string studentId)
        {
            Guard.WhenArgument(studentId, "StudentId can not be null!").IsNullOrWhiteSpace().Throw();

            var studentCourseDto = new StudentCourseDto() { StudentId = studentId, CourseId = courseId };

            var studentCourse = mapper.MapTo<StudentCourse>(studentCourseDto);
            Guard.WhenArgument(studentCourse, "Student Course can not be null!").IsNull().Throw();

            var checkIfObjectAlreadyExists = this.studentCourses.AllAndDeleted
                .FirstOrDefault(sc => sc.CourseId == courseId && sc.StudentId == studentId);

            if (checkIfObjectAlreadyExists != null)
            {
                checkIfObjectAlreadyExists.IsDeleted = false;
            }
            else
            {
                this.studentCourses.Add(studentCourse);
            }
            this.saver.SaveChanges();
        }

        public void DeleteCourseFromStudent(Guid courseId, string studentId)
        {
            Guard.WhenArgument(studentId, "StudentId can not be null!").IsNullOrWhiteSpace().Throw();

            var studentCourseDto = this.GetStudentCourseByIds(courseId, studentId);

            var studentCourse = this.mapper.MapTo<StudentCourse>(studentCourseDto);
            Guard.WhenArgument(studentCourse, "Student Course can not be null!").IsNull().Throw();

            this.studentCourses.Delete(studentCourse);
            this.saver.SaveChanges();
        }
    }
}
