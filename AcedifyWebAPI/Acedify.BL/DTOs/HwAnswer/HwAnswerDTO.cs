using Acedify.Web.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public class HwAnswerDTO
    {
        public string? HwId { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? Thumbnail { get; set; }
        public string? StudentId { get; set; }
        public string? Hw_ID { get; set; }
    }
}
