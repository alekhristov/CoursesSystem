using CoursesSystem.Data.Models;
using CoursesSystem.Services.Data.Contracts;
using CoursesSystem.Utils.Contracts;
using CoursesSystem.Web.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace CoursesSystem.Web.UnitTests.ControllersTests.CoursesControllerTests
{
    [TestClass]
    public class Constructor_Should
    {
        public static Mock<UserManager<TUser>> MockUserManager<TUser>() where TUser : class
        {
            var store = new Mock<IUserStore<TUser>>();
            var mgr = new Mock<UserManager<TUser>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Object.UserValidators.Add(new UserValidator<TUser>());
            mgr.Object.PasswordValidators.Add(new PasswordValidator<TUser>());
            return mgr;
        }

        [TestMethod]
        public void CreateInstance_WhenInvokedWithValidParameters()
        {
            //Arrange
            var courseServiceMock = new Mock<ICourseService>();
            var studentServiceMock = new Mock<IStudentService>();
            var studentCoursesServiceMock = new Mock<IStudentCourseService>();
            var mapperMock = new Mock<IMappingProvider>();
            var userManagerMock = MockUserManager<Student>();

            //Act
            var coursesController = new CoursesController(
                courseServiceMock.Object,
                studentServiceMock.Object,
                studentCoursesServiceMock.Object,
                mapperMock.Object,
                userManagerMock.Object);

            //Assert
            Assert.IsNotNull(coursesController);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullCourseServiceParameter()
        {
            //Arrange
            //var courseServiceMock = new Mock<ICourseService>();
            var studentServiceMock = new Mock<IStudentService>();
            var studentCoursesServiceMock = new Mock<IStudentCourseService>();
            var mapperMock = new Mock<IMappingProvider>();
            var userManagerMock = MockUserManager<Student>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CoursesController(
                null,
                studentServiceMock.Object,
                studentCoursesServiceMock.Object,
                mapperMock.Object,
                userManagerMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullStudentServiceParameter()
        {
            //Arrange
            var courseServiceMock = new Mock<ICourseService>();
            //var studentServiceMock = new Mock<IStudentService>();
            var studentCoursesServiceMock = new Mock<IStudentCourseService>();
            var mapperMock = new Mock<IMappingProvider>();
            var userManagerMock = MockUserManager<Student>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CoursesController(
                courseServiceMock.Object,
                null,
                studentCoursesServiceMock.Object,
                mapperMock.Object,
                userManagerMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullStudentCourseServiceParameter()
        {
            //Arrange
            var courseServiceMock = new Mock<ICourseService>();
            var studentServiceMock = new Mock<IStudentService>();
            //var studentCoursesServiceMock = new Mock<IStudentCourseService>();
            var mapperMock = new Mock<IMappingProvider>();
            var userManagerMock = MockUserManager<Student>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CoursesController(
                courseServiceMock.Object,
                studentServiceMock.Object,
                null,
                mapperMock.Object,
                userManagerMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullMapperParameter()
        {
            //Arrange
            var courseServiceMock = new Mock<ICourseService>();
            var studentServiceMock = new Mock<IStudentService>();
            var studentCoursesServiceMock = new Mock<IStudentCourseService>();
            //var mapperMock = new Mock<IMappingProvider>();
            var userManagerMock = MockUserManager<Student>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CoursesController(
                courseServiceMock.Object,
                studentServiceMock.Object,
                studentCoursesServiceMock.Object,
                null,
                userManagerMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullUserManagerParameter()
        {
            //Arrange
            var courseServiceMock = new Mock<ICourseService>();
            var studentServiceMock = new Mock<IStudentService>();
            var studentCoursesServiceMock = new Mock<IStudentCourseService>();
            var mapperMock = new Mock<IMappingProvider>();
            //var userManagerMock = MockUserManager<Student>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CoursesController(
                courseServiceMock.Object,
                studentServiceMock.Object,
                studentCoursesServiceMock.Object,
                mapperMock.Object,
                null));
        }
    }
}
