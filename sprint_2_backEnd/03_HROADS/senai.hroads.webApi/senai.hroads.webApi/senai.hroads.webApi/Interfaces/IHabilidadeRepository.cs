using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IHabilidadeRepository
    {
        /// <summary>
        /// Lista todas as habilidades
        /// </summary>
        /// <returns>Uma lista de habilidades</returns>
        List<Habilidade> ListarTodas();

        /// <summary>
        /// Busca um habilidade através de um id
        /// </summary>
        /// <param name="id">id do habilidade buscado</param>
        /// <returns>O habilidade encontrado</returns>
        Habilidade BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma novaHabilidade 
        /// </summary>
        /// <param name="novaHabilidade">A habilidade que será cadastrado</param>
        void Cadastrar(Habilidade novaHabilidade);

        /// <summary>
        /// Atualiza uma habilidade existente
        /// </summary>
        /// <param name="habilidadeAtualizada">Uma habilidade atualizado</param>
        void Atualizar(Habilidade habilidadeAtualizada);

        /// <summary>
        /// Deleta uma habilidade através de um id
        /// </summary>
        /// <param name="id">id da habilidade que será deletada</param>
        void Deletar(int id);
    }
}
