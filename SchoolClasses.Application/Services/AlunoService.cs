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
		public ViewBaseResponse Add(InputAluno aluno)
		{
			ViewBaseResponse response = new ViewBaseResponse();

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

				List<string> MessagesValidation = _alunoRepository.MessagesValidationsSave(model);

				if (MessagesValidation.Count == 0)
					_alunoRepository.Add(model);
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

		public ViewBaseResponse Update(int id, InputAluno aluno)
		{
			ViewBaseResponse response = new ViewBaseResponse();

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

				List<string> MessagesValidation = _alunoRepository.MessagesValidationsSave(model);

				if (MessagesValidation.Count == 0)
					_alunoRepository.Update(model);
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
				_alunoRepository.Delete(id);
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
				_alunoRepository.ToggleActivate(id, toggleActivate.IsAtivo);
			}
			catch (Exception exc)
			{
				//POSSÍVEL INPLEMENTAÇÃO DE FERRAMENTA DE OBSERVABILIDADE COMO SERILOG
				System.Diagnostics.Debug.WriteLine(exc);
				response.AddErrorMessage("Operação instável, reporte um administrador");
			}

			return response;
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
				ViewAluno model = new ViewAluno();
				model.AddErrorMessage("Pesquisa instável");
				lstResult.Add(model);
				System.Diagnostics.Debug.WriteLine(exc);
			}

			return lstResult;
		}

		public List<ViewAluno> GetByIdTurma(int idTurma)
		{
			List<ViewAluno> lstResult = new List<ViewAluno>();
			try
			{
				List<AlunoModel> lst = _alunoRepository.GetByIdTurma(idTurma);
				lstResult = lst.Select(x => new ViewAluno(
					x.Id, x.Nome, x.Usuario, x.DtCriacao, x.IsAtivo
					)).ToList();
			}
			catch (Exception exc)
			{
				//POSSÍVEL INPLEMENTAÇÃO DE FERRAMENTA DE OBSERVABILIDADE COMO SERILOG
				ViewAluno model = new ViewAluno();
				model.AddErrorMessage("Pesquisa instável");
				lstResult.Add(model);
				System.Diagnostics.Debug.WriteLine(exc);
			}

			return lstResult;
		}

		public ViewAluno GetById(int id)
		{
			ViewAluno response = new ViewAluno();

			try
			{
				AlunoModel model = _alunoRepository.GetById(id);
				if (model != null)
				{
					response = new ViewAluno
					{
						Id = model.Id,
						Nome = model.Nome,
						Usuario = model.Usuario,
						DtCriacao = model.DtCriacao,
						IsAtivo = model.IsAtivo
					};
				}
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
