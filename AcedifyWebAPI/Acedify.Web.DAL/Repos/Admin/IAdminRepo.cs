using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public interface IAdminRepo
    {
        void AddAdminAsync(Admin admin);

        void UpdateAdminAsync(Admin admin);

        void DeleteAdminAsync(Admin admin);

        Admin? GetAdminByIdAsync(string adminId);

        IEnumerable<Admin> GetAllAdminsAsync();
    }
}
