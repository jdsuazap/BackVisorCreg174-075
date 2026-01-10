namespace Core.Services.Oracle
{
    using Core.Entities.Oracle;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;

    public class TipoConexionService : ITipoConexionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TipoConexionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CregTipoConexion> CreateEntity(CregTipoConexion entity)
        {
            return await _unitOfWork.TipoConexionRepository.CreateEntity(entity);
        }

        public async Task<bool> DeleteEntity(CregTipoConexion entity)
        {
            return await _unitOfWork.TipoConexionRepository.DeleteEntity(entity);
        }

        public async Task<List<CregTipoConexion>> GetEntities()
        {
            return await _unitOfWork.TipoConexionRepository.GetEntities();
        }

        public async Task<CregTipoConexion> GetEntity(int idEntity)
        {
            return await _unitOfWork.TipoConexionRepository.GetEntity(idEntity);
        }

        public async Task<CregTipoConexion> UpdateEntity(CregTipoConexion entity)
        {
            return await _unitOfWork.TipoConexionRepository.UpdateEntity(entity);
        }
    }
}
