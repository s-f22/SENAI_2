using Microsoft.EntityFrameworkCore;
using senai.spmedgroup.webApi.Context;
using senai.spmedgroup.webApi.Domains;
using senai.spmedgroup.webApi.Interfaces;
using senai.spmedgroup.webApi.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace senai.spmedgroup.webApi.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        SPMedGroupContext metodos = new SPMedGroupContext();

        public void CancelarConsulta(int id)
        {            
            Consulta consultaBuscada = metodos.Consultas.Find(id);

            if (consultaBuscada != null)
            {
                consultaBuscada.IdSituacao = 3;

                metodos.Consultas.Update(consultaBuscada);
                metodos.SaveChanges();
            }
        }

        public Consulta BuscarPorId(int idConsulta)
        {
            return metodos.Consultas.FirstOrDefault(c => c.IdConsulta == idConsulta);
        }

        public void Cadastrar(Consulta novaConsulta)
        {
            novaConsulta.IdSituacao = 2;
            novaConsulta.Resumo = "O resumo será preenchico pelo médico, após realização da consulta.";
            metodos.Consultas.Add(novaConsulta);
            metodos.SaveChanges();
        }

        public void Deletar(int idConsulta)
        {
            metodos.Consultas.Remove(BuscarPorId(idConsulta));
            metodos.SaveChanges();
        }

        public List<Consulta> ListarTodas()
        {
            //return metodos.Consultas.ToList();
            //return metodos.Consultas.Include(p => p.IdPacienteNavigation).Include(m => m.IdMedicoNavigation).Include(s => s.IdSituacaoNavigation).ToList();
            return metodos.Consultas.Select(c => new Consulta() { DataHorario = c.DataHorario , IdConsulta = c.IdConsulta, IdMedico = c.IdMedico, IdPaciente = c.IdPaciente, IdSituacao = c.IdSituacao, Resumo = c.Resumo, IdMedicoNavigation = c.IdMedicoNavigation, IdPacienteNavigation = c.IdPacienteNavigation, IdSituacaoNavigation = c.IdSituacaoNavigation }).ToList();
        }

        public void IncluirDescricao(int idConsulta, ConsultaViewModel descricaoAtualizada)
        {
            Consulta consultaBuscada = metodos.Consultas.Find(idConsulta);

            if (consultaBuscada != null)
            {
                consultaBuscada.Resumo = descricaoAtualizada.Resumo;
                consultaBuscada.IdSituacao = 1;
            }
          
            metodos.Consultas.Update(consultaBuscada);
            metodos.SaveChanges();
        }   
    }
}
