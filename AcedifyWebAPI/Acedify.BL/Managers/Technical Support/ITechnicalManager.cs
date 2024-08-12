using System.Collections.Generic;

namespace Acedify.Web.BL
{
    public interface ITechnicalSupportManager
    {
        string AddTechnicalSupport(TechnicalSupportAddDTO technicalSupport);

        string UpdateTechnicalSupport(TechnicalSupportDTO technicalSupport);

        bool DeleteTechnicalSupport(string technicalSupportId);

        TechnicalSupportDTO? GetTechnicalSupportById(string technicalSupportId);

        IEnumerable<TechnicalSupportDTO> GetAllTechnicalSupports();
    }
}
