using Bytes2you.Validation;
using CoursesSystem.Data.Models;
using CoursesSystem.Data.Repository.Contracts;
using CoursesSystem.Data.Saver.Contracts;
using CoursesSystem.DTO;
using CoursesSystem.Services.Data.Contracts;
using CoursesSystem.Utils.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesSystem.Services.Data
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> student;
        private readonly IRepository<Course> courses;
       
        private readonly IMappingProvider mapper;
        private readonly ISaver saver;

        public StudentService(
            IRepository<Student> student, 
            IRepository<Course> courses, 
            IMappingProvider mapper,
            ISaver saver)
        {
            Guard.WhenArgument(student, "Student can not be null!").IsNull().Throw();
            Guard.WhenArgument(courses, "Courses can not be null!").IsNull().Throw();
            Guard.WhenArgument(mapper, "Mapper can not be null!").IsNull().Throw();
            Guard.WhenArgument(saver, "Saver can not be null!").IsNull().Throw();

            this.student = student;
            this.courses = courses;
            this.mapper = mapper;
            this.saver = saver;
        }

        public async Task<IEnumerable<CourseDto>> GetAllRegisteredCourses(string studentId)
        {
            Guard.WhenArgument(studentId, "StudentId can not be null!").IsNullOrEmpty().Throw();

            var student = await this.student.All
                .Include(x => x.Courses)
                .FirstOrDefaultAsync(x => x.Id == studentId);

            Guard.WhenArgument(student, "Student can not be null!").IsNull().Throw();

            var registeredCourses = student.Courses
                .Where(x => x.StudentId == studentId && !x.IsDeleted)?
                .Select(c => c.Course)
                .Where(c => !c.IsDeleted);

            Guard.WhenArgument(registeredCourses, "Courses can not be null!").IsNull().Throw();

            var registeredCoursesDto = this.mapper.ProjectTo<Course, CourseDto>(registeredCourses);
            Guard.WhenArgument(registeredCoursesDto, "Registered courses Dto can not be null!").IsNull().Throw();

            return registeredCoursesDto.OrderBy(c => c.Name);
        }

        public async Task<IEnumerable<CourseDto>> GetAllNonRegisteredCourses(string studentId)
        {
            Guard.WhenArgument(studentId, "StudentId can not be null!").IsNullOrEmpty().Throw();

            var registeredCoursesDto = await this.GetAllRegisteredCourses(studentId);

            var allCourses = await this.courses.All
                .ToListAsync();

            var allCoursesDto = this.mapper.ProjectTo<Course, CourseDto>(allCourses);
            Guard.WhenArgument(allCoursesDto, "All courses Dto can not be null!").IsNull().Throw();

            var nonRegisteredCoursesDto = allCoursesDto.Where(p => !registeredCoursesDto.Any(l => p.Id == l.Id));
            Guard.WhenArgument(nonRegisteredCoursesDto, "Non-registered courses Dto can not be null!").IsNull().Throw();

            return nonRegisteredCoursesDto.OrderBy(c => c.Name);
        }
    }
}
