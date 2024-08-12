using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public class Enrollment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? Enrollment_ID { get; set; }
        public string? Payment_Type { get; set; }
        public int Payment_Amount { get; set; }
        public string? PaymentDate { get; set; }
        [ForeignKey("Course")]
        public string? CourseId { get; set; }
        public Course? Course { get; set; }
        [ForeignKey("Student")]
        public string? StudentId { get; set; }
        public Student? Student { get; set; }
    }
}
