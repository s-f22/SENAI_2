using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Samuel.Domains
{
    public class AluguelDomain
    {
        public int idAluguel { get; set; }
        public int idVeiculo { get; set; }
        public int idCliente { get; set; }
        [Required(ErrorMessage = "A data de retirada é obrigatória;")]
        [DataType(DataType.Date)]
        public DateTime dataRetirada { get; set; }
        public DateTime dataDevolucao { get; set; }
        public double valorAluguel { get; set; }
        public VeiculoDomain veiculo { get; set; }
        public ClienteDomain cliente { get; set; }
    }
}
