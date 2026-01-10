namespace Application.SQLContext.SolConexionAutogenComentario.DTOs
{
    using Application.SQLContext.Estado.DTOs;
    using Application.SQLContext.SolConexionAutogen.DTOs;

    public class SolConexionAutogenComentarioDTO
    {
        public int Id { get; set; }
        public int? CodSolConexionAutogenComentario { get; set; }
        public int CodSolConexionAutogen { get; set; }
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

        public virtual EstadoDTO CodEstadoSolicitudNavigation { get; set; } = null!;
        public virtual SolConexionAutogenComentarioDTO? CodSolConexionAutogenComentarioNavigation { get; set; }
        public virtual SolConexionAutogenDTO CodSolConexionAutogenNavigation { get; set; } = null!;
        public virtual ICollection<SolConexionAutogenComentarioDTO> InverseCodSolConexionAutogenComentarioNavigation { get; set; }
        //public virtual ICollection<SolConexionAutogenComentarioAnexoDTO> SolConexionAutogenComentarioAnexos { get; set; }

    }
}
