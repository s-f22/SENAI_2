using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Rental.WebApi.Samuel.Domains;
using Senai.Rental.WebApi.Samuel.Interfaces;
using Senai.Rental.WebApi.Samuel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Samuel.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private IClienteRepository _clienteRepository { get; set; }

        public ClientesController()
        {
            _clienteRepository = new ClienteRepository();
        }





        [HttpGet]
        public IActionResult Get()
        {
            List<ClienteDomain> listaClientes = _clienteRepository.Listar();

            return Ok(listaClientes);
        }




        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ClienteDomain clienteEncontrado = _clienteRepository.BuscarPorId(id);

            if (clienteEncontrado == null)
            {
                return NotFound("Nenhum cliente encontrado");
            }

            return Ok(clienteEncontrado);
        }




        [HttpPost]
        public IActionResult Post(ClienteDomain novoCliente)
        {
            _clienteRepository.Inserir(novoCliente);

            return StatusCode(201);
        }




        [HttpPut]
        public IActionResult PutIdBody(ClienteDomain clienteAtualizado)
        {
            if (clienteAtualizado.nome == null || clienteAtualizado.idCliente < 0)
            {
                return BadRequest
                    (
                    new
                        {
                            mensagemErro = "Nome ou ID do cliente não informado!"
                        }
                    );
            }

            ClienteDomain clienteBuscado = _clienteRepository.BuscarPorId(clienteAtualizado.idCliente);

            if (clienteBuscado != null)
            {
                try
                {
                    _clienteRepository.Atualizar(clienteAtualizado);

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
                    mensagem = "Cliente não encontrado",
                    errorStatus = true
                }
                );

        }




        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _clienteRepository.Deletar(id);

            return NoContent();
        }
    }
}
