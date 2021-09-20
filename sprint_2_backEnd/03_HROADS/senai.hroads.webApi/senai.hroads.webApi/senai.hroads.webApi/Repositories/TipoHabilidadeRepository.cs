using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai.hroads.webApi.Repositories
{
    public class TipoHabilidadeRepository : ITipoHabilidadeRepository
    {
        HROADSContext ctx = new HROADSContext();

        public void Atualizar(TipoHabilidade tipoHabilidadeAtualizado)
        {
            TipoHabilidade tipoHabilidadeBuscada = ctx.TipoHabilidades.Find(tipoHabilidadeAtualizado.IdTipo);

            if (tipoHabilidadeBuscada != null)
            {
                tipoHabilidadeBuscada.NomeTipo = tipoHabilidadeAtualizado.NomeTipo;

                ctx.TipoHabilidades.Update(tipoHabilidadeBuscada);
                ctx.SaveChanges();
            }
        }

        public TipoHabilidade BuscarPorId(int id)
        {
            return ctx.TipoHabilidades.FirstOrDefault(e => e.IdTipo == id);
        }

        public void Cadastrar(TipoHabilidade novoTipoHabilidade)
        {
            ctx.TipoHabilidades.Add(novoTipoHabilidade);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.TipoHabilidades.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<TipoHabilidade> ListarTodos()
        {
            return ctx.TipoHabilidades.ToList();
        }
    }
}
