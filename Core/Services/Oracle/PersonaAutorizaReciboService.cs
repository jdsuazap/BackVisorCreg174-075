namespace Core.Services.SQLContext
{
    using Core.Entities.Oracle;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;
    public class PersonaAutorizaReciboService : IPersonaAutorizaReciboService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonaAutorizaReciboService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CregPersonaAutoriza> CreateEntity(CregPersonaAutoriza entity)
        {
            return await _unitOfWork.PersonaAutorizaReciboRepository.CreateEntity(entity);
        }

        public async Task<bool> DeleteEntity(CregPersonaAutoriza entity)
        {
            return await _unitOfWork.PersonaAutorizaReciboRepository.DeleteEntity(entity);
        }

        public async Task<List<CregPersonaAutoriza>> GetEntities()
        {
            return await _unitOfWork.PersonaAutorizaReciboRepository.GetEntities();
        }

        public async Task<CregPersonaAutoriza> GetEntity(int idEntity)
        {
            return await _unitOfWork.PersonaAutorizaReciboRepository.GetEntity(idEntity);
        }

        public async Task<CregPersonaAutoriza> UpdateEntity(CregPersonaAutoriza entity)
        {
            return await _unitOfWork.PersonaAutorizaReciboRepository.UpdateEntity(entity);
        }
    }
}
