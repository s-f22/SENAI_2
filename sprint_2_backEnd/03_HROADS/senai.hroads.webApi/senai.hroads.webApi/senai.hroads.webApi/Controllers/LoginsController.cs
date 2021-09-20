using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {

        private IUsuarioRepository _LoginRepository { get; set; }

        public LoginsController()
        {
            _LoginRepository = new UsuarioRepository();
        }


        [HttpPost]

        public IActionResult Login(Usuario userLogin)
        {
            Usuario usuarioBuscado = _LoginRepository.Login(userLogin.Email, userLogin.Senha);

            if (usuarioBuscado == null)
            {
                return NotFound("Email ou senha invalido;");
            }

            // Define os dados que serão fornecidos no token - Payload
            var minhasClaims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuarioNavigation.Titulo),
            };

            // Define a chave de acesso ao token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("hroads-senai-chave"));

            // Define as credenciais do token
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Composição do token
            var meuToken = new JwtSecurityToken
                (
                    issuer: "HROADS.webAPI",
                    audience: "HROADS.webAPI",
                    claims: minhasClaims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(meuToken)
            }
                     );

        }

    }
}
