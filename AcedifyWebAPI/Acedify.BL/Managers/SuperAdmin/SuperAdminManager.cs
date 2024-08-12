using Acedify.Web.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Acedify.Web.BL
{
    public class SuperAdminManager : ISuperAdminManager
    {
        private readonly ISuperAdminRepo _superAdminRepo;

        public SuperAdminManager(ISuperAdminRepo superAdminRepo)
        {
            _superAdminRepo = superAdminRepo;
        }

        public string AddSuperAdmin(SuperAdminAddDTO superAdmin)
        {
            SuperAdmin newSuperAdmin = new SuperAdmin
            {
                Id = Guid.NewGuid().ToString(),
                Name = superAdmin.Name,
                Email = superAdmin.Email,
                UserName = superAdmin.Username,
                Role = superAdmin.Role,
                JoinedAt = superAdmin.JoinedAt,
            };
            _superAdminRepo.AddSuperAdmin(newSuperAdmin);
            return newSuperAdmin.Id;
        }

        public string UpdateSuperAdmin(SuperAdminDTO superAdmin)
        {
            if (superAdmin.Id == null)
            {
                return "SuperAdmin's Id is not found";
            }
            SuperAdmin superAdminToUpdate = _superAdminRepo.GetSuperAdminById(superAdmin.Id);
            if (superAdminToUpdate == null)
            {
                return "SuperAdmin Not Found";
            }
            superAdminToUpdate.Name = superAdmin.Name;
            superAdminToUpdate.Email = superAdmin.Email;
            superAdminToUpdate.UserName = superAdmin.Username;
            superAdminToUpdate.Role = superAdmin.Role;
            superAdminToUpdate.JoinedAt = superAdmin.JoinedAt;
            superAdminToUpdate.ProfilePic = superAdmin.ProfilePic;
            _superAdminRepo.UpdateSuperAdmin(superAdminToUpdate);
            return "SuperAdmin is Updated Successfully";
        }

        public bool DeleteSuperAdmin(string superAdminId)
        {
            if (superAdminId == null)
            {
                return false;
            }
            var superAdmin = _superAdminRepo.GetSuperAdminById(superAdminId); 
            if (superAdmin == null)
            { return false; }
            _superAdminRepo.DeleteSuperAdmin(superAdmin);
            return true;
        }

        public SuperAdminDTO? GetSuperAdminById(string superAdminId)
        {
            SuperAdmin superAdmin = _superAdminRepo.GetSuperAdminById(superAdminId);
            if (superAdmin == null)
            {
                return null;
            }
            SuperAdminDTO superAdminDTO = new SuperAdminDTO
            {
                Id = superAdmin.Id,
                Name = superAdmin.Name,
                Email = superAdmin.Email,
                Username = superAdmin.UserName,
                Role = superAdmin.Role,
                JoinedAt = superAdmin.JoinedAt,
                ProfilePic = superAdmin.ProfilePic
            };
            return superAdminDTO;
        }

        public IEnumerable<SuperAdminDTO> GetAllSuperAdmins()
        {
            var superAdmins = _superAdminRepo.GetAllSuperAdmins();
            var allSuperAdmins = superAdmins.Select(superAdmin => new SuperAdminDTO
            {
                Id = superAdmin.Id,
                Name = superAdmin.Name,
                Email = superAdmin.Email,
                Username = superAdmin.UserName,
                Role = superAdmin.Role,
                JoinedAt = superAdmin.JoinedAt,
                ProfilePic = superAdmin.ProfilePic
            });
            return allSuperAdmins;
        }
    }
}
