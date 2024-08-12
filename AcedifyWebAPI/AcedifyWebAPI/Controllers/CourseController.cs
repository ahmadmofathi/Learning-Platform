using Acedify.Web.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Acedify.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseManager _codeManager;
        public CourseController(ICourseManager codeManager)
        {
            _codeManager = codeManager;
        }

        [HttpGet]
        public ActionResult GetAllCourses()
        {
            return Ok(_codeManager.GetAllCourses());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetCourse(string id)
        {
            if (id == null)
            {
                return BadRequest("Id is not found");
            }
            return Ok(_codeManager.GetCourseById(id));
        }

        [HttpPost]
        public ActionResult AddCourse(CourseAddDTO code)
        {
            if (code == null)
            {
                return BadRequest("Course is Null");
            }
            return Ok(_codeManager.AddCourse(code));
        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateCourse(string id, CourseDTO code)
        {
            if (id == null)
            {
                return BadRequest("Id is null");
            }
            return Ok(_codeManager.UpdateCourse(code));
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteCourse(string id)
        {
            if (id == null)
            {
                return BadRequest("Id is not found");
            }
            return Ok(_codeManager.DeleteCourse(id));
        }
    }
}
