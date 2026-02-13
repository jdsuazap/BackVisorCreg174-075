using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Oracle
{
    public partial class Creg075Disenio
    {
        public long Id { get; set; }
        public int Cod075Conexion { get; set; }
        public Creg075ServicioConexion Creg075ServicioConexion { get; set; }        
        public long Cod075Factibilidad { get; set; }
        public Creg075Factibilidad Creg075Factibilidad { get; set; }
        public int TipoDocumento { get; set; }
        public string NombreProyecto { get; set; } = null!;
        public string? NombreConstructora { get; set; }
        public string? Nit { get; set; }
        public bool? TieneDocumentacion { get; set; }
        public int? Etapa { get; set; }
        public string CedulaObservaciones { get; set; } = null!;
        public string NombreObservaciones { get; set; } = null!;
        public bool? Estado { get; set; }

        public virtual ICollection<Creg075DisenioActor> Creg075DisenioActor { get; set; }
        public virtual ICollection<Creg075DisenioAnexo> Creg075DisenioAnexo { get; set; }
        public virtual ICollection<Creg075DisenioDocu> Creg075DisenioDocu { get; set; }
    }
}
