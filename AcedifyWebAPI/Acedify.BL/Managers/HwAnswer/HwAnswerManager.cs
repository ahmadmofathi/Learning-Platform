using Acedify.Web.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public class HwAnswerManager : IHwAnswerManager
    {
        private readonly IHwAnswerRepo _hwAnswerRepo;

        public HwAnswerManager(IHwAnswerRepo hwAnswerRepo)
        {
            _hwAnswerRepo = hwAnswerRepo;
        }

        public string AddHwAnswer(HwAnswerAddDTO hwAnswer)
        {
            HwAnswer newHwAnswer = new HwAnswer
            {
                HwId = Guid.NewGuid().ToString(),
                FileName = hwAnswer.FileName,
                FilePath = hwAnswer.FilePath,
                Thumbnail = hwAnswer.Thumbnail,
                Hw_ID = hwAnswer.Hw_ID,
                StudentId = hwAnswer.StudentId,
            };
            _hwAnswerRepo.AddHwAnswer(newHwAnswer);
            return newHwAnswer.HwId;
        }

        public string UpdateHwAnswer(HwAnswerDTO hwAnswer)
        {
            if (hwAnswer.HwId == null)
            {
                return "HwAnswer's Id is not found";
            }
            HwAnswer hwAnswerToUpdate = _hwAnswerRepo.GetHwAnswerById(hwAnswer.HwId);
            if (hwAnswerToUpdate == null)
            {
                return "HwAnswer Not Found";
            }
            hwAnswerToUpdate.Hw_ID = hwAnswer.Hw_ID;
            hwAnswerToUpdate.StudentId = hwAnswer.StudentId;
            hwAnswerToUpdate.FileName = hwAnswer.FileName;
            hwAnswerToUpdate.FilePath = hwAnswer.FilePath;
            hwAnswerToUpdate.Thumbnail = hwAnswer.Thumbnail;

            _hwAnswerRepo.UpdateHwAnswer(hwAnswerToUpdate);
            return "HwAnswer is Updated Successfully";
        }

        public bool DeleteHwAnswer(string hwAnswerId)
        {
            if (hwAnswerId == null)
            {
                return false;
            }
            var hwAnswer = _hwAnswerRepo.GetHwAnswerById(hwAnswerId);
            if (hwAnswer == null)
            {
                return false;
            }
            _hwAnswerRepo.DeleteHwAnswer(hwAnswer);
            return true;
        }

        public HwAnswerDTO? GetHwAnswerById(string hwAnswerId)
        {
            HwAnswer hwAnswer = _hwAnswerRepo.GetHwAnswerById(hwAnswerId);
            if (hwAnswer == null)
            {
                return null;
            }
            HwAnswerDTO HwAnswer = new HwAnswerDTO
            {
                HwId = hwAnswer.HwId,
                FileName = hwAnswer.FileName,
                FilePath = hwAnswer.FilePath,
                Thumbnail = hwAnswer.Thumbnail,
                Hw_ID = hwAnswer.Hw_ID,
                StudentId = hwAnswer.StudentId,
            };
            return HwAnswer;
        }

        public IEnumerable<HwAnswerDTO> GetAllHwAnswers()
        {
            var hwAnswers = _hwAnswerRepo.GetAllHwAnswers();
            var allHwAnswers = hwAnswers.Select(hwAnswer => new HwAnswerDTO
            {
                HwId = hwAnswer.HwId,
                FileName = hwAnswer.FileName,
                FilePath = hwAnswer.FilePath,
                Thumbnail = hwAnswer.Thumbnail,
                Hw_ID = hwAnswer.Hw_ID,
                StudentId = hwAnswer.StudentId,
            });
            return allHwAnswers;
        }
    }
}
