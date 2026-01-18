using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class Creg075Anexo
    {
        public int Id { get; set; }
        public int Cod075Conexion { get; set; }
        public int CodDocumentos { get; set; }
        public string NameDocument { get; set; } = null!;
        public string ExtDocument { get; set; } = null!;
        public int SizeDocument { get; set; }
        public string UrlDocument { get; set; } = null!;
        public string UrlRelDocument { get; set; } = null!;
        public string OriginalDocument { get; set; } = null!;
        public int EstadoDocumento { get; set; }
        public DateTime? Expedicion { get; set; }
        public bool ValidationDocument { get; set; }
        public bool SendNotification { get; set; }

        public virtual Creg075ServicioConexion Cod075ConexionNavigation { get; set; } = null!;
        public virtual CregDocumentosFormulario CodDocumentosNavigation { get; set; } = null!;
    }
}
