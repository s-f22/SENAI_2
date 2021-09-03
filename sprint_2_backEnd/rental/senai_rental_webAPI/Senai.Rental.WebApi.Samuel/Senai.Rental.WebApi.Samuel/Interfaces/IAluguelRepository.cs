using Senai.Rental.WebApi.Samuel.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Samuel.Interfaces
{
    interface IAluguelRepository
    {

        /// <summary>
        /// Lista todos os alugueis
        /// </summary>
        /// <returns>Uma lista de alugueis</returns>
        List<AluguelDomain> Listar();


        /// <summary>
        /// Busca um aluguel através do seu id
        /// </summary>
        /// <param name="idAluguel">id do aluguel que será buscado</param>
        /// <returns>Um aluguel buscado</returns>
        AluguelDomain BuscarPorId(int idAluguel);


        /// <summary>
        /// Cadastra um novo aluguel
        /// </summary>
        /// <param name="novoAluguel">Objeto novoAluguel com os novos dados</param>
        void Inserir(AluguelDomain novoAluguel);


        /// <summary>
        /// Atualiza um aluguel existente
        /// </summary>
        /// <param name="aluguelAtualizado">Objeto aluguelAtualizado com os novos dados atualizados</param>
        void Atualizar(AluguelDomain aluguelAtualizado);


        /// <summary>
        /// Deleta um aluguel existente
        /// </summary>
        /// <param name="idAluguel">id do aluguel que será deletado</param>
        void Deletar(int idAluguel);
    }
}
