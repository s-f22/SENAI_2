using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        // Listar todos os usuários;
        List<UsuarioDomain> ListarTodos();

        // Buscar um usuário por e-mail e senha (login);
        UsuarioDomain Login(string email, string senha);
    }
}
