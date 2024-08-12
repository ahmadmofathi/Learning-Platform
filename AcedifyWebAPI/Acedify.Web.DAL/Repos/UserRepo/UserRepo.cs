using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext _context;

        public UserRepo(AppDbContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Set<User>().Add(user);
            _context.SaveChangesAsync();
        }

        public void UpdateUser(User user)
        {

        }

        public bool DeleteUser(User user)
        {
                _context.Set<User>().Remove(user);
                return true;
        }
        public User? GetUserById(string userId)
        {
            return _context.Set<User>().FirstOrDefault(c => c.Id == userId);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Set<User>();
        }
    }
}
