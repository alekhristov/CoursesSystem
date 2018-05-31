using CoursesSystem.Data.Models;
using CoursesSystem.Data.Repository.Contracts;
using CoursesSystem.Data.Saver.Contracts;
using CoursesSystem.Utils.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace CoursesSystem.Services.Data.UnitTests.StudentService_Should
{
    [TestClass]
    public class GetAllNonRegisteredCourses_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullStudentIdParameter()
        {
            //Arrange
            var studentMock = new Mock<IRepository<Student>>();
            var coursesMock = new Mock<IRepository<Course>>();
            var studentCoursesMock = new Mock<IRepository<StudentCourse>>();
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();

            var studentService = new StudentService(
                studentMock.Object,
                coursesMock.Object,
                studentCoursesMock.Object,
                mapperMock.Object,
                saverMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => studentService.GetAllNonRegisteredCourses(null));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidEmptyStudentIdParameter()
        {
            //Arrange
            var studentMock = new Mock<IRepository<Student>>();
            var coursesMock = new Mock<IRepository<Course>>();
            var studentCoursesMock = new Mock<IRepository<StudentCourse>>();
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();

            var studentService = new StudentService(
                studentMock.Object,
                coursesMock.Object,
                studentCoursesMock.Object,
                mapperMock.Object,
                saverMock.Object);

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentException>(() => studentService.GetAllNonRegisteredCourses(string.Empty));
        }
    }
}
