using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public interface IHwAnswerRepo
    {
        void AddHwAnswer(HwAnswer hwAnswer);

        void UpdateHwAnswer(HwAnswer hwAnswer);

        bool DeleteHwAnswer(HwAnswer hwAnswer);

        HwAnswer? GetHwAnswerById(string hwAnswerId);

        IEnumerable<HwAnswer> GetAllHwAnswers();
    }
}
