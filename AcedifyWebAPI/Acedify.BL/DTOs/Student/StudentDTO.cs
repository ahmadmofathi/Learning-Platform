using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public class StudentDTO
    {
        public string? Student_ID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Role { get; set; }
        public string? ProfilePic { get; set; }
        public string? Class { get; set; }
        public string? Coins { get; set; }
        public string? Category { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public string? School { get; set; }
        public string? Second_Lang { get; set; }
        public string? Std_Phone { get; set; }
        public string? Parent_Phone { get; set; }
        public string? Facebook_Link { get; set; }
        public int Balance { get; set; }
        public string? ID_Number { get; set; }
        public bool? isActivated { get; set; }
    }
}
