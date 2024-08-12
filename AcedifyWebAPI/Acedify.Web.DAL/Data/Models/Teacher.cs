using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public class Teacher : User
    {
        public string? ID_Number { get; set; }
        public string? Subject { get; set; }
        public string? Bio {  get; set; }
        public string? Payment_Method { get; set; }
        public int Students_No { get; set; }
    }
}
