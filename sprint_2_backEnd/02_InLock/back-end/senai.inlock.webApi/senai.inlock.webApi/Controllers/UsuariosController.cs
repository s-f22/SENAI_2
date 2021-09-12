using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Controllers
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


        [HttpPost("login")]
        public IActionResult Login(UsuarioDomain logando)
        {
            UsuarioDomain usuarioEncontrado = _usuarioRepository.Login(logando.email, logando.senha);

            if (usuarioEncontrado == null)
            {
                return NotFound("E-mail ou senha inválidos;");
            }

            //return Ok(usuarioEncontrado);

            var minhasClaims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioEncontrado.email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioEncontrado.idUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioEncontrado.idTipoUsuario.ToString()),
                new Claim("Claim personalizada", "Valor Teste")
            };

            //Define a chave de acesso ao token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inLock-chave-webApi-autenticacao"));

            //Define as credenciais do token - Signature
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Composição do token
            var meuToken = new JwtSecurityToken(
                    issuer                  :       "inLock.webAPI",                    // emissor do token
                    audience                :       "inLock.webAPI",                    // destinatario do token (não necessariamento o emissor)
                    claims                  :       minhasClaims,                       // dados definidos na linha 43 
                    expires                 :       DateTime.Now.AddMinutes(30),        // tempo de expiração do token
                    signingCredentials      :       creds                               // credenciais do token
                );

            return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                    });

        }
    }
}
