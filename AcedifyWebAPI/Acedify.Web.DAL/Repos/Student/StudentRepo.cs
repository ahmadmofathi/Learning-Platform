using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public class StudentRepo :IStudentRepo
    {
        private readonly AppDbContext _context;

        public StudentRepo(AppDbContext context)
        {
            _context = context;
        }

        public void AddStudent(Student student)
        {
            _context.Set<Student>().Add(student);
            _context.SaveChangesAsync();
        }

        public void UpdateStudent(Student student)
        {

        }

        public bool DeleteStudent(Student student)
        {
                _context.Set<Student>().Remove(student);
                return true;
        }
        public Student? GetStudentById(string studentId)
        {
            return _context.Set<Student>().FirstOrDefault(c => c.Id == studentId);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Set<Student>();
        }
    }
}
