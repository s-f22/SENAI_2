using Microsoft.AspNetCore.Http;
using senai.spmedgroup.webApi.Domains;
using System.Collections.Generic;

namespace senai.spmedgroup.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> ListarTodos();


        Usuario BuscarPorId(int idUsuario);


        void Cadastrar(Usuario novoUsuario);


        void Atualizar(int id, Usuario UsuarioAtualizado);


        void Deletar(int idUsuario);


        /// <summary>
        /// Verifica se os dados do usuario estao cadastrados no sistema
        /// </summary>
        /// <param name="email">Email do usuario</param>
        /// <param name="senha">Senha para acesso</param>
        /// <returns>Um usuario autenticado</returns>
        Usuario ValidarEmailSenha(string email, string senha);


        void SalvarFotoBD(IFormFile foto, int idUsuario);


        string CarregarFotoBD(int idUsuario);


        List<Consulta> ListarMinhasConsultas(int idUsuarioLogado);
    }
}
