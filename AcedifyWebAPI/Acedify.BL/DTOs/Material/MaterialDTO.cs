using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public class MaterialDTO
    {
        public string? Material_Id { get; set; }
        public string? File_Id { get; set; }
        public string? File_Name { get; set; }
        public string? File_Link { get; set; }
        public string? CourseId { get; set; }
    }
}
