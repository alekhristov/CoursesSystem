using CoursesSystem.Data.Models;
using CoursesSystem.DTO;
using CoursesSystem.Services.Data.Contracts;
using CoursesSystem.Utils.Contracts;
using CoursesSystem.Web.Controllers;
using CoursesSystem.Web.Models.CoursesViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoursesSystem.Web.UnitTests.ControllersTests.CoursesControllerTests
{
    [TestClass]
    public class Index_Should
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
        public void ThrowArgumentNullException_WhenGetAllAvailableCoursesReturnsNull()
        {
            //Arrange
            var courseServiceMock = new Mock<ICourseService>();
            var studentServiceMock = new Mock<IStudentService>();
            var studentCoursesServiceMock = new Mock<IStudentCourseService>();
            var mapperMock = new Mock<IMappingProvider>();
            var userManagerMock = MockUserManager<Student>();

            var student = new Student()
            {
                Id = "uniqueId",
                FirstName = "Marto",
                LastName = "Stamatov",
                FacultyNumber = new Guid("12367a78-faf1-40c9-abcd-0c3131a03312")
            };

            var firstCourse = new CourseDto()
            {
                Id = new Guid("12367a78-faf1-40c9-abcd-0c3131a03312"),
                Name = "DSA",
                Credits = 5,
                LecturerName = "Sasho Dikov"
            };

            var secondCourse = new CourseDto()
            {
                Id = new Guid("12367a78-0000-40c9-abcd-0c3131a03312"),
                Name = "Design Patterns",
                Credits = 4,
                LecturerName = "Marto Stamatov"
            };

            var courses = new List<CourseDto>()
            {
                firstCourse,
                secondCourse
            };

            var firstCourseModel = new CourseViewModel()
            {
                Id = new Guid("12367a78-faf1-40c9-abcd-0c3131a03312"),
                Name = "DSA",
                Credits = 5,
                LecturerName = "Sasho Dikov"
            };

            var secondCourseModel = new CourseViewModel()
            {
                Id = new Guid("12367a78-0000-40c9-abcd-0c3131a03312"),
                Name = "Design Patterns",
                Credits = 4,
                LecturerName = "Marto Stamatov"
            };

            var courseModels = new List<CourseViewModel>()
            {
                firstCourseModel,
                secondCourseModel
            };

            courseServiceMock
                .Setup(x => x.GetAllAvailableCourses())
                .ReturnsAsync((IEnumerable<CourseDto>)null);

            mapperMock
                .Setup(x => x.ProjectTo<CourseDto, CourseViewModel>(courses))
                .Returns(courseModels);

            studentServiceMock
                .Setup(x => x.GetAllRegisteredCourses(It.IsAny<string>()))
                .ReturnsAsync(courses);

            var coursesController = new CoursesController(
                courseServiceMock.Object,
                studentServiceMock.Object,
                studentCoursesServiceMock.Object,
                mapperMock.Object,
                userManagerMock.Object);

            var user = new Mock<ClaimsPrincipal>();
            coursesController.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user.Object }
            };

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => coursesController.Index());
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenMapperProjectToMethodReturnsNull()
        {
            //Arrange
            var courseServiceMock = new Mock<ICourseService>();
            var studentServiceMock = new Mock<IStudentService>();
            var studentCoursesServiceMock = new Mock<IStudentCourseService>();
            var mapperMock = new Mock<IMappingProvider>();
            var userManagerMock = MockUserManager<Student>();

            var student = new Student()
            {
                Id = "uniqueId",
                FirstName = "Marto",
                LastName = "Stamatov",
                FacultyNumber = new Guid("12367a78-faf1-40c9-abcd-0c3131a03312")
            };

            var firstCourse = new CourseDto()
            {
                Id = new Guid("12367a78-faf1-40c9-abcd-0c3131a03312"),
                Name = "DSA",
                Credits = 5,
                LecturerName = "Sasho Dikov"
            };

            var secondCourse = new CourseDto()
            {
                Id = new Guid("12367a78-0000-40c9-abcd-0c3131a03312"),
                Name = "Design Patterns",
                Credits = 4,
                LecturerName = "Marto Stamatov"
            };

            var courses = new List<CourseDto>()
            {
                firstCourse,
                secondCourse
            };

            var firstCourseModel = new CourseViewModel()
            {
                Id = new Guid("12367a78-faf1-40c9-abcd-0c3131a03312"),
                Name = "DSA",
                Credits = 5,
                LecturerName = "Sasho Dikov"
            };

            var secondCourseModel = new CourseViewModel()
            {
                Id = new Guid("12367a78-0000-40c9-abcd-0c3131a03312"),
                Name = "Design Patterns",
                Credits = 4,
                LecturerName = "Marto Stamatov"
            };

            var courseModels = new List<CourseViewModel>()
            {
                firstCourseModel,
                secondCourseModel
            };

            courseServiceMock
                .Setup(x => x.GetAllAvailableCourses())
                .ReturnsAsync(courses);

            mapperMock
                .Setup(x => x.ProjectTo<CourseDto, CourseViewModel>(courses))
                .Returns((List<CourseViewModel>)null);

            studentServiceMock
                .Setup(x => x.GetAllRegisteredCourses(It.IsAny<string>()))
                .ReturnsAsync(courses);

            var coursesController = new CoursesController(
                courseServiceMock.Object,
                studentServiceMock.Object,
                studentCoursesServiceMock.Object,
                mapperMock.Object,
                userManagerMock.Object);

            var user = new Mock<ClaimsPrincipal>();
            coursesController.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user.Object }
            };

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => coursesController.Index());
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenGetAllRegisteredCoursesMethodReturnsNull()
        {
            //Arrange
            var courseServiceMock = new Mock<ICourseService>();
            var studentServiceMock = new Mock<IStudentService>();
            var studentCoursesServiceMock = new Mock<IStudentCourseService>();
            var mapperMock = new Mock<IMappingProvider>();
            var userManagerMock = MockUserManager<Student>();

            var student = new Student()
            {
                Id = "uniqueId",
                FirstName = "Marto",
                LastName = "Stamatov",
                FacultyNumber = new Guid("12367a78-faf1-40c9-abcd-0c3131a03312")
            };

            var firstCourse = new CourseDto()
            {
                Id = new Guid("12367a78-faf1-40c9-abcd-0c3131a03312"),
                Name = "DSA",
                Credits = 5,
                LecturerName = "Sasho Dikov"
            };

            var secondCourse = new CourseDto()
            {
                Id = new Guid("12367a78-0000-40c9-abcd-0c3131a03312"),
                Name = "Design Patterns",
                Credits = 4,
                LecturerName = "Marto Stamatov"
            };

            var courses = new List<CourseDto>()
            {
                firstCourse,
                secondCourse
            };

            var firstCourseModel = new CourseViewModel()
            {
                Id = new Guid("12367a78-faf1-40c9-abcd-0c3131a03312"),
                Name = "DSA",
                Credits = 5,
                LecturerName = "Sasho Dikov"
            };

            var secondCourseModel = new CourseViewModel()
            {
                Id = new Guid("12367a78-0000-40c9-abcd-0c3131a03312"),
                Name = "Design Patterns",
                Credits = 4,
                LecturerName = "Marto Stamatov"
            };

            var courseModels = new List<CourseViewModel>()
            {
                firstCourseModel,
                secondCourseModel
            };

            courseServiceMock
                .Setup(x => x.GetAllAvailableCourses())
                .ReturnsAsync(courses);

            mapperMock
                .Setup(x => x.ProjectTo<CourseDto, CourseViewModel>(courses))
                .Returns(courseModels);

            studentServiceMock
                .Setup(x => x.GetAllRegisteredCourses(It.IsAny<string>()))
                .ReturnsAsync((IEnumerable<CourseDto>)null);

            var coursesController = new CoursesController(
                courseServiceMock.Object,
                studentServiceMock.Object,
                studentCoursesServiceMock.Object,
                mapperMock.Object,
                userManagerMock.Object);

            var user = new Mock<ClaimsPrincipal>();
            coursesController.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user.Object }
            };

            //Act && Assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(() => coursesController.Index());
        }
    }
}
