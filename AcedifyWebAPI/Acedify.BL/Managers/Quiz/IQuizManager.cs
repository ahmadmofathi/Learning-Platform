using Acedify.Web.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public interface IQuizManager
    {
        string AddQuiz(QuizAddDTO quiz);

        string UpdateQuiz(QuizDTO quiz);

        bool DeleteQuiz(string quizId);

        QuizDTO? GetQuizById(string quizId);

        IEnumerable<QuizDTO> GetAllQuizs();
    }
}
