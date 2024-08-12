using Acedify.Web.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public class VideoDTO
    {
        public string? Video_ID { get; set; }
        public string? Video_Title { get; set; }
        public string? Video_Description { get; set; }
        public int Views_No { get; set; }
        public string? Video_Path { get; set; }
        public string? Thumbnail { get; set; }
        public string? TeacherId { get; set; }
        public string? CourseId { get; set; }
    }
}
