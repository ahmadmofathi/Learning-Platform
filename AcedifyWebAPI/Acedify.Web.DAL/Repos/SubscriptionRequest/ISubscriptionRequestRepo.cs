using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public interface ISubscriptionRequestRepo
    {
        void AddSubscriptionRequest(SubscriptionRequest subscriptionRequest);

        void UpdateSubscriptionRequest(SubscriptionRequest subscriptionRequest);

        bool DeleteSubscriptionRequest(SubscriptionRequest subscriptionRequest);

        SubscriptionRequest? GetSubscriptionRequestById(string subscriptionRequestId);

        IEnumerable<SubscriptionRequest> GetAllSubscriptionRequests();
    }
}
