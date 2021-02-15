using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASP_NET5.Business;
using RestWithASP_NET5.Data.VO;

namespace RestWithASP_NET5.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:ApiVersion}")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private IUsuarioBusiness _usuarioBusiness;

        public UsuarioController(ILogger<UsuarioController> logger,
                                 IUsuarioBusiness usuarioBusiness)
        {
            _logger = logger;
            _usuarioBusiness = usuarioBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usuarioBusiness.FindAll());
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            var usuario = _usuarioBusiness.FindByID(Id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Post([FromBody] UsuarioVO UsuarioVO)
        {
            if (UsuarioVO == null)
            {
                return BadRequest();
            }
            return Ok(_usuarioBusiness.Create(UsuarioVO));
        }

        [HttpPut]
        public IActionResult Put([FromBody] UsuarioVO UsuarioVO)
        {
            if (UsuarioVO == null)
            {
                return BadRequest();
            }
            return Ok(_usuarioBusiness.Update(UsuarioVO));
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var result = _usuarioBusiness.Delete(Id);
            if (!result)
            {
                return BadRequest();
            }
            return Ok($"Registro {Id.ToString()} excluido com sucesso.");
        }
    }
}
