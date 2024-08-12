using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public interface IUserManager
    {
        string AddUser(UserAddDTO user);

        string UpdateUser(UserDTO user);

        bool DeleteUser(string userId);

        UserDTO? GetUserById(string userId);

        IEnumerable<UserDTO> GetAllUsers();
    }
}
