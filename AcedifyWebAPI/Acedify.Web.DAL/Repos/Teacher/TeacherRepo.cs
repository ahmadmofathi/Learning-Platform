using Microsoft.Azure.Documents;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public class TeacherRepo : ITeacherRepo
    {
        private readonly AppDbContext _context;

        public TeacherRepo(AppDbContext context)
        {
            _context = context;
        }

        public void AddTeacher(Teacher teacher)
        {
            _context.Set<Teacher>().Add(teacher);
            _context.SaveChangesAsync();
        }

        public void UpdateTeacher(Teacher teacher)
        {

        }

        public bool DeleteTeacher(Teacher teacher)
        {
            _context.Set<User>().Remove(teacher);
            return true;
        }
        public Teacher? GetTeacherById(string teacherId)
        {
            return _context.Set<Teacher>().FirstOrDefault(c => c.Id == teacherId);
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            return _context.Set<Teacher>();
        }
    }
}
