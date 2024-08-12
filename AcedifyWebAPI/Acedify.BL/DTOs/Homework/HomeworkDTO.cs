using Acedify.Web.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public class HomeworkDTO
    {
        public string? HW_ID { get; set; }
        public string? HW_Name { get; set; }
        public string? HW_Description { get; set; }
        public int HW_Score { get; set; }
        public string? Thumbnail { get; set; }
        public string? CourseId { get; set; }
        public string? TeacherId { get; set; }
    }
}
