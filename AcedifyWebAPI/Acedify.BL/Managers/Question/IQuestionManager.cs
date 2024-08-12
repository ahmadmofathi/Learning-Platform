using Acedify.Web.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public interface IQuestionManager
    {
        string AddQuestion(QuestionAddDTO question);

        string UpdateQuestion(QuestionDTO question);

        bool DeleteQuestion(string questionId);

        QuestionDTO? GetQuestionById(string questionId);

        IEnumerable<QuestionDTO> GetAllQuestions();
    }
}
