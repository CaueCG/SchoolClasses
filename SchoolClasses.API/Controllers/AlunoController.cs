using Microsoft.AspNetCore.Mvc;

namespace SchoolClasses.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {

        private readonly ILogger<AlunoController> _logger;

        public AlunoController(ILogger<AlunoController> logger)
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
