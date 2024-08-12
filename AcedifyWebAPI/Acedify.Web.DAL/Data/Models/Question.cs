using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? Question_ID { get; set; }
        public string? Question_Title { get; set; }
        public string? Question_Description { get; set;}
        public string? Thumbnail { get; set; }
        public int QuestionScore { get;set; }
        public string[]? Choices { get; set; }
        [ForeignKey("Course")]
        public string? CourseId { get; set; }
        public Course? Course { get; set; }
        [ForeignKey("Quiz")]
        public string? Quiz_ID { get; set; }
        public Quiz? Quiz { get; set; }

    }
}
