using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public class HwAnswer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? HwId { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? Thumbnail { get; set; }
        [ForeignKey("Student")]
        public string? StudentId { get; set; }
        public Student? Student { get; set; }
        [ForeignKey("Homework")]
        public string? Hw_ID { get; set; }
        public Homework? Homework { get; set; }
    }
}
