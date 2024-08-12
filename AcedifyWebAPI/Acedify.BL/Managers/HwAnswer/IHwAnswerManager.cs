using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public interface IHwAnswerManager
    {
        string AddHwAnswer(HwAnswerAddDTO hwAnswer);

        string UpdateHwAnswer(HwAnswerDTO hwAnswer);

        bool DeleteHwAnswer(string hwAnswerId);

        HwAnswerDTO? GetHwAnswerById(string hwAnswerId);

        IEnumerable<HwAnswerDTO> GetAllHwAnswers();
    }
}
