using Acedify.Web.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Acedify.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionRequestsController : ControllerBase
    {
        private readonly ISubscriptionRequestManager _subscriptionRequestManager;
        public SubscriptionRequestsController(ISubscriptionRequestManager subscriptionRequestManager)
        {
            _subscriptionRequestManager = subscriptionRequestManager;
        }

        [HttpGet]
        public ActionResult GetAllSubscriptionRequests()
        {
            return Ok(_subscriptionRequestManager.GetAllSubscriptionRequests());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetSubscriptionRequest(string id)
        {
            if (id == null)
            {
                return BadRequest("Id is not found");
            }
            return Ok(_subscriptionRequestManager.GetSubscriptionRequestById(id));
        }

        [HttpPost]
        public ActionResult AddSubscriptionRequest(SubReqAddDTO subscriptionRequest)
        {
            if (subscriptionRequest == null)
            {
                return BadRequest("SubscriptionRequest is Null");
            }
            return Ok(_subscriptionRequestManager.AddSubscriptionRequest(subscriptionRequest));
        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateSubscriptionRequest(string id, SubReqDTO subscriptionRequest)
        {
            if (id == null)
            {
                return BadRequest("Id is null");
            }
            return Ok(_subscriptionRequestManager.UpdateSubscriptionRequest(subscriptionRequest));
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteSubscriptionRequest(string id)
        {
            if (id == null)
            {
                return BadRequest("Id is not found");
            }
            return Ok(_subscriptionRequestManager.DeleteSubscriptionRequest(id));
        }
    }
}
