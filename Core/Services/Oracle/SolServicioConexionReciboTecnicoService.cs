namespace Core.Services.Oracle
{
    using Core.CustomEntities;
    using Core.Entities.Oracle;
    using Core.Enumerations;
    using Core.Exceptions;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;
    using Core.Options;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Options;
    using System.Linq.Expressions;

    public class SolServicioConexionReciboTecnicoService : ISolServicioConexionReciboTecnicoService
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IFileWithDoccPerFormDependenciesService<Creg075ReciboTecnicoAnexo> _solServicioConexionFileService;
        private readonly PathOptions _pathOptions;

        public SolServicioConexionReciboTecnicoService(
            IUnitOfWork unitOfWork,
            //IFileWithDoccPerFormDependenciesService<Creg075ReciboTecnicoAnexo> solServicioConexionFileService,
            IOptions<PathOptions> pathOptions)
        {
            _unitOfWork = unitOfWork;
            //_solServicioConexionFileService = solServicioConexionFileService;
            _pathOptions = pathOptions.Value;
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
