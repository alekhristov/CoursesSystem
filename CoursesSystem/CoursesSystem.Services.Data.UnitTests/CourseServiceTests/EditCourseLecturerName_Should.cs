using CoursesSystem.Data.Models;
using CoursesSystem.Data.Repository.Contracts;
using CoursesSystem.Data.Saver.Contracts;
using CoursesSystem.Utils.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoursesSystem.Services.Data.UnitTests.CourseServiceTests
{
    [TestClass]
    public class EditCourseLecturerName_Should
    {
        [TestMethod]
        public void CallCoursesUpdateMethodOnce_WhenInvokedWithValidParameters()
        {
            //Arrange
            var coursesMock = new Mock<IRepository<Course>>();
            var studentCoursesMock = new Mock<IRepository<StudentCourse>>();
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();

            var courseNewLecturerName = "Marto Stamatov";

            var firstCourse = new Course()
            {
                Id = new Guid("12367a78-faf1-40c9-abcd-0c3131a03312"),
                Name = "DSA",
                Credits = 5,
                LecturerName = "Sasho Dikov"
            };

            var secondCourse = new Course()
            {
                Id = new Guid("12367a78-0000-40c9-abcd-0c3131a03312"),
                Name = "Design Patterns",
                Credits = 4,
                LecturerName = "Marto Stamatov"
            };

            var courses = new List<Course>()
            {
                firstCourse,
                secondCourse
            }
            .AsQueryable();

            coursesMock
                .Setup(x => x.All)
                .Returns(courses);

            var courseService = new CourseService(
                coursesMock.Object,
                studentCoursesMock.Object,
                mapperMock.Object,
                saverMock.Object);

            //Act
            courseService.EditCourseLecturerName(firstCourse.Id, courseNewLecturerName);

            //Assert
            coursesMock.Verify(x => x.Update(firstCourse), Times.Once);
        }

        [TestMethod]
        public void CallSaverSaveChangesMethodOnce_WhenInvokedWithValidParameters()
        {
            //Arrange
            var coursesMock = new Mock<IRepository<Course>>();
            var studentCoursesMock = new Mock<IRepository<StudentCourse>>();
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();

            var courseNewLecturerName = "Marto Stamatov";

            var firstCourse = new Course()
            {
                Id = new Guid("12367a78-faf1-40c9-abcd-0c3131a03312"),
                Name = "DSA",
                Credits = 5,
                LecturerName = "Sasho Dikov"
            };

            var secondCourse = new Course()
            {
                Id = new Guid("12367a78-0000-40c9-abcd-0c3131a03312"),
                Name = "Design Patterns",
                Credits = 4,
                LecturerName = "Marto Stamatov"
            };

            var courses = new List<Course>()
            {
                firstCourse,
                secondCourse
            }
            .AsQueryable();

            coursesMock
                .Setup(x => x.All)
                .Returns(courses);

            var courseService = new CourseService(
                coursesMock.Object,
                studentCoursesMock.Object,
                mapperMock.Object,
                saverMock.Object);

            //Act
            courseService.EditCourseLecturerName(firstCourse.Id, courseNewLecturerName);

            //Assert
            saverMock.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenCoursesAllPropertyReturnsNull()
        {
            //Arrange
            var coursesMock = new Mock<IRepository<Course>>();
            var studentCoursesMock = new Mock<IRepository<StudentCourse>>();
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();

            var courseNewLecturerName = "Marto Stamatov";

            var firstCourse = new Course()
            {
                Id = new Guid("12367a78-faf1-40c9-abcd-0c3131a03312"),
                Name = "DSA",
                Credits = 5,
                LecturerName = "Sasho Dikov"
            };

            var secondCourse = new Course()
            {
                Id = new Guid("12367a78-0000-40c9-abcd-0c3131a03312"),
                Name = "Design Patterns",
                Credits = 4,
                LecturerName = "Marto Stamatov"
            };

            var courses = new List<Course>()
            {
                firstCourse,
                secondCourse
            }
            .AsQueryable();

            coursesMock
                .Setup(x => x.All)
                .Returns((IQueryable<Course>)null);

            var courseService = new CourseService(
                coursesMock.Object,
                studentCoursesMock.Object,
                mapperMock.Object,
                saverMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => courseService.EditCourseLecturerName(firstCourse.Id, courseNewLecturerName));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullCourseNewLecturerNameParameter()
        {
            //Arrange
            var coursesMock = new Mock<IRepository<Course>>();
            var studentCoursesMock = new Mock<IRepository<StudentCourse>>();
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();

            var courseNewLecturerName = "Marto Stamatov";

            var firstCourse = new Course()
            {
                Id = new Guid("12367a78-faf1-40c9-abcd-0c3131a03312"),
                Name = "DSA",
                Credits = 5,
                LecturerName = "Sasho Dikov"
            };

            var secondCourse = new Course()
            {
                Id = new Guid("12367a78-0000-40c9-abcd-0c3131a03312"),
                Name = "Design Patterns",
                Credits = 4,
                LecturerName = "Marto Stamatov"
            };

            var courses = new List<Course>()
            {
                firstCourse,
                secondCourse
            }
            .AsQueryable();

            coursesMock
                .Setup(x => x.All)
                .Returns(courses);

            var courseService = new CourseService(
                coursesMock.Object,
                studentCoursesMock.Object,
                mapperMock.Object,
                saverMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => courseService.EditCourseLecturerName(firstCourse.Id, null));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidEmptyCourseNewLecturerNameParameter()
        {
            //Arrange
            var coursesMock = new Mock<IRepository<Course>>();
            var studentCoursesMock = new Mock<IRepository<StudentCourse>>();
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();

            var courseNewLecturerName = "Marto Stamatov";

            var firstCourse = new Course()
            {
                Id = new Guid("12367a78-faf1-40c9-abcd-0c3131a03312"),
                Name = "DSA",
                Credits = 5,
                LecturerName = "Sasho Dikov"
            };

            var secondCourse = new Course()
            {
                Id = new Guid("12367a78-0000-40c9-abcd-0c3131a03312"),
                Name = "Design Patterns",
                Credits = 4,
                LecturerName = "Marto Stamatov"
            };

            var courses = new List<Course>()
            {
                firstCourse,
                secondCourse
            }
            .AsQueryable();

            coursesMock
                .Setup(x => x.All)
                .Returns(courses);

            var courseService = new CourseService(
                coursesMock.Object,
                studentCoursesMock.Object,
                mapperMock.Object,
                saverMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => courseService.EditCourseLecturerName(firstCourse.Id, string.Empty));
        }
    }
}
