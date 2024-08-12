using Acedify.Web.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Acedify.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeworkController : ControllerBase
    {
        private readonly IHomeworkManager _homeworkManager;
        public HomeworkController(IHomeworkManager homeworkManager)
        {
            _homeworkManager = homeworkManager;
        }

        [HttpGet]
        public ActionResult GetAllHomeworks()
        {
            return Ok(_homeworkManager.GetAllHomeworks());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetHomework(string id)
        {
            if (id == null)
            {
                return BadRequest("Id is not found");
            }
            return Ok(_homeworkManager.GetHomeworkById(id));
        }

        [HttpPost]
        public ActionResult AddHomework(HomeworkAddDTO homework)
        {
            if (homework == null)
            {
                return BadRequest("Homework is Null");
            }
            return Ok(_homeworkManager.AddHomework(homework));
        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateHomework(string id, HomeworkDTO homework)
        {
            if (id == null)
            {
                return BadRequest("Id is null");
            }
            return Ok(_homeworkManager.UpdateHomework(homework));
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteHomework(string id)
        {
            if (id == null)
            {
                return BadRequest("Id is not found");
            }
            return Ok(_homeworkManager.DeleteHomework(id));
        }
    }
}
