#nullable disable
namespace Core.Entities.SQLContext
{
    public partial class DocumentosXformulario : BaseEntity
    {
        /// <summary>
        /// Codigo modulo documento
        /// </summary>
        public int CodFormularioPrincipal { get; set; }
        /// <summary>
        /// Descripción del registro
        /// </summary>
        public string NombreDocumento { get; set; } = null!;
        /// <summary>
        /// Descripcion a mostrar como texto informativo
        /// </summary>
        public string Descripcion { get; set; } = null!;
        /// <summary>
        /// Indica el estado del registro
        /// </summary>
        public bool? Estado { get; set; }
        /// <summary>
        /// Indica si el documento es requerido
        /// </summary>
        public bool Requiered { get; set; }
        /// <summary>
        /// Indica si este documento tiene limite de cargas
        /// </summary>
        public long LimitLoad { get; set; }
        /// <summary>
        /// Indica si el documento tiene vigencia
        /// </summary>
        public bool Vigencia { get; set; }
        /// <summary>
        /// Indica vigencia maxima, en dias
        /// </summary>
        public int VigenciaMaxima { get; set; }
        /// <summary>
        /// Indica si el docuemento hace parte de un campo del formulario
        /// </summary>
        public bool? IsCampo { get; set; }
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
        
    }
}
