namespace Core.Services.Oracle
{
    using Core.Entities.Oracle;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;

    public class EstratoSocioeconomicoService : IEstratoSocioeconomicoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EstratoSocioeconomicoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CregEstratoSocioeconomico> CreateEntity(CregEstratoSocioeconomico entity)
        {
            return await _unitOfWork.EstratoSocioeconomicoRepository.CreateEntity(entity);
        }

        public async Task<bool> DeleteEntity(CregEstratoSocioeconomico entity)
        {
            return await _unitOfWork.EstratoSocioeconomicoRepository.DeleteEntity(entity);
        }

        public async Task<List<CregEstratoSocioeconomico>> GetEntities()
        {
            return await _unitOfWork.EstratoSocioeconomicoRepository.GetEntities();
        }

        public async Task<CregEstratoSocioeconomico> GetEntity(int idEntity)
        {
            return await _unitOfWork.EstratoSocioeconomicoRepository.GetEntity(idEntity);
        }

        public async Task<CregEstratoSocioeconomico> UpdateEntity(CregEstratoSocioeconomico entity)
        {
            return await _unitOfWork.EstratoSocioeconomicoRepository.UpdateEntity(entity);
        }
    }
}
