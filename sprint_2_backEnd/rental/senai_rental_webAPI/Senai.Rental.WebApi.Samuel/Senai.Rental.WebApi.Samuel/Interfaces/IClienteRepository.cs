﻿using Senai.Rental.WebApi.Samuel.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Samuel.Interfaces
{
    interface IClienteRepository
    {

        /// <summary>
        /// Lista todos os clientes
        /// </summary>
        /// <returns>Uma lista de clientes</returns>
        List<ClienteDomain> Listar();


        /// <summary>
        /// Busca um cliente através do seu id
        /// </summary>
        /// <param name="idCliente">id do cliente que será buscado</param>
        /// <returns>Um cliente buscado</returns>
        ClienteDomain BuscarPorId(int idCliente);


        /// <summary>
        /// Cadastra um novo cliente
        /// </summary>
        /// <param name="novoCliente">Objeto novoCliente com os novos dados</param>
        void Inserir(ClienteDomain novoCliente);


        /// <summary>
        /// Atualiza um cliente existente
        /// </summary>
        /// <param name="clienteAtualizado">Objeto clienteAtualizado com os novos dados atualizados</param>
        void Atualizar(ClienteDomain clienteAtualizado);


        /// <summary>
        /// Deleta um cliente existente
        /// </summary>
        /// <param name="idCliente">id do cliente que será deletado</param>
        void Deletar(int idCliente);
    }
}
