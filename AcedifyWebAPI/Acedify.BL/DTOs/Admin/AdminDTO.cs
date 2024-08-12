using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public class AdminDTO
    {
        public string? AdminId { get; set; }
        public string? Payment_Method { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Role { get; set; }
        public string? ProfilePic { get; set; }
    }
}
