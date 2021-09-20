using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;

namespace senai.hroads.webApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {

        private IClasseRepository _classeRepository { get; set; }

        public ClassesController()
        {
            _classeRepository = new ClasseRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_classeRepository.ListarTodos());
        }

        [HttpGet("{idClasse}")]
        public IActionResult BuscarPorId(int idClasse)
        {
            return Ok(_classeRepository.BuscarPorId(idClasse));
        }

        [HttpPost]
        public IActionResult Cadastrar(Classe novaClasse)
        {
            _classeRepository.Cadastrar(novaClasse);

            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult Atualizar(Classe classeAtualizada)
        {
            _classeRepository.Atualizar(classeAtualizada);

            return StatusCode(204);
        }

        [HttpDelete("{idClasse}")]
        public IActionResult Deletar(int idClasse)
        {
            _classeRepository.Deletar(idClasse);

            return StatusCode(204);
        }

    }
}
