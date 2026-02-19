namespace Core.Interfaces
{
    using Core.Interfaces.Oracle;
    using Microsoft.EntityFrameworkCore.Storage;

    /// <summary>
    /// Interfaz encargada de indicar los atributos y métodos que la unidad de trabajo debe implementar
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        ICregCiudadRepository CregCiudadRepository { get; }
        IDepartamentoRepository DepartamentoRepository { get; }
        ITipoGeneracionRepository TipoGeneracionRepository { get; }
        IClasificacionProyectoRepository ClasificacionProyectoRepository { get; }
        ITipoClienteRepository TipoClienteRepository { get; }
        ITipoSolicitudServicioRepository TipoSolicitudServicioRepository { get; }
        ITipoSolicitudReciboRepository TipoSolicitudReciboRepository { get; }
        IPersonaAutorizaReciboRepository PersonaAutorizaReciboRepository { get; }
        ICreg_TransformadorRepository Creg_transformadorRepository { get; }
      
        IComercializadorRepository ComercializadorRepository { get; }
        IEmpresasRepository EmpresasRepository { get; }
        IDocumentosXformularioRepository DocumentosXformularioRepository { get; }
        IEstratoSocioeconomicoRepository EstratoSocioeconomicoRepository { get; }
        ITipoAerogeneradorRepository TipoAerogeneradorRepository { get; }
        ITipoClaseCargaRepository TipoClaseCargaRepository { get; }        
        ITipoCompletitudRepository TipoCompletitudRepository { get; }
        ITipoConexionRepository TipoConexionRepository { get; }
        ITipoConstruccionRepository TipoConstruccionRepository { get; }        
        ITipoIdentificacionRepository TipoIdentificacionRepository { get; }
        ITipoPersonaRepository TipoPersonaRepository { get; }
        ITipoProyectoRepository TipoProyectoRepository { get; }
        ITipoServicioRepository TipoServicioRepository { get; }
        ITipoTecnologiaRepository TipoTecnologiaRepository { get; }
        ITipoTensionRepository TipoTensionRepository { get; }
        ITipoTramiteVisitaRepository TipoTramiteVisitaRepository { get; }
        ITipoZonaRepository TipoZonaRepository { get; }
        IPasosSolConexionAutogenRepository PasosSolConexionAutogenRepository { get; }
        IEstadoRepository EstadoRepository { get; }
        IActividadEconomicaRepository ActividadEconomicaRepository { get; }
        ISolConexionAutogenRepository SolConexionAutogenRepository { get; }
        ISolServicioConexionRepository SolServicioConexionRepository { get; }
        ISolServicioConexionFactibilidadRepository SolServicioConexionFactibilidadRepository { get; }

        ISolServicioConexionDisenioRepository SolServicioConexionDisenioRepository { get; }
        ISolServicioConexionReciboTecnicoRepository SolServicioConexionReciboTecnicoRepository { get; }

        //IPasosSolServicioConexionRepository PasosSolServicioConexionRepository { get; }
        //ITipoActivoRepository TipoActivoRepository { get; }
        //ISolConexionAutogenComentarioRepository SolConexionAutogenComentarioRepository { get; }
        //ISolConexionAutogenXvisitaRepository SolConexionAutogenXvisitaRepository { get; }
        //ISolServicioConexionComentarioRepository SolServicioConexionComentarioRepository { get; }
        //ISolServicioConexionReviewRepository SolServicioConexionReviewRepository { get; }
        //ISolConexionAutogenComentarioRepository SolConexionAutogenComentarioRepository { get; }
        //ISolServicioConexionComentarioAnexoRepository SolServicioConexionComentarioAnexoRepository { get; }

        //Task<IDbContextTransaction> BeginTransactionAsync();
        //void SaveChanges();
        //Task SaveChangesAsync();
    }
}
