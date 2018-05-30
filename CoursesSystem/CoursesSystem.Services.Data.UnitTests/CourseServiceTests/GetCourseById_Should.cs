using CoursesSystem.Data.Models;
using CoursesSystem.Data.Repository.Contracts;
using CoursesSystem.Data.Saver.Contracts;
using CoursesSystem.DTO;
using CoursesSystem.Utils.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesSystem.Services.Data.UnitTests.CourseServiceTests
{
    [TestClass]
    public class GetCourseById_Should
    {
        [TestMethod]
        public async Task ReturnCourseDto_WhenInvokedWithValidParameters()
        {
            ////Arrange
            //var coursesMock = new Mock<IRepository<Course>>();
            //var studentCoursesMock = new Mock<IRepository<StudentCourse>>();
            //var mapperMock = new Mock<IMappingProvider>();
            //var saverMock = new Mock<ISaver>();

            //var firstCourse = new Course()
            //{
            //    Id = new Guid("12367a78-faf1-40c9-abcd-0c3131a03312"),
            //    Name = "DSA",
            //    Credits = 5,
            //    LecturerName = "Sasho Dikov"
            //};

            //var secondCourse = new Course()
            //{
            //    Id = new Guid("12367a78-0000-40c9-abcd-0c3131a03312"),
            //    Name = "Design Patterns",
            //    Credits = 4,
            //    LecturerName = "Marto Stamatov"
            //};

            //var courses = new List<Course>()
            //{
            //    firstCourse,
            //    secondCourse
            //}
            //.AsQueryable();

            //var firstCourseDto = new CourseDto()
            //{
            //    Id = new Guid("12367a78-faf1-40c9-abcd-0c3131a03312"),
            //    Name = "DSA",
            //    Credits = 5,
            //    LecturerName = "Sasho Dikov"
            //};

            //var secondCourseDto = new CourseDto()
            //{
            //    Id = new Guid("12367a78-0000-40c9-abcd-0c3131a03312"),
            //    Name = "Design Patterns",
            //    Credits = 4,
            //    LecturerName = "Marto Stamatov"
            //};

            //IEnumerable<CourseDto> coursesDto = new List<CourseDto>()
            //{
            //    firstCourseDto,
            //    secondCourseDto
            //};

            //coursesMock
            //    .Setup(x => x.All)
            //    .Returns(courses);

            //var test = await Task.FromResult(courses.ToList());

            //mapperMock
            //    .Setup(x => x.ProjectTo<Course, CourseDto>(test))
            //    .Returns(coursesDto);

            //var courseService = new CourseService(
            //coursesMock.Object,
            //studentCoursesMock.Object,
            //mapperMock.Object,
            //saverMock.Object);

            ////Act
            //var actualResult = await courseService.GetCourseById(firstCourse.Id);

            ////Assert
            //Assert.IsNotNull(actualResult);
            //Assert.IsInstanceOfType(actualResult, typeof(CourseDto));
        }
    }
}
