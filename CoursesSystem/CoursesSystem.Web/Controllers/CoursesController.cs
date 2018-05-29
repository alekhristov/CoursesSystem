using Bytes2you.Validation;
using CoursesSystem.DTO;
using CoursesSystem.Services.Data.Contracts;
using CoursesSystem.Utils.Contracts;
using CoursesSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoursesSystem.Web.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService courseService;
        private readonly IMappingProvider mapper;

        public CoursesController(ICourseService courseService, IMappingProvider mapper)
        {
            Guard.WhenArgument(courseService, "Course Service can not be null!").IsNull().Throw();
            Guard.WhenArgument(mapper, "Mapper can not be null!").IsNull().Throw();

            this.courseService = courseService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var model = new CoursesViewModel();

            var availableCourses = await this.courseService.GetAllAvailableCourses();
            Guard.WhenArgument(availableCourses, "Available Courses can not be null!").IsNull().Throw();

            var availableCoursesModel = mapper.ProjectTo<CourseDto, CourseViewModel>(availableCourses);
            Guard.WhenArgument(availableCoursesModel, "Available Courses can not be null!").IsNull().Throw();

            model.Courses = availableCoursesModel;

            return View(model);
        }
    }
}