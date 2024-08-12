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
    public class Video
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? Video_ID { get; set; }
        public string? Video_Title { get; set; }
        public string? Video_Description { get; set; }
        public int Views_No { get; set; }
        public string? Video_Path { get; set; }
        public string? Thumbnail {  get; set; }
        [ForeignKey("Teacher")]
        public string? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        [ForeignKey("Course")]
        public string? CourseId {  get; set; }
        public Course? Course { get; set; } 


    }
}
