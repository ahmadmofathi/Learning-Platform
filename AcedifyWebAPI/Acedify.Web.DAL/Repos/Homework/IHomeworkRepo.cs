using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public interface IHomeworkRepo
    {
        void AddHomework(Homework homework);

        void UpdateHomework(Homework homework);

        bool DeleteHomework(Homework homework);

        Homework? GetHomeworkById(string homeworkId);

        IEnumerable<Homework> GetAllHomeworks();
    }
}
