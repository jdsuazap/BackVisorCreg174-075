namespace Core.Services.SQLContext
{
    using Core.Entities.SQLContext;
    using Core.Interfaces;
    using Core.Interfaces.SQLContext;
    using System.Linq.Expressions;

    public class SolServicioConexionDisenioService: ISolServicioConexionDisenioService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SolServicioConexionDisenioService(
            IUnitOfWork unitOfWork
            )
        {
            unitOfWork = _unitOfWork;
        }        

        public async Task<List<SolServicioConexionDisenio>> GetAllAsync(Expression<Func<SolServicioConexionDisenio, bool>> filter = null, Func<IQueryable<SolServicioConexionDisenio>, IOrderedQueryable<SolServicioConexionDisenio>>? orderBy = null, bool isTracking = false, params Expression<Func<SolServicioConexionDisenio, object>>[] includeObjectProperties)
        {
            return await _unitOfWork.SolServicioConexionDisenioRepository.GetAllAsync(filter, orderBy, isTracking, includeObjectProperties);
        }

    }
}
