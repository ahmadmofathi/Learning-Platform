using Acedify.Web.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public interface IHomeworkManager
    {
        string AddHomework(HomeworkAddDTO homework);

        string UpdateHomework(HomeworkDTO homework);

        bool DeleteHomework(string homeworkId);

        HomeworkDTO? GetHomeworkById(string homeworkId);

        IEnumerable<HomeworkDTO> GetAllHomeworks();
    }
}
