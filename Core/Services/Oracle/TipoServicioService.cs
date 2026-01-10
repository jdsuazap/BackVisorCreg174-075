namespace Core.Services.Oracle
{
    using Core.Entities.Oracle;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;
    public class TipoServicioService : ITipoServicioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TipoServicioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CregTipoServicio> CreateEntity(CregTipoServicio entity)
        {
            return await _unitOfWork.TipoServicioRepository.CreateEntity(entity);
        }

        public async Task<bool> DeleteEntity(CregTipoServicio entity)
        {
            return await _unitOfWork.TipoServicioRepository.DeleteEntity(entity);
        }

        public async Task<List<CregTipoServicio>> GetEntities()
        {
            return await _unitOfWork.TipoServicioRepository.GetEntities();
        }

        public async Task<CregTipoServicio> GetEntity(int idEntity)
        {
            return await _unitOfWork.TipoServicioRepository.GetEntity(idEntity);
        }

        public async Task<CregTipoServicio> UpdateEntity(CregTipoServicio entity)
        {
            return await _unitOfWork.TipoServicioRepository.UpdateEntity(entity);
        }
    }
}
