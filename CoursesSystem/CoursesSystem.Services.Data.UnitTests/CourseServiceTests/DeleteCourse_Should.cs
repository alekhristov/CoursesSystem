using CoursesSystem.Data.Models;
using CoursesSystem.Data.Repository.Contracts;
using CoursesSystem.Data.Saver.Contracts;
using CoursesSystem.DTO;
using CoursesSystem.Utils.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoursesSystem.Services.Data.UnitTests.CourseServiceTests
{
    [TestClass]
    public class DeleteCourse_Should
    {
        [TestMethod]
        public void CallCourseDeleteMethodOnce_WhenInvokedWithValidParameters()
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

            var student = new Student()
            {
                Id = "uniqueId",
                FirstName = "Marto",
                LastName = "Stamatov",
                FacultyNumber = new Guid("12367a78-0000-40c9-abcd-0c3131a03312")
            };

            var studentCourse = new StudentCourse()
            {
                Course = firstCourse,
                CourseId = firstCourse.Id,
                Student = student,
                StudentId = student.Id
            };

            var courses = new List<Course>()
            {
                firstCourse,
                secondCourse
            }
            .AsQueryable();

            var studentCourses = new List<StudentCourse>()
            {
                studentCourse
            }
            .AsQueryable();

            coursesMock
                .Setup(x => x.All)
                .Returns(courses);

            studentCoursesMock
                .Setup(x => x.All)
                .Returns(studentCourses);

            var courseService = new CourseService(
                coursesMock.Object,
                studentCoursesMock.Object,
                mapperMock.Object,
                saverMock.Object);

            //Act
            courseService.DeleteCourse(firstCourse.Id);

            //Assert
            coursesMock.Verify(x => x.Delete(firstCourse), Times.Once);
        }

        [TestMethod]
        public void DeleteAllCoursesFromStudentCourses_WhenInvokedWithValidParameters()
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

            var student = new Student()
            {
                Id = "uniqueId",
                FirstName = "Marto",
                LastName = "Stamatov",
                FacultyNumber = new Guid("12367a78-0000-40c9-abcd-0c3131a03312")
            };

            var studentCourse = new StudentCourse()
            {
                Course = firstCourse,
                CourseId = firstCourse.Id,
                Student = student,
                StudentId = student.Id
            };

            var courses = new List<Course>()
            {
                firstCourse,
                secondCourse
            }
            .AsQueryable();

            var studentCourses = new List<StudentCourse>()
            {
                studentCourse
            }
            .AsQueryable();

            coursesMock
                .Setup(x => x.All)
                .Returns(courses);

            studentCoursesMock
                .Setup(x => x.All)
                .Returns(studentCourses);

            var courseService = new CourseService(
                coursesMock.Object,
                studentCoursesMock.Object,
                mapperMock.Object,
                saverMock.Object);

            //Act
            courseService.DeleteCourse(firstCourse.Id);

            //Assert
            Assert.IsTrue(studentCourses.ToArray()[0].IsDeleted);
        }


        [TestMethod]
        public void CallCourseSaveChangesOnce_WhenInvokedWithValidParameters()
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

            var student = new Student()
            {
                Id = "uniqueId",
                FirstName = "Marto",
                LastName = "Stamatov",
                FacultyNumber = new Guid("12367a78-0000-40c9-abcd-0c3131a03312")
            };

            var studentCourse = new StudentCourse()
            {
                Course = firstCourse,
                CourseId = firstCourse.Id,
                Student = student,
                StudentId = student.Id
            };

            var courses = new List<Course>()
            {
                firstCourse,
                secondCourse
            }
            .AsQueryable();

            var studentCourses = new List<StudentCourse>()
            {
                studentCourse
            }
            .AsQueryable();

            coursesMock
                .Setup(x => x.All)
                .Returns(courses);

            studentCoursesMock
                .Setup(x => x.All)
                .Returns(studentCourses);

            var courseService = new CourseService(
                coursesMock.Object,
                studentCoursesMock.Object,
                mapperMock.Object,
                saverMock.Object);

            //Act
            courseService.DeleteCourse(firstCourse.Id);

            //Assert
            saverMock.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenCoursesAllPropeertReturnsNull()
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

            var student = new Student()
            {
                Id = "uniqueId",
                FirstName = "Marto",
                LastName = "Stamatov",
                FacultyNumber = new Guid("12367a78-0000-40c9-abcd-0c3131a03312")
            };

            var studentCourse = new StudentCourse()
            {
                Course = firstCourse,
                CourseId = firstCourse.Id,
                Student = student,
                StudentId = student.Id
            };

            var courses = new List<Course>()
            {
                firstCourse,
                secondCourse
            }
            .AsQueryable();

            var studentCourses = new List<StudentCourse>()
            {
                studentCourse
            }
            .AsQueryable();

            coursesMock
                .Setup(x => x.All)
                .Returns((IQueryable<Course>)null);

            studentCoursesMock
                .Setup(x => x.All)
                .Returns(studentCourses);

            var courseService = new CourseService(
                coursesMock.Object,
                studentCoursesMock.Object,
                mapperMock.Object,
                saverMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => courseService.DeleteCourse(firstCourse.Id));
        }
    }
}
