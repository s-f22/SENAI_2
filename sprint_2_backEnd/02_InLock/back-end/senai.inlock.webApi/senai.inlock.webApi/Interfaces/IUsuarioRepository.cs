using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        
        /// <summary>
        /// Autentica o usuario atraves de seu email e senha
        /// </summary>
        /// <param name="email">Email para realizar o login</param>
        /// <param name="senha">Senha pessoal do usuario</param>
        /// <returns>Caso haja um usuario com as informações fornecidas, retorna o usuario encontrado </returns>
        UsuarioDomain Login(string email, string senha);
    }
}
