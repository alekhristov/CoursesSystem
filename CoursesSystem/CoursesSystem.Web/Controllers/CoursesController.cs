using Bytes2you.Validation;
using CoursesSystem.Data.Models;
using CoursesSystem.DTO;
using CoursesSystem.Services.Data.Contracts;
using CoursesSystem.Utils.Contracts;
using CoursesSystem.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    }
}