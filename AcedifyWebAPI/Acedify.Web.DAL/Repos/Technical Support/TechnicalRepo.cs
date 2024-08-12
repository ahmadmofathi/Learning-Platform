using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public class TechnicalRepo : ITechnicalRepo
    {
        private readonly AppDbContext _context;

        public TechnicalRepo(AppDbContext context)
        {
            _context = context;
        }

        public void AddTechnicalSupport(TechnicalSupport technicalSupport)
        {
            _context.Set<TechnicalSupport>().Add(technicalSupport);
            _context.SaveChangesAsync();
        }

        public void UpdateTechnicalSupport(TechnicalSupport technicalSupport)
        {

        }

        public bool DeleteTechnicalSupport(TechnicalSupport technical)
        {
                _context.Set<TechnicalSupport>().Remove(technical);
                return true;
        }
        public TechnicalSupport? GetTechnicalSupportById(string technicalSupportId)
        {
            return _context.Set<TechnicalSupport>().FirstOrDefault(c => c.Id == technicalSupportId);
        }

        public IEnumerable<TechnicalSupport> GetAllTechnicalSupports()
        {
            return _context.Set<TechnicalSupport>();
        }
    }
}
