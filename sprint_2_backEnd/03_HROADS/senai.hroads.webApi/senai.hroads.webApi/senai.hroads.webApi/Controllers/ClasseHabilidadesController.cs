using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class ClasseHabilidadesController : ControllerBase
    {

        private IClasseHabilidadeRepository _classeHabilidadeRepository { get; set; }

        public ClasseHabilidadesController()
        {
            _classeHabilidadeRepository = new ClasseHabilidadeRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_classeHabilidadeRepository.ListarTodas());
        }

        [HttpGet("{idClasseHabilidade}")]
        public IActionResult BuscarPorId(int idClasseHabilidade)
        {
            return Ok(_classeHabilidadeRepository.BuscarPorId(idClasseHabilidade));
        }

        [HttpPost]
        public IActionResult Cadastrar(ClasseHabilidade novaClasseHabilidade)
        {
            _classeHabilidadeRepository.Cadastrar(novaClasseHabilidade);

            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult Atualizar(ClasseHabilidade classeHabilidadeAtualizada)
        {
            _classeHabilidadeRepository.Atualizar(classeHabilidadeAtualizada);

            return StatusCode(204);
        }

        [HttpDelete("{idClasseHabilidade}")]
        public IActionResult Deletar(int idClasseHabilidade)
        {
            _classeHabilidadeRepository.Deletar(idClasseHabilidade);

            return StatusCode(204);
        }

    }
}
