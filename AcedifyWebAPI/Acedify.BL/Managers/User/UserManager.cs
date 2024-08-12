using Acedify.Web.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepo _userRepo;

        public UserManager(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public string AddUser(UserAddDTO user)
        {
            User newUser = new User
            {
                Id = Guid.NewGuid().ToString(),
                Name = user.Name,
                Email = user.Email,
                UserName = user.Username,
                Role = user.Role,
            };
            _userRepo.AddUser(newUser);
            return newUser.Id;
        }

        public string UpdateUser(UserDTO user)
        {
            if (user.Id == null)
            {
                return "User's Id is not found";
            }
            User userToUpdate = _userRepo.GetUserById(user.Id);
            if (userToUpdate == null)
            {
                return "User Not Found";
            }
            userToUpdate.Role = user.Role;
            userToUpdate.Name = user.Name;
            userToUpdate.Email = user.Email;
            userToUpdate.UserName = user.Username;
            userToUpdate.ProfilePic = user.ProfilePic;
            _userRepo.UpdateUser(userToUpdate);
            return "User is Updated Successfully";
        }

        public bool DeleteUser(string userId)
        {
            if (userId == null)
            {
                return false;
            }
            var user = _userRepo.GetUserById(userId);
            if (user == null)
            {
                return false;
            }
            _userRepo.DeleteUser(user);
            return true;
        }

        public UserDTO? GetUserById(string userId)
        {
            User dbUser = _userRepo.GetUserById(userId);
            if (dbUser == null)
            {
                return null;
            }
            UserDTO User = new UserDTO
            {
                Id = userId,
                Name = dbUser.Name,
                Email = dbUser.Email,
                Username = dbUser.UserName,
                Role = dbUser.Role,
                ProfilePic = dbUser.ProfilePic,
            };
            return User;
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            var users = _userRepo.GetAllUsers();
            var allUsers = users.Select(user => new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Username = user.UserName,
                Role = user.Role,
                ProfilePic = user.ProfilePic,
            });
            return allUsers;
        }
    }
}
