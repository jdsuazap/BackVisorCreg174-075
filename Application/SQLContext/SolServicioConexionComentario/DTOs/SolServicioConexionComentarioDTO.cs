namespace Application.SQLContext.SolServicioConexionComentario.DTOs
{
    using Application.Oracle.SolServicioConexion.DTOs;

    public class SolServicioConexionComentarioDTO
    {
        public int Id { get; set; }
        public int? CodSolServicioConexionComentario { get; set; }
        public int CodSolServicioConexion { get; set; }
        public int CodUsuario { get; set; }
        public int? CodPerfil { get; set; }
        public int CodEstadoSolicitud { get; set; }
        public string? TituloComentario { get; set; }
        public string DescripcionComentario { get; set; } = null!;
        public bool IsGestor { get; set; }
        public bool IsPrivate { get; set; }
        public bool? Estado { get; set; }
        public string CodUser { get; set; } = null!;
        public DateTime FechaRegistro { get; set; }
        public string CodUserUpdate { get; set; } = null!;
        public DateTime FechaRegistroUpdate { get; set; }
        public string Info { get; set; } = null!;
        public string InfoUpdate { get; set; } = null!;

        public virtual SolServicioConexionComentarioDTO? CodSolServicioConexionComentarioNavigation { get; set; }
        public virtual SolServicioConexionDTO CodSolServicioConexionNavigation { get; set; } = null!;
        public virtual ICollection<SolServicioConexionComentarioDTO> InverseCodSolServicioConexionComentarioNavigation { get; set; }
    }
}
