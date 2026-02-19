using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class Creg075ReciboTecnicoAnexo
    {
        public int Id { get; set; }
        public int Cod075ReciboTecnico { get; set; }
        public int Cod075Conexion { get; set; }
        public int CodDocumentos { get; set; }
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

        public Creg075ReciboTecnico Creg075ReciboTecnico { get; set; }
        public CregDocumentosFormulario CregDocumentosFormulario { get; set; }
        public Creg075ServicioConexion Creg075ServicioConexion { get; set; }

    }
}
