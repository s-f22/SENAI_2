using senai.spmedgroup.webApi.Domains;
using senai.spmedgroup.webApi.ViewModels;
using System.Collections.Generic;

namespace senai.spmedgroup.webApi.Interfaces
{
    interface IConsultaRepository
    {
        /// <summary>
        /// Lista todos as consultas
        /// </summary>
        /// <returns>Uma lista de consultas</returns>
        List<Consulta> ListarTodas();

        /// <summary>
        /// Busca uma consulta através do ID
        /// </summary>
        /// <param name="idConsulta">ID da consulta que será buscada</param>
        /// <returns>Uma consulta buscada</returns>
        Consulta BuscarPorId(int idConsulta);

        /// <summary>
        /// Cadastra uma nova consulta
        /// </summary>
        /// <param name="novaConsulta">Objeto novaConsulta que será cadastrada</param>
        void Cadastrar(Consulta novaConsulta);

        /// <summary>
        /// Cancela uma consulta agendada
        /// </summary>
        /// <param name="id">ID da consulta que será cancelada</param>
        
        void CancelarConsulta(int id);

        /// <summary>
        /// Deleta uma consulta existente
        /// </summary>
        /// <param name="idConsulta">ID da consulta que será deletada</param>
        void Deletar(int idConsulta);



        /// <summary>
        /// Atualiza a descrição do atendimento realizado
        /// </summary>
        /// <param name="idConsulta">ID da consulta cuja descrição sera atualizada</param>
        /// <param name="descricaoAtualizada">Resumo do atendimento, preenchido pelo médico</param>
        void IncluirDescricao(int idConsulta, ConsultaViewModel descricaoAtualizada);



    }
}
