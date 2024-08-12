using Acedify.Web.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public class CourseAddDTO
    {
        public string? CourseName { get; set; }
        public string? CourseDescription { get; set; }
        public string? Thumbnail { get; set; }
        public string? Valid_Period { get; set; }
        public int Price { get; set; }
        public string? Pre_Requirement { get; set; }
        public int Videos_No { get; set; }
        public string? TeacherId { get; set; }
        public string? CategoryId { get; set; }
    }
}
