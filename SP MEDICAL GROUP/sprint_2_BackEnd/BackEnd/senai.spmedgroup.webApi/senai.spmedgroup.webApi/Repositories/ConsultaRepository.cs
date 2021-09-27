using senai.spmedgroup.webApi.Context;
using senai.spmedgroup.webApi.Domains;
using senai.spmedgroup.webApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai.spmedgroup.webApi.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        SPMedGroupContext metodos = new SPMedGroupContext();

        public void Atualizar(int id, Consulta consultaAtualizada)
        {
            //Consulta consultaBuscada = metodos.Consultas.Find(id);
            Consulta consultaBuscada = metodos.Consulta.Find(id);

            if (consultaBuscada != null)
            {
                consultaBuscada.IdMedico = consultaAtualizada.IdMedico;
                consultaBuscada.IdPaciente = consultaAtualizada.IdPaciente;
                consultaBuscada.IdSituacao = consultaAtualizada.IdSituacao;
                consultaBuscada.DataHorario = consultaAtualizada.DataHorario;

                metodos.Consulta.Update(consultaBuscada);
                metodos.SaveChanges();
            }
        }

        public Consulta BuscarPorId(int idConsulta)
        {
            return metodos.Consulta.FirstOrDefault(c => c.IdConsulta == idConsulta);
        }

        public void Cadastrar(Consulta novaConsulta)
        {
            metodos.Consulta.Add(novaConsulta);
            metodos.SaveChanges();
        }

        public void Deletar(int idConsulta)
        {
            metodos.Consulta.Remove(BuscarPorId(idConsulta));
            metodos.SaveChanges();
        }

        public List<Consulta> ListarTodas()
        {
            return metodos.Consulta.ToList();
        }
    }
}
