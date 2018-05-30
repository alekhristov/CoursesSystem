using Bytes2you.Validation;
using CoursesSystem.Data.Models;
using CoursesSystem.Data.Repository.Contracts;
using CoursesSystem.Data.Saver.Contracts;
using CoursesSystem.DTO;
using CoursesSystem.Services.Data.Contracts;
using CoursesSystem.Utils;
using CoursesSystem.Utils.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesSystem.Services.Data
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> courses;
        private readonly IRepository<StudentCourse> studentCourses;
        private readonly IMappingProvider mapper;
        private readonly ISaver saver;

        public CourseService(
            IRepository<Course> courses, 
            IRepository<StudentCourse> studentCourses,
            IMappingProvider mapper, 
            ISaver saver)
        {
            Guard.WhenArgument(courses, "Courses can not be null!").IsNull().Throw();
            Guard.WhenArgument(studentCourses, "StudentCourses can not be null!").IsNull().Throw();
            Guard.WhenArgument(mapper, "Mapper can not be null!").IsNull().Throw();
            Guard.WhenArgument(saver, "Saver can not be null!").IsNull().Throw();

            this.courses = courses;
            this.studentCourses = studentCourses;
            this.mapper = mapper;
            this.saver = saver;
        }

        public void AddCourse(CourseDto courseDto)
        {
            Guard.WhenArgument(courseDto, "Course Dto can not be null!").IsNull().Throw();

            //courseDto.LecturerName = courseDto.LecturerName.UppercaseFirstLetter();

            var course = this.mapper.MapTo<Course>(courseDto);
            Guard.WhenArgument(course, "Course can not be null!").IsNull().Throw();

            this.courses.Add(course);
            this.saver.SaveChanges();
        }

        public void DeleteCourse(Guid courseId)
        {
            var course = this.courses.All.FirstOrDefault(c => c.Id == courseId);
            Guard.WhenArgument(course, "Course can not be null!").IsNull().Throw();

            this.courses.Delete(course);

            var studentCourses = this.studentCourses.All
                .Include(sc => sc.Course)
                .Include(sc => sc.Student)
                .Where(c => c.CourseId == courseId)
                .ToList();

            foreach (var item in studentCourses)
            {
                item.IsDeleted = true;
            }

            this.saver.SaveChanges();
        }

        public void EditCourseCredits(Guid courseId, int courseNewCredits)
        {
            var course = this.courses.All.FirstOrDefault(c => c.Id == courseId);
            Guard.WhenArgument(course, "Course can not be null!").IsNull().Throw();

            course.Credits = courseNewCredits;

            this.courses.Update(course);
            this.saver.SaveChanges();
        }

        public void EditCourseLecturerName(Guid courseId, string courseNewLecturerName)
        {
            Guard.WhenArgument(courseNewLecturerName, "LecturerName can not be null!").IsNullOrWhiteSpace().Throw();

            var course = this.courses.All.FirstOrDefault(c => c.Id == courseId);
            Guard.WhenArgument(course, "Course can not be null!").IsNull().Throw();

            course.LecturerName = courseNewLecturerName;

            this.courses.Update(course);
            this.saver.SaveChanges();
        }

        public void EditCourseName(Guid courseId, string courseNewName)
        {
            Guard.WhenArgument(courseNewName, "Name can not be null!").IsNullOrWhiteSpace().Throw();

            var course = this.courses.All.FirstOrDefault(c => c.Id == courseId);
            Guard.WhenArgument(course, "Course can not be null!").IsNull().Throw();

            course.Name = courseNewName;

            this.courses.Update(course);
            this.saver.SaveChanges();
        }

        public async Task<IEnumerable<CourseDto>> GetAllAvailableCourses()
        {
            var allCourses = await this.courses.All
                .OrderBy(c => c.Name)
                .ToListAsync();

            Guard.WhenArgument(allCourses, "All courses can not be null!").IsNull().Throw();

            var allCoursesDto = this.mapper.ProjectTo<Course, CourseDto>(allCourses);
            Guard.WhenArgument(allCoursesDto, "All courses Dto can not be null!").IsNull().Throw();

            return allCoursesDto;
        }

        public async Task<CourseDto> GetCourseById(Guid courseId)
        {
            var course = await this.courses.All
                .FirstOrDefaultAsync(c => c.Id == courseId);

            Guard.WhenArgument(course, "Course can not be null!").IsNull().Throw();

            var courseDto = this.mapper.MapTo<CourseDto>(course);
            Guard.WhenArgument(courseDto, "Course Dto can not be null!").IsNull().Throw();

            return courseDto;
        }
    }
}
