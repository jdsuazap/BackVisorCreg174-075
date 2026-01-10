namespace Core.Services.Oracle
{
    using Core.Entities.Oracle;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;
    public class TipoConstruccionService : ITipoConstruccionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TipoConstruccionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CregTipoConstruccion> CreateEntity(CregTipoConstruccion entity)
        {
            return await _unitOfWork.TipoConstruccionRepository.CreateEntity(entity);
        }

        public async Task<bool> DeleteEntity(CregTipoConstruccion entity)
        {
            return await _unitOfWork.TipoConstruccionRepository.DeleteEntity(entity);
        }

        public async Task<List<CregTipoConstruccion>> GetEntities()
        {
            return await _unitOfWork.TipoConstruccionRepository.GetEntities();
        }

        public async Task<CregTipoConstruccion> GetEntity(int idEntity)
        {
            return await _unitOfWork.TipoConstruccionRepository.GetEntity(idEntity);
        }

        public async Task<CregTipoConstruccion> UpdateEntity(CregTipoConstruccion entity)
        {
            return await _unitOfWork.TipoConstruccionRepository.UpdateEntity(entity);
        }
    }
}
