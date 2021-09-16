using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface ITipoHabilidadeRepository
    {
        /// <summary>
        /// Lista todos os tipos de habilidades 
        /// </summary>
        /// <returns>Uma lista de tipos de habilidades</returns>
        List<TipoHabilidade> ListarTodos();

        /// <summary>
        /// Busca um tipo de habilidade através de um id
        /// </summary>
        /// <param name="id">id do tipo de habilidade buscado</param>
        /// <returns>O tipo de habilidade encontrada</returns>
        TipoHabilidade BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novoTipoHabilidade 
        /// </summary>
        /// <param name="novoTipoHabilidade">O tipo de habilidade que será cadastrado</param>
        void Cadastrar(TipoHabilidade novoTipoHabilidade);

        /// <summary>
        /// Atualiza uma habilidade existente
        /// </summary>
        /// <param name="tipoHabilidadeAtualizado">Um tipo de habilidade atualizada</param>
        void Atualizar(TipoHabilidade tipoHabilidadeAtualizado);

        /// <summary>
        /// Deleta um tipo de habilidade através de um id
        /// </summary>
        /// <param name="id">id do tipo de habilidade que será deletada</param>
        void Deletar(int id);
    }
}
