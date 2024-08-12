using Acedify.Web.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Acedify.Web.BL
{
    public class TeacherManager : ITeacherManager
    {
        private readonly ITeacherRepo _teacherRepo;

        public TeacherManager(ITeacherRepo teacherRepo)
        {
            _teacherRepo = teacherRepo;
        }

        public string AddTeacher(TeacherAddDTO teacher)
        {
            Teacher newTeacher = new Teacher
            {
                ID_Number = teacher.ID_Number,
                Subject = teacher.Subject,
                Bio = teacher.Bio,
                Payment_Method = teacher.Payment_Method,
                Students_No = teacher.Students_No,
                Id = Guid.NewGuid().ToString(),
                Name = teacher.Name,
                Email = teacher.Email,
                UserName = teacher.Username,
                Role = teacher.Role,
            };
            _teacherRepo.AddTeacher(newTeacher);
            return newTeacher.Id;
        }

        public string UpdateTeacher(TeacherDTO teacher)
        {
            if (teacher.Id == null)
            {
                return "Teacher's Id is not found";
            }
            Teacher teacherToUpdate = _teacherRepo.GetTeacherById(teacher.Id);
            if (teacherToUpdate == null)
            {
                return "Teacher Not Found";
            }
            teacherToUpdate.ID_Number = teacher.ID_Number;
            teacherToUpdate.Subject = teacher.Subject;
            teacherToUpdate.Bio = teacher.Bio;
            teacherToUpdate.Payment_Method = teacher.Payment_Method;
            teacherToUpdate.Students_No = teacher.Students_No;
            teacherToUpdate.Name = teacher.Name;
            teacherToUpdate.Email = teacher.Email;
            teacherToUpdate.UserName = teacher.Username;
            teacherToUpdate.Role = teacher.Role;
            teacherToUpdate.ProfilePic = teacher.ProfilePic;
            _teacherRepo.UpdateTeacher(teacherToUpdate);
            return "Teacher is Updated Successfully";
        }

        public bool DeleteTeacher(string teacherId)
        {
            if (teacherId == null)
            {
                return false;
            }
            var teacher = _teacherRepo.GetTeacherById(teacherId);
            if (teacher == null)
            { return false; }
            _teacherRepo.DeleteTeacher(teacher);
            return true;
        }

        public TeacherDTO? GetTeacherById(string teacherId)
        {
            Teacher teacher = _teacherRepo.GetTeacherById(teacherId);
            if (teacher == null)
            {
                return null;
            }
            TeacherDTO teacherDTO = new TeacherDTO
            {
                ID_Number = teacher.ID_Number,
                Subject = teacher.Subject,
                Bio = teacher.Bio,
                Payment_Method = teacher.Payment_Method,
                Students_No = teacher.Students_No,
                Id = teacher.Id,
                Name = teacher.Name,
                Email = teacher.Email,
                Username = teacher.UserName,
                Role = teacher.Role,
                ProfilePic = teacher.ProfilePic
            };
            return teacherDTO;
        }

        public IEnumerable<TeacherDTO> GetAllTeachers()
        {
            var teachers = _teacherRepo.GetAllTeachers();
            var allTeachers = teachers.Select(teacher => new TeacherDTO
            {
                ID_Number = teacher.ID_Number,
                Subject = teacher.Subject,
                Bio = teacher.Bio,
                Payment_Method = teacher.Payment_Method,
                Students_No = teacher.Students_No,
                Id = teacher.Id,
                Name = teacher.Name,
                Email = teacher.Email,
                Username = teacher.UserName,
                Role = teacher.Role,
                ProfilePic = teacher.ProfilePic
            });
            return allTeachers;
        }
    }
}
