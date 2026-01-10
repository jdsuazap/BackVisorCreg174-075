namespace Core.Services.Oracle
{
    using Core.Entities.Oracle;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;
    public class TipoAerogeneradorService : ITipoAerogeneradorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TipoAerogeneradorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CregTipoAerogenerador> CreateEntity(CregTipoAerogenerador entity)
        {
            return await _unitOfWork.TipoAerogeneradorRepository.CreateEntity(entity);
        }

        public async Task<bool> DeleteEntity(CregTipoAerogenerador entity)
        {
            return await _unitOfWork.TipoAerogeneradorRepository.DeleteEntity(entity);
        }

        public async Task<List<CregTipoAerogenerador>> GetEntities()
        {
            return await _unitOfWork.TipoAerogeneradorRepository.GetEntities();
        }

        public async Task<CregTipoAerogenerador> GetEntity(int idEntity)
        {
            return await _unitOfWork.TipoAerogeneradorRepository.GetEntity(idEntity);
        }

        public async Task<CregTipoAerogenerador> UpdateEntity(CregTipoAerogenerador entity)
        {
            return await _unitOfWork.TipoAerogeneradorRepository.UpdateEntity(entity);
        }
    }
}
