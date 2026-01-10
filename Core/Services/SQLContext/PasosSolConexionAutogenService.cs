using Core.Entities.SQLContext;
using Core.Interfaces;
using Core.Interfaces.SQLContext;

namespace Core.Services.SQLContext
{
    public class PasosSolConexionAutogenService : IPasosSolConexionAutogenService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PasosSolConexionAutogenService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PasosSolConexionAutogen> CreateEntity(PasosSolConexionAutogen entity)
        {
            return await _unitOfWork.PasosSolConexionAutogenRepository.CreateEntity(entity);
        }

        public async Task<bool> DeleteEntity(PasosSolConexionAutogen entity)
        {
            return await _unitOfWork.PasosSolConexionAutogenRepository.DeleteEntity(entity);
        }

        public async Task<List<PasosSolConexionAutogen>> GetEntities()
        {
            return await _unitOfWork.PasosSolConexionAutogenRepository.GetEntities();
        }

        public async Task<PasosSolConexionAutogen> GetEntity(int idEntity)
        {
            return await _unitOfWork.PasosSolConexionAutogenRepository.GetEntity(idEntity);
        }

        public async Task<PasosSolConexionAutogen> UpdateEntity(PasosSolConexionAutogen entity)
        {
            return await _unitOfWork.PasosSolConexionAutogenRepository.UpdateEntity(entity);
        }
    }
}
