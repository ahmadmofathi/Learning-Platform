using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public class QuestionRepo : IQuestionRepo
    {
        private readonly AppDbContext _context;

        public QuestionRepo(AppDbContext context)
        {
            _context = context;
        }

        public void AddQuestion(Question question)
        {
            _context.Set<Question>().Add(question);
            _context.SaveChangesAsync();
        }

        public void UpdateQuestion(Question question)
        {

        }

        public bool DeleteQuestion(Question question)
        {
                _context.Set<Question>().Remove(question);
                return true;
        }
        public Question? GetQuestionById(string questionId)
        {
            return _context.Set<Question>().FirstOrDefault(c => c.Question_ID == questionId);
        }

        public IEnumerable<Question> GetAllQuestions()
        {
            return _context.Set<Question>();
        }
    }
}
