using Acedify.Web.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryRepo _categoryRepo;

        public CategoryManager(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public string AddCategory(CategoryAddDTO category)
        {
            Category newCategory = new Category
            {
                CategoryId = Guid.NewGuid().ToString(),
                CategoryName = category.CategoryName,
                CategoryThumbnail = category.CategoryThumbnail,
                Lectures_No = category.Lectures_No,
                TeacherId = category.TeacherId,
            };
            _categoryRepo.AddCategory(newCategory);
            return newCategory.CategoryId;
        }

        public string UpdateCategory(CategoryDTO category)
        {
            if (category.CategoryId == null)
            {
                return "Category's Id is not found";
            }
            Category categoryToUpdate = _categoryRepo.GetCategoryById(category.CategoryId);
            if (categoryToUpdate == null)
            {
                return "Category Not Found";
            }
            categoryToUpdate.CategoryName = category.CategoryName;
            categoryToUpdate.TeacherId = category.TeacherId;
            categoryToUpdate.CategoryThumbnail = category.CategoryThumbnail;
            categoryToUpdate.Lectures_No = category.Lectures_No;
            _categoryRepo.UpdateCategory(categoryToUpdate);
            return "Category is Updated Successfully";
        }

        public bool DeleteCategory(string categoryId)
        {
            if (categoryId == null)
            {
                return false;
            }
            var category = _categoryRepo.GetCategoryById(categoryId);
            if (category == null)
            {
                return false;
            }
            _categoryRepo.DeleteCategory(category);
            return true;
        }

        public CategoryDTO? GetCategoryById(string categoryId)
        {
            Category dbCategory = _categoryRepo.GetCategoryById(categoryId);
            if (dbCategory == null)
            {
                return null;
            }
            CategoryDTO Category = new CategoryDTO
            {
                CategoryId = categoryId,
                CategoryName = dbCategory.CategoryName,
                CategoryThumbnail = dbCategory.CategoryThumbnail,
                Lectures_No = dbCategory.Lectures_No,
                TeacherId = dbCategory.TeacherId,
            };
            return Category;
        }

        public IEnumerable<CategoryDTO> GetAllCategorys()
        {
            var categorys = _categoryRepo.GetAllCategorys();
            var allCategorys = categorys.Select(category => new CategoryDTO
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                CategoryThumbnail = category.CategoryThumbnail,
                Lectures_No = category.Lectures_No,
                TeacherId = category.TeacherId,
            });
            return allCategorys;
        }
    }
}
