using SchoolClasses.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses.Core.Interfaces.Repositories
{
    public interface ICursoRepository
    {
        void Add(CursoModel turma);
        void Update(CursoModel turma);
        void Delete(int id);
        List<CursoModel> getAll();
    }
}
