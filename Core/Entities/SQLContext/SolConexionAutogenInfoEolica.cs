#nullable disable

namespace Core.Entities.SQLContext
{
    public partial class SolConexionAutogenInfoEolica
    {
        public int IdSolConexionAutogenInfoEolica { get; set; }
        /// <summary>
        /// Codigo maestro de Solicitud de Conexion
        /// </summary>
        public int CodSolConexionAutogen { get; set; }
        /// <summary>
        /// Fabricante del aerogenerador
        /// </summary>
        public string? FabricanteAerogenerador { get; set; }
        /// <summary>
        /// Modelo
        /// </summary>
        public string? Modelo { get; set; }
        /// <summary>
        /// Voltaje AC  (V)
        /// </summary>
        public decimal? VoltajeAc { get; set; }
        /// <summary>
        /// Potencia nominal (kW)
        /// </summary>
        public decimal? PotenciaNominal { get; set; }
        /// <summary>
        /// Numero de aerogeneradores
        /// </summary>
        public decimal? NumAerogeneradores { get; set; }
        /// <summary>
        /// Codigo maestro de Tipo Aerogenerador
        /// </summary>
        public int? CodTipoAerogenerador { get; set; }
        /// <summary>
        /// Cuenta con control central de planta (PPC)
        /// </summary>
        public string? PoseePpc { get; set; }
        /// <summary>
        /// Potencia nominal (kVA)
        /// </summary>
        public decimal? TransfoPotNominal { get; set; }
        /// <summary>
        /// Impedancia de C.C. (%)
        /// </summary>
        public decimal? TransfoImpedanciaCc { get; set; }
        /// <summary>
        /// Grupo de conexion
        /// </summary>
        public string? TransfoGrupoConex { get; set; }
        /// <summary>
        /// Elementos de proteccion, control o maniobra que limitan la inyeccion de energia a la red
        /// </summary>
        public string? DescripcionElementos { get; set; }
        /// <summary>
        /// Cumple estandar IEEE 1547-2003 o superior
        /// </summary>
        public bool? CumpleIeee1547 { get; set; }
        /// <summary>
        /// Version (año) [estandar IEEE 1547-2003 o superior]
        /// </summary>
        public decimal? AnioIeee1547 { get; set; }
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
        public virtual TipoAerogenerador CodTipoAerogeneradorNavigation { get; set; }
    }
}
