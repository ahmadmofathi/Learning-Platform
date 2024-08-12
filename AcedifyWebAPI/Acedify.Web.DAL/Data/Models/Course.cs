using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? CourseId { get; set; }
        public string? CourseName { get; set;}
        public string? CourseDescription { get; set; }
        public string? Thumbnail { get; set; }
        public string? Valid_Period { get; set; }
        public int Price {  get; set; }
        public string? Pre_Requirement { get; set; }
        public int Videos_No { get; set; }
         
        [ForeignKey("Teacher")]
        public string? TeacherId { get; set; }  
        public Teacher? Teacher { get; set; }
         
        [ForeignKey("Category")]
        public string? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
