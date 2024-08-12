using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public interface IMaterialManager
    {
        string AddMaterial(MaterialAddDTO material);

        string UpdateMaterial(MaterialDTO material);

        bool DeleteMaterial(string materialId);

        MaterialDTO? GetMaterialById(string materialId);

        IEnumerable<MaterialDTO> GetAllMaterials();
    }
}
