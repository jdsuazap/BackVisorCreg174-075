namespace Core.Services.Oracle
{
    using Core.Entities.Oracle;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;

    public class DepartamentoService : IDepartamentoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartamentoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CregDepartamento>> GetEntities()
        {
            return await _unitOfWork.DepartamentoRepository.GetEntities();
        }
    }
}
