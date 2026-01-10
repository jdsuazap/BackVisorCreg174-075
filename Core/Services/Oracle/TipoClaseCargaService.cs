namespace Core.Services.Oracle
{
    using Core.Entities.Oracle;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;

    public class TipoClaseCargaService : ITipoClaseCargaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TipoClaseCargaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CregTipoClaseCarga> CreateEntity(CregTipoClaseCarga entity)
        {
            return await _unitOfWork.TipoClaseCargaRepository.CreateEntity(entity);
        }

        public async Task<bool> DeleteEntity(CregTipoClaseCarga entity)
        {
            return await _unitOfWork.TipoClaseCargaRepository.DeleteEntity(entity);
        }

        public async Task<List<CregTipoClaseCarga>> GetEntities()
        {
            return await _unitOfWork.TipoClaseCargaRepository.GetEntities();
        }

        public async Task<CregTipoClaseCarga> GetEntity(int idEntity)
        {
            return await _unitOfWork.TipoClaseCargaRepository.GetEntity(idEntity);
        }

        public async Task<CregTipoClaseCarga> UpdateEntity(CregTipoClaseCarga entity)
        {
            return await _unitOfWork.TipoClaseCargaRepository.UpdateEntity(entity);
        }
    }
}
