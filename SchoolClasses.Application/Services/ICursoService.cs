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
    public interface ICursoService
    {
        ViewBaseResponse Add(InputCurso curso);
        ViewBaseResponse Update(int id, InputCurso curso);
        ViewBaseResponse Delete(int id);
        List<ViewCurso> GetAll();
		ViewCurso GetById(int id);

	}
}
