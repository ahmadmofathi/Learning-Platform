using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public class SubscriptionRequestRepo :ISubscriptionRequestRepo
    {
        private readonly AppDbContext _context;

        public SubscriptionRequestRepo(AppDbContext context)
        {
            _context = context;
        }

        public void AddSubscriptionRequest(SubscriptionRequest subReq)
        {
            _context.Set<SubscriptionRequest>().Add(subReq);
            _context.SaveChangesAsync();
        }

        public void UpdateSubscriptionRequest(SubscriptionRequest subReq)
        {

        }

        public bool DeleteSubscriptionRequest(SubscriptionRequest subscriptionRequest)
        {
                _context.Set<SubscriptionRequest>().Remove(subscriptionRequest);
                return true;
        }
        public SubscriptionRequest? GetSubscriptionRequestById(string subReqId)
        {
            return _context.Set<SubscriptionRequest>().FirstOrDefault(c => c.SubscriptionRequestId == subReqId);
        }

        public IEnumerable<SubscriptionRequest> GetAllSubscriptionRequests()
        {
            return _context.Set<SubscriptionRequest>();
        }
    }
}
