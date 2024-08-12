using Acedify.Web.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Acedify.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizManager _quizManager;
        public QuizController(IQuizManager quizManager)
        {
            _quizManager = quizManager;
        }

        [HttpGet]
        public ActionResult GetAllQuizs()
        {
            return Ok(_quizManager.GetAllQuizs());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetQuiz(string id)
        {
            if (id == null)
            {
                return BadRequest("Id is not found");
            }
            return Ok(_quizManager.GetQuizById(id));
        }

        [HttpPost]
        public ActionResult AddQuiz(QuizAddDTO quiz)
        {
            if (quiz == null)
            {
                return BadRequest("Quiz is Null");
            }
            return Ok(_quizManager.AddQuiz(quiz));
        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateQuiz(string id, QuizDTO quiz)
        {
            if (id == null)
            {
                return BadRequest("Id is null");
            }
            return Ok(_quizManager.UpdateQuiz(quiz));
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteQuiz(string id)
        {
            if (id == null)
            {
                return BadRequest("Id is not found");
            }
            return Ok(_quizManager.DeleteQuiz(id));
        }
    }
}
