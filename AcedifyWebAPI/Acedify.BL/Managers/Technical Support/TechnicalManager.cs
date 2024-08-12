using Acedify.Web.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Acedify.Web.BL
{
    public class TechnicalSupportManager : ITechnicalSupportManager
    {
        private readonly ITechnicalRepo _technicalSupportRepo;

        public TechnicalSupportManager(ITechnicalRepo technicalSupportRepo)
        {
            _technicalSupportRepo = technicalSupportRepo;
        }

        public string AddTechnicalSupport(TechnicalSupportAddDTO technicalSupport)
        {
            TechnicalSupport newTechnicalSupport = new TechnicalSupport
            {
                Id = Guid.NewGuid().ToString(),
                Name = technicalSupport.Name,
                Email = technicalSupport.Email,
                UserName = technicalSupport.Username,
                Role = technicalSupport.Role,
                ID_Number = technicalSupport.ID_Number,
                Facebook_Link = technicalSupport.Facebook_Link,
                Phone = technicalSupport.Phone,
                TeacherId = technicalSupport.TeacherId
            };
            _technicalSupportRepo.AddTechnicalSupport(newTechnicalSupport);
            return newTechnicalSupport.Id;
        }

        public string UpdateTechnicalSupport(TechnicalSupportDTO technicalSupport)
        {
            if (technicalSupport.Id == null)
            {
                return "Technical Support's Id is not found";
            }
            TechnicalSupport technicalSupportToUpdate = _technicalSupportRepo.GetTechnicalSupportById(technicalSupport.Id);
            if (technicalSupportToUpdate == null)
            {
                return "Technical Support Not Found";
            }
            technicalSupportToUpdate.Name = technicalSupport.Name;
            technicalSupportToUpdate.Email = technicalSupport.Email;
            technicalSupportToUpdate.UserName = technicalSupport.Username;
            technicalSupportToUpdate.Role = technicalSupport.Role;
            technicalSupportToUpdate.ProfilePic = technicalSupport.ProfilePic;
            technicalSupportToUpdate.ID_Number = technicalSupport.ID_Number;
            technicalSupportToUpdate.Facebook_Link = technicalSupport.Facebook_Link;
            technicalSupportToUpdate.Phone = technicalSupport.Phone;
            technicalSupportToUpdate.TeacherId = technicalSupport.TeacherId;
            _technicalSupportRepo.UpdateTechnicalSupport(technicalSupportToUpdate);
            return "Technical Support is Updated Successfully";
        }

        public bool DeleteTechnicalSupport(string technicalSupportId)
        {
            if (technicalSupportId == null)
            {
                return false;
            }
            var tech = _technicalSupportRepo.GetTechnicalSupportById(technicalSupportId);
            if (tech == null)
            { return false; }
            _technicalSupportRepo.DeleteTechnicalSupport(tech);
            return true;
        }

        public TechnicalSupportDTO? GetTechnicalSupportById(string technicalSupportId)
        {
            TechnicalSupport technicalSupport = _technicalSupportRepo.GetTechnicalSupportById(technicalSupportId);
            if (technicalSupport == null)
            {
                return null;
            }
            TechnicalSupportDTO technicalSupportDTO = new TechnicalSupportDTO
            {
                Id = technicalSupport.Id,
                Name = technicalSupport.Name,
                Email = technicalSupport.Email,
                Username = technicalSupport.UserName,
                Role = technicalSupport.Role,
                ProfilePic = technicalSupport.ProfilePic,
                ID_Number = technicalSupport.ID_Number,
                Facebook_Link = technicalSupport.Facebook_Link,
                Phone = technicalSupport.Phone,
                TeacherId = technicalSupport.TeacherId
            };
            return technicalSupportDTO;
        }

        public IEnumerable<TechnicalSupportDTO> GetAllTechnicalSupports()
        {
            var technicalSupports = _technicalSupportRepo.GetAllTechnicalSupports();
            var allTechnicalSupports = technicalSupports.Select(technicalSupport => new TechnicalSupportDTO
            {
                Id = technicalSupport.Id,
                Name = technicalSupport.Name,
                Email = technicalSupport.Email,
                Username = technicalSupport.UserName,
                Role = technicalSupport.Role,
                ProfilePic = technicalSupport.ProfilePic,
                ID_Number = technicalSupport.ID_Number,
                Facebook_Link = technicalSupport.Facebook_Link,
                Phone = technicalSupport.Phone,
                TeacherId = technicalSupport.TeacherId
            });
            return allTechnicalSupports;
        }
    }
}
