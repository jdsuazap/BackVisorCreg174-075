#nullable disable

namespace Core.Entities.SQLContext
{
    public partial class SolServicioConexionDetalle
    {
        /// <summary>
        /// Identificación del registro
        /// </summary>
        public int IdSolServicioConexionDetalle { get; set; }
        /// <summary>
        /// ID Solicitud Servicio Conexión
        /// </summary>
        public int CodSolServicioConexion { get; set; }
        /// <summary>
        /// No,bre del Prooyecto
        /// </summary>
        public string NombreProyecto { get; set; } = null!;
        /// <summary>
        /// ID Tipo de Solicitud
        /// </summary>
        public int CodTipoSolicitud { get; set; }
        /// <summary>
        /// Numero de la solicitud existente a modificar o revaluar
        /// </summary>
        public string? NumeroSolicitud { get; set; }
        /// <summary>
        /// Fecha Vigencia solicitud existente
        /// </summary>
        public DateTime? Vigencia { get; set; }
        /// <summary>
        /// ID tipo de servicio solicitado 
        /// </summary>
        public int? CodTipoServicioSolicitud { get; set; }
        /// <summary>
        /// Nombre del tipo servicio de la solicitud que no aparece en el sistema
        /// </summary>
        public string? OtroTipoServicioSolicitud { get; set; }
        /// <summary>
        /// Carga existente en kVA
        /// </summary>
        public decimal CargaExistente { get; set; }
        /// <summary>
        ///  Carga máxima requerida en kVA
        /// </summary>
        public decimal CargaMaximaRequerida { get; set; }
        /// <summary>
        /// ID  Nivel de tensión solicitado
        /// </summary>
        public int CodNivelTension { get; set; }
        /// <summary>
        /// Si el proyecto incluye algún sistema de generación (1-Si, 0-No)
        /// </summary>
        public bool IncluyeSistemaGeneracion { get; set; }
        /// <summary>
        /// Fecha estimada de entrada en operación
        /// </summary>
        public DateTime? FechaEstimadaEntradaOperacion { get; set; }
        /// <summary>
        /// Cedula del último que crea el registro
        /// </summary>
        public string CodUser { get; set; } = null!;
        /// <summary>
        /// Fecha de creación del registro.
        /// </summary>
        public DateTime FechaRegistro { get; set; }
        /// <summary>
        /// Cedula del ultimo último que actualizó el registro
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

        public virtual SolServicioConexion CodSolServicioConexionNavigation { get; set; } = null!;
    }
}
