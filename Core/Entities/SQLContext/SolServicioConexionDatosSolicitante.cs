#nullable disable

namespace Core.Entities.SQLContext
{
    public partial class SolServicioConexionDatosSolicitante
    {
        /// <summary>
        /// Identificación del registro
        /// </summary>
        public int IdSolServicioConexionDatosSolicitantes { get; set; }
        /// <summary>
        /// ID de la solicitud servicio conexion
        /// </summary>
        public int CodSolServicioConexion { get; set; }
        /// <summary>
        /// Nombre del Solicitante o Suscriptor/Usuario
        /// </summary>
        public string Nombre { get; set; } = null!;
        /// <summary>
        /// ID del tipo de persona
        /// </summary>
        public int CodTipoPersona { get; set; }
        /// <summary>
        /// ID tipo de documento
        /// </summary>
        public int CodTipoDocumento { get; set; }
        /// <summary>
        /// Documento del Solicitante o Suscriptor/Usuario
        /// </summary>
        public string NumeroDocumento { get; set; } = null!;
        /// <summary>
        /// Dirección del Solicitante o Suscriptor/Usuario
        /// </summary>
        public string Direccion { get; set; } = null!;
        /// <summary>
        /// ID del municipio
        /// </summary>
        public string CodMunicipio { get; set; } = null!;
        /// <summary>
        /// ID del Departamento
        /// </summary>
        public string CodDepartamento { get; set; } = null!;
        /// <summary>
        /// Celular del Solicitante o Suscriptor/Usuario
        /// </summary>
        public decimal Celular { get; set; }
        /// <summary>
        /// Telefono del Solicitante o Suscriptor/Usuario
        /// </summary>
        public decimal? Telefono { get; set; }
        /// <summary>
        /// Email del Solicitante o Suscriptor/Usuario
        /// </summary>
        public string Email { get; set; } = null!;
        /// <summary>
        /// Se valida si el Solicitante o Suscriptor/Usuario autorizo las notificaciones al email
        /// </summary>
        public bool AutorizacionNotificacionEmail { get; set; }
        /// <summary>
        /// Validación para saber si el solicitante de la solicitud es el propietario del predio (1-si es propietario, 0-Si no lo es)
        /// </summary>
        public bool? EsSolicitantePropietario { get; set; }
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
        public virtual Departamento CodDepartamentoNavigation { get; set; } = null!;
        public virtual Ciudad CodMunicipioNavigation { get; set; } = null!;
    }
}
