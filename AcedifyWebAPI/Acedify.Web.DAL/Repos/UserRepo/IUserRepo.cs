using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public interface IUserRepo
    {
        // Adds a new user to the repository
        void AddUser(User user);

        // Updates an existing user in the repository
        void UpdateUser(User user);

        // Deletes a user from the repository
        bool DeleteUser(User user);

        // Retrieves a user by their ID
        User? GetUserById(string userId);

        // Retrieves all users in the repository
        IEnumerable<User> GetAllUsers();
    }
}
