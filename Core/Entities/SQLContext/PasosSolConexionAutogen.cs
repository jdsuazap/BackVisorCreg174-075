#nullable disable
namespace Core.Entities.SQLContext
{
    public partial class PasosSolConexionAutogen : BaseEntity
    {
        /// <summary>
        /// Codigo maestro de Solicitud de Conexion
        /// </summary>
        public int CodSolConexionAutogen { get; set; }

        /// <summary>
        /// Codigo maestro de Reporte de Hallazgo
        /// </summary>
        public int? CodSolConexionAutogenReporteHallazgo { get; set; }

        /// <summary>
        /// Codigo maestro de Estado de Solicitud de Conexion
        /// </summary>
        public int CodEstado { get; set; }

        /// <summary>
        /// Estado del registro (Activo/Inactivo)
        /// </summary>
        public bool Estado { get; set; }

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

        public virtual Estado CodEstadoNavigation { get; set; }
        public virtual SolConexionAutogen CodSolConexionAutogenNavigation { get; set; }
    }
}
