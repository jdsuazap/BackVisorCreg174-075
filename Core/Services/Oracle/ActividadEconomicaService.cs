namespace Core.Services.Oracle
{
    using Core.Entities.Oracle;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;

    public class ActividadEconomicaService : IActividadEconomicaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActividadEconomicaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CregActividadEconomica> CreateEntity(CregActividadEconomica entity)
        {
            return await _unitOfWork.ActividadEconomicaRepository.CreateEntity(entity);
        }

        public async Task<bool> DeleteEntity(CregActividadEconomica entity)
        {
            return await _unitOfWork.ActividadEconomicaRepository.DeleteEntity(entity);
        }

        public async Task<List<CregActividadEconomica>> GetEntities()
        {
            return await _unitOfWork.ActividadEconomicaRepository.GetEntities();
        }

        public async Task<CregActividadEconomica> GetEntity(int idEntity)
        {
            return await _unitOfWork.ActividadEconomicaRepository.GetEntity(idEntity);
        }

        public async Task<CregActividadEconomica> UpdateEntity(CregActividadEconomica entity)
        {
            return await _unitOfWork.ActividadEconomicaRepository.UpdateEntity(entity);
        }
    }
}
