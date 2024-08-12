using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public class SuperAdminRepo : ISuperAdminRepo
    {
        private readonly AppDbContext _context;

        public SuperAdminRepo(AppDbContext context)
        {
            _context = context;
        }

        public void AddSuperAdmin(SuperAdmin superAdmin)
        {
            _context.Set<SuperAdmin>().Add(superAdmin);
            _context.SaveChangesAsync();
        }

        public void UpdateSuperAdmin(SuperAdmin superAdmin)
        {

        }

        public bool DeleteSuperAdmin(SuperAdmin superAdmin)
        {
                _context.Set<SuperAdmin>().Remove(superAdmin);
                return true;
        }
        public SuperAdmin? GetSuperAdminById(string superAdminId)
        {
            return _context.Set<SuperAdmin>().FirstOrDefault(c => c.Id == superAdminId);
        }

        public IEnumerable<SuperAdmin> GetAllSuperAdmins()
        {
            return _context.Set<SuperAdmin>();
        }
    }
}
