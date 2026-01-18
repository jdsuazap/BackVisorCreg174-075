using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class Creg075Disenio
    {
        public long Id { get; set; }
        public int Cod075Conexion { get; set; }
        public long CodFactibilidad { get; set; }
        public int TipoDocumento { get; set; }
        public string NombreProyecto { get; set; } = null!;
        public string? NombreConstructora { get; set; }
        public string? Nit { get; set; }
        public bool? TieneDocumentacion { get; set; }
        public int? Etapa { get; set; }
        public string CedulaObservaciones { get; set; } = null!;
        public string NombreObservaciones { get; set; } = null!;
        public bool? Estado { get; set; }

        public virtual Creg075ServicioConexion Cod075ConexionNavigation { get; set; } = null!;
        public virtual Creg075Factibilidad CodFactibilidadNavigation { get; set; } = null!;
    }
}
