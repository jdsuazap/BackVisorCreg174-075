using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class Creg075Factibilidad
    {
        public Creg075Factibilidad()
        {
            Creg075Disenios = new HashSet<Creg075Disenio>();
        }

        public long Id { get; set; }
        public int Cod075Conexion { get; set; }
        public string NumeroFactibilidad { get; set; } = null!;
        public DateTime FechaFactibilidad { get; set; }
        public int VigenciaFactibilidad { get; set; }
        public int CodTipoSolicitud { get; set; }
        public decimal CargaAprobada { get; set; }
        public decimal CargaExistente { get; set; }
        public int NivelAprobacion { get; set; }
        public string? NombreCircuitobt { get; set; }
        public string? NumeroCircuitobt { get; set; }
        public string NombreCircuitomt { get; set; } = null!;
        public string NumeroCircuitomt { get; set; } = null!;
        public string SubestacionPotencia { get; set; } = null!;
        public string DistanciaPuntoConexion { get; set; } = null!;
        public string NivelTrifasico { get; set; } = null!;
        public string NivelMonofasico { get; set; } = null!;
        public string TransformadorDistribucion { get; set; } = null!;
        public string NumeroNodo { get; set; } = null!;
        public string Longitud { get; set; } = null!;
        public string Latitud { get; set; } = null!;
        public string? Altura { get; set; }
        public DateTime FechaRespuestaFactibiidad { get; set; }
        public bool Estado { get; set; }

        public virtual Creg075ServicioConexion Cod075ConexionNavigation { get; set; } = null!;
        public virtual CregTipoSolicitudRecibo CodTipoSolicitudNavigation { get; set; } = null!;
        public virtual ICollection<Creg075Disenio> Creg075Disenios { get; set; }
    }
}
