using Acedify.Web.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Acedify.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManager _codeManager;
        public CategoryController(ICategoryManager codeManager)
        {
            _codeManager = codeManager;
        }

        [HttpGet]
        public ActionResult GetAllCategorys()
        {
            return Ok(_codeManager.GetAllCategorys());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetCategory(string id)
        {
            if (id == null)
            {
                return BadRequest("Id is not found");
            }
            return Ok(_codeManager.GetCategoryById(id));
        }

        [HttpPost]
        public ActionResult AddCategory(CategoryAddDTO code)
        {
            if (code == null)
            {
                return BadRequest("Category is Null");
            }
            return Ok(_codeManager.AddCategory(code));
        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateCategory(string id, CategoryDTO code)
        {
            if (id == null)
            {
                return BadRequest("Id is null");
            }
            return Ok(_codeManager.UpdateCategory(code));
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteCategory(string id)
        {
            if (id == null)
            {
                return BadRequest("Id is not found");
            }
            return Ok(_codeManager.DeleteCategory(id));
        }
    }
}
