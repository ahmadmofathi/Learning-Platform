using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public interface ICategoryManager
    {
        string AddCategory(CategoryAddDTO category);

        string UpdateCategory(CategoryDTO category);

        bool DeleteCategory(string categoryId);

        CategoryDTO? GetCategoryById(string categoryId);

        IEnumerable<CategoryDTO> GetAllCategorys();
    }
}
