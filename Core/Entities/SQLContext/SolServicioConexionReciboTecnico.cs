// Asegúrate de ajustar el espacio de nombres y las referencias según tu proyecto
using System;

namespace Core.Entities.SQLContext
{
    public class SolServicioConexionReciboTecnico : GenericBaseEntity<long>
    {
        public SolServicioConexionReciboTecnico()
        {
            Etapa = 1;
            //SolServicioConexionTipoProyectoPorReciboTecnicos = new HashSet<SolServicioConexionTipoProyectoPorReciboTecnico>();
        }

        /// <summary>
        /// ID asociado a la solicitud del servicio de conexión
        /// </summary>
        public int CodSolServicioConexion { get; set; }
        /// <summary>
        /// Fecha de la solicitud
        /// </summary>
        public DateTime FechaSolicitud { get; set; }
        public int CodTipoSolicitud { get; set; }
        /// <summary>
        /// Nombre del proyecto
        /// </summary>
        public string NombreProyecto { get; set; } = null!;
        public string OficinaRadicacion { get; set; } = null!;
        /// <summary>
        /// Dirección de la obra
        /// </summary>
        public string Direccion { get; set; } = null!;
        /// <summary>
        /// Comercializador de la obra
        /// </summary>
        public string Comercializador { get; set; } = null!;
        /// <summary>
        /// Número de matrícula inmobiliaria
        /// </summary>
        public string NumeroMatricula { get; set; } = null!;
        /// <summary>
        /// No Cliente activo para cargar cobro de medidores
        /// </summary>
        public string? ClienteCargoCobroMedidores { get; set; }
        /// <summary>
        /// ID Persona autorización recibo
        /// </summary>
        public int CodPersonaAutorizacion { get; set; }
        /// <summary>
        /// ID Tipo Completitud
        /// </summary>
        public int CodTipoCompletitud { get; set; }
        /// <summary>
        /// Etapa del proyecto
        /// </summary>
        public int? EtapaProyecto { get; set; }
        public int Etapa { get; set; }
        /// <summary>
        /// Nombre Constructora
        /// </summary>
        public string NombreConstructora { get; set; } = null!;
        /// <summary>
        /// Nit de la constructora
        /// </summary>
        public string NitConstructora { get; set; } = null!;
        /// <summary>
        /// Nombre del ingeniero
        /// </summary>
        public string NombreIngeniero { get; set; } = null!;
        /// <summary>
        /// Firma Ingeniero
        /// </summary>
        public string FirmaIngeniero { get; set; } = null!;
        /// <summary>
        /// Matricula Profesional del Ingeniero
        /// </summary>
        public string MatriculaProfesional { get; set; } = null!;
        public string TelefonoIngeniero { get; set; } = null!;
        /// <summary>
        /// Email del ingeniero
        /// </summary>
        public string EmailIngeniero { get; set; } = null!;
        public string CedulaIngeniero { get; set; } = null!;
        /// <summary>
        /// Nombre del Propietario
        /// </summary>
        public string NombrePropietario { get; set; } = null!;
        /// <summary>
        /// Firma del Propietario
        /// </summary>
        public string FirmaPropietario { get; set; } = null!;
        /// <summary>
        /// Teléfono del Propietario
        /// </summary>
        public string TelefonoPropietario { get; set; } = null!;
        /// <summary>
        /// Email del Propietario
        /// </summary>
        public string EmailPropietario { get; set; } = null!;
        public string CedulaPropietario { get; set; } = null!;
        /// <summary>
        /// Observaciones de la solicitud recibo tecnico
        /// </summary>
        public string? Observaciones { get; set; }

        public virtual TipoCompletitud CodTipoCompletitudNavigation { get; set; }
        public virtual TipoSolicitudRecibo CodTipoSolicitudNavigation { get; set; }
        public SolServicioConexion CodSolServicioConexionNavigation { get; set; }
        //public virtual ICollection<SolServicioConexionTipoProyectoPorReciboTecnico> SolServicioConexionTipoProyectoPorReciboTecnicos { get; set; }

    }
}
