using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Samuel.Domains
{
    public class ClienteDomain
    {
        public int idCliente { get; set; }
        [Required(ErrorMessage = "O nome do cliente é obrigatório")]
        public string nome { get; set; }
        [Required(ErrorMessage = "O sobrenome do cliente também é obrigatório")]
        public string sobrenome { get; set; }
        public string cnh { get; set; }
    }
}
