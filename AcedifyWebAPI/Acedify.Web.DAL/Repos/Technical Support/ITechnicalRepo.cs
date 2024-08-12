using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public interface ITechnicalRepo
    {
        void AddTechnicalSupport(TechnicalSupport technical);

        void UpdateTechnicalSupport(TechnicalSupport technical);

        bool DeleteTechnicalSupport(TechnicalSupport technical);

        TechnicalSupport? GetTechnicalSupportById(string technicalId);

        IEnumerable<TechnicalSupport> GetAllTechnicalSupports();
    }
}
