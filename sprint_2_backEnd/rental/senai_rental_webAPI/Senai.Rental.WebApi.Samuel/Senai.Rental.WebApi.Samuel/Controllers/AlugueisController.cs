using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Rental.WebApi.Samuel.Interfaces;
using Senai.Rental.WebApi.Samuel.Repositories;
using Senai.Rental.WebApi.Samuel.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Samuel.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class AlugueisController : ControllerBase
    {
        private IAluguelRepository _aluguelRepository { get; set; }

        public AlugueisController()
        {
            _aluguelRepository = new AluguelRepository();
        }



        [HttpGet]
        public IActionResult Get()
        {
            List<AluguelDomain> listaAlugueis = _aluguelRepository.Listar();

            return Ok(listaAlugueis);
        }



        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            AluguelDomain aluguelEncontrado = _aluguelRepository.BuscarPorId(id);

            if (aluguelEncontrado == null)
            {
                return NotFound("Nenhum aluguel encontrado");
            }

            return Ok(aluguelEncontrado);
        }



        [HttpPost]
        public IActionResult Post(AluguelDomain novoAluguel)
        {
            _aluguelRepository.Inserir(novoAluguel);

            return StatusCode(201);
        }



        [HttpPut]
        public IActionResult PutIdBody(AluguelDomain aluguelAtualizado)
        {
            if (aluguelAtualizado.valorAluguel <= 0 || aluguelAtualizado.idAluguel < 0)
            {
                return BadRequest
                    (
                    new
                    {
                        mensagemErro = "Valor ou ID do aluguel não informado!"
                    }
                    );
            }

            AluguelDomain aluguelBuscado = _aluguelRepository.BuscarPorId(aluguelAtualizado.idAluguel);

            if (aluguelBuscado != null)
            {
                try
                {
                    _aluguelRepository.Atualizar(aluguelAtualizado);

                    return NoContent();
                }
                catch (Exception codErro)
                {
                    return BadRequest(codErro);
                }
            }

            return NotFound(
                new
                {
                    mensagem = "Aluguel não encontrado",
                    errorStatus = true
                }
                );

        }




        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _aluguelRepository.Deletar(id);

            return NoContent();
        }




    }
}
