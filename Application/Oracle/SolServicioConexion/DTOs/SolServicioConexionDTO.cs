namespace Application.Oracle.SolServicioConexion.DTOs
{
    using Core.Entities.Oracle;

    public class SolServicioConexionDTO
    {
        public int Id { get; set; }
        public int Empresa { get; set; }
        public string NumeroRadicado { get; set; } = null!;
        public DateTime FechaSolicitud { get; set; }
        public int CodTipoConexion { get; set; }
        public int CodTipoUso { get; set; }
        public string? OtroTipoUso { get; set; }
        public int CodEstrato { get; set; }
        public int? CodActividadEconomica { get; set; }
        public bool ExisteRed { get; set; }
        public string DistanciaRed { get; set; } = null!;
        public string Transformador { get; set; } = null!;
        public string Nodo { get; set; } = null!;
        public string Circuito { get; set; } = null!;
        public string? ObservacionesSolicitante { get; set; }
        public bool DocumentacionCompleta { get; set; }
        public bool ObraConforme { get; set; }
        public bool ReciboTecnico { get; set; }
        public bool NormalizacionVisita { get; set; }
        public bool FactibilidadApoyo { get; set; }
        public bool Normalizacion { get; set; }
        public bool Anulacion { get; set; }
        public bool DesistirSolicitud { get; set; }
        public bool Factibilidad { get; set; }
        public int? CodEstado { get; set; }
        public int CodEtapa { get; set; }

        public virtual CregActividadEconomica? CodActividadEconomicaNavigation { get; set; }
        public virtual CregEstado CodEstadoNavigation { get; set; } = null!;
        public virtual CregEstratoSocioeconomico? CodEstratoNavigation { get; set; }
        public virtual CregEtapa CodEtapaNavigation { get; set; } = null!;
        public virtual CregTipoConexion CodTipoConexionNavigation { get; set; } = null!;
        public virtual ICollection<Creg075Anexo> Creg075Anexos { get; set; }
        public virtual Creg075Detalle Creg075Detalles { get; set; }
        public virtual ICollection<Creg075DetallesCuenta> Creg075DetallesCuentas { get; set; }
        public virtual ICollection<Creg075Disenio> Creg075Disenios { get; set; }
        public virtual ICollection<Creg075Factibilidad> Creg075Factibilidads { get; set; }
        public virtual Creg075Predio? Creg075Predios { get; set; }
        public virtual ICollection<Creg075Solicitante> Creg075Solicitantes { get; set; }
        public virtual Creg075Suscriptor? Creg075Suscriptors { get; set; }
        //public virtual ICollection<SolServicioConexionReciboTecnicoDTO> SolReciboTecnicos { get; set; }
        //public virtual ICollection<SolServicioConexionComentarioDTO> SolServicioConexionComentarios { get; set; }
        //public List<ReciboTecnicoDTO> ReciboTecnico { get; internal set; }
    }
}
