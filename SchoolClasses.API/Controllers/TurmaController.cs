using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Add()
        {
            return Ok();
        }

        [HttpPut("api/turma/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            return Ok();
        }

        [HttpDelete("api/turma/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();
        }

        [HttpPatch("api/turma/{id}")]
        public async Task<IActionResult> ToggleActivate(int id)
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
