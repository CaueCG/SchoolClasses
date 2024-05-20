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

            _alunoService.Add(aluno);
            return Ok();
        }

        [HttpPut("api/aluno/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] InputAluno aluno)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _alunoService.Update(id, aluno);
            return Ok();
        }

        [HttpDelete("api/aluno/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _alunoService.Delete(id);
            return Ok();
        }

        [HttpPatch("api/aluno/{id}")]
        public async Task<IActionResult> ToggleActivate(int id, ToggleActivate toggleActivate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _alunoService.ToggleActivate(id, toggleActivate);
            return Ok();
        }

        [HttpGet("api/aluno")]
        public async Task<IActionResult> GetAll()
        {
            List<ViewAluno> lst = _alunoService.GetAll();
            return Ok(lst);
        }
    }
}
