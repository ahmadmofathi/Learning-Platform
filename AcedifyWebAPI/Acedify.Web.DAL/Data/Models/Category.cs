using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? CategoryId {  get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryThumbnail { get; set;}
        public int Lectures_No { get; set; }

        [ForeignKey("Teacher")]
        public string? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
    }
}
