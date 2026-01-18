namespace Core.Services.SQLContext
{
    using Core.Entities.SQLContext;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;
    using Core.Interfaces.SQLContext;
    using Core.Options;
    using Microsoft.Extensions.Options;

    public class SolServicioConexionComentarioService
     : ISolServicioConexionComentarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PathOptions _pathOptions;
        private readonly ISolServicioConexionService _solServicioConexionService;

        private SolServicioConexionComentario _entity = null!;

        public SolServicioConexionComentarioService(
            IUnitOfWork unitOfWork,
            IOptions<PathOptions> pathOptions,
            ISolServicioConexionService solServicioConexionService)
        {
            _unitOfWork = unitOfWork;
            _pathOptions = pathOptions.Value;
            _solServicioConexionService = solServicioConexionService;
        }

        public async Task<List<SolServicioConexionComentario>> GetEntitiesByRequest(int idRequest)
        {
            return await _unitOfWork.SolServicioConexionComentarioRepository.GetEntitiesByRequest(idRequest);
        }
    }
}
