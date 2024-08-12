using Acedify.Web.BL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Acedify.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherManager _teacherManager;

        public TeachersController(ITeacherManager teacherManager)
        {
            _teacherManager = teacherManager;
        }

        [HttpPost]
        public IActionResult AddTeacher([FromBody] TeacherAddDTO teacher)
        {
            var teacherId = _teacherManager.AddTeacher(teacher);
            return Ok(new { TeacherId = teacherId });
        }


        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateTeacher(string id, TeacherDTO teacher)
        {
            if (id == null)
            {
                return BadRequest("Id is null");
            }
            return Ok(_teacherManager.UpdateTeacher(teacher));
        }

        [HttpDelete("{teacherId}")]
        public IActionResult DeleteTeacher(string teacherId)
        {
            var result = _teacherManager.DeleteTeacher(teacherId);
            return Ok(result);
        }

        [HttpGet("{teacherId}")]
        public IActionResult GetTeacherById(string teacherId)
        {
            var teacher = _teacherManager.GetTeacherById(teacherId);
            if (teacher == null)
            {
                return NotFound();
            }
            return Ok(teacher);
        }

        [HttpGet]
        public IActionResult GetAllTeachers()
        {
            var teachers = _teacherManager.GetAllTeachers();
            return Ok(teachers);
        }
    }
}
