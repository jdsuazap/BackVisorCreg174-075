#nullable disable

namespace Core.Entities.SQLContext
{
    public partial class TipoCliente : BaseEntity
    {
        public TipoCliente()
        {
            SolConexionAutogens = new HashSet<SolConexionAutogen>();
            SolServicioConexionDetalleCuenta = new HashSet<SolServicioConexionDetalleCuenta>();
            SolServicioConexions = new HashSet<SolServicioConexion>();
        }

        /// <summary>
        /// Descripcion del registro
        /// </summary>
        public string Descripcion { get; set; } = null!;
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

        public virtual ICollection<SolConexionAutogen> SolConexionAutogens { get; set; }
        public virtual ICollection<SolServicioConexionDetalleCuenta> SolServicioConexionDetalleCuenta { get; set; }
        public virtual ICollection<SolServicioConexion> SolServicioConexions { get; set; }
    }
}
