using AutoMapper;
using CoursesSystem.Data.Models;
using CoursesSystem.DTO;

namespace CoursesSystem.Web.Properties
{
    public class MappingSettings : Profile
    {
        public MappingSettings()
        {
            this.CreateMap<StudentDto, Student>(MemberList.Source);
            this.CreateMap<CourseDto, Course>(MemberList.Source);
            this.CreateMap<StudentCourseDto, StudentCourse>(MemberList.Source);
        }
    }
}
