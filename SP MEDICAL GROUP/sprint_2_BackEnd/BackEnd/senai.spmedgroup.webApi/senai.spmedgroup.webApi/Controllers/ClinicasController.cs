using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai.spmedgroup.webApi.Domains;
using senai.spmedgroup.webApi.Interfaces;
using senai.spmedgroup.webApi.Repositories;

namespace senai.spmedgroup.webApi.Controllers
{
    [Produces ("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClinicasController : ControllerBase
    {

        private IClinicaRepository _clinicaRepository { get; set; }

        public ClinicasController()
        {
            _clinicaRepository = new ClinicaRepository();
        }



        [HttpGet]
        public IActionResult ListarTodas()
        {
            _clinicaRepository.ListarTodas();
            return Ok(200);
        }



        [HttpGet("{idClinica}")]
        public IActionResult BuscarPorId(int idClinica)
        {
            _clinicaRepository.BuscarPorId(idClinica);
            return Ok(200);
        }



        [Authorize (Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Clinica novaClinica)
        {
            _clinicaRepository.Cadastrar(novaClinica);
            return StatusCode(201);
        }



        [Authorize (Roles = "1")]
        [HttpPut]
        public IActionResult Atualizar(int id, Clinica clinicaAtualizada)
        {
            _clinicaRepository.Atualizar(id, clinicaAtualizada);
            return StatusCode(204);
        }



        [Authorize(Roles = "1")]
        [HttpDelete]
        public IActionResult Deletar(int id)
        {
            _clinicaRepository.Deletar(id);
            return StatusCode(204);
        }

    }
}
