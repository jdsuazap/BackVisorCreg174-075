#nullable disable
namespace Core.Entities.SQLContext
{
    public partial class Departamento : StringBaseEntity
    {
        public Departamento()
        {
            Ciudads = new HashSet<Ciudad>();
            SolConexionAutogens = new HashSet<SolConexionAutogen>();
            SolServicioConexionDatosSolicitantes = new HashSet<SolServicioConexionDatosSolicitante>();
            SolServicioConexionDatosSuscriptors = new HashSet<SolServicioConexionDatosSuscriptor>();
        }

        /// <summary>
        /// Codigo del DANE
        /// </summary>
        public string CodigoDane { get; set; } = null!;
        /// <summary>
        /// Nombre del departamento
        /// </summary>
        public string NombreDepartamento { get; set; } = null!;
        /// <summary>
        /// Abreviatura del departamento
        /// </summary>
        public string Abreviatura { get; set; } = null!;
        /// <summary>
        /// Estado del registro (Activo/Inactivo)
        /// </summary>
        public bool? Estado { get; set; }
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

        public virtual ICollection<Ciudad> Ciudads { get; set; }
        public virtual ICollection<SolConexionAutogen> SolConexionAutogens { get; set; }
        public virtual ICollection<SolServicioConexionDatosSolicitante> SolServicioConexionDatosSolicitantes { get; set; }
        public virtual ICollection<SolServicioConexionDatosSuscriptor> SolServicioConexionDatosSuscriptors { get; set; }
    }
}
