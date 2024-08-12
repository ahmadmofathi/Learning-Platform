using Acedify.Web.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public class HomeworkManager:IHomeworkManager
    {
        private readonly IHomeworkRepo _homeworkRepo;

        public HomeworkManager(IHomeworkRepo homeworkRepo)
        {
            _homeworkRepo = homeworkRepo;
        }

        public string AddHomework(HomeworkAddDTO homework)
        {
            Homework newHomework = new Homework
            {
                HW_ID = Guid.NewGuid().ToString(),
                HW_Name = homework.HW_Name,
                HW_Description = homework.HW_Description,
                HW_Score = homework.HW_Score,
                CourseId = homework.CourseId,
                TeacherId = homework.TeacherId,
                Thumbnail = homework.Thumbnail,
            };
            _homeworkRepo.AddHomework(newHomework);
            return newHomework.HW_ID;
        }

        public string UpdateHomework(HomeworkDTO homework)
        {
            if (homework.HW_ID == null)
            {
                return "Homework's Id is not found";
            }
            Homework homeworkToUpdate = _homeworkRepo.GetHomeworkById(homework.HW_ID);
            if (homeworkToUpdate == null)
            {
                return "Homework Not Found";
            }
            homeworkToUpdate.HW_Name = homework.HW_Name;
            homeworkToUpdate.HW_Description = homework.HW_Description;
            homeworkToUpdate.HW_Score = homework.HW_Score;
            homeworkToUpdate.Thumbnail = homework.Thumbnail;
            homeworkToUpdate.CourseId = homework.CourseId;
            homeworkToUpdate.TeacherId = homework.TeacherId;
            _homeworkRepo.UpdateHomework(homeworkToUpdate);
            return "Homework is Updated Successfully";
        }

        public bool DeleteHomework(string homeworkId)
        {
            if (homeworkId == null)
            {
                return false;
            }
            var homework = _homeworkRepo.GetHomeworkById(homeworkId);
            if (homework == null)
            {
                return false;
            }
            _homeworkRepo.DeleteHomework(homework);
            return true;
        }

        public HomeworkDTO? GetHomeworkById(string homeworkId)
        {
            Homework dbHomework = _homeworkRepo.GetHomeworkById(homeworkId);
            if (dbHomework == null)
            {
                return null;
            }
            HomeworkDTO Homework = new HomeworkDTO
            {
                HW_ID = dbHomework.HW_ID,
                HW_Name = dbHomework.HW_Name,
                HW_Description = dbHomework.HW_Description,
                HW_Score = dbHomework.HW_Score,
                CourseId = dbHomework.CourseId,
                TeacherId = dbHomework.TeacherId,
                Thumbnail = dbHomework.Thumbnail,
            };
            return Homework;
        }

        public IEnumerable<HomeworkDTO> GetAllHomeworks()
        {
            var homeworks = _homeworkRepo.GetAllHomeworks();
            var allHomeworks = homeworks.Select(dbHomework => new HomeworkDTO
            {
                HW_ID = dbHomework.HW_ID,
                HW_Name = dbHomework.HW_Name,
                HW_Description = dbHomework.HW_Description,
                HW_Score = dbHomework.HW_Score,
                CourseId = dbHomework.CourseId,
                TeacherId = dbHomework.TeacherId,
                Thumbnail = dbHomework.Thumbnail,
            });
            return allHomeworks;
        }
    }
}
