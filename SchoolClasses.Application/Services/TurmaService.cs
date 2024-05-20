using SchoolClasses.Application.RequestModels;
using SchoolClasses.Application.ResponseModels;
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
        public ViewBaseResponse Add(InputTurma turma)
        {
            ViewBaseResponse response = new ViewBaseResponse();

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

                List<string> MessagesValidation = _turmaRepository.MessagesValidationsSave(model);

                if (MessagesValidation.Count == 0)
                    _turmaRepository.Add(model);
                else
                    foreach (string message in MessagesValidation)
                        response.AddErrorMessage(message);

            }
            catch (Exception exc)
            {
                //POSSÍVEL INPLEMENTAÇÃO DE FERRAMENTA DE OBSERVABILIDADE COMO SERILOG
                System.Diagnostics.Debug.WriteLine(exc);
                response.AddErrorMessage("Operação instável, reporte um administrador");
            }

            return response;
        }

        public ViewBaseResponse Update(int id, InputTurma turma)
        {
            ViewBaseResponse response = new ViewBaseResponse();

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

                List<string> MessagesValidation = _turmaRepository.MessagesValidationsSave(model);

                if (MessagesValidation.Count == 0)
                    _turmaRepository.Update(model);
                else
                    foreach (string message in MessagesValidation)
                        response.AddErrorMessage(message);

            }
            catch (Exception exc)
            {
                //POSSÍVEL INPLEMENTAÇÃO DE FERRAMENTA DE OBSERVABILIDADE COMO SERILOG
                System.Diagnostics.Debug.WriteLine(exc);
                response.AddErrorMessage("Operação instável, reporte um administrador");
            }

            return response;
        }

        public ViewBaseResponse Delete(int id)
        {
            ViewBaseResponse response = new ViewBaseResponse();

            try
            {
                _turmaRepository.Delete(id);
            }
            catch (Exception exc)
            {
                //POSSÍVEL INPLEMENTAÇÃO DE FERRAMENTA DE OBSERVABILIDADE COMO SERILOG
                System.Diagnostics.Debug.WriteLine(exc);
                response.AddErrorMessage("Operação instável, reporte um administrador");
            }

            return response;
        }

        public ViewBaseResponse ToggleActivate(int id, ToggleActivate toggleActivate)
        {
            ViewBaseResponse response = new ViewBaseResponse();

            try
            {
                _turmaRepository.ToggleActivate(id, toggleActivate.IsAtivo);
            }
            catch (Exception exc)
            {
                //POSSÍVEL INPLEMENTAÇÃO DE FERRAMENTA DE OBSERVABILIDADE COMO SERILOG
                System.Diagnostics.Debug.WriteLine(exc);
                response.AddErrorMessage("Operação instável, reporte um administrador");
            }

            return response;
        }

        public List<ViewTurma> GetAll()
        {
            List<ViewTurma> lstResult = new List<ViewTurma>();
            try
            {
                List<TurmaModel> lst = _turmaRepository.getAll();
                lstResult = lst.Select(x => new ViewTurma(
                    x.Id, x.IdCurso, x.Nome, x.Ano, x.IsAtivo, x.DtCriacao)).ToList();
            }
            catch (Exception exc)
            {
                //POSSÍVEL INPLEMENTAÇÃO DE FERRAMENTA DE OBSERVABILIDADE COMO SERILOG
                ViewTurma model = new ViewTurma();
                model.AddErrorMessage("Pesquisa instável");
                lstResult.Add(model);
                System.Diagnostics.Debug.WriteLine(exc);
            }

            return lstResult;

        }
    }
}
