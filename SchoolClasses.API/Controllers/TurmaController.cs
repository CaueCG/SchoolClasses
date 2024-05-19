using Microsoft.AspNetCore.Mvc;
using SchoolClasses.Application.RequestModels;
using SchoolClasses.Application.Services;

namespace SchoolClasses.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            return Ok();
        }

        [HttpPut("api/turma/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] InputTurma turma)
        {
            return Ok();
        }

        [HttpDelete("api/turma/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();
        }

        [HttpPatch("api/turma/{id}")]
        public async Task<IActionResult> ToggleActivate(int id, [FromBody] ToggleActivate toggleActivate)
        {
            return Ok();
        }

        [HttpGet("api/turma")]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }
    }
}
