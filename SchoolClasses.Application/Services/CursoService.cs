using SchoolClasses.Application.RequestModels;
using SchoolClasses.Core.Interfaces.Repositories;
using SchoolClasses.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses.Application.Services
{
    public class CursoService : ICursoService
    {
        private ICursoRepository _cursoRepository;
        public CursoService(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public void Add(InputCurso curso)
        {
            try
            {
                CursoModel model = new CursoModel
                {
                    Nome = curso.Nome
                };

                _cursoRepository.Add(model);
            }
            catch (Exception exc)
            {
                //POSSÍVEL INPLEMENTAÇÃO DE FERRAMENTA DE OBSERVABILIDADE COMO SERILOG
                System.Diagnostics.Debug.WriteLine(exc);
            }
        }
        public void Update(int id, InputCurso curso)
        {
            try
            {
                CursoModel model = new CursoModel
                {
                    Id = id,
                    Nome = curso.Nome
                };

                _cursoRepository.Update(model);
            }
            catch (Exception exc)
            {
                //POSSÍVEL INPLEMENTAÇÃO DE FERRAMENTA DE OBSERVABILIDADE COMO SERILOG
                System.Diagnostics.Debug.WriteLine(exc);
            }
        }
        public void Delete(int id)
        {
            try
            {
                _cursoRepository.Delete(id);
            }
            catch (Exception exc)
            {
                //POSSÍVEL INPLEMENTAÇÃO DE FERRAMENTA DE OBSERVABILIDADE COMO SERILOG
                System.Diagnostics.Debug.WriteLine(exc);
            }
        }
        public List<CursoModel> GetAll()
        {
            List<CursoModel> lst = new List<CursoModel>();
            try
            {
                lst = _cursoRepository.getAll();
            }
            catch (Exception exc)
            {
                //POSSÍVEL INPLEMENTAÇÃO DE FERRAMENTA DE OBSERVABILIDADE COMO SERILOG
                System.Diagnostics.Debug.WriteLine(exc);
            }

            return lst;
        }
    }
}
