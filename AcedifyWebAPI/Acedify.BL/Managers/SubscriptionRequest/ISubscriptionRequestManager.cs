using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Acedify.Web.BL
{
    public interface ISubscriptionRequestManager
    {
        string AddSubscriptionRequest(SubReqAddDTO subscriptionRequest);

        string UpdateSubscriptionRequest(SubReqDTO subscriptionRequest);

        bool DeleteSubscriptionRequest(string subscriptionRequestId);

        SubReqDTO? GetSubscriptionRequestById(string subscriptionRequestId);

        IEnumerable<SubReqDTO> GetAllSubscriptionRequests();
    }
}
