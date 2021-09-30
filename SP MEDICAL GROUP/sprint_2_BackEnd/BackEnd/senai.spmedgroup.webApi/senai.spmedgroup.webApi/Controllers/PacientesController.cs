using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai.spmedgroup.webApi.Interfaces;
using senai.spmedgroup.webApi.Repositories;

namespace senai.spmedgroup.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private IPacienteRepository _pacienteRepository { get; set; }


        public PacientesController()
        {
            _pacienteRepository = new PacienteRepository();
        }


        [Authorize]
        [HttpGet]
        public IActionResult ListasTodos()
        {
            
            return Ok(_pacienteRepository.ListarTodos());
        }
    }
}
