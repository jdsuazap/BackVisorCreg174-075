using Core.Entities.SQLContext;
using Core.Interfaces;
using Core.Interfaces.SQLContext;

namespace Core.Services.SQLContext
{
    public class TipoIdentificacionService : ITipoIdentificacionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TipoIdentificacionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TipoIdentificacion> CreateEntity(TipoIdentificacion entity)
        {
            return await _unitOfWork.TipoIdentificacionRepository.CreateEntity(entity);
        }

        public async Task<bool> DeleteEntity(TipoIdentificacion entity)
        {
            return await _unitOfWork.TipoIdentificacionRepository.DeleteEntity(entity);
        }

        public async Task<List<TipoIdentificacion>> GetEntities()
        {
            return await _unitOfWork.TipoIdentificacionRepository.GetEntities();
        }

        public async Task<TipoIdentificacion> GetEntity(int idEntity)
        {
            return await _unitOfWork.TipoIdentificacionRepository.GetEntity(idEntity);
        }

        public async Task<TipoIdentificacion> UpdateEntity(TipoIdentificacion entity)
        {
            return await _unitOfWork.TipoIdentificacionRepository.UpdateEntity(entity);
        }
    }
}
