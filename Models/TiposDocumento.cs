using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace APIGestionDocumentos.Models
{
    public partial class TiposDocumento
    {
        public TiposDocumento()
        {
            Documentos = new HashSet<Documento>();
        }

        public int Codigo { get; set; }
        public string Nombre { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public bool Activo { get; set; }

        [JsonIgnore]
        public virtual ICollection<Documento>? Documentos { get; set; }
    }
}
