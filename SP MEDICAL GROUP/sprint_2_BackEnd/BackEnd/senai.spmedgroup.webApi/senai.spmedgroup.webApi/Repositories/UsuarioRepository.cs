using Microsoft.AspNetCore.Http;
using senai.spmedgroup.webApi.Context;
using senai.spmedgroup.webApi.Domains;
using senai.spmedgroup.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace senai.spmedgroup.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        SPMedGroupContext metodo = new SPMedGroupContext();


        public void Atualizar(int id, Usuario UsuarioAtualizado)
        {
            Usuario usuarioBuscado =  metodo.Usuarios.Find(id);

            if (usuarioBuscado != null)
            {
                usuarioBuscado.IdTipoUsuario = UsuarioAtualizado.IdTipoUsuario;
                usuarioBuscado.Nome = UsuarioAtualizado.Nome;
                usuarioBuscado.Email = UsuarioAtualizado.Email;
                usuarioBuscado.Senha = UsuarioAtualizado.Senha;

                metodo.Usuarios.Update(usuarioBuscado);
                metodo.SaveChanges();
            }
        }




        public Usuario BuscarPorId(int idUsuario)
        {
            return metodo.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);
        }




        public void Cadastrar(Usuario novoUsuario)
        {
            metodo.Usuarios.Add(novoUsuario);
            metodo.SaveChanges();
        }




        public string CarregarFotoBD(int idUsuario)
        {
            ImagemUsuario imgUsuario = new ImagemUsuario();

            imgUsuario = metodo.ImagemUsuarios.FirstOrDefault(i => i.IdImagem == idUsuario);

            //Verificar se existe imagem de perfil para o usuario.
            if (imgUsuario != null)
            {
                return Convert.ToBase64String(imgUsuario.ImgBinario);
            }

            return null;
        }




        public void Deletar(int idUsuario)
        {
            metodo.Usuarios.Remove(BuscarPorId(idUsuario));
            metodo.SaveChanges();
        }




        public List<Usuario> ListarTodos()
        {
            return metodo.Usuarios.ToList();
        }




        public void SalvarFotoBD(IFormFile foto, int idUsuario)
        {
            ImagemUsuario imgUsuario = new ImagemUsuario();

            using (var ms = new MemoryStream())
            {
                //copia a imagem enviada para a memoria ms
                foto.CopyTo(ms);

                //converte a imagem para binário, armazenado em uma matriz
                imgUsuario.ImgBinario = ms.ToArray();

                //captura o nome do arquivo de imagem
                imgUsuario.NomeArquivo = foto.FileName;

                //captura a extensão do arquivo de imagem a partir de seu nome
                imgUsuario.MimeType = foto.FileName.Split('.').Last();

                //atribui o id do usuario informado a imagem
                imgUsuario.IdUsuario = idUsuario;
            }

            //Analisar se usuario ja possui foto de perfil.

            ImagemUsuario imgExistente = new ImagemUsuario();

            imgExistente = metodo.ImagemUsuarios.FirstOrDefault(i => i.IdUsuario == idUsuario);

            if (imgExistente != null)
            {
                imgExistente.ImgBinario = imgUsuario.ImgBinario;
                imgExistente.NomeArquivo = imgUsuario.NomeArquivo;
                imgExistente.MimeType = imgUsuario.MimeType;
                imgExistente.IdUsuario = imgUsuario.IdUsuario;

                metodo.ImagemUsuarios.Update(imgExistente);
            }
            else
            {
                metodo.ImagemUsuarios.Add(imgUsuario);
            }

            metodo.SaveChanges();

        }




        public Usuario ValidarEmailSenha(string email, string senha)
        {
            return metodo.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
