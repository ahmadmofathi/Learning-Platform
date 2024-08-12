using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public interface IEnrollmentRepo
    {
        void AddEnrollment(Enrollment enrollment);

        void UpdateEnrollment(Enrollment enrollment);

        bool DeleteEnrollment(Enrollment enrollment);

        Enrollment? GetEnrollmentById(string enrollmentId);

        IEnumerable<Enrollment> GetAllEnrollments();
    }
}
