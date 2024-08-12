using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public interface IStudentRepo
    {
        void AddStudent(Student student);

        void UpdateStudent(Student student);

        bool DeleteStudent(Student student);

        Student? GetStudentById(string studentId);

        IEnumerable<Student> GetAllStudents();
    }
}
