using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.spmedgroup.webApi.Domains;
using senai.spmedgroup.webApi.Interfaces;
using senai.spmedgroup.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedgroup.webApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }


        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }



        [HttpGet]
        public IActionResult Listar()
        {
            return Ok( _usuarioRepository.ListarTodos() );
        }



        [HttpGet("{idUsuario}")]
        public IActionResult BuscarPorId(int idUsuario)
        {
            return Ok(_usuarioRepository.BuscarPorId(idUsuario));
        }


        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Usuario novoUsuario)
        {
            _usuarioRepository.Cadastrar(novoUsuario);
            return StatusCode(201);
        }



        [HttpPut("{idUsuario}")]
        public IActionResult Atualizar(int idUsuario, Usuario usuarioAtualizado)
        {
            _usuarioRepository.Atualizar(idUsuario, usuarioAtualizado);
            return StatusCode(204);
        }



        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _usuarioRepository.Deletar(id);
            return StatusCode(204);
        }



        [HttpPost("{foto_perfil}")]
        public IActionResult SalvarFotoBD(IFormFile arquivo)
        {
            try
            {
                if (arquivo.Length > 250000)
                
                    return BadRequest(new { mensagem = "Tamanho maximo excedido;" });
                
                string extensao = arquivo.FileName.Split('.').Last();

                if (extensao != "jpg")
                
                    return BadRequest(new { mensagem = "Insira um arquivo .jpg" });
                
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                _usuarioRepository.SalvarFotoBD(arquivo, idUsuario);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        
        [HttpGet("foto_perfil")]
        public IActionResult CarregarFoto()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                string base64 = _usuarioRepository.CarregarFotoBD(idUsuario);

                return Ok(base64);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
