using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public class HomeworkRepo:IHomeworkRepo
    {
        private readonly AppDbContext _context;

        public HomeworkRepo(AppDbContext context)
        {
            _context = context;
        }

        public void AddHomework(Homework homework)
        {
            _context.Set<Homework>().Add(homework);
            _context.SaveChangesAsync();
        }

        public void UpdateHomework(Homework homework)
        {

        }

        public bool DeleteHomework(Homework homework)
        {
                _context.Set<Homework>().Remove(homework);
                return true;
        }
        public Homework? GetHomeworkById(string homeworkId)
        {
            return _context.Set<Homework>().FirstOrDefault(c => c.HW_ID == homeworkId);
        }

        public IEnumerable<Homework> GetAllHomeworks()
        {
            return _context.Set<Homework>();
        }
    }
}
