using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IClasseClasseHabilidadeRepository
    {
        /// <summary>
        /// Lista todas as classes e habilidades
        /// </summary>
        /// <returns>Uma lista de classes e habilidades</returns>
        List<ClasseHabilidade> ListarTodas();

        /// <summary>
        /// Busca uma ClasseHabilidade através de um id
        /// </summary>
        /// <param name="id">id da ClasseHabilidade buscada</param>
        /// <returns>A ClasseHabilidade encontrada</returns>
        ClasseHabilidade BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma novaClasseHabilidade 
        /// </summary>
        /// <param name="novaClasseHabilidade">A ClasseHabilidade que será cadastrada</param>
        void Cadastrar(ClasseHabilidade novaClasseHabilidade);

        /// <summary>
        /// Atualiza uma ClasseHabilidade existente
        /// </summary>
        /// <param name="habilidadeAtualizada">Uma ClasseHabilidade atualizada</param>
        void Atualizar(ClasseHabilidade habilidadeAtualizada);

        /// <summary>
        /// Deleta uma ClasseHabilidade através de um id
        /// </summary>
        /// <param name="id">id da ClasseHabilidade que será deletada</param>
        void Deletar(int id);
    }
}
