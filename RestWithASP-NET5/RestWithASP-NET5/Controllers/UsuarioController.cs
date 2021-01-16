using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASP_NET5.Model;
using RestWithASP_NET5.Services;

namespace RestWithASP_NET5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private IUsuarioService _usuarioService;

        public UsuarioController(ILogger<UsuarioController> logger,
                                 IUsuarioService usuarioService)
        {
            _logger = logger;
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usuarioService.FindAll());
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            var usuario = _usuarioService.FindByID(Id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Post([FromBody] UsuarioModel usuarioModel)
        {
            if (usuarioModel == null)
            {
                return BadRequest();
            }
            return Ok(_usuarioService.Create(usuarioModel));
        }

        [HttpPut]
        public IActionResult Put([FromBody] UsuarioModel usuarioModel)
        {
            if (usuarioModel == null)
            {
                return BadRequest();
            }
            return Ok(_usuarioService.Update(usuarioModel));
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _usuarioService.Delete(Id);
            return NoContent();
        }

    }
}
