using CoursesSystem.Data.Models;
using CoursesSystem.Data.Repository.Contracts;
using CoursesSystem.Data.Saver.Contracts;
using CoursesSystem.Services.Data.Contracts;
using CoursesSystem.Utils.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace CoursesSystem.Services.Data.UnitTests.CourseServiceTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_WhenInvokedWithValidParameters()
        {
            //Arrange
            var coursesMock = new Mock<IRepository<Course>>();
            var studentCoursesMock = new Mock<IRepository<StudentCourse>>();
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();

            //Act
            var courseService = new CourseService(
                coursesMock.Object,
                studentCoursesMock.Object,
                mapperMock.Object,
                saverMock.Object);

            //Assert
            Assert.IsNotNull(courseService);
            Assert.IsInstanceOfType(courseService, typeof(ICourseService));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullCoursesParameter()
        {
            //Arrange
            //var coursesMock = new Mock<IRepository<Course>>();
            var studentCoursesMock = new Mock<IRepository<StudentCourse>>();
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CourseService(
                null,
                studentCoursesMock.Object,
                mapperMock.Object,
                saverMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullStudentCoursesParameter()
        {
            //Arrange
            var coursesMock = new Mock<IRepository<Course>>();
            //var studentCoursesMock = new Mock<IRepository<StudentCourse>>();
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CourseService(
                coursesMock.Object,
                null,
                mapperMock.Object,
                saverMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullMapperParameter()
        {
            //Arrange
            var coursesMock = new Mock<IRepository<Course>>();
            var studentCoursesMock = new Mock<IRepository<StudentCourse>>();
            //var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CourseService(
                coursesMock.Object,
                studentCoursesMock.Object,
                null,
                saverMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullSaverParameter()
        {
            //Arrange
            var coursesMock = new Mock<IRepository<Course>>();
            var studentCoursesMock = new Mock<IRepository<StudentCourse>>();
            var mapperMock = new Mock<IMappingProvider>();
            //var saverMock = new Mock<ISaver>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CourseService(
                coursesMock.Object,
                studentCoursesMock.Object,
                mapperMock.Object,
                null));
        }
    }
}
