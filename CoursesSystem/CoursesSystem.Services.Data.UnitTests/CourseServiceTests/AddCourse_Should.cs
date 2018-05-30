using CoursesSystem.Data.Models;
using CoursesSystem.Data.Repository.Contracts;
using CoursesSystem.Data.Saver.Contracts;
using CoursesSystem.DTO;
using CoursesSystem.Utils.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace CoursesSystem.Services.Data.UnitTests.CourseServiceTests
{
    [TestClass]
    public class AddCourse_Should
    {
        [TestMethod]
        public void CallCourseAddMethodOnce_WhenInvokedWithValidParameters()
        {
            //Arrange
            var coursesMock = new Mock<IRepository<Course>>();
            var studentCoursesMock = new Mock<IRepository<StudentCourse>>();
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();

            var courseDto = new CourseDto()
            {
                Id = new Guid("12367a78-faf1-40c9-abcd-0c3131a03312"),
                Name = "DSA",
                Credits = 5,
                LecturerName = "Sasho Dikov"
            };

            var course = new Course()
            {
                Id = new Guid("12367a78-faf1-40c9-abcd-0c3131a03312"),
                Name = "DSA",
                Credits = 5,
                LecturerName = "Sasho Dikov"
            };

            mapperMock
                .Setup(x => x.MapTo<Course>(courseDto))
                .Returns(course);

            var courseService = new CourseService(
                coursesMock.Object,
                studentCoursesMock.Object,
                mapperMock.Object,
                saverMock.Object);

            //Act
            courseService.AddCourse(courseDto);

            //Assert
            coursesMock.Verify(x => x.Add(course), Times.Once);
        }

        [TestMethod]
        public void CallSaverSaveChangesMethodOnce_WhenInvokedWithValidParameters()
        {
            //Arrange
            var coursesMock = new Mock<IRepository<Course>>();
            var studentCoursesMock = new Mock<IRepository<StudentCourse>>();
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();

            var courseDto = new CourseDto()
            {
                Id = new Guid("12367a78-faf1-40c9-abcd-0c3131a03312"),
                Name = "DSA",
                Credits = 5,
                LecturerName = "Sasho Dikov"
            };

            var course = new Course()
            {
                Id = new Guid("12367a78-faf1-40c9-abcd-0c3131a03312"),
                Name = "DSA",
                Credits = 5,
                LecturerName = "Sasho Dikov"
            };

            mapperMock
                .Setup(x => x.MapTo<Course>(courseDto))
                .Returns(course);

            var courseService = new CourseService(
                coursesMock.Object,
                studentCoursesMock.Object,
                mapperMock.Object,
                saverMock.Object);

            //Act
            courseService.AddCourse(courseDto);

            //Assert
            saverMock.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullCourseDtoParameter()
        {
            //Arrange
            var coursesMock = new Mock<IRepository<Course>>();
            var studentCoursesMock = new Mock<IRepository<StudentCourse>>();
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();

            var courseDto = new CourseDto()
            {
                Id = new Guid("12367a78-faf1-40c9-abcd-0c3131a03312"),
                Name = "DSA",
                Credits = 5,
                LecturerName = "Sasho Dikov"
            };

            var course = new Course()
            {
                Id = new Guid("12367a78-faf1-40c9-abcd-0c3131a03312"),
                Name = "DSA",
                Credits = 5,
                LecturerName = "Sasho Dikov"
            };

            mapperMock
                .Setup(x => x.MapTo<Course>(courseDto))
                .Returns(course);

            var courseService = new CourseService(
                coursesMock.Object,
                studentCoursesMock.Object,
                mapperMock.Object,
                saverMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => courseService.AddCourse(null));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenMapperMapToMethodReturnsNull()
        {
            //Arrange
            var coursesMock = new Mock<IRepository<Course>>();
            var studentCoursesMock = new Mock<IRepository<StudentCourse>>();
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();

            var courseDto = new CourseDto()
            {
                Id = new Guid("12367a78-faf1-40c9-abcd-0c3131a03312"),
                Name = "DSA",
                Credits = 5,
                LecturerName = "Sasho Dikov"
            };

            var course = new Course()
            {
                Id = new Guid("12367a78-faf1-40c9-abcd-0c3131a03312"),
                Name = "DSA",
                Credits = 5,
                LecturerName = "Sasho Dikov"
            };

            mapperMock
                .Setup(x => x.MapTo<Course>(courseDto))
                .Returns((Course)null);

            var courseService = new CourseService(
                coursesMock.Object,
                studentCoursesMock.Object,
                mapperMock.Object,
                saverMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => courseService.AddCourse(courseDto));
        }
    }
}