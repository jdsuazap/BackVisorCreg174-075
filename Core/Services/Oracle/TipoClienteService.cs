namespace Core.Services.Oracle
{
    using Core.Entities.Oracle;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;
    public class TipoClienteService : ITipoClienteService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TipoClienteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CregTipoCliente> CreateEntity(CregTipoCliente entity)
        {
            return await _unitOfWork.TipoClienteRepository.CreateEntity(entity);
        }

        public async Task<bool> DeleteEntity(CregTipoCliente entity)
        {
            return await _unitOfWork.TipoClienteRepository.DeleteEntity(entity);
        }

        public async Task<List<CregTipoCliente>> GetEntities()
        {
            return await _unitOfWork.TipoClienteRepository.GetEntities();
        }

        public async Task<CregTipoCliente> GetEntity(int idEntity)
        {
            return await _unitOfWork.TipoClienteRepository.GetEntity(idEntity);
        }

        public async Task<CregTipoCliente> UpdateEntity(CregTipoCliente entity)
        {
            return await _unitOfWork.TipoClienteRepository.UpdateEntity(entity);
        }
    }
}
