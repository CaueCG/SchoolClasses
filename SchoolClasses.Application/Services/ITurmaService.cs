using SchoolClasses.Application.RequestModels;
using SchoolClasses.Application.ResponseModels;
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
        ViewBaseResponse Add(InputTurma turma);
        ViewBaseResponse Update(int id, InputTurma turma);
        ViewBaseResponse Delete (int id);
        ViewBaseResponse ToggleActivate(int id, ToggleActivate toggleActivate);
        List<ViewTurma> GetAll();
        ViewTurma GetById(int id);
    }
}
