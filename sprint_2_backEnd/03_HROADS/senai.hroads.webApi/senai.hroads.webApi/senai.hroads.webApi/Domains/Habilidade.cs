using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class Habilidade
    {
        public byte IdHabilidade { get; set; }
        public byte? IdTipo { get; set; }
        public string NomeHabilidade { get; set; }

        public virtual TipoHabilidade IdTipoNavigation { get; set; }
    }
}
