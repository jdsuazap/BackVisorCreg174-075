namespace Application.SQLContext.SolServicioConexionDetalle.DTOs
{
    using Application.SQLContext.SolServicioConexion.DTOs;

    public class SolServicioConexionDetalleDTO
    {
        public int Id { get; set; }
        public int CodSolServicioConexion { get; set; }
        public string NombreProyecto { get; set; } = null!;
        public int CodTipoSolicitud { get; set; }
        public string? NumeroSolicitud { get; set; }
        public DateTime? Vigencia { get; set; }
        public int? CodTipoServicioSolicitud { get; set; }
        public string? OtroTipoServicioSolicitud { get; set; }
        public decimal CargaExistente { get; set; }
        public decimal CargaMaximaRequerida { get; set; }
        public int CodNivelTension { get; set; }
        public bool IncluyeSistemaGeneracion { get; set; }
        public DateTime? FechaEstimadaEntradaOperacion { get; set; }
        public string CodUser { get; set; } = null!;
        public DateTime FechaRegistro { get; set; }
        public string CodUserUpdate { get; set; } = null!;
        public DateTime FechaRegistroUpdate { get; set; }
        public string Info { get; set; } = null!;
        public string InfoUpdate { get; set; } = null!;

        public virtual SolServicioConexionDTO CodSolServicioConexionNavigation { get; set; } = null!;
    }
}
