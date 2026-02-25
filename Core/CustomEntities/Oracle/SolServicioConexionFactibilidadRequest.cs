namespace Core.CustomEntities.Oracle
{
    using Core.Entities.Oracle;

    public class SolServicioConexionFactibilidadRequest
    {
        public int Cod075Conexion { get; set; }

        public string NumeroFactibilidad { get; set; } = null!;

        public DateTime FechaFactibilidad { get; set; }

        public DateTime FechaRespuestaFactibilidad { get; set; }

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

        public bool? Estado { get; set; }

        public virtual Creg075ServicioConexion Creg075ServicioConexion { get; set; } = null!;
        public virtual CregTipoTension CregTipoTension { get; set; } = null!;
        public virtual Creg075FactibilidadObs Creg075FactibilidadObs { get; set; } = null!;
        public virtual List<Creg075FactibilidadAnexo> Creg075FactibilidadAnexo { get; set; } = new List<Creg075FactibilidadAnexo>();
        public virtual List<Creg075FactibilidadDetCuen> Creg075FactibilidadDetCuen { get; set; } = new List<Creg075FactibilidadDetCuen>();
        public virtual List<Creg075FactibilidadDocu> Creg075FactibilidadDocu { get; set; } = new List<Creg075FactibilidadDocu>();
        public virtual List<Creg075FactibilidadProye> Creg075FactibilidadProye { get; set; } = new List<Creg075FactibilidadProye>();
        public virtual List<Creg075Disenio> Creg075Disenio { get; set; } = new List<Creg075Disenio>();

    }
}
