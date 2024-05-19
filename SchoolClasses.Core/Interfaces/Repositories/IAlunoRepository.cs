using SchoolClasses.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses.Core.Interfaces.Repositories
{
    public interface IAlunoRepository
    {
        void Add(AlunoModel turma);
        void Update(AlunoModel turma);
        void Delete(int id);
        void ToggleActivate(int id, bool toggleActivate);
        List<AlunoModel> getAll();
    }
}
