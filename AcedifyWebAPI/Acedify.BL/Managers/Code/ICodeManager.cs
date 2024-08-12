using Acedify.Web.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public interface ICodeManager
    {
        string AddCode(CodeAddDTO code);

        string UpdateCode(CodeDTO code);

        bool DeleteCode(string codeId);

        CodeDTO? GetCodeById(string codeId);

        IEnumerable<CodeDTO> GetAllCodes();
    }
}
