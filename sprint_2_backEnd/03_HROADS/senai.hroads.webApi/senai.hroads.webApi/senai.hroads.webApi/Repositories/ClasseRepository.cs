using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class ClasseRepository : IClasseRepository
    {
        HROADSContext ctx = new HROADSContext();

        public void Atualizar(Classe classeAtualizada)
        {
            Classe classeBuscada = ctx.Classes.Find(classeAtualizada);

            if (classeBuscada != null)
            {
                classeBuscada.NomeClasse = classeAtualizada.NomeClasse;

                ctx.Classes.Update(classeBuscada);
                ctx.SaveChanges();
            }
        }

        public Classe BuscarPorId(int id)
        {
            return ctx.Classes.FirstOrDefault(e => e.IdClasse == id);
        }

        public void Cadastrar(Classe novaClasse)
        {
            ctx.Classes.Add(novaClasse);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Classes.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Classe> ListarTodos()
        {
            return ctx.Classes.ToList();
        }
    }
}
