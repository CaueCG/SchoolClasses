using SchoolClasses.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses.Core.Interfaces.Repositories
{
    public interface IAlunoTurmaRepository
    {
        void Delete(AlunoTurmaModel alunoTurma);
        void Add(AlunoTurmaModel alunoTurma);
        List<string> MessagesValidationsSave(AlunoTurmaModel model);
    }
}
