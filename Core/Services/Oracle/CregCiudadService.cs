namespace Core.Services.Oracle
{
    using Core.Entities.Oracle;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;

    public class CregCiudadService : ICregCiudadService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CregCiudadService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CregCiudad>> GetEntitiesByDepartamento(string idEntityDpto)
        {
            return await _unitOfWork.CregCiudadRepository.GetEntitiesByDepartamento(idEntityDpto);
        }
    }
}
