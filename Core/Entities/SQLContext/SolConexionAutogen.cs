#nullable disable
namespace Core.Entities.SQLContext
{
    public partial class SolConexionAutogen : BaseEntity
    {
        public SolConexionAutogen()
        {
            PasosSolConexionAutogens = new HashSet<PasosSolConexionAutogen>();
            SolConexionAutogenAnexos = new HashSet<SolConexionAutogenAnexo>();
            //SolConexionAutogenComentarios = new HashSet<SolConexionAutogenComentario>();
            SolConexionAutogenObservacions = new HashSet<SolConexionAutogenObservacion>();
            SolConexionAutogenTecnUtilizada = new HashSet<SolConexionAutogenTecnUtilizada>();            
            SolConexionAutogenInsumos = new HashSet<SolConexionAutogenInsumo>();
            
        }

        /// <summary>
        /// Codigo maestro de usuario (cliente)
        /// </summary>
        public int CodUsuario { get; set; }

        /// <summary>
        /// Codigo maestro de TipoProcedimientoConexion
        /// </summary>
        public int? CodTipoProcedimientoConexion { get; set; }

        /// <summary>
        /// Empresa asociada a la solicitud
        /// </summary>
        public int? Empresa { get; set; }

        /// <summary>
        /// Indica si el OR instalara el transformador o nodo
        /// </summary>
        public bool? OrinstalaActivos { get; set; }

        /// <summary>
        /// Numero de radicado generado para la solicitud (Generado automaticamente)
        /// </summary>
        public string NumeroRadicado { get; set; } = null!;

        /// <summary>
        /// Codigo del tipo de Generación al que pertenece el solicitante
        /// </summary>
        public int CodTipoGeneracion { get; set; }

        /// <summary>
        /// Indica si el solicitante entrega excedentes a la red
        /// </summary>
        public bool EntregaExcedentes { get; set; }

        /// <summary>
        /// Fecha Prevista para la entrada en operacion
        /// </summary>
        public DateTime FechaPrevistaOper { get; set; }

        /// <summary>
        /// Clasificacion del proyecto, del solicitante, de acuerdo a su capacidad
        /// </summary>
        public int? CodClasificacionProyecto { get; set; }

        /// <summary>
        /// Codigo maestro de Comercializador
        /// </summary>
        public int? CodComercializador { get; set; }

        /// <summary>
        /// Nombre del comercializador que atiende al solicitante
        /// </summary>
        public string? NombreOtroComercializador { get; set; }

        /// <summary>
        /// Codigo de cuenta del solicitante, si es atendido por la empresa directamente
        /// </summary>
        public int? CodCuentaCliente { get; set; }

        /// <summary>
        /// Codigo SIC (Frontera) del otro comercializador por el que es atendido
        /// </summary>
        public int? CodigoSic { get; set; }

        /// <summary>
        /// Nombre del solicitante
        /// </summary>
        public string NombreCliente { get; set; } = null!;

        /// <summary>
        /// Codigo del tipo de identificacion
        /// </summary>
        public int CodTipoIdentificacionCliente { get; set; }

        /// <summary>
        /// Numero de identificacion del cliente
        /// </summary>
        public string NumeroIdentificacionCliente { get; set; } = null!;

        /// <summary>
        /// Direccion del cliente
        /// </summary>
        public string DireccionCliente { get; set; } = null!;

        /// <summary>
        /// Codigo de departamento al que pertenece el cliente
        /// </summary>
        public string CodDepartamentoCliente { get; set; } = null!;

        /// <summary>
        /// Codigo de municipio al que pertenece el cliente
        /// </summary>
        public string CodMunicipioCliente { get; set; } = null!;

        /// <summary>
        /// Barrio del cliente
        /// </summary>
        public string? BarrioCliente { get; set; }

        /// <summary>
        /// Telefono del cliente
        /// </summary>
        public decimal TelefonoCliente { get; set; }

        /// <summary>
        /// Email del cliente
        /// </summary>
        public string EmailCliente { get; set; } = null!;

        /// <summary>
        /// Codigo del tipo de cliente
        /// </summary>
        public int CodTipoCliente { get; set; }

        /// <summary>
        /// Corresponde a Otros tipos de clientes
        /// </summary>
        public string? OtroTipoCliente { get; set; }

        /// <summary>
        /// Codigo maestro de EstratoSocioeconomico. Estrato del cliente, si es de tipo cliente Residencial
        /// </summary>
        public int? CodEstratoCliente { get; set; }

        /// <summary>
        /// Capacidad nominal o instalada del sistema (kW)
        /// </summary>
        public decimal CapacidadNominal { get; set; }

        /// <summary>
        /// Potencia maxima declarada (kW)
        /// </summary>
        public decimal PotenciaMaximaDeclarada { get; set; }

        /// <summary>
        /// Nivel de tension (kV)
        /// </summary>
        public decimal NivelTension { get; set; }

        /// <summary>
        /// Si entrega excedentes, codigo de la subestacion, transformador o circuito al cual se realizara la conexion
        /// </summary>
        public string? CodTransformador { get; set; }

        /// <summary>
        /// Codigo de subestacion del transformador
        /// </summary>
        public string? CodSubestacion { get; set; }

        /// <summary>
        /// Para sistemas de generacion basados en inversores o aerogeneradores, indica si la funcion de proteccion esta en dichos elementos
        /// </summary>
        public bool? ProtAntiIslaFuncionProteccion { get; set; }

        /// <summary>
        /// Si ProtAntiIsla_FuncionProteccion es NO, como se garantiza la funcion de la proteccion AntiIsla (arreglo de protecciones)
        /// </summary>
        public string? ProtAntiIslaDescFuncionAntiIsla { get; set; }

        /// <summary>
        /// Indica si el cliente suministrara el medidor
        /// </summary>
        public bool ClienteSuministraMedidor { get; set; }

        /// <summary>
        /// Indica si el medidor tiene perfil horario
        /// </summary>
        public bool MedidorPerfilHorario { get; set; }

        /// <summary>
        /// Indica si el medidor es bidireccional
        /// </summary>
        public bool MedidorBidireccional { get; set; }

        /// <summary>
        /// Indica si la solicitud esta habilitada para editar los datos por el usuario
        /// </summary>
        public bool EsEditable { get; set; }

        /// <summary>
        /// Aclaraciones que desee realizar, el solicitante, sobre el proyecto
        /// </summary>
        public string? Observaciones { get; set; }

        /// <summary>
        /// Fecha en que se da la conformidad a una solicitud
        /// </summary>
        public DateTime? FechaConformidad { get; set; }

        /// <summary>
        /// Dias a tener en cuenta para validar que la solicitud pueda realizar prorroga
        /// </summary>
        public int? DiasValidacionProrroga { get; set; }

        /// <summary>
        /// Fecha limite para que se pueda realizar una prorroga a la solicitud
        /// </summary>
        public DateTime? FechaLimiteProrroga { get; set; }

        /// <summary>
        /// Columna calculada, indica si la solicitud es apta para poder solicitar prorroga
        /// </summary>
        public bool? AptoParaProrroga { get; set; }

        /// <summary>
        /// Dias que faltan para terminar el plazo para que se pueda realizar una prorroga a la solicitud
        /// </summary>
        public int? DiasFaltantesProrroga { get; set; }

        /// <summary>
        /// Indica si la solicitud tiene una prorroga
        /// </summary>
        public bool ProrrogaEnProceso { get; set; }

        /// <summary>
        /// Estado del flujo principal en el que estaba la solicitud cuando se creó la prórroga
        /// </summary>
        public int? EstadoAnteriorProrroga { get; set; }

        /// <summary>
        /// Estado actual de la solicitud de prorroga para los AGGE
        /// </summary>
        public int? UltimoEstadoProrroga { get; set; }

        /// <summary>
        /// Dias a tener en cuenta para validar que la solicitud pueda colocarse en Conexión
        /// </summary>
        public int? DiasValidacionConexion { get; set; }

        /// <summary>
        /// Fecha limite para que la solicitud se pueda colocar En Conexión
        /// </summary>
        public DateTime? FechaLimiteConexion { get; set; }

        /// <summary>
        /// Columna calculada, indica si la solicitud es apta para poder quedar En Conexion
        /// </summary>
        public bool? AptoParaConexion { get; set; }

        /// <summary>
        /// Dias que faltan para terminar el plazo para que se pueda colocar la solicitud En Conexión
        /// </summary>
        public int? DiasFaltantesConexion { get; set; }

        /// <summary>
        /// Indica si se envió el contrato de conexión al usuario cliente
        /// </summary>
        public bool? ContratoConexion { get; set; }

        /// <summary>
        /// Indica si el contrato de conexión se adjunto por el usuario cliente
        /// </summary>
        public bool? ContratoConexionFirmado { get; set; }

        /// <summary>
        /// Validación si esta aprobada o no la vigencia , para realizar la visita
        /// </summary>
        public bool AprobacionVigencia { get; set; }

        /// <summary>
        /// Indica si la solicitud es apta para solicitar desistimiento
        /// </summary>
        public bool AptoParaDesistimiento { get; set; }

        /// <summary>
        /// Indica si se aprobó el RETIE que se anexó
        /// </summary>
        public bool? DocumentacionRetieAprobada { get; set; }

        /// <summary>
        /// Indica si se anexó la documentación de la visita
        /// </summary>
        public bool DocumentacionVisitaEntregada { get; set; }

        /// <summary>
        /// Indica si el hallazgo fue grave (Procedimiento de Desconexión)
        /// </summary>
        public bool? UltimoHallazgoFueGrave { get; set; }

        /// <summary>
        /// Indica si el OR solicita desconexion voluntaria al cliente
        /// </summary>
        public bool? DesconexionVoluntaria { get; set; }

        /// <summary>
        /// Indica si el la solicitud supera la capacidad del trafo
        /// </summary>
        public bool? SuperaLimiteTransformador { get; set; }

        /// <summary>
        /// Indica si el usuario autoriza los gastos en la solicitud para superar la capacidad del trafo
        /// </summary>
        public bool? AutorizaGastosSuperaLimites { get; set; }

        /// <summary>
        /// Codigo maestro de Estados
        /// </summary>
        public int Estado { get; set; }

        /// <summary>
        /// Estado de la visita en flujo de desconexion
        /// </summary>
        public int? EstadoVisita { get; set; }

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

        public virtual Ciudad CodMunicipioClienteNavigation { get; set; } = null!;
        public virtual Departamento CodDepartamentoClienteNavigation { get; set; } = null!;
       
        public virtual ICollection<PasosSolConexionAutogen> PasosSolConexionAutogens { get; set; }
        public virtual ICollection<SolConexionAutogenAnexo> SolConexionAutogenAnexos { get; set; }
        //public virtual ICollection<SolConexionAutogenComentario> SolConexionAutogenComentarios { get; set; }
        public virtual ICollection<SolConexionAutogenObservacion> SolConexionAutogenObservacions { get; set; }
        public virtual ICollection<SolConexionAutogenTecnUtilizada> SolConexionAutogenTecnUtilizada { get; set; }        
        public virtual ICollection<SolConexionAutogenInsumo> SolConexionAutogenInsumos { get; set; }        
    }

    public partial class SolConexionAutogen
    {
        public bool? RequiereRETIE { get; set; }
        public string? MsgRequiereRETIE { get; set; }
        public bool? RequiereContrato { get; set; }
        public string? MsgRequiereContrato { get; set; }
        public bool ExcedeVisitaConexionRechazo { get; set; }
    }
}
