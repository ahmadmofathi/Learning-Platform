using Acedify.Web.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public interface ICourseManager
    {
        string AddCourse(CourseAddDTO course);

        string UpdateCourse(CourseDTO course);

        bool DeleteCourse(string courseId);

        CourseDTO? GetCourseById(string courseId);

        IEnumerable<CourseDTO> GetAllCourses();
    }
}
