using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public class QuizRepo :IQuizRepo
    {
        private readonly AppDbContext _context;

        public QuizRepo(AppDbContext context)
        {
            _context = context;
        }

        public void AddQuiz(Quiz quiz)
        {
            _context.Set<Quiz>().Add(quiz);
            _context.SaveChangesAsync();
        }

        public void UpdateQuiz(Quiz quiz)
        {

        }

        public bool DeleteQuiz(Quiz quiz)
        {
                _context.Set<Quiz>().Remove(quiz);
                return true;
        }
        public Quiz? GetQuizById(string quizId)
        {
            return _context.Set<Quiz>().FirstOrDefault(c => c.Quiz_ID == quizId);
        }

        public IEnumerable<Quiz> GetAllQuizs()
        {
            return _context.Set<Quiz>();
        }
    }
}
