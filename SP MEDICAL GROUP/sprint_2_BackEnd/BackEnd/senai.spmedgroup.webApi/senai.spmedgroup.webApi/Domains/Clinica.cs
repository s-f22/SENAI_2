using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.spmedgroup.webApi.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Medicos = new HashSet<Medico>();
        }

        public short IdClinica { get; set; }


        [Required(ErrorMessage = "O nome da clínica é obrigatório")]
        public string NomeFantasia { get; set; }


        [Required(ErrorMessage = "O campo CNPJ é obrigatório")]
        public string Cnpj { get; set; }


        [Required(ErrorMessage = "A razão social é obrigatória")]
        public string RazaoSocial { get; set; }


        [Required(ErrorMessage = "Por favor, preencha o endereço da clínica")]
        public string Endereco { get; set; }


        public string Telefone { get; set; }


        [Required(ErrorMessage = "Por favor, informe o horário de funcionamento da clínica")]
        public string HorarioFuncionamento { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
