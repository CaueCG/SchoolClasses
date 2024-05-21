using Microsoft.AspNetCore.Mvc;
using SchoolClasses.Application.RequestModels;
using SchoolClasses.Application.ResponseModels;
using SchoolClasses.Application.Services;
using SchoolClasses.Core.Models;

namespace SchoolClasses.API.Controllers
{
	[ApiController]
	public class CursoController : ControllerBase
	{

		private readonly ILogger<CursoController> _logger;
		private ICursoService _cursoService;

		public CursoController(ILogger<CursoController> logger, ICursoService cursoService)
		{
			_logger = logger;
			_cursoService = cursoService;
		}

		[HttpPost("api/curso")]
		public async Task<IActionResult> Add([FromBody] InputCurso curso)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var result = _cursoService.Add(curso);
			if (result.Success)
				return Ok(result);
			else if (result.Errors.Count > 0)
				return BadRequest(result);

			return StatusCode(StatusCodes.Status500InternalServerError);
		}

		[HttpPut("api/curso/{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] InputCurso curso)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var result = _cursoService.Update(id, curso);
			if (result.Success)
				return Ok(result);
			else if (result.Errors.Count > 0)
				return BadRequest(result);

			return StatusCode(StatusCodes.Status500InternalServerError);
		}

		[HttpDelete("api/curso/{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = _cursoService.Delete(id);
			if (result.Success)
				return Ok(result);
			else if (result.Errors.Count > 0)
				return BadRequest(result);

			return StatusCode(StatusCodes.Status500InternalServerError);
		}

		[HttpGet("api/curso")]
		public async Task<IActionResult> GetAll()
		{
			List<ViewCurso> result = _cursoService.GetAll();
			if (result.Count == 0)
				return Ok(result);

			if (result[0].Success)
				return Ok(result);
			else if (result[0].Errors.Count > 0)
				return BadRequest(result);

			return StatusCode(StatusCodes.Status500InternalServerError);
		}

		[HttpGet("api/curso/{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var result = _cursoService.GetById(id);
			if (result.Id == 0)
				return BadRequest(result);
			if (result.Success)
				return Ok(result);
			else if (result.Errors.Count > 0)
				return BadRequest(result);

			return StatusCode(StatusCodes.Status500InternalServerError);
		}
	}
}
