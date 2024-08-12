using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public class Admin : User
    {
        public string? Payment_Method {  get; set; }

    }
}
