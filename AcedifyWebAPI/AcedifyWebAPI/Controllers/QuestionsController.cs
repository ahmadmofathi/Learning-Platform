using Acedify.Web.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Acedify.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionManager _questionManager;
        public QuestionsController(IQuestionManager questionManager)
        {
            _questionManager = questionManager;
        }

        [HttpGet]
        public ActionResult GetAllQuestions()
        {
            return Ok(_questionManager.GetAllQuestions());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetQuestion(string id)
        {
            if (id == null)
            {
                return BadRequest("Id is not found");
            }
            return Ok(_questionManager.GetQuestionById(id));
        }

        [HttpPost]
        public ActionResult AddQuestion(QuestionAddDTO question)
        {
            if (question == null)
            {
                return BadRequest("Question is Null");
            }
            return Ok(_questionManager.AddQuestion(question));
        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateQuestion(string id, QuestionDTO question)
        {
            if (id == null)
            {
                return BadRequest("Id is null");
            }
            return Ok(_questionManager.UpdateQuestion(question));
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteQuestion(string id)
        {
            if (id == null)
            {
                return BadRequest("Id is not found");
            }
            return Ok(_questionManager.DeleteQuestion(id));
        }
    }
}
