using Acedify.Web.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public class EnrollmentDTO
    {
        public string? Enrollment_ID { get; set; }
        public string? Payment_Type { get; set; }
        public int Payment_Amount { get; set; }
        public string? PaymentDate { get; set; }
        public string? CourseId { get; set; }
        public string? StudentId { get; set; }
    }
}
