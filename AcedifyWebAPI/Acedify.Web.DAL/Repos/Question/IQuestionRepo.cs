using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public interface IQuestionRepo
    {
        void AddQuestion(Question question);

        void UpdateQuestion(Question question);

        bool DeleteQuestion(Question question);

        Question? GetQuestionById(string questionId);

        IEnumerable<Question> GetAllQuestions();
    }
}
