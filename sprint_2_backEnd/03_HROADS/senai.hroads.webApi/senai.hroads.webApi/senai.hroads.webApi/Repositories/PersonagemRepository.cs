using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai.hroads.webApi.Repositories
{
    public class PersonagemRepository : IPersonagemRepository
    {
        HROADSContext ctx = new HROADSContext();

        public void Atualizar(Personagem personagemAtualizado)
        {
            Personagem personagemBuscado = ctx.Personagens.Find(personagemAtualizado.IdPersonagem);

            if (personagemBuscado != null)
            {
                personagemBuscado.IdClasse = personagemAtualizado.IdClasse;
                personagemBuscado.NomePersonagem = personagemAtualizado.NomePersonagem;
                personagemBuscado.VidaMax = personagemAtualizado.VidaMax;
                personagemBuscado.ManaMax = personagemAtualizado.ManaMax;
                personagemBuscado.DataCriacao = personagemAtualizado.DataCriacao;
                personagemBuscado.DataAtualizacao = personagemAtualizado.DataAtualizacao;

                ctx.Personagens.Update(personagemBuscado);
                ctx.SaveChanges();
            }
        }

        public Personagem BuscarPorId(int id)
        {
            return ctx.Personagens.Include(u => u.IdClasseNavigation).FirstOrDefault(e => e.IdPersonagem == id);
        }

        public void Cadastrar(Personagem novoPersonagem)
        {
            ctx.Personagens.Add(novoPersonagem);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Personagens.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Personagem> ListarTodos()
        {
            return ctx.Personagens.Include(u => u.IdClasseNavigation).ToList();
        }
    }
}
