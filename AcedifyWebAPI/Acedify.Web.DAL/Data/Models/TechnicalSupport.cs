using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public class TechnicalSupport : User
    {
        public string? ID_Number { get; set; }
        public string? Facebook_Link { get; set; }
        public string? Phone { get; set; }

        [ForeignKey("Teacher")]
        public string? TeacherId { get; set; }   
        public Teacher? Teacher { get; set; }
    }
}
