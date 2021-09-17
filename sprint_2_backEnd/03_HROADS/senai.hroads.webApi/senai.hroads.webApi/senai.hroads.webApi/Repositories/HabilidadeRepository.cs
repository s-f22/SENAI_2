using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class HabilidadeRepository : IHabilidadeRepository
    {
        HROADSContext ctx = new HROADSContext();

        public void Atualizar(Habilidade habilidadeAtualizada)
        {
            Habilidade habilidadeBuscada = ctx.Habilidades.Find(habilidadeAtualizada);

            if (habilidadeBuscada != null)
            {
                habilidadeBuscada.IdTipo = habilidadeAtualizada.IdTipo;
                habilidadeBuscada.NomeHabilidade = habilidadeAtualizada.NomeHabilidade;

                ctx.Habilidades.Update(habilidadeBuscada);
                ctx.SaveChanges();
            }
        }

        public Habilidade BuscarPorId(int id)
        {
            return ctx.Habilidades.FirstOrDefault(e => e.IdHabilidade == id);
        }

        public void Cadastrar(Habilidade novaHabilidade)
        {
            ctx.Habilidades.Add(novaHabilidade);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Habilidades.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Habilidade> ListarTodas()
        {
            return ctx.Habilidades.ToList();
        }
    }
}
