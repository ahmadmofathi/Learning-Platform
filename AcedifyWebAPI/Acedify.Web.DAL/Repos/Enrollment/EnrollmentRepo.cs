using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public class EnrollmentRepo : IEnrollmentRepo
    {
        private readonly AppDbContext _context;

        public EnrollmentRepo(AppDbContext context)
        {
            _context = context;
        }

        public void AddEnrollment(Enrollment enrollment)
        {
            _context.Set<Enrollment>().Add(enrollment);
            _context.SaveChangesAsync();
        }

        public void UpdateEnrollment(Enrollment enrollment)
        {

        }

        public bool DeleteEnrollment(Enrollment enrollment)
        {
                _context.Set<Enrollment>().Remove(enrollment);
                return true;
        }
        public Enrollment? GetEnrollmentById(string enrollmentId)
        {
            return _context.Set<Enrollment>().FirstOrDefault(c => c.Enrollment_ID == enrollmentId);
        }

        public IEnumerable<Enrollment> GetAllEnrollments()
        {
            return _context.Set<Enrollment>();
        }
    }
}
