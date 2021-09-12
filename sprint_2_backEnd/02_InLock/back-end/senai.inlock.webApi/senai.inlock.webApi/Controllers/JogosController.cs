using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Controllers
{
    [Produces("application/json")]

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {


        private IJogoRepository _jogoRepository { get; set; }

        public JogosController()
        {
            _jogoRepository = new JogoRepository();
        }


        // ---------------------------------- LISTAR TODOS -----------------------------------------

        [HttpGet]
        public IActionResult Get()
        {
            List<JogoDomain> listaJogos = _jogoRepository.ListarTodos();

            return Ok(listaJogos);
        }


        // ---------------------------------- BUSCAR POR ID -----------------------------------------
        
        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            JogoDomain jogoBuscado = _jogoRepository.BuscarPorId(id);

            if (jogoBuscado == null)
            {
                return NotFound();
            }

            return Ok(jogoBuscado);
        }


        // ---------------------------------- CADASTRAR -----------------------------------------
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(JogoDomain novoJogo)
        {
            _jogoRepository.Cadastrar(novoJogo);

            return StatusCode(201);
        }



        // ---------------------------------- ATUALIZAR -----------------------------------------

        [HttpPut]
        public IActionResult Put(JogoDomain jogoAtualizado)
        {
            JogoDomain jogoBuscado = _jogoRepository.BuscarPorId(jogoAtualizado.idJogo);

            if (jogoBuscado != null)
            {
                try
                {
                    _jogoRepository.Atualizar(jogoAtualizado);
                    return NoContent();
                }
                catch (Exception CodErro)
                {
                    return BadRequest(CodErro);
                }
            }

            return NotFound(
                    new
                    {
                        Mensagem = "Jogo não encontrado!",
                        ErrorStats = true
                    }
                );
        }



        // ---------------------------------- DELETAR -----------------------------------------

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _jogoRepository.Deletar(id);

            return NoContent();
        }



    }
}
