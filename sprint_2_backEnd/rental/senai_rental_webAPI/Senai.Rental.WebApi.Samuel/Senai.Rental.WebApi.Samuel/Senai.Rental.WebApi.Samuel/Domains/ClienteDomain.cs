using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi_Samuel.Domains
{
    public class ClienteDomain
    {
        public int idCliente { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string cnh { get; set; }
    }
}
