using CoursesSystem.Data.Models;
using CoursesSystem.Data.Repository.Contracts;
using CoursesSystem.Data.Saver.Contracts;
using CoursesSystem.Utils.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace CoursesSystem.Services.Data.UnitTests.StudentCourseService_Should
{
    [TestClass]
    public class GetStudentCourseByIds_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullStudentIdParameter()
        {
            //Arrange
            var studentCoursesMock = new Mock<IRepository<StudentCourse>>();
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();

            var studentCourseService = new StudentCourseService(
                studentCoursesMock.Object,
                mapperMock.Object,
                saverMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => studentCourseService.GetStudentCourseByIds(Guid.NewGuid(), null));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidEmptyStudentIdParameter()
        {
            //Arrange
            var studentCoursesMock = new Mock<IRepository<StudentCourse>>();
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();

            var studentCourseService = new StudentCourseService(
                studentCoursesMock.Object,
                mapperMock.Object,
                saverMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => studentCourseService.GetStudentCourseByIds(Guid.NewGuid(), string.Empty));
        }
    }
}
