using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public interface IAdminManager
    {
        string AddAdmin(AdminAddDTO admin);

        string UpdateAdmin(AdminDTO admin);

        bool DeleteAdmin(string adminId);

        AdminDTO GetAdminById(string adminId);

        IEnumerable<AdminDTO> GetAllAdmins();
    }
}
