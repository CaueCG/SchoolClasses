using SchoolClasses.Application.RequestModels;
using SchoolClasses.Application.ResponseModels;
using SchoolClasses.Core.Interfaces.Repositories;
using SchoolClasses.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses.Application.Services
{
    public class AlunoService : IAlunoService
    {
        private IAlunoRepository _alunoRepository;
        public AlunoService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }
        public void Add(InputAluno aluno)
        {
            try
            {
                AlunoModel model = new AlunoModel
                {
                    Nome = aluno.Nome,
                    Usuario = aluno.Usuario,
                    Senha = aluno.Senha,
                    DtCriacao = DateTime.Now,
                    IsAtivo = aluno.IsAtivo
                };

                _alunoRepository.Add(model);
            }
            catch (Exception exc)
            {
                //POSSÍVEL INPLEMENTAÇÃO DE FERRAMENTA DE OBSERVABILIDADE COMO SERILOG
                System.Diagnostics.Debug.WriteLine(exc);
            }
        }
        public void Update(int id, InputAluno aluno)
        {
            try
            {
                AlunoModel model = new AlunoModel
                {
                    Id = id,
                    Nome = aluno.Nome,
                    Usuario = aluno.Usuario,
                    Senha = aluno.Senha,
                    DtCriacao = DateTime.Now,
                    IsAtivo = aluno.IsAtivo
                };

                _alunoRepository.Update(model);
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
                _alunoRepository.Delete(id);
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
                _alunoRepository.ToggleActivate(id, toggleActivate.IsAtivo);
            }
            catch (Exception exc)
            {
                //POSSÍVEL INPLEMENTAÇÃO DE FERRAMENTA DE OBSERVABILIDADE COMO SERILOG
                System.Diagnostics.Debug.WriteLine(exc);
            }
        }
        public List<ViewAluno> GetAll()
        {
            List<ViewAluno> lstResult = new List<ViewAluno>();
            try
            {
                List<AlunoModel> lst = _alunoRepository.getAll();
                lstResult = lst.Select(x => new ViewAluno(
                    x.Id, x.Nome, x.Usuario, x.DtCriacao, x.IsAtivo
                    )).ToList();
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
