using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi_Samuel.Domains
{
    public class VeiculoDomain
    {
        public int idVeiculo { get; set; }
        public int idModelo { get; set; }
        public int idEmpresa { get; set; }
        public string corVeiculo { get; set; }
        public EmpresaDomain Empresa { get; set; }
        public ModeloDomain Modelo { get; set; }

    }
}
