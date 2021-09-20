using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;

namespace senai.hroads.webApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuariosController : ControllerBase
    {


        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TipoUsuariosController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_tipoUsuarioRepository.ListarTodos());
        }

        [HttpGet("{idTipoUsuario}")]
        public IActionResult BuscarPorId(int idTipoUsuario)
        {
            return Ok(_tipoUsuarioRepository.BuscarPorId(idTipoUsuario));
        }

        [HttpPost]
        public IActionResult Cadastrar(TipoUsuario novoTipoUsuario)
        {
            _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);

            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult Atualizar(TipoUsuario tipoUsuarioAtualizado)
        {
            _tipoUsuarioRepository.Atualizar(tipoUsuarioAtualizado);

            return StatusCode(204);
        }

        [HttpDelete("{idTipoUsuario}")]
        public IActionResult Deletar(int idTipoUsuario)
        {
            _tipoUsuarioRepository.Deletar(idTipoUsuario);

            return StatusCode(204);
        }


    }
}
