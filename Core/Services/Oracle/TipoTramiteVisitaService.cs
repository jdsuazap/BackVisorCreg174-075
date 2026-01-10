namespace Core.Services.Oracle
{
    using Core.Entities.Oracle;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;
    public class TipoTramiteVisitaService : ITipoTramiteVisitaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TipoTramiteVisitaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CregTipoTramiteVisita> CreateEntity(CregTipoTramiteVisita entity)
        {
            return await _unitOfWork.TipoTramiteVisitaRepository.CreateEntity(entity);
        }

        public async Task<bool> DeleteEntity(CregTipoTramiteVisita entity)
        {
            return await _unitOfWork.TipoTramiteVisitaRepository.DeleteEntity(entity);
        }

        public async Task<List<CregTipoTramiteVisita>> GetEntities()
        {
            return await _unitOfWork.TipoTramiteVisitaRepository.GetEntities();
        }

        public async Task<CregTipoTramiteVisita> GetEntity(int idEntity)
        {
            return await _unitOfWork.TipoTramiteVisitaRepository.GetEntity(idEntity);
        }

        public async Task<CregTipoTramiteVisita> UpdateEntity(CregTipoTramiteVisita entity)
        {
            return await _unitOfWork.TipoTramiteVisitaRepository.UpdateEntity(entity);
        }
    }
}
