using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public class User : IdentityUser<string>
    {
        public string? Name {  get; set; }
        public string? Role { get; set; }
        public string? ProfilePic {  get; set; }
    }
}
