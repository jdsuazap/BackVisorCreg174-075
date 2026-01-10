#nullable disable

namespace Core.Entities.SQLContext
{
    public partial class SolServicioConexion : BaseEntity
    {
        public SolServicioConexion()
        {
            PasosSolServicioConexions = new HashSet<PasosSolServicioConexion>();
            //SolServicioConexionAnexos = new HashSet<SolServicioConexionAnexo>();
            SolServicioConexionDetalleCuenta = new HashSet<SolServicioConexionDetalleCuenta>();
            //SolRevisionEstudios = new HashSet<SolRevisionEstudio>();
            SolServicioConexionDisenio = new HashSet<SolServicioConexionDisenio>();
            SolServicioConexionReciboTecnicos = new HashSet<SolServicioConexionReciboTecnico>();
            Etapa = 1;
            PuedeRealizarFactibilidad = false;

        }

        /// <summary>
        /// Codigo maestro de usuario (cliente)
        /// </summary>
        public int CodUsuario { get; set; }

        /// <summary>
        /// Codigo de la empresa por donde se realizo la solicitud 1-> Pereira, 2 -> Cartago
        /// </summary>
        public int? Empresa { get; set; }

        /// <summary>
        /// Número del radicado generado para la solicitud
        /// </summary>
        public string NumeroRadicado { get; set; } = null!;
        /// <summary>
        /// Fecha en la que se realizó la solicitud
        /// </summary>
        public DateTime FechaSolicitud { get; set; }
        /// <summary>
        /// Id del tipo de conexión asociados a esta solicitud
        /// </summary>
        public int CodTipoConexion { get; set; }
        /// <summary>
        /// Id del tipo de uso
        /// </summary>
        public int CodTipoUso { get; set; }
        /// <summary>
        /// Nombre del tipo de uso si el último selecciono la opción de tipo de uso &quot;Otro&quot;
        /// </summary>
        public string? OtroTipoUso { get; set; }
        /// <summary>
        /// ID del Estrato socioeconómico
        /// </summary>
        public int? CodEstrato { get; set; }
        /// <summary>
        /// ID Actividad económica industrial CIIU
        /// </summary>
        public int? CodActividadEconomica { get; set; }
        /// <summary>
        /// ¿Hay red eléctrica cercana al predio? (0-no, 1-sí)
        /// </summary >
        public bool ExisteRedCercana { get; set; }
        /// <summary>
        /// Distancia actual del predio a la red más cercana
        /// </summary>
        public string DistanciaRedCercana { get; set; } = null!;
        /// <summary>
        /// Número de transformador de la red eléctrica más cercano
        /// </summary>
        public string Transformador { get; set; } = null!;
        /// <summary>
        /// Número de poste de la red eléctrica más cercano
        /// </summary>
        public string Nodo { get; set; } = null!;
        /// <summary>
        /// Circuito de la red eléctrica más cercano
        /// </summary>
        public string Circuito { get; set; } = null!;
        /// <summary>
        /// Observaciones del solicitante
        /// </summary>
        public string? ObservacionesSolicitante { get; set; }
        /// <summary>
        /// Estado actual de la solicitud
        /// </summary>
        public int CodEstado { get; set; }
        /// <summary>
        /// Cedula del último que crea el registro
        /// </summary>
        public string CodUser { get; set; } = null!;
        /// <summary>
        /// Fecha de creación del registro.
        /// </summary>
        public DateTime FechaRegistro { get; set; }
        /// <summary>
        /// Cedula del último último que actualizó el registro
        /// </summary>
        public string CodUserUpdate { get; set; } = null!;
        /// <summary>
        /// Fecha de la última actualización del registro.
        /// </summary>
        public DateTime FechaRegistroUpdate { get; set; }
        /// <summary>
        /// En este campo almacenamos la dirección ip, navegador y versión del navegador del cliente.
        /// </summary>
        public string Info { get; set; } = null!;
        /// <summary>
        /// En este campo almacenamos la última dirección ip, navegador y versión del navegador del cliente.
        /// </summary>
        public string InfoUpdate { get; set; } = null!;
        /// <summary>
        /// En este campo se confirma si la documentacion esta completa o no.
        /// </summary>
        public bool SeguimientoDocumentacionCompleta { get; set; }
        /// <summary>
        /// En este campo se confirma si la documentacion esta conforme o no.
        /// </summary>
        public bool SeguimientoObraConforme { get; set; }
        /// <summary>
        /// En este campo se confirma si la documentacion esta completa o no.
        /// </summary>
        public bool ReciboTecnicoDocumentacionCompleta { get; set; }
        /// <summary>
        /// En este campo se confirma si la documentacion esta conforme o no.
        /// </summary>
        public bool NormalizacionVisitaConforme { get; set; }

        public bool PuedeActualizarFactibilidadPerfilApoyo { get; set; }
        /// <summary>
        /// En este campo se confirma si la documentacion requeire otra etapa o no.
        /// </summary>
        public bool NormalizacionOtraEtapa { get; set; }

        public bool AnulacionHabilitada { get; set; }
        public bool DesistirSolicitudHabilitado { get; set; }
        public bool PuedeRealizarFactibilidad { get; set; }

        public int Etapa { get; set; }
      
        public virtual SolServicioConexionDatosSolicitante? SolServicioConexionDatosSolicitante { get; set; }
        public virtual SolServicioConexionDatosSuscriptor? SolServicioConexionDatosSuscriptor { get; set; }
        public virtual SolServicioConexionDetalle? SolServicioConexionDetalle { get; set; }
        public virtual SolServicioConexionPredio? SolServicioConexionPredio { get; set; }
        public virtual ICollection<SolServicioConexionDetalleCuenta> SolServicioConexionDetalleCuenta { get; set; }
        public virtual ICollection<PasosSolServicioConexion> PasosSolServicioConexions { get; set; }
        public virtual ICollection<SolServicioConexionFactibilidad> SolServicioConexionFactibilidades { get; set; } = new List<SolServicioConexionFactibilidad>();
        public virtual ICollection<SolServicioConexionDisenio> SolServicioConexionDisenio { get; set; }     
        public virtual ICollection<SolServicioConexionReciboTecnico> SolServicioConexionReciboTecnicos { get; set; }
    }
}
