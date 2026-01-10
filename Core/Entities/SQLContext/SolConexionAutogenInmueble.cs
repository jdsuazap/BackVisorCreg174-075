#nullable disable

namespace Core.Entities.SQLContext
{
    public partial class SolConexionAutogenInmueble
    {
        public int IdSolConexionAutogenInmueble { get; set; }
        /// <summary>
        /// Codigo maestro de Solicitud de Conexion
        /// </summary>
        public int CodSolConexionAutogen { get; set; }
        /// <summary>
        /// Direccion de ubicacion del proyecto
        /// </summary>
        public string Direccion { get; set; } = null!;
        /// <summary>
        /// Municipio del proyecto
        /// </summary>
        public string Municipio { get; set; } = null!;
        /// <summary>
        /// Corregimiento del proyecto
        /// </summary>
        public string? Corregimiento { get; set; }
        /// <summary>
        /// Vereda del proyecto
        /// </summary>
        public string? Vereda { get; set; }
        /// <summary>
        /// Ubicacion georreferenciada wgs84 (de googlemaps)
        /// </summary>
        public string? UbicacionGeoWgs { get; set; }
        /// <summary>
        /// Codigo de matricula del poste o transformador mas cercano
        /// </summary>
        public string? NumeroPosteTransformador { get; set; }
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
        public virtual Ciudad MunicipioNavigation { get; set; } = null!;
    }
}
