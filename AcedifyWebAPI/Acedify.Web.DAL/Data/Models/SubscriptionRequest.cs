using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public class SubscriptionRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? SubscriptionRequestId { get; set; }
        public string? StudentName { get; set; }
        public bool? isAccepted { get; set;}
        public string? Acceptance_Date { get; set; }

        [ForeignKey("Student")]
        public string? StudentId { get; set; }
        public Student? Student { get; set; }

        [ForeignKey("Teacher")]
        public string? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
    }
}
