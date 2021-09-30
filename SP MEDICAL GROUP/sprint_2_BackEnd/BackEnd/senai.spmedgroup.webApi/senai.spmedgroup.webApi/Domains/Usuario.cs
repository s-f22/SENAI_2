using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.spmedgroup.webApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Medicos = new HashSet<Medico>();
            Pacientes = new HashSet<Paciente>();
        }

        public int IdUsuario { get; set; }
        public short? IdTipoUsuario { get; set; }
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "A senha deve conter no mínimo 8 caracteres")]
        public string Senha { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ImagemUsuario ImagemUsuario { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
