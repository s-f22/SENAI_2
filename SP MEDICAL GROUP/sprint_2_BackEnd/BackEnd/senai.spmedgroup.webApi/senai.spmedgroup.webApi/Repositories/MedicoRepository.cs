using senai.spmedgroup.webApi.Context;
using senai.spmedgroup.webApi.Domains;
using senai.spmedgroup.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedgroup.webApi.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        SPMedGroupContext metodos = new SPMedGroupContext();
        public List<Medico> ListarTodos()
        {
            return metodos.Medicos.ToList();
        }
    }
}
