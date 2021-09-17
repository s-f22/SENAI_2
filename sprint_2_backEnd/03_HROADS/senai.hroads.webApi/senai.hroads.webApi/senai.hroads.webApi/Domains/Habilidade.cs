using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class Habilidade
    {
        public Habilidade()
        {
            ClasseHabilidades = new HashSet<ClasseHabilidade>();
        }

        public byte IdHabilidade { get; set; }
        public byte? IdTipo { get; set; }
        public string NomeHabilidade { get; set; }

        public virtual TipoHabilidade IdTipoNavigation { get; set; }
        public virtual ICollection<ClasseHabilidade> ClasseHabilidades { get; set; }
    }
}
