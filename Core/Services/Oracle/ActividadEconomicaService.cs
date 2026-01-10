namespace Core.Services.Oracle
{
    using Core.Entities.SQLContext;
    using Core.Interfaces;
    using Core.Interfaces.SQLContext;

    public class ActividadEconomicaService : IActividadEconomicaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActividadEconomicaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ActividadEconomica> CreateEntity(ActividadEconomica entity)
        {
            return await _unitOfWork.ActividadEconomicaRepository.CreateEntity(entity);
        }

        public async Task<bool> DeleteEntity(ActividadEconomica entity)
        {
            return await _unitOfWork.ActividadEconomicaRepository.DeleteEntity(entity);
        }

        public async Task<List<ActividadEconomica>> GetEntities()
        {
            return await _unitOfWork.ActividadEconomicaRepository.GetEntities();
        }

        public async Task<ActividadEconomica> GetEntity(int idEntity)
        {
            return await _unitOfWork.ActividadEconomicaRepository.GetEntity(idEntity);
        }

        public async Task<ActividadEconomica> UpdateEntity(ActividadEconomica entity)
        {
            return await _unitOfWork.ActividadEconomicaRepository.UpdateEntity(entity);
        }
    }
}
