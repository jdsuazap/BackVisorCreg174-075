#nullable disable

namespace Core.Entities.SQLContext
{
    public partial class SolConexionAutogenTecnUtilizada : BaseEntity
    {
        /// <summary>
        /// Codigo maestro de Solicitud de Conexion
        /// </summary>
        public int CodSolConexionAutogen { get; set; }
        /// <summary>
        /// Codigo maestro de Tipo Tecnologia
        /// </summary>
        public int? CodTipoTecnologia { get; set; }
        /// <summary>
        /// Otro tipo de tecnologia utilizada
        /// </summary>
        public string? OtroTipoTecnologia { get; set; }
        /// <summary>
        /// Descripcion de capacidad en kW por cada tecnologia utilizada
        /// </summary>
        public string? CapacidadKwPorTecnologia { get; set; }
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

        public virtual SolConexionAutogen CodSolConexionAutogenNavigation { get; set; }
        public virtual TipoTecnologia CodTipoTecnologiaNavigation { get; set; }
    }
}
