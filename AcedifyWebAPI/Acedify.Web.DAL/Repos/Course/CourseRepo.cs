using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public class CourseRepo : ICourseRepo
    {
        private readonly AppDbContext _context;

        public CourseRepo(AppDbContext context)
        {
            _context = context;
        }

        public void AddCourse(Course course)
        {
            _context.Set<Course>().Add(course);
            _context.SaveChangesAsync();
        }

        public void UpdateCourse(Course course)
        {

        }

        public bool DeleteCourse(Course course)
        {
                _context.Set<Course>().Remove(course);
                return true;
        }
        public Course? GetCourseById(string courseId)
        {
            return _context.Set<Course>().FirstOrDefault(c => c.CourseId == courseId);
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _context.Set<Course>();
        }
    }
}
