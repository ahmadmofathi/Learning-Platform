using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public class CategoryDTO
    {
        public string? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryThumbnail { get; set; }
        public int Lectures_No { get; set; }
        public string? TeacherId { get; set; }
    }
}
