using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
                foto.CopyTo(ms);
                                
                imgUsuario.ImgBinario = ms.ToArray();
                                
                imgUsuario.NomeArquivo = foto.FileName;
                                
                imgUsuario.MimeType = foto.FileName.Split('.').Last();
                                
                imgUsuario.IdUsuario = idUsuario;
            }
                        
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
                metodo.ImagemUsuarios.Add(imgUsuario);
            
            metodo.SaveChanges();

        }




        public Usuario ValidarEmailSenha(string email, string senha)
        {
            return metodo.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }






        public List<Consulta> ListarMinhasConsultas(int idUsuarioLogado)
        {
            Usuario usuarioLogado = metodo.Usuarios.Find(idUsuarioLogado);

            if (usuarioLogado.IdTipoUsuario == 2)
            {
                Medico medico = metodo.Medicos.FirstOrDefault(u => u.IdUsuario == idUsuarioLogado);

                //return metodo.Consultas.Select(c => new Consulta() { DataHorario = c.DataHorario, IdConsulta = c.IdConsulta, IdMedico = c.IdMedico, IdPaciente = c.IdPaciente, IdSituacao = c.IdSituacao, Resumo = c.Resumo }).Where(m => m.IdMedico == medico.IdMedico).ToList();

                //RETORNO OPCIONAL COM JSON COMPLETO
                return metodo.Consultas.Include(p => p.IdPacienteNavigation).Include(p => p.IdSituacaoNavigation).Where(m => m.IdMedico == medico.IdMedico).ToList();
            }

            else if (usuarioLogado.IdTipoUsuario == 3)
            {
                Paciente paciente = metodo.Pacientes.FirstOrDefault(u => u.IdUsuario == idUsuarioLogado);

                //return metodo.Consultas.Select(c => new Consulta() { DataHorario = c.DataHorario, IdConsulta = c.IdConsulta, IdMedico = c.IdMedico, IdPaciente = c.IdPaciente, IdSituacao = c.IdSituacao, Resumo = c.Resumo }).Where(p => p.IdPaciente == paciente.IdPaciente).ToList();

                //RETORNO OPCIONAL COM JSON COMPLETO
                return metodo.Consultas.Include(m => m.IdMedicoNavigation).Include(m => m.IdSituacaoNavigation).Where(m => m.IdPaciente == paciente.IdPaciente).ToList();
            }

            else
                return null;            

        }
    }
}
