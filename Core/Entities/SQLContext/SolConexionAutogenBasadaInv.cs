#nullable disable

namespace Core.Entities.SQLContext
{
    public partial class SolConexionAutogenBasadaInv
    {
        public int IdSolConexionAutogenBasadaInv { get; set; }
        /// <summary>
        /// Codigo maestro de Solicitud de Conexion
        /// </summary>
        public int CodSolConexionAutogen { get; set; }
        /// <summary>
        /// Potencia por panel
        /// </summary>
        public decimal? PotenciaPanel { get; set; }
        /// <summary>
        /// Numero de paneles
        /// </summary>
        public decimal? NumPaneles { get; set; }
        /// <summary>
        /// Posee rele de flujo inverso
        /// </summary>
        public bool? PoseeRele { get; set; }
        /// <summary>
        /// Capacidad en DC (kW DC)
        /// </summary>
        public decimal? CapacidadDc { get; set; }
        /// <summary>
        /// Potencia total en AC (kW AC)
        /// </summary>
        public decimal? PotTotalAc { get; set; }
        /// <summary>
        /// Voltaje salida del Inversor (V)
        /// </summary>
        public decimal? VoltSalInv { get; set; }
        /// <summary>
        /// Voltaje entrada del Inversor (V)
        /// </summary>
        public decimal? VoltEntInv { get; set; }
        /// <summary>
        /// Numero de fases
        /// </summary>
        public decimal? NumFases { get; set; }
        /// <summary>
        /// Numero de Inversores
        /// </summary>
        public decimal? NumInversores { get; set; }
        /// <summary>
        /// Cuenta con control central de planta (PPC)
        /// </summary>
        public bool? PoseePpc { get; set; }
        /// <summary>
        /// Fabricante de los inversores
        /// </summary>
        public string? FabricanteInv { get; set; }
        /// <summary>
        /// Modelo de los inversores
        /// </summary>
        public string? ModeloInv { get; set; }
        /// <summary>
        /// Cumple estandar UL 1741-2010 o superior
        /// </summary>
        public bool? CumpleUl1741 { get; set; }
        /// <summary>
        /// Version (año) [estandar UL 1741-2010 o superior]
        /// </summary>
        public decimal? AnioUl1741 { get; set; }
        /// <summary>
        /// Cumple estandar IEC 61727-2004 o superior
        /// </summary>
        public bool? CumpleIec61727 { get; set; }
        /// <summary>
        /// Version (año) [estandar IEC 61727-2004 o superior]
        /// </summary>
        public decimal? AnioIec61727 { get; set; }
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
