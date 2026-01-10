using Core.Entities.Oracle;
using Core.Interfaces;
using Core.Interfaces.Oracle;

namespace Core.Services.Oracle
{
    public class TipoGeneracionService : ITipoGeneracionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TipoGeneracionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CregTipoGeneracion> CreateEntity(CregTipoGeneracion entity)
        {
            return await _unitOfWork.TipoGeneracionRepository.CreateEntity(entity);
        }

        public async Task<bool> DeleteEntity(CregTipoGeneracion entity)
        {
            return await _unitOfWork.TipoGeneracionRepository.DeleteEntity(entity);
        }

        public async Task<List<CregTipoGeneracion>> GetEntities()
        {
            return await _unitOfWork.TipoGeneracionRepository.GetEntities();
        }

        public async Task<CregTipoGeneracion> GetEntity(int idEntity)
        {
            return await _unitOfWork.TipoGeneracionRepository.GetEntity(idEntity);
        }

        public async Task<CregTipoGeneracion> UpdateEntity(CregTipoGeneracion entity)
        {
            return await _unitOfWork.TipoGeneracionRepository.UpdateEntity(entity);
        }
    }
}
