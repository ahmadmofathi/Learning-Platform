using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acedify.Web.DAL;

namespace Acedify.Web.BL
{
    public class QuestionManager : IQuestionManager
    {
        private readonly IQuestionRepo _questionRepo;

        public QuestionManager(IQuestionRepo questionRepo)
        {
            _questionRepo = questionRepo;
        }

        public string AddQuestion(QuestionAddDTO question)
        {
            Question newQuestion = new Question
            {
                Question_ID = Guid.NewGuid().ToString(),
                Question_Title = question.Question_Title,
                Question_Description = question.Question_Description,
                Thumbnail = question.Thumbnail,
                CourseId = question.CourseId,
                QuestionScore = question.QuestionScore,
                Choices = question.Choices,
                Quiz_ID = question.Quiz_ID,

            };
            _questionRepo.AddQuestion(newQuestion);
            return newQuestion.Question_ID;
        }

        public string UpdateQuestion(QuestionDTO question)
        {
            if (question.Question_ID == null)
            {
                return "Question's Id is not found";
            }
            Question questionToUpdate = _questionRepo.GetQuestionById(question.Question_ID);
            if (questionToUpdate == null)
            {
                return "Question Not Found";
            }
            questionToUpdate.Question_Title = question.Question_Title;
            questionToUpdate.Question_Description = question.Question_Description;
            questionToUpdate.Thumbnail = question.Thumbnail;
            questionToUpdate.QuestionScore = question.QuestionScore;
            questionToUpdate.Choices = question.Choices;
            questionToUpdate.Quiz_ID = question.Quiz_ID;
            questionToUpdate.CourseId = question.CourseId;
            _questionRepo.UpdateQuestion(questionToUpdate);
            return "Question is Updated Successfully";
        }

        public bool DeleteQuestion(string questionId)
        {
            if (questionId == null)
            {
                return false;
            }
            var question = _questionRepo.GetQuestionById(questionId);
            if (question == null)
            {
                return false;
            }
            _questionRepo.DeleteQuestion(question);
            return true;
        }

        public QuestionDTO? GetQuestionById(string questionId)
        {
            Question question = _questionRepo.GetQuestionById(questionId);
            if (question == null)
            {
                return null;
            }
            QuestionDTO Question = new QuestionDTO
            {
                Question_ID = question.Question_ID,
                Question_Title = question.Question_Title,
                Question_Description = question.Question_Description,
                Thumbnail = question.Thumbnail,
                CourseId = question.CourseId,
                QuestionScore = question.QuestionScore,
                Choices = question.Choices,
                Quiz_ID = question.Quiz_ID,
            };
            return Question;
        }

        public IEnumerable<QuestionDTO> GetAllQuestions()
        {
            var questions = _questionRepo.GetAllQuestions();
            var allQuestions = questions.Select(question => new QuestionDTO
            {
                Question_ID = question.Question_ID,
                Question_Title = question.Question_Title,
                Question_Description = question.Question_Description,
                Thumbnail = question.Thumbnail,
                CourseId = question.CourseId,
                QuestionScore = question.QuestionScore,
                Choices = question.Choices,
                Quiz_ID = question.Quiz_ID,
            });
            return allQuestions;
        }
    }
}
