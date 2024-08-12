using Acedify.Web.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Acedify.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollmentManager _codeManager;
        public EnrollmentsController(IEnrollmentManager codeManager)
        {
            _codeManager = codeManager;
        }

        [HttpGet]
        public ActionResult GetAllEnrollments()
        {
            return Ok(_codeManager.GetAllEnrollments());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetEnrollment(string id)
        {
            if (id == null)
            {
                return BadRequest("Id is not found");
            }
            return Ok(_codeManager.GetEnrollmentById(id));
        }

        [HttpPost]
        public ActionResult AddEnrollment(EnrollmentAddDTO code)
        {
            if (code == null)
            {
                return BadRequest("Enrollment is Null");
            }
            return Ok(_codeManager.AddEnrollment(code));
        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateEnrollment(string id, EnrollmentDTO code)
        {
            if (id == null)
            {
                return BadRequest("Id is null");
            }
            return Ok(_codeManager.UpdateEnrollment(code));
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteEnrollment(string id)
        {
            if (id == null)
            {
                return BadRequest("Id is not found");
            }
            return Ok(_codeManager.DeleteEnrollment(id));
        }
    }
}
