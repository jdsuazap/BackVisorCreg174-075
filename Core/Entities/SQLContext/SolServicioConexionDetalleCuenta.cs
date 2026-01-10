#nullable disable

namespace Core.Entities.SQLContext
{
    public partial class SolServicioConexionDetalleCuenta : BaseEntity
    {
        /// <summary>
        /// ID Solicitud Servicio Conexión
        /// </summary>
        public int CodSolServicioConexion { get; set; }
        /// <summary>
        /// ID Tipo Carga
        /// </summary>
        public int CodTipoCarga { get; set; }
        /// <summary>
        /// ID Tipo Clase Carga
        /// </summary>
        public int CodTipoClaseCarga { get; set; }
        /// <summary>
        /// Valor de la carga
        /// </summary>
        public decimal ValorCarga { get; set; }
        /// <summary>
        /// Cedula del último que crea el registro
        /// </summary>
        public string CodUser { get; set; } = null!;
        /// <summary>
        /// Fecha de creación del registro.
        /// </summary>
        public DateTime FechaRegistro { get; set; }
        /// <summary>
        /// Cedula del último que actualizó el registro
        /// </summary>
        public string CodUserUpdate { get; set; } = null!;
        /// <summary>
        /// Fecha de la ultima actualización del registro.
        /// </summary>
        public DateTime FechaRegistroUpdate { get; set; }
        /// <summary>
        /// En este campo almacenamos la dirección ip, navegador y versión del navegador del cliente.
        /// </summary>
        public string Info { get; set; } = null!;
        /// <summary>
        /// En este campo almacenamos la ultima dirección ip, navegador y versión del navegador del cliente.
        /// </summary>
        public string InfoUpdate { get; set; } = null!;

        public virtual SolServicioConexion CodSolServicioConexionNavigation { get; set; } = null!;
    }
}
