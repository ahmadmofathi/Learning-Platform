using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public class Quiz
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? Quiz_ID { get; set; }
        public string? Quiz_Name { get; set;}
        public string? TimeInMins { get; set; }
        public int NoOfQuestions { get; set; }
        public int NoOfValidDays { get; set; }
        public int PassingScore { get; set; }
        public string? Thumbnail { get; set; }

        [ForeignKey("Teacher")]
        public string? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
    }
}
