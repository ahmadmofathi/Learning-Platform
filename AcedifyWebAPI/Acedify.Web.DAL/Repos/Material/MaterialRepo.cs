using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public class MaterialRepo : IMaterialRepo
    {
        private readonly AppDbContext _context;

        public MaterialRepo(AppDbContext context)
        {
            _context = context;
        }

        public void AddMaterial(Material material)
        {
            _context.Set<Material>().Add(material);
            _context.SaveChangesAsync();
        }

        public void UpdateMaterial(Material material)
        {

        }

        public bool DeleteMaterial(Material material)
        {
                _context.Set<Material>().Remove(material);
                return true;
        }
        public Material? GetMaterialById(string materialId)
        {
            return _context.Set<Material>().FirstOrDefault(c => c.Material_Id == materialId);
        }

        public IEnumerable<Material> GetAllMaterials()
        {
            return _context.Set<Material>();
        }
    }
}
