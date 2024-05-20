using SchoolClasses.Application.RequestModels;
using SchoolClasses.Application.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses.Application.Services
{
    public interface IAlunoTurmaService
    {
        ViewBaseResponse Add(InputAlunoTurma alunoTurma);
        ViewBaseResponse Delete(int idAluno, int idTurma);
    }
}
