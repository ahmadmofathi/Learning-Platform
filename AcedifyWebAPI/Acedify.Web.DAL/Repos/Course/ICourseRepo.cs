using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public interface ICourseRepo
    {
        void AddCourse(Course course);

        void UpdateCourse(Course course);

        bool DeleteCourse(Course course);

        Course? GetCourseById(string courseId);

        IEnumerable<Course> GetAllCourses();
    }
}
