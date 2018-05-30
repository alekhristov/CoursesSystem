using CoursesSystem.Data.Models;
using CoursesSystem.Data.Repository.Contracts;
using CoursesSystem.Data.Saver.Contracts;
using CoursesSystem.Services.Data.Contracts;
using CoursesSystem.Utils.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace CoursesSystem.Services.Data.UnitTests.StudentCourseService_Should
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_WhenInvokedWithValidParameters()
        {
            //Arrange
            var studentCoursesMock = new Mock<IRepository<StudentCourse>>();
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();

            //Act
            var studentCourseService = new StudentCourseService(
                studentCoursesMock.Object,
                mapperMock.Object,
                saverMock.Object);

            //Assert
            Assert.IsNotNull(studentCourseService);
            Assert.IsInstanceOfType(studentCourseService, typeof(IStudentCourseService));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullStudentCoursesParameter()
        {
            //Arrange
            //var studentCoursesMock = new Mock<IRepository<StudentCourse>>();
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new StudentCourseService(
                null,
                mapperMock.Object,
                saverMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullMapperParameter()
        {
            //Arrange
            var studentCoursesMock = new Mock<IRepository<StudentCourse>>();
            //var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new StudentCourseService(
                studentCoursesMock.Object,
                null,
                saverMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullSaverParameter()
        {
            //Arrange
            var studentCoursesMock = new Mock<IRepository<StudentCourse>>();
            var mapperMock = new Mock<IMappingProvider>();
            //var saverMock = new Mock<ISaver>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new StudentCourseService(
                studentCoursesMock.Object,
                mapperMock.Object,
                null));
        }
    }
}
