using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public interface ICategoryRepo
    {
        void AddCategory(Category category);

        void UpdateCategory(Category category);

        bool DeleteCategory(Category category);

        Category? GetCategoryById(string categoryId);

        IEnumerable<Category> GetAllCategorys();
    }
}
