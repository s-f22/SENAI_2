using Senai.Rental.WebApi.Samuel.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Samuel.Interfaces
{
    interface IVeiculoRepository
    {

        /// <summary>
        /// Lista todos os veiculos
        /// </summary>
        /// <returns>Uma lista de veiculos</returns>
        List<VeiculoDomain> Listar();


        /// <summary>
        /// Busca um veiculo através do seu id
        /// </summary>
        /// <param name="idVeiculo">id do veiculo que será buscado</param>
        /// <returns>Um veiculo buscado</returns>
        VeiculoDomain BuscarPorId(int idVeiculo);


        /// <summary>
        /// Cadastra um novo veiculo
        /// </summary>
        /// <param name="novoVeiculo">Objeto novoVeiculo com os novos dados</param>
        void Inserir(VeiculoDomain novoVeiculo);


        /// <summary>
        /// Atualiza um veiculo existente
        /// </summary>
        /// <param name="veiculoAtualizado">Objeto veiculoAtualizado com os novos dados atualizados</param>
        void Atualizar(VeiculoDomain veiculoAtualizado);


        /// <summary>
        /// Deleta um veiculo existente
        /// </summary>
        /// <param name="idVeiculo">id do veiculo que será deletado</param>
        void Deletar(int idVeiculo);
    }
}
