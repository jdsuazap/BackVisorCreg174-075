namespace Core.Entities.SQLContext
{
    public partial class SolConexionAutogenComentario : BaseEntity
    {
        public SolConexionAutogenComentario()
        {
            InverseCodSolConexionAutogenComentarioNavigation = new HashSet<SolConexionAutogenComentario>();
        }

        /// <summary>
        /// Codigo padre al que pertenece este comentario, si es null, indica que es comentario padre de lo contrario es una respuesta a un comentario
        /// </summary>
        public int? CodSolConexionAutogenComentario { get; set; }
        /// <summary>
        /// Codigo maestro de SolConexionAutogen
        /// </summary>
        public int CodSolConexionAutogen { get; set; }
        /// <summary>
        /// Codigo maestro de Usuario que genera el comentario o respuesta
        /// </summary>
        public int CodUsuario { get; set; }
        /// <summary>
        /// Codigo maestro de Perfil. Hace referencia al perfil al que se le esta haciendo un comentario
        /// </summary>
        public int? CodPerfil { get; set; }
        /// <summary>
        /// Codigo maestro de Estado. Indica el estado actual de la solicitud al momento de realizar el comentario
        /// </summary>
        public int CodEstadoSolicitud { get; set; }
        /// <summary>
        /// Titulo para comentario
        /// </summary>
        public string? TituloComentario { get; set; }
        /// <summary>
        /// Descripcion del comentario realizado
        /// </summary>
        public string DescripcionComentario { get; set; } = null!;
        /// <summary>
        /// Indica si el usuario es Gestor Administrativo de la aplicacion
        /// </summary>
        public bool IsGestor { get; set; }
        /// <summary>
        /// Indica si el comentario es privado. Solo puede ser visto por los actores implicados
        /// </summary>
        public bool IsPrivate { get; set; }
        /// <summary>
        /// Estado del registro (Activo/Inactivo)
        /// </summary>
        public bool? Estado { get; set; }
        /// <summary>
        /// Cedula del usuario que crea el registro
        /// </summary>
        public string CodUser { get; set; } = null!;
        /// <summary>
        /// Fecha de creación del registro.
        /// </summary>
        public DateTime FechaRegistro { get; set; }
        /// <summary>
        /// Cedula del ultimo usuario que actualizó el registro
        /// </summary>
        public string CodUserUpdate { get; set; } = null!;
        /// <summary>
        /// Fecha de la ultima actualización del registro.
        /// </summary>
        public DateTime FechaRegistroUpdate { get; set; }
        /// <summary>
        /// En este campo almacenamos la direccion ip, navegador y version del navegador del cliente.
        /// </summary>
        public string Info { get; set; } = null!;
        /// <summary>
        /// En este campo almacenamos la ultima direccion ip, navegador y version del navegador del cliente.
        /// </summary>
        public string InfoUpdate { get; set; } = null!;

        public virtual Estado CodEstadoSolicitudNavigation { get; set; } = null!;
        public virtual SolConexionAutogenComentario? CodSolConexionAutogenComentarioNavigation { get; set; }
        public virtual SolConexionAutogen CodSolConexionAutogenNavigation { get; set; } = null!;
        public virtual ICollection<SolConexionAutogenComentario> InverseCodSolConexionAutogenComentarioNavigation { get; set; }
    }
}
