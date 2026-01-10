#nullable disable

namespace Core.Entities.SQLContext
{
    public partial class SolConexionAutogenTecnologia
    {
        public int IdSolConexionAutogenTecnologias { get; set; }
        /// <summary>
        /// Codigo maestro de Solicitud de Conexion
        /// </summary>
        public int CodSolConexionAutogen { get; set; }
        /// <summary>
        /// Cuenta con almacenamiento de energia
        /// </summary>
        public bool AlmacenamientoEnergia { get; set; }
        /// <summary>
        /// Capacidad en kW
        /// </summary>
        public decimal? CapacidadKw { get; set; }
        /// <summary>
        /// Capacidad en kWh
        /// </summary>
        public decimal? CapacidadKwh { get; set; }
        /// <summary>
        /// Sistema basado en inversores
        /// </summary>
        public bool BasadoInversores { get; set; }
        /// <summary>
        /// Sistema basado en maquinas sincronicas
        /// </summary>
        public bool BasadoMaqSincronicas { get; set; }
        /// <summary>
        /// Sistema basado en maquinas asincronicas
        /// </summary>
        public bool BasadoMaqAsincronicas { get; set; }
        /// <summary>
        /// Otra tecnologia base
        /// </summary>
        public string? OtraTecnologiaBase { get; set; }
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
    }
}
