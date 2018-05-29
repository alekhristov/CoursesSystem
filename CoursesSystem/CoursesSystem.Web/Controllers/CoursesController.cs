using Bytes2you.Validation;
using CoursesSystem.Data.Models;
using CoursesSystem.DTO;
using CoursesSystem.Services.Data.Contracts;
using CoursesSystem.Utils.Contracts;
using CoursesSystem.Web.Models.CoursesViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesSystem.Web.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService courseService;
        private readonly IStudentService studentService;
        private readonly IStudentCourseService studentCourseService;
        private readonly IMappingProvider mapper;
        private readonly UserManager<Student> userManager;

        public CoursesController(
            ICourseService courseService,
            IStudentService studentService,
            IStudentCourseService studentCourseService,
            IMappingProvider mapper,
            UserManager<Student> userManager)
        {
            Guard.WhenArgument(courseService, "Course Service can not be null!").IsNull().Throw();
            Guard.WhenArgument(studentService, "Student Service can not be null!").IsNull().Throw();
            Guard.WhenArgument(studentCourseService, "StudentCourse Service can not be null!").IsNull().Throw();
            Guard.WhenArgument(mapper, "Mapper can not be null!").IsNull().Throw();
            Guard.WhenArgument(userManager, "User Manager").IsNull().Throw();

            this.courseService = courseService;
            this.studentService = studentService;
            this.studentCourseService = studentCourseService;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var model = new CoursesViewModel();

            var availableCourses = await this.courseService.GetAllAvailableCourses();
            Guard.WhenArgument(availableCourses, "Available Courses can not be null!").IsNull().Throw();

            var availableCoursesModel = mapper.ProjectTo<CourseDto, CourseViewModel>(availableCourses).ToList();
            Guard.WhenArgument(availableCoursesModel, "Available Courses can not be null!").IsNull().Throw();

            var studentId = this.userManager.GetUserId(this.HttpContext.User);
            var registeredCourses = await studentService.GetAllRegisteredCourses(studentId);

            foreach (var course in registeredCourses)
            {
                for (int i = 0; i < availableCoursesModel.Count(); i++)
                {
                    if (course.Id == availableCoursesModel[i].Id)
                    {
                        availableCoursesModel[i].IsRegistered = true;
                    }
                }
            }

            model.Courses = availableCoursesModel;

            return View(model);
        }

        public async Task<IActionResult> CoursesTables()
        {
            var model = new CoursesTablesViewModel();
            var studentId = this.userManager.GetUserId(this.HttpContext.User);

            var registeredCourses = await this.studentService.GetAllRegisteredCourses(studentId);
            Guard.WhenArgument(registeredCourses, "Registered Courses can not be null!").IsNull().Throw();

            var registeredCoursesModel = mapper.ProjectTo<CourseDto, CourseViewModel>(registeredCourses);
            Guard.WhenArgument(registeredCoursesModel, "Registered Courses can not be null!").IsNull().Throw();

            var notRegisteredCourses = await studentService.GetAllNonRegisteredCourses(studentId);
            Guard.WhenArgument(notRegisteredCourses, "Non-Registered Courses can not be null!").IsNull().Throw();

            var notRegisteredCoursesModel = mapper.ProjectTo<CourseDto, CourseViewModel>(notRegisteredCourses);
            Guard.WhenArgument(notRegisteredCourses, "Non-Registered Courses can not be null!").IsNull().Throw();

            model.RegisteredCourses = registeredCoursesModel;
            model.NotRegisteredCourses = notRegisteredCoursesModel;

            return View(model);
        }

        public IActionResult RegisterCourse([FromBody]CourseViewModel model)
        {
            var studentId = this.userManager.GetUserId(this.HttpContext.User);
            studentCourseService.AddCourseToStudent(model.Id, studentId);

            return Json($"{model.Name} course successfully registered!");
        }

        public IActionResult UnregisterCourse([FromBody]CourseViewModel model)
        {
            var studentId = this.userManager.GetUserId(this.HttpContext.User);
            studentCourseService.DeleteCourseFromStudent(model.Id, studentId);

            return Json($"{model.Name} course successfully unregistered!");
        }

        public async Task<IActionResult> ManageCourses()
        {
            var model = new CoursesViewModel();

            var availableCourses = await this.courseService.GetAllAvailableCourses();
            Guard.WhenArgument(availableCourses, "Available Courses can not be null!").IsNull().Throw();

            var availableCoursesModel = mapper.ProjectTo<CourseDto, CourseViewModel>(availableCourses);
            Guard.WhenArgument(availableCoursesModel, "Available Courses can not be null!").IsNull().Throw();

            model.Courses = availableCoursesModel;

            return View(model);
        }

        public async Task<IActionResult> Edit(Guid courseId)
        {
            var courseDto = await courseService.GetCourseById(courseId);
            Guard.WhenArgument(courseDto, "Course Dto can not be null!").IsNull().Throw();

            var courseModel = this.mapper.MapTo<CourseViewModel>(courseDto);
            Guard.WhenArgument(courseModel, "CourseModel can not be null!").IsNull().Throw();

            return View(courseModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CourseViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }

            var courseDto = await courseService.GetCourseById(model.Id);
            Guard.WhenArgument(courseDto, "Course Dto can not be null!").IsNull().Throw();

            if (model.Name != courseDto.Name)
            {
                this.courseService.EditCourseName(model.Id, model.Name);
            }

            if (model.Credits != courseDto.Credits)
            {
                this.courseService.EditCourseCredits(model.Id, model.Credits);
            }

            if (model.LecturerName != courseDto.LecturerName)
            {
                this.courseService.EditCourseLecturerName(model.Id, model.LecturerName);
            }

            return RedirectToAction("ManageCourses");
        }
    }
}