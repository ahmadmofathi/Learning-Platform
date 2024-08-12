using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public interface IEnrollmentManager
    {
        string AddEnrollment(EnrollmentAddDTO enrollment);

        string UpdateEnrollment(EnrollmentDTO enrollment);

        bool DeleteEnrollment(string enrollmentId);

        EnrollmentDTO? GetEnrollmentById(string enrollmentId);

        IEnumerable<EnrollmentDTO> GetAllEnrollments();
    }
}
