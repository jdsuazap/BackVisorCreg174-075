namespace Core.Services.Oracle
{
    using Core.Entities.Oracle;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;
    public class TipoTecnologiaService : ITipoTecnologiaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TipoTecnologiaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CregTipoTecnologia> CreateEntity(CregTipoTecnologia entity)
        {
            return await _unitOfWork.TipoTecnologiaRepository.CreateEntity(entity);
        }

        public async Task<bool> DeleteEntity(CregTipoTecnologia entity)
        {
            return await _unitOfWork.TipoTecnologiaRepository.DeleteEntity(entity);
        }

        public async Task<List<CregTipoTecnologia>> GetEntities()
        {
            return await _unitOfWork.TipoTecnologiaRepository.GetEntities();
        }

        public async Task<CregTipoTecnologia> GetEntity(int idEntity)
        {
            return await _unitOfWork.TipoTecnologiaRepository.GetEntity(idEntity);
        }

        public async Task<CregTipoTecnologia> UpdateEntity(CregTipoTecnologia entity)
        {
            return await _unitOfWork.TipoTecnologiaRepository.UpdateEntity(entity);
        }
    }
}
