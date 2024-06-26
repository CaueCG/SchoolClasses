﻿using SchoolClasses.Application.RequestModels;
using SchoolClasses.Application.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses.Application.Services
{
    public interface IAlunoService
    {
        ViewBaseResponse Add(InputAluno aluno);
        ViewBaseResponse Update(int id, InputUpdateAluno aluno);
        ViewBaseResponse Delete(int id);
        ViewBaseResponse ToggleActivate(int id, ToggleActivate toggleActivate);
        List<ViewAluno> GetAll();
        List<ViewAluno> GetByIdTurma(int idTurma);
        ViewAluno GetById(int id);
    }
}
