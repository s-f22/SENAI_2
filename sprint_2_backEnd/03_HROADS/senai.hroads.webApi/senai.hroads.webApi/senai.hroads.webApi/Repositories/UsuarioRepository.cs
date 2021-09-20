using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        HROADSContext ctx = new HROADSContext();

        public void Atualizar(Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(usuarioAtualizado);

            if (usuarioBuscado != null)
            {
                usuarioBuscado.Nickname = usuarioAtualizado.Nickname;
                usuarioBuscado.Email = usuarioAtualizado.Email;
                usuarioBuscado.Senha = usuarioAtualizado.Senha;
                usuarioBuscado.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;

                ctx.Usuarios.Update(usuarioBuscado);
                ctx.SaveChanges();
            }

        }





        public Usuario BuscarPorId(int id)
        {
           return ctx.Usuarios.FirstOrDefault(e => e.IdUsuario == id);
        }





        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);
            ctx.SaveChanges();
        }





        public void Deletar(int id)
        {
            ctx.Usuarios.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }





        public List<Usuario> ListarTodos()
        {
            return ctx.Usuarios.ToList();
        }





        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.Include(u => u.IdTipoUsuarioNavigation).FirstOrDefault(e => e.Email == email && e.Senha == senha);
        }
    }
}
