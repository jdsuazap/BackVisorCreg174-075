namespace Core.Services.Oracle
{
    using Core.Entities.Oracle;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;
    public class TipoZonaService : ITipoZonaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TipoZonaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CregTipoZona> CreateEntity(CregTipoZona entity)
        {
            return await _unitOfWork.TipoZonaRepository.CreateEntity(entity);
        }

        public async Task<bool> DeleteEntity(CregTipoZona entity)
        {
            return await _unitOfWork.TipoZonaRepository.DeleteEntity(entity);
        }

        public async Task<List<CregTipoZona>> GetEntities()
        {
            return await _unitOfWork.TipoZonaRepository.GetEntities();
        }

        public async Task<CregTipoZona> GetEntity(int idEntity)
        {
            return await _unitOfWork.TipoZonaRepository.GetEntity(idEntity);
        }

        public async Task<CregTipoZona> UpdateEntity(CregTipoZona entity)
        {
            return await _unitOfWork.TipoZonaRepository.UpdateEntity(entity);
        }
    }
}
