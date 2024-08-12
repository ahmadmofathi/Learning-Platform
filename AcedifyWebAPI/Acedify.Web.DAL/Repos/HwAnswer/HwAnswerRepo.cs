using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public class HwAnswerRepo : IHwAnswerRepo
    {
        private readonly AppDbContext _context;

        public HwAnswerRepo(AppDbContext context)
        {
            _context = context;
        }

        public void AddHwAnswer(HwAnswer hwAnswer)
        {
            _context.Set<HwAnswer>().Add(hwAnswer);
            _context.SaveChangesAsync();
        }

        public void UpdateHwAnswer(HwAnswer hwAnswer)
        {

        }

        public bool DeleteHwAnswer(HwAnswer hwAnswer)
        {
                _context.Set<HwAnswer>().Remove(hwAnswer);
                return true;
        }
        public HwAnswer? GetHwAnswerById(string hwAnswerId)
        {
            return _context.Set<HwAnswer>().FirstOrDefault(c => c.HwId == hwAnswerId);
        }

        public IEnumerable<HwAnswer> GetAllHwAnswers()
        {
            return _context.Set<HwAnswer>();
        }
    }
}
