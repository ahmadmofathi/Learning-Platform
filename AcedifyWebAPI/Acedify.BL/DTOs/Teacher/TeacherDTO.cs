using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public class TeacherDTO
    {
        public string? ID_Number { get; set; }
        public string? Subject { get; set; }
        public string? Bio { get; set; }
        public string? Payment_Method { get; set; }
        public int Students_No { get; set; }
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Role { get; set; }
        public string? ProfilePic { get; set; }
    }
}
