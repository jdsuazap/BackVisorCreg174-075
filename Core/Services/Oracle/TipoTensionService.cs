namespace Core.Services.Oracle
{
    using Core.Entities.Oracle;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;

    public class TipoTensionService : ITipoTensionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TipoTensionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CregTipoTension> CreateEntity(CregTipoTension entity)
        {
            return await _unitOfWork.TipoTensionRepository.CreateEntity(entity);
        }

        public async Task<bool> DeleteEntity(CregTipoTension entity)
        {
            return await _unitOfWork.TipoTensionRepository.DeleteEntity(entity);
        }

        public async Task<List<CregTipoTension>> GetEntities()
        {
            return await _unitOfWork.TipoTensionRepository.GetEntities();
        }

        public async Task<CregTipoTension> GetEntity(int idEntity)
        {
            return await _unitOfWork.TipoTensionRepository.GetEntity(idEntity);
        }

        public async Task<CregTipoTension> UpdateEntity(CregTipoTension entity)
        {
            return await _unitOfWork.TipoTensionRepository.UpdateEntity(entity);
        }
    }
}
