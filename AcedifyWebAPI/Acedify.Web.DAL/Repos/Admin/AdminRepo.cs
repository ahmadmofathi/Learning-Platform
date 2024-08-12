using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public class AdminRepo : IAdminRepo
    {
        private readonly AppDbContext _context;

        public AdminRepo(AppDbContext context)
        {
            _context = context;
        }

        public void AddAdminAsync(Admin admin)
        {
            _context.Set<Admin>().Add(admin);
            _context.SaveChangesAsync();
        }

        public void UpdateAdminAsync(Admin admin)
        {
            _context.SaveChanges();
        }

        public void DeleteAdminAsync(Admin admin)
        {
                _context.Set<Admin>().Remove(admin);
                _context.SaveChangesAsync();
        }

        public Admin? GetAdminByIdAsync(string adminId)
        {
            return _context.Set<Admin>().Find(adminId);
        }

        public IEnumerable<Admin> GetAllAdminsAsync()
        {
            return _context.Set<Admin>();
        }
    }
}
