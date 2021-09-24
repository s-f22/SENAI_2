﻿using senai.spmedgroup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        /// Atualiza uma consulta existente
        /// </summary>
        /// <param name="id">ID da consulta que será atualizada</param>
        /// <param name="consultaAtualizada">Objeto com as novas informações</param>
        void Atualizar(int id, Consulta consultaAtualizada);

        /// <summary>
        /// Deleta uma consulta existente
        /// </summary>
        /// <param name="idConsulta">ID da consulta que será deletada</param>
        void Deletar(int idConsulta);
    }
}
