using Microsoft.AspNetCore.Mvc;
using SchoolClasses.Application.RequestModels;
using SchoolClasses.Application.ResponseModels;
using SchoolClasses.Application.Services;

namespace SchoolClasses.API.Controllers
{
	[ApiController]
	public class AlunoController : ControllerBase
	{

		private readonly ILogger<AlunoController> _logger;
		private IAlunoService _alunoService;
		public AlunoController(ILogger<AlunoController> logger, IAlunoService alunoService)
		{
			_logger = logger;
			_alunoService = alunoService;
		}

		[HttpPost("api/aluno")]
		public async Task<IActionResult> Add([FromBody] InputAluno aluno)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var result = _alunoService.Add(aluno);
			if (result.Success)
				return Ok(result);
			else if (result.Errors.Count > 0)
				return BadRequest(result);

			return StatusCode(StatusCodes.Status500InternalServerError);
		}

		[HttpPut("api/aluno/{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] InputAluno aluno)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var result = _alunoService.Update(id, aluno);
			if (result.Success)
				return Ok(result);
			else if (result.Errors.Count > 0)
				return BadRequest(result);

			return StatusCode(StatusCodes.Status500InternalServerError);
		}

		[HttpDelete("api/aluno/{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = _alunoService.Delete(id);
			if (result.Success)
				return Ok(result);
			else if (result.Errors.Count > 0)
				return BadRequest(result);

			return StatusCode(StatusCodes.Status500InternalServerError);
		}

		[HttpPatch("api/aluno/{id}")]
		public async Task<IActionResult> ToggleActivate(int id, ToggleActivate toggleActivate)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var result = _alunoService.ToggleActivate(id, toggleActivate);
			if (result.Success)
				return Ok(result);
			else if (result.Errors.Count > 0)
				return BadRequest(result);

			return StatusCode(StatusCodes.Status500InternalServerError);
		}

		[HttpGet("api/aluno")]
		public async Task<IActionResult> GetAll()
		{
			List<ViewAluno> result = _alunoService.GetAll();
			if (result.Count == 0)
				return Ok(result);

			if (result[0].Success)
				return Ok(result);
			else if (result[0].Errors.Count > 0)
				return BadRequest(result);

			return StatusCode(StatusCodes.Status500InternalServerError);
		}

		[HttpGet("api/aluno/{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var result = _alunoService.GetById(id);
			if (result.Id == 0)
				return BadRequest(result);
			if (result.Success)
				return Ok(result);
			else if (result.Errors.Count > 0)
				return BadRequest(result);

			return StatusCode(StatusCodes.Status500InternalServerError);
		}

		[HttpGet("api/aluno/turma/{idTurma}")]
		public async Task<IActionResult> GetByIdTurma(int idTurma)
		{
			List<ViewAluno> result = _alunoService.GetByIdTurma(idTurma);
			if (result.Count == 0)
				return Ok(result);

			if (result[0].Success)
				return Ok(result);
			else if (result[0].Errors.Count > 0)
				return BadRequest(result);

			return StatusCode(StatusCodes.Status500InternalServerError);
		}
	}
}
