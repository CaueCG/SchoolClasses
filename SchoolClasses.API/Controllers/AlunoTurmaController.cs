using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolClasses.Application.RequestModels;
using SchoolClasses.Application.Services;

namespace SchoolClasses.API.Controllers
{
    [ApiController]
    public class AlunoTurmaController : ControllerBase
    {
        private readonly ILogger<CursoController> _logger;
        private IAlunoTurmaService _alunoTurmaService;

        public AlunoTurmaController(ILogger<CursoController> logger, IAlunoTurmaService alunoTurmaService)
        {
            _logger = logger;
            _alunoTurmaService = alunoTurmaService;
        }

        [HttpPost("api/alunoturma")]
        public async Task<IActionResult> Add([FromBody] InputAlunoTurma alunoTurma)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _alunoTurmaService.Add(alunoTurma);
            if (result.Success)
                return Ok(result);
            else if (result.Errors.Count > 0)
                return BadRequest(result);

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete("api/alunoturma/{IdAluno}/{IdTurma}")]
        public async Task<IActionResult> Add(int IdAluno, int IdTurma)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _alunoTurmaService.Delete(IdAluno, IdTurma);
            if (result.Success)
                return Ok(result);
            else if (result.Errors.Count > 0)
                return BadRequest(result);

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
