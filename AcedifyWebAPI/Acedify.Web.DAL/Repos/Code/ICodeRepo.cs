using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public interface ICodeRepo
    {
        void AddCode(Code code);

        void UpdateCode(Code code);

        bool DeleteCode(Code code);

        Code? GetCodeById(string codeId);

        IEnumerable<Code> GetAllCodes();
    }
}
