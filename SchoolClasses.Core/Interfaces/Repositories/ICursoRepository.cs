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
        void Add(CursoModel curso);
        void Update(CursoModel curso);
        void Delete(int id);
        List<CursoModel> getAll();
        //bool CanSave(CursoModel curso); //ABSTRAÇÃO QUE VERIFICA AS REGRAS DE NEGÓCIO ANTES DE DAR ADD OU UPDATE
    }
}
