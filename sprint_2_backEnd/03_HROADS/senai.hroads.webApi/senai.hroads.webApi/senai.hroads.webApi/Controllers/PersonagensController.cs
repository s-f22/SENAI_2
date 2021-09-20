using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;

namespace senai.hroads.webApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class PersonagensController : ControllerBase
    {

        private IPersonagemRepository _personagemRepository { get; set; }

        public PersonagensController()
        {
            _personagemRepository = new PersonagemRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_personagemRepository.ListarTodos());
        }

        [HttpGet("{idPersonagem}")]
        public IActionResult BuscarPorId(int idPersonagem)
        {
            return Ok(_personagemRepository.BuscarPorId(idPersonagem));
        }

        [HttpPost]
        public IActionResult Cadastrar(Personagem novoPersonagem)
        {
            _personagemRepository.Cadastrar(novoPersonagem);

            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult Atualizar(Personagem personagemAtualizado)
        {
            _personagemRepository.Atualizar(personagemAtualizado);

            return StatusCode(204);
        }

        [HttpDelete("{idPersonagem}")]
        public IActionResult Deletar(int idPersonagem)
        {
            _personagemRepository.Deletar(idPersonagem);

            return StatusCode(204);
        }

    }
}
