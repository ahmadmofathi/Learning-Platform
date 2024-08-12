using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public class SubReqAddDTO
    {
        public string? StudentName { get; set; }
        public bool? isAccepted { get; set; }
        public string? Acceptance_Date { get; set; }
        public string? StudentId { get; set; }
        public string? TeacherId { get; set; }
    }
}
