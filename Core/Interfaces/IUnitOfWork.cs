namespace Core.Interfaces
{
    using Core.Interfaces.Oracle;
    using Core.Interfaces.SQLContext;
    using Microsoft.EntityFrameworkCore.Storage;

    /// <summary>
    /// Interfaz encargada de indicar los atributos y métodos que la unidad de trabajo debe implementar
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {

        ICregCiudadRepository CregCiudadRepository { get; }
        ITipoSolicitudServicioRepository TipoSolicitudServicioRepository { get; }
        ITipoSolicitudReciboRepository TipoSolicitudReciboRepository { get; }
        #region SQLContext       

        IComercializadorRepository ComercializadorRepository { get; }
        IEmpresasRepository EmpresasRepository { get; }
        IDocumentosXformularioRepository DocumentosXformularioRepository { get; }
        IEstratoSocioeconomicoRepository EstratoSocioeconomicoRepository { get; }
        IMotivoProrrogaRepository MotivoProrrogaRepository { get; }
        ITipoActivoRepository TipoActivoRepository { get; }
        ITipoAerogeneradorRepository TipoAerogeneradorRepository { get; }
        ITipoClaseCargaRepository TipoClaseCargaRepository { get; }
        ITipoClienteRepository TipoClienteRepository { get; }
        ITipoCompletitudRepository TipoCompletitudRepository { get; }
        ITipoConexionRepository TipoConexionRepository { get; }
        ITipoConstruccionRepository TipoConstruccionRepository { get; }
        ITipoGeneracionRepository TipoGeneracionRepository { get; }
        ITipoIdentificacionRepository TipoIdentificacionRepository { get; }
        ITipoPersonaRepository TipoPersonaRepository { get; }
        ITipoProyectoRepository TipoProyectoRepository { get; }
        ITipoServicioRepository TipoServicioRepository { get; }
        ITipoTecnologiaRepository TipoTecnologiaRepository { get; }
        ITipoTensionRepository TipoTensionRepository { get; }
        ITipoTramiteVisitaRepository TipoTramiteVisitaRepository { get; }
        ITipoZonaRepository TipoZonaRepository { get; }
        IPasosSolConexionAutogenRepository PasosSolConexionAutogenRepository { get; }
        IPasosSolServicioConexionRepository PasosSolServicioConexionRepository { get; }
        ISolConexionAutogenRepository SolConexionAutogenRepository { get; }
        //ISolConexionAutogenComentarioRepository SolConexionAutogenComentarioRepository { get; }
        //ISolConexionAutogenXvisitaRepository SolConexionAutogenXvisitaRepository { get; }

        ISolServicioConexionReciboTecnicoRepository SolServicioConexionReciboTecnicoRepository { get; }
        ISolServicioConexionRepository SolServicioConexionRepository { get; }
        ISolServicioConexionComentarioRepository SolServicioConexionComentarioRepository { get; }
        
        IDepartamentoRepository DepartamentoRepository { get; }

        ISolServicioConexionFactibilidadRepository SolServicioConexionFactibilidadRepository { get; }
        ISolServicioConexionDisenioRepository SolServicioConexionDisenioRepository { get; }
        IEstadoRepository EstadoRepository { get; }
        IActividadEconomicaRepository ActividadEconomicaRepository { get; }
        IClasificacionProyectoRepository ClasificacionProyectoRepository { get; }
        ISolServicioConexionReviewRepository SolServicioConexionReviewRepository { get; }
        ISolConexionAutogenComentarioRepository SolConexionAutogenComentarioRepository { get; }

        //ISolServicioConexionComentarioAnexoRepository SolServicioConexionComentarioAnexoRepository { get; }


        #endregion

        Task<IDbContextTransaction> BeginTransactionAsync();
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
