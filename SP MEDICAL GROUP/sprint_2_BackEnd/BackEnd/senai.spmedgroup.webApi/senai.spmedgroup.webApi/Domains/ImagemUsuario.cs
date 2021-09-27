using System;
using System.Collections.Generic;

#nullable disable

namespace senai.spmedgroup.webApi.Domains
{
    public partial class ImagemUsuario
    {
        public int IdImagem { get; set; }
        public int IdUsuario { get; set; }
        public byte[] ImgBinario { get; set; }
        public string MimeType { get; set; }
        public string NomeArquivo { get; set; }
        public DateTime? DataInclusao { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
