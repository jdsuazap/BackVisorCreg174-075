namespace Core.Interfaces.SQLContext
{
    using Core.Entities.SQLContext;

    public interface IMotivoProrrogaRepository
    {        
        Task<List<MotivoProrroga>> GetEntities();       
    }
}
