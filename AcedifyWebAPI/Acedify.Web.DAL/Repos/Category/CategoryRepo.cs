using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly AppDbContext _context;

        public CategoryRepo(AppDbContext context)
        {
            _context = context;
        }

        public void AddCategory(Category category)
        {
            _context.Set<Category>().Add(category);
        }

        public void UpdateCategory(Category category)
        {
            
        }

        public bool DeleteCategory(Category category)
        {
                _context.Set<Category>().Remove(category);
                return true;
        }
        public Category? GetCategoryById(string categoryId)
        {
            return _context.Set<Category>().FirstOrDefault(c=> c.CategoryId==categoryId);
        }

        public IEnumerable<Category> GetAllCategorys()
        {
            return _context.Set<Category>();
        }
    }
}
