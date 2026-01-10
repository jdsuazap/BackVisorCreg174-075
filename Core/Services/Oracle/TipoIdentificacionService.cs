namespace Core.Services.Oracle
{
    using Core.Entities.Oracle;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;
    public class TipoIdentificacionService : ITipoIdentificacionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TipoIdentificacionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CregTipoIdentificacion> CreateEntity(CregTipoIdentificacion entity)
        {
            return await _unitOfWork.TipoIdentificacionRepository.CreateEntity(entity);
        }

        public async Task<bool> DeleteEntity(CregTipoIdentificacion entity)
        {
            return await _unitOfWork.TipoIdentificacionRepository.DeleteEntity(entity);
        }

        public async Task<List<CregTipoIdentificacion>> GetEntities()
        {
            return await _unitOfWork.TipoIdentificacionRepository.GetEntities();
        }

        public async Task<CregTipoIdentificacion> GetEntity(int idEntity)
        {
            return await _unitOfWork.TipoIdentificacionRepository.GetEntity(idEntity);
        }

        public async Task<CregTipoIdentificacion> UpdateEntity(CregTipoIdentificacion entity)
        {
            return await _unitOfWork.TipoIdentificacionRepository.UpdateEntity(entity);
        }
    }
}
