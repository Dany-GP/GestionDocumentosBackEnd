using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace APIGestionDocumentos.Models
{
    public partial class Tramite
    {
        public int Codigo { get; set; }
        public int Documento { get; set; }
        public string Nombre { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public bool Activo { get; set; }

        [JsonIgnore]
        public virtual Documento? DocumentoNavigation { get; set; } = null!;
    }
}
