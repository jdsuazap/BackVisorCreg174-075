namespace Core.Services.SQLContext
{
    using Core.Entities.SQLContext;
    using Core.Interfaces;
    using Core.Interfaces.SQLContext;
    using Core.Options;
    using Microsoft.Extensions.Options;

    public class SolServicioConexionReciboTecnicoService : ISolServicioConexionReciboTecnicoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PathOptions _pathOptions;

        public SolServicioConexionReciboTecnicoService(
            IUnitOfWork unitOfWork,
            IOptions<PathOptions> pathOptions)
        {
            _unitOfWork = unitOfWork;
            _pathOptions = pathOptions.Value;
        }
       

        public async Task<List<SolServicioConexionReciboTecnico>> GetEntities()
        {
            return await _unitOfWork.SolServicioConexionReciboTecnicoRepository.GetEntities();
        }
    }
}
