using Acedify.Web.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public class SubReqDTO
    {
        public string? SubscriptionRequestId { get; set; }
        public string? StudentName { get; set; }
        public bool? isAccepted { get; set; }
        public string? Acceptance_Date { get; set; }
        public string? StudentId { get; set; }
        public string? TeacherId { get; set; }
    }
}
