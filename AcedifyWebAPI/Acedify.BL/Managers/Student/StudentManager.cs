using Acedify.Web.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Acedify.Web.BL
{
    public class StudentManager : IStudentManager
    {
        private readonly IStudentRepo _studentRepo;

        public StudentManager(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }

        public string AddStudent(StudentAddDTO student)
        {
            Student newStudent = new Student
            {
                Id = Guid.NewGuid().ToString(),
                Name = student.Name,
                Email = student.Email,
                UserName = student.Username,
                Role = student.Role,
                Class = student.Class,
                Coins = student.Coins,
                Category = student.Category,
                City = student.City,
                Address = student.Address,
                School = student.School,
                Second_Lang = student.Second_Lang,
                Std_Phone = student.Std_Phone,
                Parent_Phone = student.Parent_Phone,
                Facebook_Link = student.Facebook_Link,
                Balance = student.Balance,
                ID_Number = student.ID_Number,
                isActivated = student.isActivated
            };
            _studentRepo.AddStudent(newStudent);
            return newStudent.Id;
        }

        public string UpdateStudent(StudentDTO student)
        {
            if (student.Student_ID == null)
            {
                return "Student's Id is not found";
            }
            Student studentToUpdate = _studentRepo.GetStudentById(student.Student_ID);
            if (studentToUpdate == null)
            {
                return "Student Not Found";
            }
            studentToUpdate.Name = student.Name;
            studentToUpdate.Email = student.Email;
            studentToUpdate.UserName = student.Username;
            studentToUpdate.Role = student.Role;
            studentToUpdate.ProfilePic = student.ProfilePic;
            studentToUpdate.Class = student.Class;
            studentToUpdate.Coins = student.Coins;
            studentToUpdate.Category = student.Category;
            studentToUpdate.City = student.City;
            studentToUpdate.Address = student.Address;
            studentToUpdate.School = student.School;
            studentToUpdate.Second_Lang = student.Second_Lang;
            studentToUpdate.Std_Phone = student.Std_Phone;
            studentToUpdate.Parent_Phone = student.Parent_Phone;
            studentToUpdate.Facebook_Link = student.Facebook_Link;
            studentToUpdate.Balance = student.Balance;
            studentToUpdate.ID_Number = student.ID_Number;
            studentToUpdate.isActivated = student.isActivated;
            _studentRepo.UpdateStudent(studentToUpdate);
            return "Student is Updated Successfully";
        }

        public bool DeleteStudent(string studentId)
        {
            if (studentId == null)
            {
                return false;
            }
            var std = _studentRepo.GetStudentById(studentId);
            if (std == null) { 
            return false;
            }
            _studentRepo.DeleteStudent(std);
            return true;
        }

        public StudentDTO? GetStudentById(string studentId)
        {
            Student student = _studentRepo.GetStudentById(studentId);
            if (student == null)
            {
                return null;
            }
            StudentDTO studentDTO = new StudentDTO
            {
                Student_ID = student.Id,
                Name = student.Name,
                Email = student.Email,
                Username = student.UserName,
                Role = student.Role,
                ProfilePic = student.ProfilePic,
                Class = student.Class,
                Coins = student.Coins,
                Category = student.Category,
                City = student.City,
                Address = student.Address,
                School = student.School,
                Second_Lang = student.Second_Lang,
                Std_Phone = student.Std_Phone,
                Parent_Phone = student.Parent_Phone,
                Facebook_Link = student.Facebook_Link,
                Balance = student.Balance,
                ID_Number = student.ID_Number,
                isActivated = student.isActivated
            };
            return studentDTO;
        }

        public IEnumerable<StudentDTO> GetAllStudents()
        {
            var students = _studentRepo.GetAllStudents();
            var allStudents = students.Select(student => new StudentDTO
            {
                Student_ID = student.Id,
                Name = student.Name,
                Email = student.Email,
                Username = student.UserName,
                Role = student.Role,
                ProfilePic = student.ProfilePic,
                Class = student.Class,
                Coins = student.Coins,
                Category = student.Category,
                City = student.City,
                Address = student.Address,
                School = student.School,
                Second_Lang = student.Second_Lang,
                Std_Phone = student.Std_Phone,
                Parent_Phone = student.Parent_Phone,
                Facebook_Link = student.Facebook_Link,
                Balance = student.Balance,
                ID_Number = student.ID_Number,
                isActivated = student.isActivated
            });
            return allStudents;
        }
    }
}
