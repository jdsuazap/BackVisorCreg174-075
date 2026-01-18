namespace Application.Oracle.SolServicioConexion.DTOs
{
    using Application.SQLContext.SolReciboTecnico.DTOs;
    using Application.SQLContext.SolServicioConexionComentario.DTOs;
    using Application.SQLContext.SolServicioConexionDatosSolicitantes.DTOs;
    using Application.SQLContext.SolServicioConexionDatosSuscriptor.DTOs;
    using Application.SQLContext.SolServicioConexionDetalle.DTOs;
    using Application.SQLContext.SolServicioConexionDetalleCuentas.DTOs;
    using Application.SQLContext.SolServicioConexionPredio.DTOs;
    using Application.SQLContext.SolServicioConexionReciboTecnico.DTOs;

    public class SolServicioConexionDTO
    {
        public int Id { get; set; }
        public int CodUsuario { get; set; }
        public string NumeroRadicado { get; set; } = null!;
        public int Empresa { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public int CodTipoConexion { get; set; }
        public int CodTipoUso { get; set; }
        public string? OtroTipoUso { get; set; }
        public int CodEstrato { get; set; }
        public int? CodActividadEconomica { get; set; }
        public bool ExisteRedCercana { get; set; }
        public string DistanciaRedCercana { get; set; } = null!;
        public string Transformador { get; set; } = null!;
        public string Nodo { get; set; } = null!;
        public string Circuito { get; set; } = null!;
        public string? ObservacionesSolicitante { get; set; }
        public int? CodEstado { get; set; }
        public string CodUser { get; set; } = null!;
        public DateTime FechaRegistro { get; set; }
        public string CodUserUpdate { get; set; } = null!;
        public DateTime FechaRegistroUpdate { get; set; }
        public string Info { get; set; } = null!;
        public string InfoUpdate { get; set; } = null!;
        public AlertSolServicioConexionDTO Alert { get; internal set; }
        public bool HasFactibilidadTemp { get; internal set; } = false;
        public bool SeguimientoDocumentacionCompleta { get; set; }
        public bool SeguimientoObraConforme { get; set; }
        public bool NormalizacionDocumentacionCompleta { get; set; }
        public bool ReciboTecnicoDocumentacionCompleta { get; set; }
        public bool NormalizacionVisitaConforme { get; set; }
        public bool NormalizacionOtraEtapa { get; set; }
        public bool AnulacionHabilitada { get; set; }
        public bool DesistirSolicitudHabilitado { get; set; }
        public bool PuedeRealizarFactibilidad { get; set; }
        public int Etapa { get; set; }
        public bool PuedeActualizarFactibilidadPerfilApoyo { get; set; }       
        public virtual SolServicioConexionDatosSolicitantesDTO? SolServicioConexionDatosSolicitante { get; set; }
        public virtual SolServicioConexionDatosSuscriptorDTO? SolServicioConexionDatosSuscriptor { get; set; }
        public virtual SolServicioConexionDetalleDTO? SolServicioConexionDetalle { get; set; }
        public virtual ICollection<SolServicioConexionDetalleCuentasDTO> SolServicioConexionDetalleCuenta { get; set; }
        public virtual SolServicioConexionPredioDTO SolServicioConexionPredio { get; set; }
        public virtual ICollection<SolServicioConexionReciboTecnicoDTO> SolReciboTecnicos { get; set; }
        public virtual ICollection<SolServicioConexionComentarioDTO> SolServicioConexionComentarios { get; set; }
        public List<ReciboTecnicoDTO> ReciboTecnico { get; internal set; }
    }
}
