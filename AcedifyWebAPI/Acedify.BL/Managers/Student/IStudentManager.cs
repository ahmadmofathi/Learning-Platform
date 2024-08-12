using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public interface IStudentManager
    {
        string AddStudent(StudentAddDTO student);

        string UpdateStudent(StudentDTO student);

        bool DeleteStudent(string studentId);

        StudentDTO? GetStudentById(string studentId);

        IEnumerable<StudentDTO> GetAllStudents();
    }
}
