namespace Core.Services.Oracle
{
    using Core.Entities.Oracle;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;

    public class EstadoService : IEstadoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EstadoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CregEstado> CreateEntity(CregEstado entity)
        {
            return await _unitOfWork.EstadoRepository.CreateEntity(entity);
        }

        public async Task<bool> DeleteEntity(CregEstado entity)
        {
            return await _unitOfWork.EstadoRepository.DeleteEntity(entity);
        }

        public async Task<List<CregEstado>> GetEntities()
        {
            return await _unitOfWork.EstadoRepository.GetEntities();
        }

        public async Task<List<CregEstado>> GetEntitiesByIdTipoEstado(int idTipoEstado)
        {
            return await _unitOfWork.EstadoRepository.GetEntitiesByIdTipoEstado(idTipoEstado);
        }

        public async Task<CregEstado> GetEntity(int idEntity)
        {
            return await _unitOfWork.EstadoRepository.GetEntity(idEntity);
        }

        public async Task<CregEstado> UpdateEntity(CregEstado entity)
        {
            return await _unitOfWork.EstadoRepository.UpdateEntity(entity);
        }
    }
}
