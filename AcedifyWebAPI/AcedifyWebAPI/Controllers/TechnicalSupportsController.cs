using Acedify.Web.BL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Acedify.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicalSupportController : ControllerBase
    {
        private readonly ITechnicalSupportManager _technicalSupportManager;

        public TechnicalSupportController(ITechnicalSupportManager technicalSupportManager)
        {
            _technicalSupportManager = technicalSupportManager;
        }

        [HttpPost]
        public IActionResult AddTechnicalSupport([FromBody] TechnicalSupportAddDTO technicalSupport)
        {
            var technicalSupportId = _technicalSupportManager.AddTechnicalSupport(technicalSupport);
            return Ok(new { TechnicalSupportId = technicalSupportId });
        }


        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateTechnicalSupport(string id, TechnicalSupportDTO technicalSupport)
        {
            if (id == null)
            {
                return BadRequest("Id is null");
            }
            return Ok(_technicalSupportManager.UpdateTechnicalSupport(technicalSupport));
        }

        [HttpDelete("{technicalSupportId}")]
        public IActionResult DeleteTechnicalSupport(string technicalSupportId)
        {
            var result = _technicalSupportManager.DeleteTechnicalSupport(technicalSupportId);
            return Ok(result);
        }

        [HttpGet("{technicalSupportId}")]
        public IActionResult GetTechnicalSupportById(string technicalSupportId)
        {
            var technicalSupport = _technicalSupportManager.GetTechnicalSupportById(technicalSupportId);
            if (technicalSupport == null)
            {
                return NotFound();
            }
            return Ok(technicalSupport);
        }

        [HttpGet]
        public IActionResult GetAllTechnicalSupports()
        {
            var technicalSupports = _technicalSupportManager.GetAllTechnicalSupports();
            return Ok(technicalSupports);
        }
    }
}
