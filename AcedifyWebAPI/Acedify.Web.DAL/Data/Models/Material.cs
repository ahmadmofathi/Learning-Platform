using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public class Material
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? Material_Id { get; set; }
        public string? File_Id { get; set; }
        public string? File_Name { get; set; }
        public string? File_Link { get; set; }
        [ForeignKey("Course")]
        public string? CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
