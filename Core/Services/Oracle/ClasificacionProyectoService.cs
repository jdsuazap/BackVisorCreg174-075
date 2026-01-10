using Core.Entities.Oracle;
using Core.Interfaces;
using Core.Interfaces.Oracle;

namespace Core.Services.Oracle
{
    public class ClasificacionProyectoService : IClasificacionProyectoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClasificacionProyectoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CregClasificacionProyecto> CreateEntity(CregClasificacionProyecto entity)
        {
            return await _unitOfWork.ClasificacionProyectoRepository.CreateEntity(entity);
        }

        public async Task<bool> DeleteEntity(CregClasificacionProyecto entity)
        {
            return await _unitOfWork.ClasificacionProyectoRepository.DeleteEntity(entity);
        }

        public async Task<List<CregClasificacionProyecto>> GetEntities()
        {
            return await _unitOfWork.ClasificacionProyectoRepository.GetEntities();
        }

        public async Task<CregClasificacionProyecto> GetEntity(int idEntity)
        {
            return await _unitOfWork.ClasificacionProyectoRepository.GetEntity(idEntity);
        }

        public async Task<CregClasificacionProyecto> UpdateEntity(CregClasificacionProyecto entity)
        {
            return await _unitOfWork.ClasificacionProyectoRepository.UpdateEntity(entity);
        }
    }
}
