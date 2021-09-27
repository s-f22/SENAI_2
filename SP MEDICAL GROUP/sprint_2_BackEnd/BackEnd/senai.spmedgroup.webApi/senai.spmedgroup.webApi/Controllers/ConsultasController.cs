using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai.spmedgroup.webApi.Domains;
using senai.spmedgroup.webApi.Interfaces;
using senai.spmedgroup.webApi.Repositories;

namespace senai.spmedgroup.webApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository _consultaRepository { get; set; }

        public ConsultasController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        /// <summary>
        /// Lista todas as consultas
        /// </summary>
        /// <returns>Status Code 200 - OK, com todas as consultas cadastradas</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_consultaRepository.ListarTodas());
        }

        /// <summary>
        /// Lista uma consulta por meio de seu Id
        /// </summary>
        /// <param name="idConsulta">Id da consulta que deseja visualizar</param>
        /// <returns>Status Code 200 - OK, com a consulta correspondente ao Id informado</returns>
        [HttpGet("{idConsulta}")]
        public IActionResult BuscarPorID(int idConsulta)
        {
            return Ok(_consultaRepository.BuscarPorId(idConsulta));
        }

        /// <summary>
        /// Cadastra uma nova consulta
        /// </summary>
        /// <param name="novaConsulta">Consulta com informações atualizadas</param>
        /// <returns>Status Code 201 - Created, Confirmação padrao</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Consulta novaConsulta)
        {
            _consultaRepository.Cadastrar(novaConsulta);
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza dados de uma consulta existente, localizando-a por seu Id
        /// </summary>
        /// <param name="idConsulta">Id da consulta que deja atualizar</param>
        /// <param name="consultaAtualizada">Consulta com dados atualizados</param>
        /// <returns>Status Code 204 - Sucesso</returns>
        [HttpPut("{idConsulta}")]
        public IActionResult Atualizar(int idConsulta, Consulta consultaAtualizada)
        {
            _consultaRepository.Atualizar(idConsulta, consultaAtualizada);

            return StatusCode(204);
        }

        /// <summary>
        /// Exclui uma consulta do banco de dados
        /// </summary>
        /// <param name="id">Id correspondente a consulta que deseja excluir</param>
        /// <returns>Status Code 204 - Sucesso</returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _consultaRepository.Deletar(id);

            return StatusCode(204);
        }

    }
}
