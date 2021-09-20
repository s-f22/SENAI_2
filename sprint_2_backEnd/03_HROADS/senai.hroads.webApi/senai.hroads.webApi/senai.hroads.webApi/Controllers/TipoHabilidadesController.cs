using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;

namespace senai.hroads.webApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class TipoHabilidadesController : ControllerBase
    {
        private ITipoHabilidadeRepository _tipoHabilidadeRepository { get; set; }

        public TipoHabilidadesController()
        {
            _tipoHabilidadeRepository = new TipoHabilidadeRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_tipoHabilidadeRepository.ListarTodos());
        }

        [HttpGet("{idTipoHabilidade}")]
        public IActionResult BuscarPorId(int idTipoHabilidade)
        {
            return Ok(_tipoHabilidadeRepository.BuscarPorId(idTipoHabilidade));
        }

        [HttpPost]
        public IActionResult Cadastrar(TipoHabilidade novoTipoHabilidade)
        {
            _tipoHabilidadeRepository.Cadastrar(novoTipoHabilidade);

            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult Atualizar(TipoHabilidade tipoHabilidadeAtualizado)
        {
            _tipoHabilidadeRepository.Atualizar(tipoHabilidadeAtualizado);

            return StatusCode(204);
        }

        [HttpDelete("{idTipoHabilidade}")]
        public IActionResult Deletar(int idTipoHabilidade)
        {
            _tipoHabilidadeRepository.Deletar(idTipoHabilidade);

            return StatusCode(204);
        }
    }
}
