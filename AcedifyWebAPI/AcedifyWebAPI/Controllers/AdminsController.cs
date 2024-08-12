using Acedify.Web.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Acedify.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminManager _adminManager;
        public AdminsController(IAdminManager adminManager)
        {
            _adminManager = adminManager;
        }

        [HttpGet]
        public ActionResult GetAllAdmins()
        {
            return Ok(_adminManager.GetAllAdmins());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetAdmin(string id)
        {
            if(id == null)
            {
                return BadRequest("Id is not found");
            }
            return Ok(_adminManager.GetAdminById(id));
        }

        [HttpPost]
        public ActionResult AddAdmin(AdminAddDTO admin)
        {
            if(admin == null)
            {
                return BadRequest("Admin is Null");
            }
            return Ok(_adminManager.AddAdmin(admin));
        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateAdmin(string id,AdminDTO admin)
        {
            if(id == null)
            {
                return BadRequest("Id is null");
            }
            return Ok(_adminManager.UpdateAdmin(admin));
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteAdmin(string id)
        {
            if(id == null)
            {
                return BadRequest("Id is not found");
            }
            return Ok(_adminManager.DeleteAdmin(id));
        }
    }
}
