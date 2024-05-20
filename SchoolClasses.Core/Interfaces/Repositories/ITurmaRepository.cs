using SchoolClasses.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses.Core.Interfaces.Repositories
{
    public interface ITurmaRepository
    {
        void Add(TurmaModel turma);
        void Update(TurmaModel turma);
        void Delete(int id);
        void ToggleActivate(int id, bool toggleActivate);
        List<TurmaModel> getAll();
        //List<string> MessagesValidationsSave(TurmaModel turma); //ABSTRAÇÃO QUE VERIFICA AS REGRAS DE NEGÓCIO ANTES DE DAR ADD OU UPDATE

    }
}
