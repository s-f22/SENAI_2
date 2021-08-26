using senai_filmes_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Interfaces
{
    /// <summary>
    /// Interface responsavel pelo repositorio FilmeRepository
    /// </summary>
    interface IFilmeInterface
    {
        /// <summary>
        /// Lista todos os filmes
        /// </summary>
        /// <returns>Uma lista de filmes</returns>
        List<FilmeDomain> ListarTodos();


        /// <summary>
        /// Busca um filme por seu id
        /// </summary>
        /// <param name="idFilme"></param>
        /// <returns>O filme, caso encontrado</returns>
        FilmeDomain BuscarPorId(int idFilme);


        /// <summary>
        /// Insere um novo filme
        /// </summary>
        /// <param name="novoFilme">Objeto novoFilme com os novos dados</param>
        void Cadastrar(FilmeDomain novoFilme);


        /// <summary>
        /// Atualiza um filme existente
        /// </summary>
        /// <param name="filmeAtualizado">Objeto filme já com dados atualizados, com id incluso no corpo</param>
        void AtualizarIdCorpo(FilmeDomain filmeAtualizado);


        /// <summary>
        /// Atualiza um filme existente, passando seu id
        /// </summary>
        /// <param name="idFilme">id do filme que sera atualizado</param>
        /// <param name="filmeAtualizado">Objeto filmeAtualizado já contendo os dados atualizados</param>
        void AtualizarIdUrl(int idFilme, FilmeDomain filmeAtualizado);


        /// <summary>
        /// Remove um filme existente
        /// </summary>
        /// <param name="idFilme">id do filme a ser deletado</param>
        void DeletarFilme(int idFilme);
    }
}
