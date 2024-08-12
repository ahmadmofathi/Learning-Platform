using System.Collections.Generic;

namespace Acedify.Web.BL
{
    public interface ITeacherManager
    {
        string AddTeacher(TeacherAddDTO teacher);

        string UpdateTeacher(TeacherDTO teacher);

        bool DeleteTeacher(string teacherId);

        TeacherDTO? GetTeacherById(string teacherId);

        IEnumerable<TeacherDTO> GetAllTeachers();
    }
}
