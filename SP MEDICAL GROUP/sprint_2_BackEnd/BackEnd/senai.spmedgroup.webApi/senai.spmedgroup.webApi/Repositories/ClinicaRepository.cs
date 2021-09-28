using senai.spmedgroup.webApi.Context;
using senai.spmedgroup.webApi.Domains;
using senai.spmedgroup.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedgroup.webApi.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        SPMedGroupContext metodos = new SPMedGroupContext();

        public void Atualizar(int id, Clinica clinicaAtualizada)
        {
            Clinica clinicaBuscada = metodos.Clinicas.Find(id);

            if (clinicaBuscada != null)
            {
                clinicaBuscada.NomeFantasia = clinicaAtualizada.NomeFantasia;
                clinicaBuscada.Cnpj = clinicaAtualizada.Cnpj;
                clinicaBuscada.RazaoSocial = clinicaAtualizada.RazaoSocial;
                clinicaBuscada.Endereco = clinicaAtualizada.Endereco;
                clinicaBuscada.Telefone = clinicaAtualizada.Telefone;
                clinicaBuscada.HorarioFuncionamento = clinicaAtualizada.HorarioFuncionamento;

                metodos.Clinicas.Update(clinicaBuscada);
                metodos.SaveChanges();
            }
        }

        public Clinica BuscarPorId(int idClinica)
        {
            return metodos.Clinicas.FirstOrDefault(c => c.IdClinica == idClinica);
        }

        public void Cadastrar(Clinica novaClinica)
        {
            metodos.Clinicas.Add(novaClinica);
            metodos.SaveChanges();
        }

        public void Deletar(int idClinica)
        {
            metodos.Clinicas.Remove(BuscarPorId(idClinica));
            metodos.SaveChanges();
        }

        public List<Clinica> ListarTodas()
        {
            return metodos.Clinicas.ToList();
        }
    }
}
