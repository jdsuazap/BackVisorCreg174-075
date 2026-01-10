namespace Core.Services.Oracle
{
    using Core.Entities.Oracle;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;

    public class ComercializadorService : IComercializadorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ComercializadorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CregComercializador> CreateEntity(CregComercializador entity)
        {
            return await _unitOfWork.ComercializadorRepository.CreateEntity(entity);
        }

        public async Task<bool> DeleteEntity(CregComercializador entity)
        {
            return await _unitOfWork.ComercializadorRepository.DeleteEntity(entity);
        }

        public async Task<List<CregComercializador>> GetEntities()
        {
            return await _unitOfWork.ComercializadorRepository.GetEntities();
        }

        public async Task<CregComercializador> GetEntity(int idEntity)
        {
            return await _unitOfWork.ComercializadorRepository.GetEntity(idEntity);
        }

        public async Task<CregComercializador> UpdateEntity(CregComercializador entity)
        {
            return await _unitOfWork.ComercializadorRepository.UpdateEntity(entity);
        }
    }
}
