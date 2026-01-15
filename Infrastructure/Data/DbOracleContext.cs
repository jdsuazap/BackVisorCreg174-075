namespace Infrastructure.Data
{
    using Core.Entities.Oracle;
    using Infrastructure.Extensions;
    using Microsoft.EntityFrameworkCore;

    public class DbOracleContext : DbContext
    {
        public DbOracleContext()
        {
        }

        public DbOracleContext(DbContextOptions<DbOracleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Creg174Anexo> Creg174Anexos { get; set; } = null!;
        public virtual DbSet<Creg174Autogen> Creg174Autogens { get; set; } = null!;
        public virtual DbSet<Creg174BasInv> Creg174BasInvs { get; set; } = null!;
        public virtual DbSet<Creg174Infoeolica> Creg174Infoeolicas { get; set; } = null!;
        public virtual DbSet<Creg174Inmueble> Creg174Inmuebles { get; set; } = null!;
        public virtual DbSet<Creg174NoBasInv> Creg174NoBasInvs { get; set; } = null!;
        public virtual DbSet<Creg174TecnUtilizada> Creg174TecnUtilizadas { get; set; } = null!;
        public virtual DbSet<Creg174Tecnologia> Creg174Tecnologias { get; set; } = null!;
        public virtual DbSet<CregCiudad> CregCiudads { get; set; } = null!;
        public virtual DbSet<CregClasificacionProyecto> CregClasificacionProyectos { get; set; } = null!;
        public virtual DbSet<CregComercializador> CregComercializadors { get; set; } = null!;
        public virtual DbSet<CregDepartamento> CregDepartamentos { get; set; } = null!;
        public virtual DbSet<CregEmpresa> CregEmpresas { get; set; } = null!;
        public virtual DbSet<CregEstado> CregEstados { get; set; } = null!;
        public virtual DbSet<CregEstratoSocioeconomico> CregEstratoSocioeconomicos { get; set; } = null!;
        public virtual DbSet<CregEtapa> CregEtapas { get; set; } = null!;
        public virtual DbSet<CregTipoAerogenerador> CregTipoAerogeneradors { get; set; } = null!;
        public virtual DbSet<CregTipoClaseCarga> CregTipoClaseCargas { get; set; } = null!;
        public virtual DbSet<CregTipoCliente> CregTipoClientes { get; set; } = null!;
        public virtual DbSet<CregTipoCompletitud> CregTipoCompletituds { get; set; } = null!;
        public virtual DbSet<CregTipoConexion> CregTipoConexions { get; set; } = null!;
        public virtual DbSet<CregTipoConstruccion> CregTipoConstruccions { get; set; } = null!;
        public virtual DbSet<CregTipoGeneracion> CregTipoGeneracions { get; set; } = null!;
        public virtual DbSet<CregTipoIdentificacion> CregTipoIdentificacions { get; set; } = null!;
        public virtual DbSet<CregTipoPersona> CregTipoPersonas { get; set; } = null!;
        public virtual DbSet<CregTipoProcedConexion> CregTipoProcedConexions { get; set; } = null!;
        public virtual DbSet<CregTipoProyecto> CregTipoProyectos { get; set; } = null!;
        public virtual DbSet<CregTipoServicio> CregTipoServicios { get; set; } = null!;
        public virtual DbSet<CregTipoSolicitudRecibo> CregTipoSolicitudRecibos { get; set; } = null!;
        public virtual DbSet<CregTipoSolicitudServicio> CregTipoSolicitudServicios { get; set; } = null!;
        public virtual DbSet<CregTipoTecnologia> CregTipoTecnologia { get; set; } = null!;
        public virtual DbSet<CregTipoTension> CregTipoTensions { get; set; } = null!;
        public virtual DbSet<CregTipoTramiteVisita> CregTipoTramiteVisita { get; set; } = null!;
        public virtual DbSet<CregTipoZona> CregTipoZonas { get; set; } = null!;
        public virtual DbSet<CregActividadEconomica> CregActividadEconomicas { get; set; } = null!;
        public virtual DbSet<CregDocumentosFormulario> CregDocumentosFormulario { get; set; } = null!;
        public virtual DbSet<CregPersonaAutoriza> CregPersonaAutorizas { get; set; } = null!;
        public virtual DbSet<Creg174Pasos> Creg174Pasos { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("CONS_INFO_CREG");
            modelBuilder.ApplyAllConfigurations();
        }
    }
}

