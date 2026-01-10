namespace Core.Services.SQLContext
{
    using Core.Interfaces;
    using Core.Options;
    using Microsoft.Extensions.Options;

    public class SolServicioConexionSubSanacionService
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly PathOptions _pathOptions;

        public SolServicioConexionSubSanacionService(
            IUnitOfWork unitOfWork,
            IOptions<PathOptions> pathOptions)
        {
            _unitOfWork = unitOfWork;
            _pathOptions = pathOptions.Value;
        }
    }

}
