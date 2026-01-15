namespace Core.Services.Oracle
{
    using Core.Entities.Oracle;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;
    public class PasosSolConexionAutogenService : IPasosSolConexionAutogenService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PasosSolConexionAutogenService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Creg174Pasos> CreateEntity(Creg174Pasos entity)
        {
            return await _unitOfWork.PasosSolConexionAutogenRepository.CreateEntity(entity);
        }

        public async Task<bool> DeleteEntity(Creg174Pasos entity)
        {
            return await _unitOfWork.PasosSolConexionAutogenRepository.DeleteEntity(entity);
        }

        public async Task<List<Creg174Pasos>> GetEntities()
        {
            return await _unitOfWork.PasosSolConexionAutogenRepository.GetEntities();
        }

        public async Task<Creg174Pasos> GetEntity(int idEntity)
        {
            return await _unitOfWork.PasosSolConexionAutogenRepository.GetEntity(idEntity);
        }

        public async Task<Creg174Pasos> UpdateEntity(Creg174Pasos entity)
        {
            return await _unitOfWork.PasosSolConexionAutogenRepository.UpdateEntity(entity);
        }
    }
}
