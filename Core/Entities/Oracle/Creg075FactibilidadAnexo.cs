using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class Creg075FactibilidadAnexo
    {
        public Creg075FactibilidadAnexo()
        {
            EstadoDocumento = 1;
        }
        public int Id { get; set; }
        public long Cod075Factibilidad { get; set; }
        public int? CodDocumentos { get; set; }
        public string NameDocument { get; set; } = null!;
        public string ExtDocument { get; set; } = null!;
        public int SizeDocument { get; set; }
        public string UrlDocument { get; set; } = null!;
        public string UrlRelDocument { get; set; } = null!;
        public string OriginalNameDocument { get; set; } = null!;
        public int EstadoDocumento { get; set; }
        public DateTime? Expedicion { get; set; }
        public bool? ValidationDocument { get; set; }
        public bool? Estado { get; set; }

        public virtual CregDocumentosFormulario? CregDocumentosFormulario { get; set; }
        public virtual Creg075Factibilidad? Creg075Factibilidad { get; set; }
    }
}
