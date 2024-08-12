using Acedify.Web.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Acedify.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeController : ControllerBase
    {
        private readonly ICodeManager _codeManager;
        public CodeController(ICodeManager codeManager)
        {
            _codeManager = codeManager;
        }

        [HttpGet]
        public ActionResult GetAllCodes()
        {
            return Ok(_codeManager.GetAllCodes());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetCode(string id)
        {
            if (id == null)
            {
                return BadRequest("Id is not found");
            }
            return Ok(_codeManager.GetCodeById(id));
        }

        [HttpPost]
        public ActionResult AddCode(CodeAddDTO code)
        {
            if (code == null)
            {
                return BadRequest("Code is Null");
            }
            return Ok(_codeManager.AddCode(code));
        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateCode(string id, CodeDTO code)
        {
            if (id == null)
            {
                return BadRequest("Id is null");
            }
            return Ok(_codeManager.UpdateCode(code));
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteCode(string id)
        {
            if (id == null)
            {
                return BadRequest("Id is not found");
            }
            return Ok(_codeManager.DeleteCode(id));
        }
    }
}
