using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Rental.WebApi.Samuel.Interfaces;
using Senai.Rental.WebApi.Samuel.Repositories;
using Senai.Rental.WebApi_Samuel.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Samuel.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private IVeiculoRepository _veiculoRepository { get; set; }

        public VeiculosController()
        {
            _veiculoRepository = new VeiculoRepository();
        }



        [HttpGet]
        public IActionResult Get()
        {
            List<VeiculoDomain> listaVeiculos = _veiculoRepository.Listar();

            return Ok(listaVeiculos);
        }



        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            VeiculoDomain veiculoEncontrado = _veiculoRepository.BuscarPorId(id);

            if (veiculoEncontrado == null)
            {
                return NotFound("Nenhum veiculo encontrado");
            }

            return Ok(veiculoEncontrado);
        }



        [HttpPost]
        public IActionResult Post(VeiculoDomain novoVeiculo)
        {
            _veiculoRepository.Inserir(novoVeiculo);

            return StatusCode(201);
        }




        [HttpPut]
        public IActionResult PutIdBody(VeiculoDomain veiculoAtualizado)
        {
            if (veiculoAtualizado.corVeiculo == null || veiculoAtualizado.idVeiculo < 0)
            {
                return BadRequest
                    (
                    new
                    {
                        mensagemErro = "Cor ou ID do veiculo não informado!"
                    }
                    );
            }

            VeiculoDomain veiculoBuscado = _veiculoRepository.BuscarPorId(veiculoAtualizado.idVeiculo);

            if (veiculoBuscado != null)
            {
                try
                {
                    _veiculoRepository.Atualizar(veiculoAtualizado);

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
                    mensagem = "Veiculo não encontrado",
                    errorStatus = true
                }
                );

        }



        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _veiculoRepository.Deletar(id);

            return NoContent();
        }



    }
}
