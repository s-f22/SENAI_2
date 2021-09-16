using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IClasseRepository
    {
        /// <summary>
        /// Lista todas as classes 
        /// </summary>
        /// <returns>Uma lista de classes</returns>
        List<Classe> ListarTodos();

        /// <summary>
        /// Busca uma classe através de um id
        /// </summary>
        /// <param name="id">id da classe buscada</param>
        /// <returns>A classe encontrada</returns>
        Classe BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma novaClasse 
        /// </summary>
        /// <param name="novaClasse">A classe que será cadastrada</param>
        void Cadastrar(Classe novaClasse);

        /// <summary>
        /// Atualiza uma classe existente
        /// </summary>
        /// <param name="classeAtualizada">Uma classe atualizada</param>
        void Atualizar(Classe classeAtualizada);

        /// <summary>
        /// Deleta uma classe através de um id
        /// </summary>
        /// <param name="id">id do classe que será deletada</param>
        void Deletar(int id);
    }
}
