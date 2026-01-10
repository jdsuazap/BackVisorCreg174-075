namespace Core.Services.Oracle
{
    using Core.Entities.Oracle;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;
    public class TipoProyectoService : ITipoProyectoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TipoProyectoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CregTipoProyecto> CreateEntity(CregTipoProyecto entity)
        {
            return await _unitOfWork.TipoProyectoRepository.CreateEntity(entity);
        }

        public async Task<bool> DeleteEntity(CregTipoProyecto entity)
        {
            return await _unitOfWork.TipoProyectoRepository.DeleteEntity(entity);
        }

        public async Task<List<CregTipoProyecto>> GetEntities()
        {
            return await _unitOfWork.TipoProyectoRepository.GetEntities();
        }

        public async Task<CregTipoProyecto> GetEntity(int idEntity)
        {
            return await _unitOfWork.TipoProyectoRepository.GetEntity(idEntity);
        }

        public async Task<CregTipoProyecto> UpdateEntity(CregTipoProyecto entity)
        {
            return await _unitOfWork.TipoProyectoRepository.UpdateEntity(entity);
        }
    }
}
