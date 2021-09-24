using System;
using System.Collections.Generic;

#nullable disable

namespace senai.spmedgroup.webApi.Domains
{
    public partial class Situacao
    {
        public Situacao()
        {
            Consulta = new HashSet<Consulta>();
        }

        public short IdSituacao { get; set; }
        public string Titulo { get; set; }

        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
