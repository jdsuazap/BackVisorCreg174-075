#nullable disable
namespace Core.Entities.SQLContext
{
    public partial class Estado : BaseEntity
    {
        public Estado()
        {
            PasosSolConexionAutogens = new HashSet<PasosSolConexionAutogen>();
            PasosSolServicioConexions = new HashSet<PasosSolServicioConexion>();
            SolConexionAutogens = new HashSet<SolConexionAutogen>();
            SolConexionAutogenComentarios = new HashSet<SolConexionAutogenComentario>();
            SolServicioConexions = new HashSet<SolServicioConexion>();
            //Usuarios = new HashSet<Usuario>();
        }

        /// <summary>
        /// Indica el tipo de estado al q pertenece, pueden ser proveedores, requerimientos, noticias, ordenes, contratos, entre otros
        /// </summary>
        public int CodTipoEstado { get; set; }
        /// <summary>
        /// Descripción del estado
        /// </summary>
        public string ParDescripcion { get; set; } = null!;
        /// <summary>
        /// Id de la etapa asociada
        /// </summary>
        public int? CodEtapa { get; set; }

        /// <summary>
        /// Codigo Homologación SUI
        /// </summary>
        public int? Homologacion { get; set; }
        /// <summary>
        /// Estado en q se encuentra el estado, activo - inactivo
        /// </summary>
        public bool? ParvEstado { get; set; }
        public string CodUser { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string CodUserUpdate { get; set; }
        public DateTime FechaRegistroUpdate { get; set; }
        public string Info { get; set; }
        public string InfoUpdate { get; set; }

        public virtual TipoEstado CodTipoEstadoNavigation { get; set; }
        public virtual ICollection<PasosSolConexionAutogen> PasosSolConexionAutogens { get; set; }
        public virtual ICollection<PasosSolServicioConexion> PasosSolServicioConexions { get; set; }
        public virtual ICollection<SolConexionAutogen> SolConexionAutogens { get; set; }
        public virtual ICollection<SolConexionAutogenComentario> SolConexionAutogenComentarios { get; set; }
        public virtual ICollection<SolServicioConexion> SolServicioConexions { get; set; }
        public virtual ICollection<SolServicioConexionComentario> SolServicioConexionComentarios { get; set; }
        public virtual ICollection<SolConexionAutogen> SolConexionAutogenEstadoAnteriorProrrogaNavigations { get; set; }
        public virtual ICollection<SolConexionAutogen> SolConexionAutogenUltimoEstadoProrrogaNavigations { get; set; }
        public virtual ICollection<SolConexionAutogen> SolConexionAutogenEstadoVisitaNavigations { get; set; }
        //public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
