using Core.Entities.SQLContext;
using Core.Interfaces;
using Core.Interfaces.SQLContext;

namespace Core.Services.SQLContext
{
    public class PasosSolServicioConexionService : IPasosSolServicioConexionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PasosSolServicioConexionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PasosSolServicioConexion> CreateEntity(PasosSolServicioConexion entity)
        {
            return await _unitOfWork.PasosSolServicioConexionRepository.CreateEntity(entity);
        }

        public async Task<bool> DeleteEntity(PasosSolServicioConexion entity)
        {
            return await _unitOfWork.PasosSolServicioConexionRepository.DeleteEntity(entity);
        }

        public async Task<List<PasosSolServicioConexion>> GetEntities()
        {
            return await _unitOfWork.PasosSolServicioConexionRepository.GetEntities();
        }

        public async Task<PasosSolServicioConexion> GetEntity(int idEntity)
        {
            return await _unitOfWork.PasosSolServicioConexionRepository.GetEntity(idEntity);
        }

        public async Task<PasosSolServicioConexion> UpdateEntity(PasosSolServicioConexion entity)
        {
            return await _unitOfWork.PasosSolServicioConexionRepository.UpdateEntity(entity);
        }
    }
}
