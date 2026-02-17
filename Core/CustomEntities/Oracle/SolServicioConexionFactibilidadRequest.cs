namespace Core.CustomEntities.Oracle
{
    using Core.Entities.Oracle;

    public class SolServicioConexionFactibilidadRequest
    {
        public int CodSolServicioConexion { get; set; }

        public string NumeroFactibilidad { get; set; } = null!;

        public DateTime FechaFactibilidad { get; set; }

        public DateTime FechaRespuestaFactibilidad { get; set; }

        public int VigenciaFactibilidad { get; set; }

        public int CodTipoSolicitud { get; set; }

        public double CargaAprobada { get; set; }

        public double CargaExistente { get; set; }

        public int CodigoNivelAprobacion { get; set; }

        public string? NombreCircuitoBt { get; set; }

        public string? NumeroCircuitoBt { get; set; }

        public string NombreCircuitoMt { get; set; } = null!;

        public string NumeroCircuitoMt { get; set; } = null!;

        public string SubEstacionPotencia { get; set; } = null!;

        public string DistanciaPuntoConexion { get; set; } = null!;

        public string NivelCortocircuitoTrifasico { get; set; } = null!;

        public string NivelCortocircuitoMonofasico { get; set; } = null!;

        public string TransformadorDistribucion { get; set; } = null!;

        public string NumeroNodo { get; set; } = null!;

        public string GeoReferenciaLongitud { get; set; } = null!;

        public string GeoReferenciaLatitud { get; set; } = null!;

        public string? GeoReferenciaH { get; set; }

        public bool? Estado { get; set; }

        public string CodUser { get; set; } = null!;

        public DateTime FechaRegistro { get; set; }

        public string CodUserUpdate { get; set; } = null!;

        public DateTime FechaRegistroUpdate { get; set; }

        public string Info { get; set; } = null!;

        public string InfoUpdate { get; set; } = null!;

        public virtual Creg075ServicioConexion Creg075ServicioConexion { get; set; } = null!;
        public virtual CregTipoTension CregTipoTension { get; set; } = null!;
        public virtual List<Creg075FactibilidadAnexo> Creg075FactibilidadAnexo { get; set; } = new List<Creg075FactibilidadAnexo>();
        public virtual List<Creg075FactibilidadDetCuen> Creg075FactibilidadDetCuen { get; set; } = new List<Creg075FactibilidadDetCuen>();
        public virtual List<Creg075Disenio> Creg075Disenio { get; set; } = new List<Creg075Disenio>();

    }
}
