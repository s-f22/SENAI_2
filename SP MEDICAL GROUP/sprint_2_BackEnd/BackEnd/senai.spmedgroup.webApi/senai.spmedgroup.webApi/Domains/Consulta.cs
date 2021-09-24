using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.spmedgroup.webApi.Domains
{
    public partial class Consulta
    {
        public int IdConsulta { get; set; }
        [Required(ErrorMessage = "Por favor, insira o iD do 'Medico';")]
        public short? IdMedico { get; set; }
        [Required(ErrorMessage = "Por favor, preencha o campo 'Paciente';")]

        public int? IdPaciente { get; set; }
        public short? IdSituacao { get; set; }
        [Required(ErrorMessage = "Por favor, preencha a data da consulta no formato DD/MM/AAAA")]
        public DateTime DataHorario { get; set; }
        public string Resumo { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual Situacao IdSituacaoNavigation { get; set; }
    }
}
