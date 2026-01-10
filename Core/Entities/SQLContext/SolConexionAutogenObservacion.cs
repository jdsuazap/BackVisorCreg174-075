namespace Core.Entities.SQLContext
{
    public partial class SolConexionAutogenObservacion : BaseEntity
    {
        public SolConexionAutogenObservacion()
        {
        }

        /// <summary>
        /// Codigo maestro de la Solicitud
        /// </summary>
        public int CodSolConexionAutogen { get; set; }
        /// <summary>
        /// Descripcion del registro
        /// </summary>
        public string Descripcion { get; set; } = null!;
        /// <summary>
        /// Estado solicitud en el momento de la observación
        /// </summary>
        public int EstadoSolicitud { get; set; }
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

        public virtual SolConexionAutogen CodSolConexionAutogenNavigation { get; set; } = null!;
    }
}
