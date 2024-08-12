using Acedify.Web.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Acedify.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperAdminsController : ControllerBase
    {
        private readonly ISuperAdminManager _superAdminManager;

        public SuperAdminsController(ISuperAdminManager superAdminManager)
        {
            _superAdminManager = superAdminManager;
        }

        [HttpPost]
        public IActionResult AddSuperAdmin([FromBody] SuperAdminAddDTO superAdmin)
        {
            var superAdminId = _superAdminManager.AddSuperAdmin(superAdmin);
            return Ok(new { SuperAdminId = superAdminId });
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateSuperAdmin(string id, SuperAdminDTO superAdmin)
        {
            if (id == null)
            {
                return BadRequest("Id is null");
            }
            return Ok(_superAdminManager.UpdateSuperAdmin(superAdmin));
        }

        [HttpDelete("{superAdminId}")]
        public IActionResult DeleteSuperAdmin(string superAdminId)
        {
            var result = _superAdminManager.DeleteSuperAdmin(superAdminId);
            return Ok(result);
        }

        [HttpGet("{superAdminId}")]
        public IActionResult GetSuperAdminById(string superAdminId)
        {
            var superAdmin = _superAdminManager.GetSuperAdminById(superAdminId);
            if (superAdmin == null)
            {
                return NotFound();
            }
            return Ok(superAdmin);
        }

        [HttpGet]
        public IActionResult GetAllSuperAdmins()
        {
            var superAdmins = _superAdminManager.GetAllSuperAdmins();
            return Ok(superAdmins);
        }
    }
}
