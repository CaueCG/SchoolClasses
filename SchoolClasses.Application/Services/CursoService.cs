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
	public class CursoService : ICursoService
	{
		private ICursoRepository _cursoRepository;
		public CursoService(ICursoRepository cursoRepository)
		{
			_cursoRepository = cursoRepository;
		}

		public ViewBaseResponse Add(InputCurso curso)
		{
			ViewBaseResponse response = new ViewBaseResponse();

			try
			{
				CursoModel model = new CursoModel
				{
					Nome = curso.Nome
				};

				List<string> MessagesValidation = _cursoRepository.MessagesValidationsSave(model);

				if (MessagesValidation.Count == 0)
					_cursoRepository.Add(model);
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

		public ViewBaseResponse Update(int id, InputCurso curso)
		{
			ViewBaseResponse response = new ViewBaseResponse();

			try
			{
				CursoModel model = new CursoModel
				{
					Id = id,
					Nome = curso.Nome
				};

				List<string> MessagesValidation = _cursoRepository.MessagesValidationsSave(model);

				if (MessagesValidation.Count == 0)
					_cursoRepository.Update(model);
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
				_cursoRepository.Delete(id);
			}
			catch (Exception exc)
			{
				//POSSÍVEL INPLEMENTAÇÃO DE FERRAMENTA DE OBSERVABILIDADE COMO SERILOG
				System.Diagnostics.Debug.WriteLine(exc);
				response.AddErrorMessage("Operação instável, reporte um administrador");
			}

			return response;
		}

		public List<ViewCurso> GetAll()
		{
			List<ViewCurso> lstResult = new List<ViewCurso>();
			try
			{
				List<CursoModel> lst = _cursoRepository.getAll();
				lstResult = lst.Select(x => new ViewCurso(
					x.Id, x.Nome)).ToList();
			}
			catch (Exception exc)
			{
				//POSSÍVEL INPLEMENTAÇÃO DE FERRAMENTA DE OBSERVABILIDADE COMO SERILOG
				ViewCurso model = new ViewCurso();
				model.AddErrorMessage("Pesquisa instável");
				lstResult.Add(model);
				System.Diagnostics.Debug.WriteLine(exc);
			}

			return lstResult;
		}

		public ViewCurso GetById(int id)
		{
			ViewCurso response = new ViewCurso();

			try
			{
				CursoModel model = _cursoRepository.GetById(id);
				if (model != null)
				{
					response = new ViewCurso
					{
						Id = model.Id,
						Nome = model.Nome
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
