using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public class Homework
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? HW_ID { get; set; }
        public string? HW_Name { get; set; }
        public string? HW_Description { get; set; }
        public int HW_Score { get; set; }
        public string? Thumbnail { get; set; }
        [ForeignKey("Course")]
        public string? CourseId { get; set; }
        public Course? Course { get; set; }


        [ForeignKey("Teacher")]
        public string? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }

    }
}
