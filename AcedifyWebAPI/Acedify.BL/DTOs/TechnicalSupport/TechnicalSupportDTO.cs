using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public class TechnicalSupportDTO
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Role { get; set; }
        public string? ProfilePic { get; set; }
        public string? ID_Number { get; set; }
        public string? Facebook_Link { get; set; }
        public string? Phone { get; set; }
        public string? TeacherId { get; set; }
    }
}
