using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoursesSystem.Web.Models;
using CoursesSystem.Services.Data.Contracts;
using Bytes2you.Validation;
using CoursesSystem.Utils.Contracts;
using CoursesSystem.DTO;

namespace CoursesSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICourseService courseService;
        private readonly IMappingProvider mapper;

        public HomeController(ICourseService courseService, IMappingProvider mapper)
        {
            Guard.WhenArgument(courseService, "Course Service can not be null!").IsNull().Throw();
            Guard.WhenArgument(mapper, "Mapper can not be null!").IsNull().Throw();

            this.courseService = courseService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return this.View();
            }

            return RedirectToAction("Courses");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Courses()
        {
            var model = new CoursesViewModel();

            var availableCourses =  await this.courseService.GetAllAvailableCourses();
            Guard.WhenArgument(availableCourses, "Available Courses can not be null!").IsNull().Throw();

            var availableCoursesModel = mapper.ProjectTo<CourseDto, CourseViewModel>(availableCourses);
            Guard.WhenArgument(availableCoursesModel, "Available Courses can not be null!").IsNull().Throw();

            model.Courses = availableCoursesModel;

            return View(model);
        }
    }
}
