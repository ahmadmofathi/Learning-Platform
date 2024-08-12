using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public interface IMaterialRepo
    {
        void AddMaterial(Material material);

        void UpdateMaterial(Material material);

        bool DeleteMaterial(Material material);

        Material? GetMaterialById(string materialId);

        IEnumerable<Material> GetAllMaterials();
    }
}
