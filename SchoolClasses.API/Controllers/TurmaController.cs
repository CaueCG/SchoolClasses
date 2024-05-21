using Microsoft.AspNetCore.Mvc;
using SchoolClasses.Application.RequestModels;
using SchoolClasses.Application.ResponseModels;
using SchoolClasses.Application.Services;
using SchoolClasses.Core.Models;

namespace SchoolClasses.API.Controllers
{
    [ApiController]
    public class TurmaController : ControllerBase
    {

        private readonly ILogger<TurmaController> _logger;
        private ITurmaService _turmaService;
        public TurmaController(ILogger<TurmaController> logger, ITurmaService turmaService)
        {
            _logger = logger;
            _turmaService = turmaService;
        }

        [HttpPost("api/turma")]
        public async Task<IActionResult> Add([FromBody] InputTurma turma)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var result = _turmaService.Add(turma);
            if (result.Success)
                return Ok(result);
            else if (result.Errors.Count > 0)
                return BadRequest(result);

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut("api/turma/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] InputUpdateTurma  turma)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _turmaService.Update(id, turma);
            if (result.Success)
                return Ok(result);
            else if (result.Errors.Count > 0)
                return BadRequest(result);

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete("api/turma/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _turmaService.Delete(id);
            if (result.Success)
                return Ok(result);
            else if (result.Errors.Count > 0)
                return BadRequest(result);

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPatch("api/turma/{id}")]
        public async Task<IActionResult> ToggleActivate(int id, [FromBody] ToggleActivate toggleActivate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _turmaService.ToggleActivate(id, toggleActivate);
            if (result.Success)
                return Ok(result);
            else if (result.Errors.Count > 0)
                return BadRequest(result);

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("api/turma")]
        public async Task<IActionResult> GetAll()
        {
            List<ViewTurma> result = _turmaService.GetAll();
            if (result.Count == 0)
                return Ok(result);

            if (result[0].Success)
                return Ok(result);
            else if (result[0].Errors.Count > 0)
                return BadRequest(result);

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

		[HttpGet("api/turma/{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var result = _turmaService.GetById(id);
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
