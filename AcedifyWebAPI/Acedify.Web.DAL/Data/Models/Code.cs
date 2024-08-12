using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public class Code
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? CodeId { get; set; }
        public string? CodeName { get; set;}
        public int Price { get; set; }

        [ForeignKey("Student")]
        public string? StudentId { get; set;}
        public Student? Student { get; set; }

    }
}
