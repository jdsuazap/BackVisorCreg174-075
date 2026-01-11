namespace Core.Services.Oracle
{
    using Core.Entities.Oracle;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;
    public class TipoSolicitudServicioService : ITipoSolicitudServicioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TipoSolicitudServicioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CregTipoSolicitudServicio> CreateEntity(CregTipoSolicitudServicio entity)
        {
            return await _unitOfWork.TipoSolicitudServicioRepository.CreateEntity(entity);
        }

        public async Task<bool> DeleteEntity(CregTipoSolicitudServicio entity)
        {
            return await _unitOfWork.TipoSolicitudServicioRepository.DeleteEntity(entity);
        }

        public async Task<List<CregTipoSolicitudServicio>> GetEntities()
        {
            return await _unitOfWork.TipoSolicitudServicioRepository.GetEntities();
        }

        public async Task<CregTipoSolicitudServicio> GetEntity(int idEntity)
        {
            return await _unitOfWork.TipoSolicitudServicioRepository.GetEntity(idEntity);
        }

        public async Task<CregTipoSolicitudServicio> UpdateEntity(CregTipoSolicitudServicio entity)
        {
            return await _unitOfWork.TipoSolicitudServicioRepository.UpdateEntity(entity);
        }
    }
}
