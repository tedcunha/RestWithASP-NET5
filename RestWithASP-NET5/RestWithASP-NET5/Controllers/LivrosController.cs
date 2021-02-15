using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASP_NET5.Model;
using RestWithASP_NET5.Business;
using RestWithASP_NET5.Data.VO;

namespace RestWithASP_NET5.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:ApiVersion}")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly ILogger<LivrosController> _logger;
        private ILivrosBusiness _livrosBusiness;

        public LivrosController(ILogger<LivrosController> logger,
                                 ILivrosBusiness livrosBusiness)
        {
            _logger = logger;
            _livrosBusiness = livrosBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_livrosBusiness.FindAll());
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            var usuario = _livrosBusiness.FindByID(Id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Post([FromBody] LivrosVO LivrosVO)
        {
            if (LivrosVO == null)
            {
                return BadRequest();
            }
            return Ok(_livrosBusiness.Create(LivrosVO));
        }

        [HttpPut]
        public IActionResult Put([FromBody] LivrosVO LivrosVO)
        {
            if (LivrosVO == null)
            {
                return BadRequest();
            }
            return Ok(_livrosBusiness.Update(LivrosVO));
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var result = _livrosBusiness.Delete(Id);
            if (!result)
            {
                return BadRequest();
            }

            return Ok($"Registro {Id.ToString()} excluido com sucesso.");
        }

    }
}
