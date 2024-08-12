using Acedify.Web.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public class CodeManager : ICodeManager
    {
        private readonly ICodeRepo _codeRepo;

        public CodeManager(ICodeRepo codeRepo)
        {
            _codeRepo = codeRepo;
        }

        public string AddCode(CodeAddDTO code)
        {
            Code newCode = new Code
            {
                CodeId = Guid.NewGuid().ToString(),
                CodeName = code.CodeName,
                Price = code.Price,
                StudentId = code.StudentId,
            };
            _codeRepo.AddCode(newCode);
            return newCode.CodeId;
        }

        public string UpdateCode(CodeDTO code)
        {
            if (code.CodeId == null)
            {
                return "Code's Id is not found";
            }
            Code codeToUpdate = _codeRepo.GetCodeById(code.CodeId);
            if (codeToUpdate == null)
            {
                return "Code Not Found";
            }
            codeToUpdate.CodeName = code.CodeName;
            codeToUpdate.StudentId = code.StudentId;
            codeToUpdate.Price = code.Price;
            _codeRepo.UpdateCode(codeToUpdate);
            return "Code is Updated Successfully";
        }

        public bool DeleteCode(string codeId)
        {
            if (codeId == null)
            {
                return false;
            }
            var code = _codeRepo.GetCodeById(codeId);
            if (code == null) { return false; }
            _codeRepo.DeleteCode(code);
            return true;
        }

        public CodeDTO? GetCodeById(string codeId)
        {
            Code dbCode = _codeRepo.GetCodeById(codeId);
            if (dbCode == null)
            {
                return null;
            }
            CodeDTO Code = new CodeDTO
            {
                CodeId = codeId,
                CodeName = dbCode.CodeName,
                Price = dbCode.Price,
                StudentId = dbCode.StudentId,
            };
            return Code;
        }

        public IEnumerable<CodeDTO> GetAllCodes()
        {
            var codes = _codeRepo.GetAllCodes();
            var allCodes = codes.Select(code => new CodeDTO
            {
                CodeId = code.CodeId,
                CodeName = code.CodeName,
                Price = code.Price,
                StudentId = code.StudentId,
            });
            return allCodes;
        }
    }
}
