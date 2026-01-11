namespace Core.Services.Oracle
{
    using Core.Entities.Oracle;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;
    public class TipoSolicitudReciboService : ITipoSolicitudReciboService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TipoSolicitudReciboService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CregTipoSolicitudRecibo> CreateEntity(CregTipoSolicitudRecibo entity)
        {
            return await _unitOfWork.TipoSolicitudReciboRepository.CreateEntity(entity);
        }

        public async Task<bool> DeleteEntity(CregTipoSolicitudRecibo entity)
        {
            return await _unitOfWork.TipoSolicitudReciboRepository.DeleteEntity(entity);
        }

        public async Task<List<CregTipoSolicitudRecibo>> GetEntities()
        {
            return await _unitOfWork.TipoSolicitudReciboRepository.GetEntities();
        }

        public async Task<CregTipoSolicitudRecibo> GetEntity(int idEntity)
        {
            return await _unitOfWork.TipoSolicitudReciboRepository.GetEntity(idEntity);
        }

        public async Task<CregTipoSolicitudRecibo> UpdateEntity(CregTipoSolicitudRecibo entity)
        {
            return await _unitOfWork.TipoSolicitudReciboRepository.UpdateEntity(entity);
        }
    }
}
