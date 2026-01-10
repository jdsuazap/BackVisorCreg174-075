#nullable disable

namespace Core.Entities.SQLContext
{
    public partial class SolConexionAutogenAnexo : BaseEntity
    {
        /// <summary>
        /// Id de la tabla a relacionar
        /// </summary>
        public int CodSolConexionAutogen { get; set; }
        /// <summary>
        /// id del documento a relacionar
        /// </summary>
        public int CodDocumentosXformulario { get; set; }
        /// <summary>
        /// Nombre del documento
        /// </summary>
        public string NameDocument { get; set; } = null!;
        /// <summary>
        /// Extensión del documento
        /// </summary>
        public string ExtDocument { get; set; } = null!;
        /// <summary>
        /// tamaño del documento
        /// </summary>
        public int SizeDocument { get; set; }
        /// <summary>
        /// Ruta del documento
        /// </summary>
        public string UrlDocument { get; set; } = null!;
        /// <summary>
        /// Ruta relativa del documento
        /// </summary>
        public string UrlRelDocument { get; set; } = null!;
        /// <summary>
        /// Nombre original del documento
        /// </summary>
        public string OriginalNameDocument { get; set; } = null!;
        /// <summary>
        /// Estado del documento
        /// </summary>
        public int EstadoDocumento { get; set; }
        /// <summary>
        /// Fecha de vencimiento del documento, si aplica
        /// </summary>
        public DateTime? Expedicion { get; set; }
        /// <summary>
        /// Este campo indica si el documento ha sido validado por el gestor de documentos al ser cargado por el proveedor
        /// </summary>
        public bool ValidationDocument { get; set; }
        /// <summary>
        /// Este campo indica si ya ha sido envio correo electronico con la notificacion del cambio
        /// </summary>
        public bool SendNotification { get; set; }
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

        public virtual DocumentosXformulario CodDocumentosXformularioNavigation { get; set; }
        public virtual SolConexionAutogen CodSolConexionAutogenNavigation { get; set; }
    }
}
