using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public class CodeAddDTO
    {
        public string? CodeName { get; set; }
        public int Price { get; set; }
        public string? StudentId { get; set; }
    }
}
