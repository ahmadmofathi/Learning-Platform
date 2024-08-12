using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public interface ITeacherRepo
    {
        void AddTeacher(Teacher teacher);

        void UpdateTeacher(Teacher teacher);

        bool DeleteTeacher(Teacher teacher);

        Teacher? GetTeacherById(string teacherId);

        IEnumerable<Teacher> GetAllTeachers();
    }
}
