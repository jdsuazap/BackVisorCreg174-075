namespace Core.Services.Oracle
{
    using Core.Entities.Oracle;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;
    using System.Linq.Expressions;

    public class SolServicioConexionReciboTecnicoService : ISolServicioConexionReciboTecnicoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SolServicioConexionReciboTecnicoService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;            
        }

       
        public async Task<List<Creg075ReciboTecnico>> GetAll(Expression<Func<Creg075ReciboTecnico, bool>> filter = null, Func<IQueryable<Creg075ReciboTecnico>, IOrderedQueryable<Creg075ReciboTecnico>>? orderBy = null, bool isTracking = false, params Expression<Func<Creg075ReciboTecnico, object>>[] includeObjectProperties)
        {
            return await _unitOfWork.SolServicioConexionReciboTecnicoRepository.GetAll(filter, orderBy, null, isTracking, includeObjectProperties);
        }

        public async Task<List<Creg075ReciboTecnico>> GetEntities()
        {
            return await _unitOfWork.SolServicioConexionReciboTecnicoRepository.GetEntities();
        }

        public async Task<Creg075ReciboTecnico> GetEntity(int idEntity)
        {
            return await _unitOfWork.SolServicioConexionReciboTecnicoRepository.GetEntity(idEntity);
        }
    }
}
