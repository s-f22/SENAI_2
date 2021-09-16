using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Lista todos os tipos de usuários 
        /// </summary>
        /// <returns>Uma lista de usuários</returns>
        List<TipoUsuario> ListarTodos();

        /// <summary>
        /// Busca um tipo de usuário através de um id
        /// </summary>
        /// <param name="id">id do usuário buscado</param>
        /// <returns>O usuário encontrado</returns>
        TipoUsuario BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novoTipoUsuario 
        /// </summary>
        /// <param name="novoTipoUsuario">O tipo de usuário que será cadastrado</param>
        void Cadastrar(TipoUsuario novoTipoUsuario);

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="tipoUsuarioAtualizado">Um tipo de usuário atualizado</param>
        void Atualizar(TipoUsuario tipoUsuarioAtualizado);

        /// <summary>
        /// Deleta um tipo de usuário através de um id
        /// </summary>
        /// <param name="id">id do usuário que será deletado</param>
        void Deletar(int id);
    }
}
