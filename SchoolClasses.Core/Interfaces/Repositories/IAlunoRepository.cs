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
        List<AlunoModel> GetByIdTurma(int idTurma);
        List<string> MessagesValidationsSave(AlunoModel aluno); //ABSTRAÇÃO QUE VERIFICA AS REGRAS DE NEGÓCIO ANTES DE DAR ADD OU UPDATE

    }
}
