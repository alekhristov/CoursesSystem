using CoursesSystem.Data.Models;
using CoursesSystem.Data.Repository.Contracts;
using CoursesSystem.Data.Saver.Contracts;
using CoursesSystem.Services.Data.Contracts;
using CoursesSystem.Utils.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace CoursesSystem.Services.Data.UnitTests.StudentService_Should
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_WhenInvokedWithValidParameters()
        {
            //Arrange
            var studentMock = new Mock<IRepository<Student>>();
            var coursesMock = new Mock<IRepository<Course>>();
            var studentCoursesMock = new Mock<IRepository<StudentCourse>>();
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();

            //Act
            var studentService = new StudentService(
                studentMock.Object,
                coursesMock.Object,
                studentCoursesMock.Object,
                mapperMock.Object,
                saverMock.Object);

            //Assert
            Assert.IsNotNull(studentService);
            Assert.IsInstanceOfType(studentService, typeof(IStudentService));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullStudentParameter()
        {
            //Arrange
            //var studentMock = new Mock<IRepository<Student>>();
            var coursesMock = new Mock<IRepository<Course>>();
            var studentCoursesMock = new Mock<IRepository<StudentCourse>>();
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new StudentService(
                null,
                coursesMock.Object,
                studentCoursesMock.Object,
                mapperMock.Object,
                saverMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullCoursesParameter()
        {
            //Arrange
            var studentMock = new Mock<IRepository<Student>>();
            //var coursesMock = new Mock<IRepository<Course>>();
            var studentCoursesMock = new Mock<IRepository<StudentCourse>>();
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new StudentService(
                studentMock.Object,
                null,
                studentCoursesMock.Object,
                mapperMock.Object,
                saverMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullStudentCoursesParameter()
        {
            //Arrange
            var studentMock = new Mock<IRepository<Student>>();
            var coursesMock = new Mock<IRepository<Course>>();
            //var studentCoursesMock = new Mock<IRepository<StudentCourse>>();
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new StudentService(
                studentMock.Object,
                coursesMock.Object,
                null,
                mapperMock.Object,
                saverMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullMapperParameter()
        {
            //Arrange
            var studentMock = new Mock<IRepository<Student>>();
            var coursesMock = new Mock<IRepository<Course>>();
            var studentCoursesMock = new Mock<IRepository<StudentCourse>>();
            //var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new StudentService(
                studentMock.Object,
                coursesMock.Object,
                studentCoursesMock.Object,
                null,
                saverMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullSaverParameter()
        {
            //Arrange
            var studentMock = new Mock<IRepository<Student>>();
            var coursesMock = new Mock<IRepository<Course>>();
            var studentCoursesMock = new Mock<IRepository<StudentCourse>>();
            var mapperMock = new Mock<IMappingProvider>();
            //var saverMock = new Mock<ISaver>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new StudentService(
                studentMock.Object,
                coursesMock.Object,
                studentCoursesMock.Object,
                mapperMock.Object,
                null));
        }
    }
}
