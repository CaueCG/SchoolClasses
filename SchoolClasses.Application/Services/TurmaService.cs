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
    public class TurmaService : ITurmaService
    {
        private ITurmaRepository _turmaRepository;
        public TurmaService(ITurmaRepository turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }
        public void Add(InputTurma turma)
        {
            try
            {
                TurmaModel model = new TurmaModel
                {
                    Nome = turma.Nome,
                    IdCurso = turma.IdCurso,
                    Ano = turma.Ano,
                    DtCriacao = DateTime.Now,
                    IsAtivo = turma.IsAtivo
                };

                _turmaRepository.Add(model);
            }
            catch (Exception exc)
            {
                //POSSÍVEL INPLEMENTAÇÃO DE FERRAMENTA DE OBSERVABILIDADE COMO SERILOG
                System.Diagnostics.Debug.WriteLine(exc);
            }
        }
        public void Update(int id, InputTurma turma)
        {
            try
            {
                TurmaModel model = new TurmaModel
                {
                    Id = id,
                    Nome = turma.Nome,
                    IdCurso = turma.IdCurso,
                    Ano = turma.Ano,
                    DtCriacao = DateTime.Now,
                    IsAtivo = turma.IsAtivo
                };

                _turmaRepository.Update(model);
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
                _turmaRepository.Delete(id);
            }
            catch (Exception exc)
            {
                //POSSÍVEL INPLEMENTAÇÃO DE FERRAMENTA DE OBSERVABILIDADE COMO SERILOG
                System.Diagnostics.Debug.WriteLine(exc);
            }
        }
        public void ToggleActivate(int id, ToggleActivate toggleActivate)
        {
            try
            {
                _turmaRepository.ToggleActivate(id, toggleActivate.IsAtivo);
            }
            catch (Exception exc)
            {
                //POSSÍVEL INPLEMENTAÇÃO DE FERRAMENTA DE OBSERVABILIDADE COMO SERILOG
                System.Diagnostics.Debug.WriteLine(exc);
            }
        }
        public List<TurmaModel> GetAll()
        {
            List<TurmaModel> lstResult = new List<TurmaModel>();
            try
            {
                lstResult = _turmaRepository.getAll();
            }
            catch (Exception exc)
            {
                //POSSÍVEL INPLEMENTAÇÃO DE FERRAMENTA DE OBSERVABILIDADE COMO SERILOG
                System.Diagnostics.Debug.WriteLine(exc);
            }

            return lstResult;
        }
    }
}
