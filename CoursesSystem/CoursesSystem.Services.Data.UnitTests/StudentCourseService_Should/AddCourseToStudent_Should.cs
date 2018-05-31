using CoursesSystem.Data.Models;
using CoursesSystem.Data.Repository.Contracts;
using CoursesSystem.Data.Saver.Contracts;
using CoursesSystem.DTO;
using CoursesSystem.Utils.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace CoursesSystem.Services.Data.UnitTests.StudentCourseService_Should
{
    [TestClass]
    public class AddCourseToStudent_Should
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
            Assert.ThrowsException<ArgumentNullException>(() => studentCourseService.AddCourseToStudent(Guid.NewGuid(), null));
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
            Assert.ThrowsException<ArgumentException>(() => studentCourseService.AddCourseToStudent(Guid.NewGuid(), string.Empty));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenMapperMapToMethodReturnsNull()
        {
            //Arrange
            var studentCoursesMock = new Mock<IRepository<StudentCourse>>();
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();

            var studentCourseDto = new StudentCourseDto()
            {
                CourseId = Guid.NewGuid(),
                StudentId = "uniqueId"
            };

            var studentCourse = new StudentCourse()
            {
                CourseId = studentCourseDto.CourseId,
                StudentId = studentCourseDto.StudentId
            };

            mapperMock
                .Setup(x => x.MapTo<StudentCourse>(studentCourseDto))
                .Returns((StudentCourse)null);

            var studentCourseService = new StudentCourseService(
                studentCoursesMock.Object,
                mapperMock.Object,
                saverMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => studentCourseService.AddCourseToStudent(studentCourseDto.CourseId, studentCourseDto.StudentId));
        }
    }
}
