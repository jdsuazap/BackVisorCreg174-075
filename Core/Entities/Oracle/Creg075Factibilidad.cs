using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class Creg075Factibilidad
    {
        public Creg075Factibilidad()
        {
            Creg075FactibilidadAnexo = new HashSet<Creg075FactibilidadAnexo>();
            Creg075FactibilidadDetCuen = new HashSet<Creg075FactibilidadDetCuen>();
            Creg075FactibilidadDocu = new HashSet<Creg075FactibilidadDocu>();
            Creg075FactibilidadProye = new HashSet<Creg075FactibilidadProye>();
            Creg075Disenios = new HashSet<Creg075Disenio>();
        }

        public long Id { get; set; }
        public int Cod075Conexion { get; set; }
        public string NumeroFactibilidad { get; set; } = null!;
        public DateTime FechaFactibilidad { get; set; }
        public long VigenciaFactibilidad { get; set; }
        public int CodTipoSolicitud { get; set; }
        public long CargaAprobada { get; set; }
        public long CargaExistente { get; set; }
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
        public DateTime FechaRespuestaFactibilidad { get; set; }
        public bool Estado { get; set; }

        public virtual Creg075ServicioConexion Creg075ServicioConexion { get; set; } = null!;
        public virtual CregTipoSolicitudRecibo CregTipoSolicitudRecibo { get; set; } = null!;
        public virtual CregTipoTension CregTipoTension { get; set; } = null!;
        public virtual ICollection<Creg075FactibilidadAnexo> Creg075FactibilidadAnexo { get; set; } = new List<Creg075FactibilidadAnexo>();
        public virtual ICollection<Creg075FactibilidadDetCuen> Creg075FactibilidadDetCuen { get; set; } = new List<Creg075FactibilidadDetCuen>();
        public virtual Creg075FactibilidadObs? Creg075FactibilidadObs { get; set; }
        public virtual ICollection<Creg075FactibilidadDocu> Creg075FactibilidadDocu { get; set; } = new List<Creg075FactibilidadDocu>();
        public virtual ICollection<Creg075FactibilidadProye> Creg075FactibilidadProye { get; set; } = new List<Creg075FactibilidadProye>();
        public virtual ICollection<Creg075Disenio> Creg075Disenios { get; set; }

    }
}
