using Acedify.Web.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public class AdminManager : IAdminManager
    {
        private readonly IAdminRepo _adminRepo;

        public AdminManager(IAdminRepo adminRepo)
        {
            _adminRepo = adminRepo;
        }

        public string AddAdmin(AdminAddDTO admin)
        {
            Admin newAdmin = new Admin
            {
               Id = Guid.NewGuid().ToString(),
               Name = admin.Name,
               Email= admin.Email,
               UserName = admin.Username,
               Payment_Method = admin.Payment_Method,
               Role = admin.Role,
            };
            _adminRepo.AddAdminAsync(newAdmin);
            return newAdmin.Id;
        }

        public string UpdateAdmin(AdminDTO admin)
        {
            if(admin.AdminId == null)
            {
                return "Admin's Id is not found";
            }
            Admin adminToUpdate = _adminRepo.GetAdminByIdAsync(admin.AdminId);
            if(adminToUpdate == null)
            {
                return "Admin Not Found";
            }
            adminToUpdate.Payment_Method= admin.Payment_Method;
            adminToUpdate.Role= admin.Role;
            adminToUpdate.Name= admin.Name;
            adminToUpdate.Email= admin.Email;
            adminToUpdate.UserName= admin.Username;
            adminToUpdate.ProfilePic= admin.ProfilePic;
            _adminRepo.UpdateAdminAsync(adminToUpdate);
            return "Admin is Updated Successfully";
        }

        public bool DeleteAdmin(string adminId)
        {
            Admin adminToDelete = _adminRepo.GetAdminByIdAsync(adminId);
            if(adminToDelete == null)
            {
                return false;
            }
            _adminRepo.DeleteAdminAsync(adminToDelete);
            return true;
        }

        public AdminDTO? GetAdminById(string adminId)
        {
            Admin dbAdmin = _adminRepo.GetAdminByIdAsync(adminId);
            if(dbAdmin == null)
            {
                return null;
            }
            AdminDTO Admin = new AdminDTO
            {
                AdminId = adminId,
                Name = dbAdmin.Name,
                Email = dbAdmin.Email,
                Username = dbAdmin.UserName,
                Payment_Method = dbAdmin.Payment_Method,
                Role = dbAdmin.Role,
                ProfilePic = dbAdmin.ProfilePic,
            };
            return Admin;
        }

        public IEnumerable<AdminDTO> GetAllAdmins()
        {
            var admins = _adminRepo.GetAllAdminsAsync();
            var allAdmins = admins.Select(admin => new AdminDTO
            {
                AdminId = admin.Id,
                Name = admin.Name,
                Email = admin.Email,
                Username = admin.UserName,
                Payment_Method = admin.Payment_Method,
                Role = admin.Role,
                ProfilePic = admin.ProfilePic,
            });
            return allAdmins;
        }
    }
}
