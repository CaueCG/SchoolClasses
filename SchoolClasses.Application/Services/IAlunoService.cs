using SchoolClasses.Application.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses.Application.Services
{
    public interface IAlunoService
    {
        void Add(InputAluno aluno);
        void Update(int id, InputAluno aluno);
        void Delete(int id);
        void ToggleActivate(int id, ToggleActivate toggleActivate);
        void GetAll();
    }
}
