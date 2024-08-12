using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public class QuizDTO
    {
        public string? Quiz_ID { get; set; }
        public string? Quiz_Name { get; set; }
        public string? TimeInMins { get; set; }
        public int NoOfQuestions { get; set; }
        public int NoOfValidDays { get; set; }
        public int PassingScore { get; set; }
        public string? Thumbnail { get; set; }
        public string? TeacherId { get; set; }
    }
}
