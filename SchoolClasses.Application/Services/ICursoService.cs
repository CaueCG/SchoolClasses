﻿using SchoolClasses.Application.RequestModels;
using SchoolClasses.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses.Application.Services
{
    public interface ICursoService
    {
        void Add(InputCurso curso);
        void Update(int id, InputCurso curso);
        void Delete(int id);
        List<CursoModel> GetAll();

    }
}
