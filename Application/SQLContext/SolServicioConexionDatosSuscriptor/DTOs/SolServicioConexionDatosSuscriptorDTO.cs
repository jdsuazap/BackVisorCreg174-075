namespace Application.SQLContext.SolServicioConexionDatosSuscriptor.DTOs
{
    using Application.SQLContext.SolServicioConexion.DTOs;

    public class SolServicioConexionDatosSuscriptorDTO
    {
        public int Id { get; set; }
        public int CodSolServicioConexion { get; set; }
        public string Nombre { get; set; } = null!;
        public int CodTipoPersona { get; set; }
        public int CodTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string CodMunicipio { get; set; } = null!;
        public string CodDepartamento { get; set; } = null!;
        public decimal Celular { get; set; }
        public decimal? Telefono { get; set; }
        public string Email { get; set; } = null!;
        public bool AutorizacionNotificacionEmail { get; set; }
        public string CodUser { get; set; } = null!;
        public DateTime FechaRegistro { get; set; }
        public string CodUserUpdate { get; set; } = null!;
        public DateTime FechaRegistroUpdate { get; set; }
        public string Info { get; set; } = null!;
        public string InfoUpdate { get; set; } = null!;

        public virtual SolServicioConexionDTO CodSolServicioConexionNavigation { get; set; } = null!;
    }
}
