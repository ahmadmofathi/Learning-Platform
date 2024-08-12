using Acedify.Web.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Acedify.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentManager _studentManager;
        public StudentsController(IStudentManager studentManager)
        {
            _studentManager = studentManager;
        }

        [HttpGet]
        public ActionResult GetAllStudents()
        {
            return Ok(_studentManager.GetAllStudents());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetStudent(string id)
        {
            if (id == null)
            {
                return BadRequest("Id is not found");
            }
            return Ok(_studentManager.GetStudentById(id));
        }

        [HttpPost]
        public ActionResult AddStudent(StudentAddDTO student)
        {
            if (student == null)
            {
                return BadRequest("Student is Null");
            }
            return Ok(_studentManager.AddStudent(student));
        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateStudent(string id, StudentDTO student)
        {
            if (id == null)
            {
                return BadRequest("Id is null");
            }
            return Ok(_studentManager.UpdateStudent(student));
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteStudent(string id)
        {
            if (id == null)
            {
                return BadRequest("Id is not found");
            }
            return Ok(_studentManager.DeleteStudent(id));
        }
    }
}
