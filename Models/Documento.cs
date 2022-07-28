using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace APIGestionDocumentos.Models
{
    public partial class Documento
    {
        public Documento()
        {
            Tramites = new HashSet<Tramite>();
        }

        public int Codigo { get; set; }
        public string Nombre { get; set; } = null!;
        public int TipoDocumento { get; set; }
        public DateTime Fecha { get; set; }
        public bool Activo { get; set; }

        [JsonIgnore]
        public virtual TiposDocumento? TipoDocumentoNavigation { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Tramite>? Tramites { get; set; }
    }
}
