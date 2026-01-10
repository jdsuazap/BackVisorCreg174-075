using Core.CustomEntities.SQLContext;
using Core.Entities.SQLContext;
using Core.ModelResponse;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public partial class DbSQLContext : DbContext
    {
        public DbSQLContext()
        {
        }

        public DbSQLContext(DbContextOptions<DbSQLContext> options)
            : base(options)
        {
        }

        #region Propiedades Contexto
        public DbSet<ResponseInt> ResponseInts { get; set; }
        public virtual DbSet<ResponseAction> ResponseActions { get; set; }
        public virtual DbSet<ResponseActionUrl> ResponseActionUrls { get; set; }
        public virtual DbSet<ResponseJsonString> ResponseJsonStrings { get; set; }
        #endregion

        #region Propiedades Contexto Entities
        
        public virtual DbSet<Empresa> Empresas { get; set; }       
        public virtual DbSet<Comentario> Comentarios { get; set; }
        public virtual DbSet<ComentarioAdjunto> ComentarioAdjuntos { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<TipoEstado> TipoEstados { get; set; } = null!;
        public virtual DbSet<TipoAccion> TipoAccions { get; set; } = null!;
        public virtual DbSet<TipoEtapa> TipoEtapas { get; set; } = null!;
        #endregion

        #region Propiedades Logica de Negocio
        public virtual DbSet<ActividadEconomica> ActividadEconomicas { get; set; }
        public virtual DbSet<ClasificacionProyecto> ClasificacionProyectos { get; set; }
        public virtual DbSet<Comercializador> Comercializadors { get; set; }
        public virtual DbSet<DocumentosXformulario> DocumentosXformularios { get; set; }
        public virtual DbSet<EstratoSocioeconomico> EstratoSocioeconomicos { get; set; }
        public virtual DbSet<MotivoProrroga> MotivoProrrogas { get; set; }
        public virtual DbSet<PasosSolConexionAutogen> PasosSolConexionAutogens { get; set; }
        public virtual DbSet<PasosSolServicioConexion> PasosSolServicioConexions { get; set; }
        public virtual DbSet<SolConexionAutogen> SolConexionAutogens { get; set; }
        public virtual DbSet<SolConexionAutogenComentario> SolConexionAutogenComentarios { get; set; } = null!;
        public virtual DbSet<SolConexionAutogenAnexo> SolConexionAutogenAnexos { get; set; }
        public virtual DbSet<SolConexionAutogenBasadaInv> SolConexionAutogenBasadaInvs { get; set; }
        public virtual DbSet<SolConexionAutogenInfoEolica> SolConexionAutogenInfoEolicas { get; set; }
        public virtual DbSet<SolConexionAutogenInmueble> SolConexionAutogenInmuebles { get; set; }
        public virtual DbSet<SolConexionAutogenNoBasadaInv> SolConexionAutogenNoBasadaInvs { get; set; }
        public virtual DbSet<SolConexionAutogenObservacion> SolConexionAutogenObservacions { get; set; } = null!;
        public virtual DbSet<SolConexionAutogenTecnUtilizada> SolConexionAutogenTecnUtilizadas { get; set; }
        public virtual DbSet<SolConexionAutogenTecnologia> SolConexionAutogenTecnologias { get; set; }
        
        //public virtual DbSet<SolConexionAutogenXvisita> SolConexionAutogenXvisita { get; set; }
        public virtual DbSet<SolConexionAutogenInsumo> SolConexionAutogenInsumos { get; set; } = null!;
        public virtual DbSet<SolServicioConexion> SolServicioConexions { get; set; }
        public virtual DbSet<SolServicioConexionAnexo> SolServicioConexionAnexos { get; set; }
        public virtual DbSet<SolServicioConexionDatosSolicitante> SolServicioConexionDatosSolicitantes { get; set; } = null!;
        public virtual DbSet<SolServicioConexionDatosSuscriptor> SolServicioConexionDatosSuscriptors { get; set; } = null!;
        public virtual DbSet<SolServicioConexionDetalle> SolServicioConexionDetalles { get; set; } = null!;
        public virtual DbSet<SolServicioConexionDetalleCuenta> SolServicioConexionDetalleCuentas { get; set; } = null!;
        public virtual DbSet<SolServicioConexionPredio> SolServicioConexionPredios { get; set; } = null!;        
        public virtual DbSet<SolServicioConexionReciboTecnico> SolServicioConexionReciboTecnicos { get; set; } = null!;
      
        public virtual DbSet<TipoActivo> TipoActivos { get; set; }
        public virtual DbSet<TipoAerogenerador> TipoAerogeneradors { get; set; }
        public virtual DbSet<TipoClaseCarga> TipoClaseCargas { get; set; }
        public virtual DbSet<TipoCliente> TipoClientes { get; set; }
        public virtual DbSet<TipoCompletitud> TipoCompletituds { get; set; }
        public virtual DbSet<TipoConexion> TipoConexions { get; set; }
        public virtual DbSet<TipoConstruccion> TipoConstruccions { get; set; } = null!;
        public virtual DbSet<TipoGeneracion> TipoGeneracions { get; set; }
        public virtual DbSet<TipoIdentificacion> TipoIdentificacions { get; set; }
        public virtual DbSet<TipoPersona> TipoPersonas { get; set; }
        public virtual DbSet<TipoProyecto> TipoProyectos { get; set; }
        public virtual DbSet<TipoServicio> TipoServicios { get; set; }
        public virtual DbSet<TipoSolicitudRecibo> TipoSolicitudRecibos { get; set; }
        public virtual DbSet<TipoSolicitudServicio> TipoSolicitudServicios { get; set; }
        public virtual DbSet<TipoTecnologia> TipoTecnologia { get; set; }
        public virtual DbSet<TipoTension> TipoTensions { get; set; }
        public virtual DbSet<TipoTramiteVisita> TipoTramiteVisita { get; set; }
        public virtual DbSet<TipoZona> TipoZonas { get; set; }
        public virtual DbSet<Ciudad> Ciudads { get; set; }
        public virtual DbSet<Departamento> Departamentos { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.ApplyAllConfigurations();

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
