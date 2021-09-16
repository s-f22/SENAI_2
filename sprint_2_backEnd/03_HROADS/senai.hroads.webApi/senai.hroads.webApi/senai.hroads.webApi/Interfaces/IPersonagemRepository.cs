using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IPersonagemRepository
    {
        /// <summary>
        /// Lista todos os personagens 
        /// </summary>
        /// <returns>Uma lista de personagens</returns>
        List<Personagem> ListarTodos();

        /// <summary>
        /// Busca um personagem através de um id
        /// </summary>
        /// <param name="id">id do personagem buscado</param>
        /// <returns>O personagem encontrado</returns>
        Personagem BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novoPersonagem 
        /// </summary>
        /// <param name="novoPersonagem">O personagem que será cadastrado</param>
        void Cadastrar(Personagem novoPersonagem);

        /// <summary>
        /// Atualiza um personagem existente
        /// </summary>
        /// <param name="personagemAtualizado">Um personagem atualizado</param>
        void Atualizar(Personagem personagemAtualizado);

        /// <summary>
        /// Deleta um personagem através de um id
        /// </summary>
        /// <param name="id">id do personagem que será deletado</param>
        void Deletar(int id);
    }
}
