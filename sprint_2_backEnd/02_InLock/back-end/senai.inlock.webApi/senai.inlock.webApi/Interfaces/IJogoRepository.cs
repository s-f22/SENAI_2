using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IJogoRepository
    {
        // ADMINISTRADOR poderá aadastrar novo Jogo

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="novoJovo">Objeto com os dados do novo jogo</param>
        void Cadastrar(JogoDomain novoJogo);





        // Listar todos os jogos e respectivos estudios - CLIENTE E ADMINISTRADOR;

        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Retorna uma lista de jogos</returns>
        List<JogoDomain> ListarTodos();





        // Buscar um jogo por idJogo - CLIENTE E ADMINISTRADOR;

        /// <summary>
        /// Busca um jogo de acordo com o id informado
        /// </summary>
        /// <param name="idJogo"></param>
        /// <returns>Retorna o jogo correspondente so id, caso encontrado</returns>
        JogoDomain BuscarPorId(int idJogo);




        /// <summary>
        /// Atualizada os dados do jogo por meio de um objeto já contendo as informações corretas
        /// </summary>
        /// <param name="jogoAtualizado">Jogo com as informações corretas</param>
        void Atualizar(JogoDomain jogoAtualizado);




        /// <summary>
        /// Excluir um jogo de acordo com o id informado
        /// </summary>
        /// <param name="idParaExcluir">Id do jogo a excluir</param>
        void Deletar(int idParaExcluir);

    }
}
