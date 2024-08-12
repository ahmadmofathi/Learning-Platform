using Acedify.Web.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public class MaterialManager : IMaterialManager
    {
        private readonly IMaterialRepo _materialRepo;

        public MaterialManager(IMaterialRepo materialRepo)
        {
            _materialRepo = materialRepo;
        }

        public string AddMaterial(MaterialAddDTO material)
        {
            Material newMaterial = new Material
            {
                Material_Id = Guid.NewGuid().ToString(),
                File_Id = material.File_Id,
                File_Name = material.File_Name,
                File_Link = material.File_Link,
                CourseId = material.CourseId,
            };
            _materialRepo.AddMaterial(newMaterial);
            return newMaterial.Material_Id;
        }

        public string UpdateMaterial(MaterialDTO material)
        {
            if (material.Material_Id == null)
            {
                return "Material's Id is not found";
            }
            Material materialToUpdate = _materialRepo.GetMaterialById(material.Material_Id);
            if (materialToUpdate == null)
            {
                return "Material Not Found";
            }
            materialToUpdate.File_Id = material.File_Id;
            materialToUpdate.File_Name = material.File_Name;
            materialToUpdate.File_Link = material.File_Link;
            materialToUpdate.CourseId = material.CourseId;
            _materialRepo.UpdateMaterial(materialToUpdate);
            return "Material is Updated Successfully";
        }

        public bool DeleteMaterial(string materialId)
        {
            if (materialId == null)
            {
                return false;
            }
            var material = _materialRepo.GetMaterialById(materialId);
            if (material == null)
            {  return false; }
            _materialRepo.DeleteMaterial(material);
            return true;
        }

        public MaterialDTO? GetMaterialById(string materialId)
        {
            Material dbMaterial = _materialRepo.GetMaterialById(materialId);
            if (dbMaterial == null)
            {
                return null;
            }
            MaterialDTO Material = new MaterialDTO
            {
                Material_Id = dbMaterial.Material_Id,
                File_Id = dbMaterial.File_Id,
                File_Name = dbMaterial.File_Name,
                File_Link = dbMaterial.File_Link,
                CourseId = dbMaterial.CourseId,
            };
            return Material;
        }

        public IEnumerable<MaterialDTO> GetAllMaterials()
        {
            var materials = _materialRepo.GetAllMaterials();
            var allMaterials = materials.Select(dbMaterial => new MaterialDTO
            {
                Material_Id = dbMaterial.Material_Id,
                File_Id = dbMaterial.File_Id,
                File_Name = dbMaterial.File_Name,
                File_Link = dbMaterial.File_Link,
                CourseId = dbMaterial.CourseId,
            });
            return allMaterials;
        }
    }
}
