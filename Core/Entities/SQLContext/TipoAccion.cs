using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.SQLContext
{
    public partial class TipoAccion: BaseEntity
    {
        public TipoAccion()
        {
        }
        /// <summary>
        /// Nombre del tipo de opción
        /// </summary>
        public string Nombre { get; set; } = null!;
        /// <summary>
        /// Descripción del tipo de opción
        /// </summary>
        public string Descripcion { get; set; } = null!;
        /// <summary>
        /// Estado del registro
        /// </summary>
        public bool? Estado { get; set; }
        /// <summary>
        /// Se carga una imagen con el logotipo de la empresa, esta debe de ser de maximo 128x128. Conecta con la tabla maestra de archivos.
        /// </summary>
        public string CodArchivo { get; set; } = null!;
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
