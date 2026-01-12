namespace Core.Services.SQLContext
{
    using Core.Entities.SQLContext;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;
    using Core.Interfaces.SQLContext;
    using Core.Options;
    using Microsoft.Extensions.Options;

    public class SolConexionAutogenComentarioService
    : ISolConexionAutogenComentarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PathOptions _pathOptions;
        private readonly ISolConexionAutogenService _solConexionAutogenService;

        private SolConexionAutogenComentario _entity = null!;

        public SolConexionAutogenComentarioService(
            IUnitOfWork unitOfWork,
            IOptions<PathOptions> pathOptions,
            ISolConexionAutogenService solConexionAutogenService)
        {
            _unitOfWork = unitOfWork;
            _pathOptions = pathOptions.Value;
            _solConexionAutogenService = solConexionAutogenService;
        }

        public async Task<List<SolConexionAutogenComentario>> GetEntitiesByRequest(int idRequest)
        {
            return await _unitOfWork.SolConexionAutogenComentarioRepository.GetEntitiesByRequest(idRequest);
        }

    }
}
