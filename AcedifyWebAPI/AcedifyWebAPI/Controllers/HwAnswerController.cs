using Acedify.Web.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Acedify.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HwAnswerController : ControllerBase
    {
        private readonly IHwAnswerManager _hwAnswerManager;
        public HwAnswerController(IHwAnswerManager hwAnswerManager)
        {
            _hwAnswerManager = hwAnswerManager;
        }

        [HttpGet]
        public ActionResult GetAllHwAnswers()
        {
            return Ok(_hwAnswerManager.GetAllHwAnswers());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetHwAnswer(string id)
        {
            if (id == null)
            {
                return BadRequest("Id is not found");
            }
            return Ok(_hwAnswerManager.GetHwAnswerById(id));
        }

        [HttpPost]
        public ActionResult AddHwAnswer(HwAnswerAddDTO hwAnswer)
        {
            if (hwAnswer == null)
            {
                return BadRequest("HwAnswer is Null");
            }
            return Ok(_hwAnswerManager.AddHwAnswer(hwAnswer));
        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateHwAnswer(string id, HwAnswerDTO hwAnswer)
        {
            if (id == null)
            {
                return BadRequest("Id is null");
            }
            return Ok(_hwAnswerManager.UpdateHwAnswer(hwAnswer));
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteHwAnswer(string id)
        {
            if (id == null)
            {
                return BadRequest("Id is not found");
            }
            return Ok(_hwAnswerManager.DeleteHwAnswer(id));
        }
    }
}
