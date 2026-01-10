namespace Core.Services.Oracle
{
    using Core.Entities.Oracle;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;
    public class TipoPersonaService : ITipoPersonaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TipoPersonaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CregTipoPersona> CreateEntity(CregTipoPersona entity)
        {
            return await _unitOfWork.TipoPersonaRepository.CreateEntity(entity);
        }

        public async Task<bool> DeleteEntity(CregTipoPersona entity)
        {
            return await _unitOfWork.TipoPersonaRepository.DeleteEntity(entity);
        }

        public async Task<List<CregTipoPersona>> GetEntities()
        {
            return await _unitOfWork.TipoPersonaRepository.GetEntities();
        }

        public async Task<CregTipoPersona> GetEntity(int idEntity)
        {
            return await _unitOfWork.TipoPersonaRepository.GetEntity(idEntity);
        }

        public async Task<CregTipoPersona> UpdateEntity(CregTipoPersona entity)
        {
            return await _unitOfWork.TipoPersonaRepository.UpdateEntity(entity);
        }
    }
}
