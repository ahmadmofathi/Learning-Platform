using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public interface IQuizRepo
    {
        void AddQuiz(Quiz quiz);

        void UpdateQuiz(Quiz quiz);

        bool DeleteQuiz(Quiz quiz);

        Quiz? GetQuizById(string quizId);

        IEnumerable<Quiz> GetAllQuizs();
    }
}
