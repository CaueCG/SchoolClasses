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
    public class AlunoTurmaService : IAlunoTurmaService
    {
        private IAlunoTurmaRepository _alunoTurmaRepository;
        public AlunoTurmaService(IAlunoTurmaRepository alunoTurmaRepository)
        {
            _alunoTurmaRepository = alunoTurmaRepository;
        }

        public ViewBaseResponse Add(InputAlunoTurma alunoTurma)
        {
            ViewBaseResponse response = new ViewBaseResponse();

            try
            {
                AlunoTurmaModel model = new AlunoTurmaModel()
                {
                    IdAluno = alunoTurma.IdAluno,
                    IdTurma = alunoTurma.IdTurma
                };

                List<string> MessagesValidation = _alunoTurmaRepository.MessagesValidationsSave(model);

                if (MessagesValidation.Count == 0)
                    _alunoTurmaRepository.Add(model);
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

        public ViewBaseResponse Delete(int idAluno, int idTurma)
        {
            ViewBaseResponse response = new ViewBaseResponse();

            try
            {
                AlunoTurmaModel model = new AlunoTurmaModel
                {
                    IdAluno = idAluno,
                    IdTurma = idTurma
                };

                List<string> MessagesValidation = _alunoTurmaRepository.MessagesValidationsDelete(model);

                if (MessagesValidation.Count == 0)
                    _alunoTurmaRepository.Delete(model);
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
    }
}
