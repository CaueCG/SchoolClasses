using SchoolClasses.Application.RequestModels;
using SchoolClasses.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses.Application.Services
{
    public interface ITurmaService
    {
        void Add(InputTurma turma);
        void Update(int id, InputTurma turma);
        void Delete (int id);
        void ToggleActivate(int id, ToggleActivate toggleActivate);
        List<TurmaModel> GetAll();
    }
}
