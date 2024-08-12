using System.Collections.Generic;

namespace Acedify.Web.BL
{
    public interface ISuperAdminManager
    {
        string AddSuperAdmin(SuperAdminAddDTO superAdmin);

        string UpdateSuperAdmin(SuperAdminDTO superAdmin);

        bool DeleteSuperAdmin(string superAdminId);

        SuperAdminDTO? GetSuperAdminById(string superAdminId);

        IEnumerable<SuperAdminDTO> GetAllSuperAdmins();
    }
}
