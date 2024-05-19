using Microsoft.AspNetCore.Mvc;

namespace SchoolClasses.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TurmaController : ControllerBase
    {

        private readonly ILogger<TurmaController> _logger;

        public TurmaController(ILogger<TurmaController> logger)
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
