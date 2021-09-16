using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os usuários 
        /// </summary>
        /// <returns>Uma lista de usuários</returns>
        List<Usuario> ListarTodos();

        /// <summary>
        /// Busca um usuário através de um id
        /// </summary>
        /// <param name="id">id do usuário buscado</param>
        /// <returns>O usuário encontrado</returns>
        Usuario BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novoUsuario 
        /// </summary>
        /// <param name="novoUsuario">O usuário que será cadastrado</param>
        void Cadastrar(Usuario novoUsuario);

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="usuarioAtualizado">Um usuário atualizado</param>
        void Atualizar(Usuario usuarioAtualizado);

        /// <summary>
        /// Deleta um usuário através de um id
        /// </summary>
        /// <param name="id">id do usuário que será deletado</param>
        void Deletar(int id);
    }
}
