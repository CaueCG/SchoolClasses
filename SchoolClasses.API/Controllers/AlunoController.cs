using Microsoft.AspNetCore.Mvc;
using SchoolClasses.Application.Services;

namespace SchoolClasses.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public async Task<IActionResult> Add()
        {
            return Ok();
        }

        [HttpPut("api/aluno/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            return Ok();
        }

        [HttpDelete("api/aluno/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();
        }

        [HttpPatch("api/aluno/{id}")]
        public async Task<IActionResult> ToggleActivate(int id)
        {
            return Ok();
        }

        [HttpGet("api/aluno")]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }
    }
}
