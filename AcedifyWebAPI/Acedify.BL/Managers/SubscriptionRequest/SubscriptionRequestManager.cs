using Acedify.Web.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public class SubscriptionRequestManager :ISubscriptionRequestManager
    {
        private readonly ISubscriptionRequestRepo _subscriptionRequestRepo;

        public SubscriptionRequestManager(ISubscriptionRequestRepo subscriptionRequestRepo)
        {
            _subscriptionRequestRepo = subscriptionRequestRepo;
        }

        public string AddSubscriptionRequest(SubReqAddDTO subscriptionRequest)
        {
            SubscriptionRequest newSubscriptionRequest = new SubscriptionRequest
            {
                SubscriptionRequestId = Guid.NewGuid().ToString(),
                StudentName = subscriptionRequest.StudentName,
                isAccepted = subscriptionRequest.isAccepted,
                Acceptance_Date = subscriptionRequest.Acceptance_Date,
                StudentId = subscriptionRequest.StudentId,
                TeacherId = subscriptionRequest.TeacherId
            };
            _subscriptionRequestRepo.AddSubscriptionRequest(newSubscriptionRequest);
            return newSubscriptionRequest.SubscriptionRequestId;
        }

        public string UpdateSubscriptionRequest(SubReqDTO subscriptionRequest)
        {
            if (subscriptionRequest.SubscriptionRequestId == null)
            {
                return "Subscription Request Id is not found";
            }
            SubscriptionRequest subscriptionRequestToUpdate = _subscriptionRequestRepo.GetSubscriptionRequestById(subscriptionRequest.SubscriptionRequestId);
            if (subscriptionRequestToUpdate == null)
            {
                return "Subscription Request Not Found";
            }
            subscriptionRequestToUpdate.StudentName = subscriptionRequest.StudentName;
            subscriptionRequestToUpdate.isAccepted = subscriptionRequest.isAccepted;
            subscriptionRequestToUpdate.Acceptance_Date = subscriptionRequest.Acceptance_Date;
            subscriptionRequestToUpdate.StudentId = subscriptionRequest.StudentId;
            subscriptionRequestToUpdate.TeacherId = subscriptionRequest.TeacherId;
            _subscriptionRequestRepo.UpdateSubscriptionRequest(subscriptionRequestToUpdate);
            return "Subscription Request is Updated Successfully";
        }

        public bool DeleteSubscriptionRequest(string subscriptionRequestId)
        {
            if (subscriptionRequestId == null)
            {
                return false;
            }
            var sub = _subscriptionRequestRepo.GetSubscriptionRequestById(subscriptionRequestId);
            if (sub == null)
            {  return false; }
            _subscriptionRequestRepo.DeleteSubscriptionRequest(sub);
            return true;
        }

        public SubReqDTO? GetSubscriptionRequestById(string subscriptionRequestId)
        {
            SubscriptionRequest subscriptionRequest = _subscriptionRequestRepo.GetSubscriptionRequestById(subscriptionRequestId);
            if (subscriptionRequest == null)
            {
                return null;
            }
            SubReqDTO subscriptionRequestDTO = new SubReqDTO
            {
                SubscriptionRequestId = subscriptionRequest.SubscriptionRequestId,
                StudentName = subscriptionRequest.StudentName,
                isAccepted = subscriptionRequest.isAccepted,
                Acceptance_Date = subscriptionRequest.Acceptance_Date,
                StudentId = subscriptionRequest.StudentId,
                TeacherId = subscriptionRequest.TeacherId
            };
            return subscriptionRequestDTO;
        }

        public IEnumerable<SubReqDTO> GetAllSubscriptionRequests()
        {
            var subscriptionRequests = _subscriptionRequestRepo.GetAllSubscriptionRequests();
            var allSubscriptionRequests = subscriptionRequests.Select(subscriptionRequest => new SubReqDTO
            {
                SubscriptionRequestId = subscriptionRequest.SubscriptionRequestId,
                StudentName = subscriptionRequest.StudentName,
                isAccepted = subscriptionRequest.isAccepted,
                Acceptance_Date = subscriptionRequest.Acceptance_Date,
                StudentId = subscriptionRequest.StudentId,
                TeacherId = subscriptionRequest.TeacherId
            });
            return allSubscriptionRequests;
        }
    }


}
