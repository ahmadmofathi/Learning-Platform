using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public class CodeRepo : ICodeRepo
    {
        private readonly AppDbContext _context;

        public CodeRepo(AppDbContext context)
        {
            _context = context;
        }

        public void AddCode(Code code)
        {
            _context.Set<Code>().Add(code);
            _context.SaveChangesAsync();
        }

        public void UpdateCode(Code code)
        {

        }

        public bool DeleteCode(Code code)
        {
                _context.Set<Code>().Remove(code);
                return true;
        }
        public Code? GetCodeById(string codeId)
        {
            return _context.Set<Code>().FirstOrDefault(c => c.CodeId == codeId);
        }

        public IEnumerable<Code> GetAllCodes()
        {
            return _context.Set<Code>();
        }
    }
}
