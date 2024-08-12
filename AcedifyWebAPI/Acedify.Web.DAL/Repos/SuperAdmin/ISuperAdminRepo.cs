using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public interface ISuperAdminRepo
    {
        void AddSuperAdmin(SuperAdmin superAdmin);

        void UpdateSuperAdmin(SuperAdmin superAdmin);

        bool DeleteSuperAdmin(SuperAdmin superAdmin);

        SuperAdmin? GetSuperAdminById(string superAdminId);

        IEnumerable<SuperAdmin> GetAllSuperAdmins();
    }
}
