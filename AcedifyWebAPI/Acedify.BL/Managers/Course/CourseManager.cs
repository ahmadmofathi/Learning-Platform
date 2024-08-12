using Acedify.Web.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public class CourseManager : ICourseManager
    {
        private readonly ICourseRepo _courseRepo;

        public CourseManager(ICourseRepo courseRepo)
        {
            _courseRepo = courseRepo;
        }

        public string AddCourse(CourseAddDTO course)
        {
            Course newCourse = new Course
            {
                CourseId = Guid.NewGuid().ToString(),
                CourseName = course.CourseName,
                CourseDescription = course.CourseDescription,
                Thumbnail = course.Thumbnail,
                Valid_Period = course.Valid_Period,
                Price = course.Price,
                Pre_Requirement = course.Pre_Requirement,
                Videos_No = course.Videos_No,
                TeacherId = course.TeacherId,
                CategoryId = course.CategoryId,
            };
            _courseRepo.AddCourse(newCourse);
            return newCourse.CourseId;
        }

        public string UpdateCourse(CourseDTO course)
        {
            if (course.CourseId == null)
            {
                return "Course's Id is not found";
            }
            Course courseToUpdate = _courseRepo.GetCourseById(course.CourseId);
            if (courseToUpdate == null)
            {
                return "Course Not Found";
            }
            courseToUpdate.CourseName = course.CourseName;
            courseToUpdate.TeacherId = course.TeacherId;
            courseToUpdate.Price = course.Price;
            courseToUpdate.Pre_Requirement = course.Pre_Requirement;
            courseToUpdate.Videos_No = course.Videos_No;
            courseToUpdate.CategoryId = course.CategoryId;
            courseToUpdate.Thumbnail = course.Thumbnail;
            courseToUpdate.Valid_Period = course.Valid_Period;
            courseToUpdate.CourseDescription = course.CourseDescription;

            _courseRepo.UpdateCourse(courseToUpdate);
            return "Course is Updated Successfully";
        }

        public bool DeleteCourse(string courseId)
        {
            if (courseId == null)
            {
                return false;
            }
            var course = _courseRepo.GetCourseById(courseId);
            if (course == null)
            {
                return false;
            }
            _courseRepo.DeleteCourse(course);
            return true;
        }

        public CourseDTO? GetCourseById(string courseId)
        {
            Course dbCourse = _courseRepo.GetCourseById(courseId);
            if (dbCourse == null)
            {
                return null;
            }
            CourseDTO Course = new CourseDTO
            {
                CourseId = courseId,
                CourseName = dbCourse.CourseName,
                Price = dbCourse.Price,
                CourseDescription = dbCourse.CourseDescription,
                Thumbnail = dbCourse.Thumbnail,
                Valid_Period = dbCourse.Valid_Period,
                Pre_Requirement = dbCourse.Pre_Requirement,
                Videos_No = dbCourse.Videos_No,
                TeacherId = dbCourse.TeacherId,
                CategoryId = dbCourse.CategoryId,
            };
            return Course;
        }

        public IEnumerable<CourseDTO> GetAllCourses()
        {
            var courses = _courseRepo.GetAllCourses();
            var allCourses = courses.Select(course => new CourseDTO
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                Price = course.Price,
                CourseDescription = course.CourseDescription,
                Thumbnail = course.Thumbnail,
                Valid_Period = course.Valid_Period,
                Pre_Requirement = course.Pre_Requirement,
                Videos_No = course.Videos_No,
                TeacherId = course.TeacherId,
                CategoryId = course.CategoryId,
            });
            return allCourses;
        }
    }
}
