namespace Infrastructure.Repositories
{
    using Core.CustomEntities;
    using Core.Enumerations;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;
    using Core.Interfaces.SQLContext;
    using Infrastructure.Data;
    using Infrastructure.Factories;
    using Infrastructure.Repositories.Oracle;
    using Infrastructure.Repositories.SQLContext;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;
    using System.Data;

    /// <summary>
    /// Clase encargada de guardar los cambios en la Base de Datos
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbSQLContext _context;
        private readonly DbOracleContext _eepContext;
        private readonly IDbConnection _dapperContext;
        private readonly IDictionary<string, DbConnectionFactoryModel> _connections;



        private readonly ICregCiudadRepository _cregCiudadRepository;


        #region SQLContext

        private readonly IEmpresasRepository _empresasRepository;
        private readonly IComercializadorRepository _comercializadorRepository;
        private readonly IDocumentosXformularioRepository _documentosXformularioRepository;
        private readonly IEstratoSocioeconomicoRepository _estratoSocioeconomicoRepository;
        private readonly IMotivoProrrogaRepository _motivoProrrogaRepository;
        private readonly ITipoActivoRepository _tipoActivoRepository;
        private readonly ITipoAerogeneradorRepository _tipoAerogeneradorRepository;
        private readonly ITipoClaseCargaRepository _tipoClaseCargaRepository;
        private readonly ITipoClienteRepository _tipoClienteRepository;
        private readonly ITipoCompletitudRepository _tipoCompletitudRepository;
        private readonly ITipoConexionRepository _tipoConexionRepository;
        private readonly ITipoConstruccionRepository _tipoConstruccionRepository;
        private readonly ITipoGeneracionRepository _tipoGeneracionRepository;
        private readonly ITipoIdentificacionRepository _tipoIdentificacionRepository;
        private readonly ITipoPersonaRepository _tipoPersonaRepository;
        private readonly ITipoProyectoRepository _tipoProyectoRepository;
        private readonly ITipoServicioRepository _tipoServicioRepository;
        private readonly ITipoTecnologiaRepository _tipoTecnologiaRepository;
        private readonly ITipoTensionRepository _tipoTensionRepository;
        private readonly ITipoTramiteVisitaRepository _tipoTramiteVisitaRepository;
        private readonly ITipoZonaRepository _tipoZonaRepository;
        private readonly IPasosSolConexionAutogenRepository _pasosSolConexionAutogenRepository;
        private readonly IPasosSolServicioConexionRepository _pasosSolServicioConexionRepository;
        private readonly ISolConexionAutogenRepository _solConexionAutogenRepository;
        //private readonly ISolConexionAutogenComentarioRepository _solConexionAutogenComentarioRepository;
        //private readonly ISolConexionAutogenXvisitaRepository _solConexionAutogenXvisitaRepository;
        
        private readonly ISolServicioConexionReciboTecnicoRepository _solServicioConexionReciboTecnicoRepository;
        private readonly ISolServicioConexionRepository _solServicioConexionRepository;
        private readonly ISolServicioConexionComentarioRepository _solServicioConexionComentarioRepository;
        private readonly IDepartamentoRepository _departamentoRepository;        
        

        private readonly ISolServicioConexionFactibilidadRepository _solServicioConexionFactibilidadRepository;        
        private readonly ISolServicioConexionDisenioRepository _solServicioConexionDisenioRepository;        
        private readonly IEstadoRepository _estadoRepository;            
        private readonly IActividadEconomicaRepository _actividadEconomicaRepository;        
        private readonly IClasificacionProyectoRepository _clasificacionProyectoRepository;        
        private readonly ISolServicioConexionReviewRepository _solServicioConexionReviewRepository;
        private readonly ISolConexionAutogenComentarioRepository _solConexionAutogenComentarioRepository;

        //private readonly ISolServicioConexionComentarioAnexoRepository _solServicioConexionComentarioAnexoRepository;
        #endregion

        public UnitOfWork(
            DbSQLContext context,
            DbOracleContext oracleContext,
            IDbConnection dapperContext,
            IDictionary<string, DbConnectionFactoryModel> conexiones
        )
        {
            _context = context;
            //_sgdContext = oracleContext;
            _eepContext = oracleContext;
            //_context.Database.SetCommandTimeout(86400);
            //_sgdContext.Database.SetCommandTimeout(86400);
            _eepContext.Database.SetCommandTimeout(86400);
            _dapperContext = dapperContext;
            _connections = conexiones;
        }
        
        public ICregCiudadRepository CregCiudadRepository => _cregCiudadRepository ?? new CregCiudadRepository(_eepContext,
               new DbConnectionFactorySingular(
                   _connections[EnumConnectionStrings.BaseDeDatoOracleEEP.ToString()]
               )
        );

        public IDepartamentoRepository DepartamentoRepository => _departamentoRepository ?? new DepartamentoRepository(_eepContext,
               new DbConnectionFactorySingular(
                   _connections[EnumConnectionStrings.BaseDeDatoOracleEEP.ToString()]
               )
        );



        #region SQLContext


        public IEstadoRepository EstadoRepository => _estadoRepository ?? new EstadoRepository(_context);       
        public IEmpresasRepository EmpresasRepository => _empresasRepository ?? new EmpresasRepository(_context);     

        public IActividadEconomicaRepository ActividadEconomicaRepository => _actividadEconomicaRepository ?? new ActividadEconomicaRepository(_context);
        public IClasificacionProyectoRepository ClasificacionProyectoRepository => _clasificacionProyectoRepository ?? new ClasificacionProyectoRepository(_context);
        public IComercializadorRepository ComercializadorRepository => _comercializadorRepository ?? new ComercializadorRepository(_context);
        public IDocumentosXformularioRepository DocumentosXformularioRepository => _documentosXformularioRepository ?? new DocumentosXformularioRepository(_context);
        public IEstratoSocioeconomicoRepository EstratoSocioeconomicoRepository => _estratoSocioeconomicoRepository ?? new EstratoSocioeconomicoRepository(_context);
        public IMotivoProrrogaRepository MotivoProrrogaRepository => _motivoProrrogaRepository ?? new MotivoProrrogaRepository(_context);
        public ITipoActivoRepository TipoActivoRepository => _tipoActivoRepository ?? new TipoActivoRepository(_context);
        public ITipoAerogeneradorRepository TipoAerogeneradorRepository => _tipoAerogeneradorRepository ?? new TipoAerogeneradorRepository(_context);
        public ITipoClaseCargaRepository TipoClaseCargaRepository => _tipoClaseCargaRepository ?? new TipoClaseCargaRepository(_context);
        public ITipoClienteRepository TipoClienteRepository => _tipoClienteRepository ?? new TipoClienteRepository(_context);
        public ITipoCompletitudRepository TipoCompletitudRepository => _tipoCompletitudRepository ?? new TipoCompletitudRepository(_context);
        public ITipoConexionRepository TipoConexionRepository => _tipoConexionRepository ?? new TipoConexionRepository(_context);
        public ITipoGeneracionRepository TipoGeneracionRepository => _tipoGeneracionRepository ?? new TipoGeneracionRepository(_context);
        public ITipoIdentificacionRepository TipoIdentificacionRepository => _tipoIdentificacionRepository ?? new TipoIdentificacionRepository(_context);
        public ITipoPersonaRepository TipoPersonaRepository => _tipoPersonaRepository ?? new TipoPersonaRepository(_context);
        public ITipoProyectoRepository TipoProyectoRepository => _tipoProyectoRepository ?? new TipoProyectoRepository(_context);
        public ITipoServicioRepository TipoServicioRepository => _tipoServicioRepository ?? new TipoServicioRepository(_context);
        //public ITipoSolicitudReciboRepository TipoSolicitudReciboRepository => _tipoSolicitudReciboRepository ?? new TipoSolicitudReciboRepository(_context);
        //public ITipoSolicitudServicioRepository TipoSolicitudServicioRepository => _tipoSolicitudServicioRepository ?? new TipoSolicitudServicioRepository(_context);
        public ITipoTecnologiaRepository TipoTecnologiaRepository => _tipoTecnologiaRepository ?? new TipoTecnologiaRepository(_context);
        public ITipoTensionRepository TipoTensionRepository => _tipoTensionRepository ?? new TipoTensionRepository(_context);
        public ITipoTramiteVisitaRepository TipoTramiteVisitaRepository => _tipoTramiteVisitaRepository ?? new TipoTramiteVisitaRepository(_context);
        public ITipoZonaRepository TipoZonaRepository => _tipoZonaRepository ?? new TipoZonaRepository(_context);
        public IPasosSolConexionAutogenRepository PasosSolConexionAutogenRepository => _pasosSolConexionAutogenRepository ?? new PasosSolConexionAutogenRepository(_context);
        public IPasosSolServicioConexionRepository PasosSolServicioConexionRepository => _pasosSolServicioConexionRepository ?? new PasosSolServicioConexionRepository(_context);
        public ISolConexionAutogenRepository SolConexionAutogenRepository => _solConexionAutogenRepository ?? new SolConexionAutogenRepository(_context, _dapperContext);
        //public ISolConexionAutogenComentarioRepository SolConexionAutogenComentarioRepository => _solConexionAutogenComentarioRepository ?? new SolConexionAutogenComentarioRepository(_context, _dapperContext, _paginacionService);
        
        //public ISolConexionAutogenXvisitaRepository SolConexionAutogenXvisitaRepository => _solConexionAutogenXvisitaRepository ?? new SolConexionAutogenXvisitaRepository(_context);
        public ISolServicioConexionReciboTecnicoRepository SolServicioConexionReciboTecnicoRepository => _solServicioConexionReciboTecnicoRepository ?? new SolServicioConexionReciboTecnicoRepository(_context);
        public ISolServicioConexionRepository SolServicioConexionRepository => _solServicioConexionRepository ?? new SolServicioConexionRepository(_context, _dapperContext);
        public ISolServicioConexionComentarioRepository SolServicioConexionComentarioRepository => _solServicioConexionComentarioRepository ?? new SolServicioConexionComentarioRepository(_context, _dapperContext);
        
        public ITipoConstruccionRepository TipoConstruccionRepository => _tipoConstruccionRepository ?? new TipoConstruccionRepository(_context, _dapperContext);        
        public ISolServicioConexionFactibilidadRepository SolServicioConexionFactibilidadRepository => _solServicioConexionFactibilidadRepository ?? new SolServicioConexionFactibilidadRepository(_context);        
        public ISolServicioConexionDisenioRepository SolServicioConexionDisenioRepository => _solServicioConexionDisenioRepository ?? new SolServicioConexionDisenioRepository(_context);
        public ISolServicioConexionReviewRepository SolServicioConexionReviewRepository => _solServicioConexionReviewRepository ?? new SolServicioConexionReviewRepository(_context);
        public ISolConexionAutogenComentarioRepository SolConexionAutogenComentarioRepository => _solConexionAutogenComentarioRepository ?? new SolConexionAutogenComentarioRepository(_context, _dapperContext);


        #endregion

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_context.Database.CurrentTransaction == null)
            {
                // Si no hay una transacción actual, comenzamos una nueva
                return await _context.Database.BeginTransactionAsync();
            }
            else
            {
                // Si ya hay una transacción en curso, la devolvemos para su reutilización
                return null;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
