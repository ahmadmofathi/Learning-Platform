using Acedify.Web.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Acedify.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        private readonly IMaterialManager _materialManager;
        public MaterialsController(IMaterialManager materialManager)
        {
            _materialManager = materialManager;
        }

        [HttpGet]
        public ActionResult GetAllMaterials()
        {
            return Ok(_materialManager.GetAllMaterials());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetMaterial(string id)
        {
            if (id == null)
            {
                return BadRequest("Id is not found");
            }
            return Ok(_materialManager.GetMaterialById(id));
        }

        [HttpPost]
        public ActionResult AddMaterial(MaterialAddDTO material)
        {
            if (material == null)
            {
                return BadRequest("Material is Null");
            }
            return Ok(_materialManager.AddMaterial(material));
        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateMaterial(string id, MaterialDTO material)
        {
            if (id == null)
            {
                return BadRequest("Id is null");
            }
            return Ok(_materialManager.UpdateMaterial(material));
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteMaterial(string id)
        {
            if (id == null)
            {
                return BadRequest("Id is not found");
            }
            return Ok(_materialManager.DeleteMaterial(id));
        }
    }
}
