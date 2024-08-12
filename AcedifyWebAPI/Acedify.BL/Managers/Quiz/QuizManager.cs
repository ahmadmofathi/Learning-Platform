using Acedify.Web.BL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public class QuizManager :IQuizManager
    {
        private readonly IQuizRepo _quizRepo;

        public QuizManager(IQuizRepo quizRepo)
        {
            _quizRepo = quizRepo;
        }

        public string AddQuiz(QuizAddDTO quiz)
        {
            Quiz newQuiz = new Quiz
            {
                Quiz_ID = Guid.NewGuid().ToString(),
                Quiz_Name = quiz.Quiz_Name,
                TimeInMins = quiz.TimeInMins,
                Thumbnail = quiz.Thumbnail,
                NoOfQuestions = quiz.NoOfQuestions,
                NoOfValidDays = quiz.NoOfValidDays,
                PassingScore = quiz.PassingScore,
                TeacherId = quiz.TeacherId,

            };
            _quizRepo.AddQuiz(newQuiz);
            return newQuiz.Quiz_ID;
        }

        public string UpdateQuiz(QuizDTO quiz)
        {
            if (quiz.Quiz_ID == null)
            {
                return "Quiz's Id is not found";
            }
            Quiz quizToUpdate = _quizRepo.GetQuizById(quiz.Quiz_ID);
            if (quizToUpdate == null)
            {
                return "Quiz Not Found";
            }
            quizToUpdate.Quiz_Name = quiz.Quiz_Name;
            quizToUpdate.TimeInMins = quiz.TimeInMins;
            quizToUpdate.Thumbnail = quiz.Thumbnail;
            quizToUpdate.NoOfQuestions = quiz.NoOfQuestions;
            quizToUpdate.NoOfValidDays = quiz.NoOfValidDays;
            quizToUpdate.PassingScore = quiz.PassingScore;
            quizToUpdate.TeacherId = quiz.TeacherId;
            _quizRepo.UpdateQuiz(quizToUpdate);
            return "Quiz is Updated Successfully";
        }

        public bool DeleteQuiz(string quizId)
        {
            if (quizId == null)
            {
                return false;
            }
            var quiz = _quizRepo.GetQuizById(quizId);
            if (quiz == null)
            {
                return false;
            }
            return _quizRepo.DeleteQuiz(quiz);
        }

        public QuizDTO? GetQuizById(string quizId)
        {
            Quiz quiz = _quizRepo.GetQuizById(quizId);
            if (quiz == null)
            {
                return null;
            }
            QuizDTO Quiz = new QuizDTO
            {
                Quiz_ID = quiz.Quiz_ID,
                Quiz_Name = quiz.Quiz_Name,
                TimeInMins = quiz.TimeInMins,
                Thumbnail = quiz.Thumbnail,
                NoOfQuestions = quiz.NoOfQuestions,
                NoOfValidDays = quiz.NoOfValidDays,
                PassingScore = quiz.PassingScore,
                TeacherId = quiz.TeacherId,
            };
            return Quiz;
        }

        public IEnumerable<QuizDTO> GetAllQuizs()
        {
            var quizs = _quizRepo.GetAllQuizs();
            var allQuizs = quizs.Select(quiz => new QuizDTO
            {
                Quiz_ID = quiz.Quiz_ID,
                Quiz_Name = quiz.Quiz_Name,
                TimeInMins = quiz.TimeInMins,
                Thumbnail = quiz.Thumbnail,
                NoOfQuestions = quiz.NoOfQuestions,
                NoOfValidDays = quiz.NoOfValidDays,
                PassingScore = quiz.PassingScore,
                TeacherId = quiz.TeacherId,
            });
            return allQuizs;
        }
    }
}
