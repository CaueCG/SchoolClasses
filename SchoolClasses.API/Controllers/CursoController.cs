using Microsoft.AspNetCore.Mvc;

namespace SchoolClasses.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CursoController : ControllerBase
    {

        private readonly ILogger<CursoController> _logger;

        public CursoController(ILogger<CursoController> logger)
        {
            _logger = logger;
        }

        [HttpGet("api/aluno")]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }
    }
}
