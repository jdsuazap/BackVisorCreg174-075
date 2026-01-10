#nullable disable

namespace Core.Entities.SQLContext
{
    public partial class SolServicioConexionPredio
    {
        /// <summary>
        /// Identificación del registro
        /// </summary>
        public int IdSolServicioConexionPredio { get; set; }
        /// <summary>
        /// ID Solicitud Conexión Factibilidad
        /// </summary>
        public int CodSolServicioConexion { get; set; }
        /// <summary>
        /// ID Tipo de Zona
        /// </summary>
        public int CodTipoZona { get; set; }
        /// <summary>
        /// Número de Identificación del Cliente - NIU
        /// </summary>
        public string IdentificacionCliente { get; set; } = null!;
        /// <summary>
        /// ID Municipio donde se encuentra el predio
        /// </summary>
        public string CodMunicipio { get; set; } = null!;
        /// <summary>
        /// ID del Departamento
        /// </summary>
        public string CodDepartamento { get; set; } = null!;
        /// <summary>
        /// Localidad donde se encuentra el predio
        /// </summary>
        public string Localidad { get; set; } = null!;
        /// <summary>
        /// Dirección del predio
        /// </summary>
        public string DireccionPredio { get; set; } = null!;
        /// <summary>
        /// Longitud Ubicación georreferenciada WGS 84 
        /// </summary>
        public string UbicacionLong { get; set; } = null!;
        /// <summary>
        /// Latitud  Ubicación georreferenciada WGS 84 
        /// </summary>
        public string UbicacionLat { get; set; } = null!;
        /// <summary>
        /// H Ubicación georreferenciada WGS 84 
        /// </summary>
        public string UbicacionH { get; set; } = null!;
        /// <summary>
        /// Indicaciones de acceso al predio
        /// </summary>
        public string DescripcionAccesoPredio { get; set; } = null!;
        /// <summary>
        /// Codigo maestro de TipoConstruccion
        /// </summary>
        public int CodTipoConstruccion { get; set; }
        /// <summary>
        /// Matricula Inmobiliaria de la edificación existente
        /// </summary>
        public string? MatriculaInmobiliaria { get; set; }
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

        public virtual SolServicioConexion CodSolServicioConexionNavigation { get; set; } = null!;
    }
}
