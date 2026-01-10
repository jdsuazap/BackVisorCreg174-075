namespace Core.Interfaces.SQLContext
{
    using Core.Entities.SQLContext;

    public interface IMotivoProrrogaService
    {        
        Task<List<MotivoProrroga>> GetEntities();
    }
}
