using Microsoft.AspNetCore.Mvc;
using SchoolClasses.Application.RequestModels;
using SchoolClasses.Application.Services;
using SchoolClasses.Core.Models;

namespace SchoolClasses.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            _cursoService.Add(curso);
            return Ok();
        }

        [HttpPut("api/curso/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] InputCurso curso)
        {
            _cursoService.Update(id, curso);
            return Ok();
        }

        [HttpDelete("api/curso/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _cursoService.Delete(id);
            return Ok();
        }

        [HttpGet("api/curso")]
        public async Task<IActionResult> GetAll()
        {
            List<CursoModel> lst = _cursoService.GetAll();
            return Ok(lst);
        }
    }
}
