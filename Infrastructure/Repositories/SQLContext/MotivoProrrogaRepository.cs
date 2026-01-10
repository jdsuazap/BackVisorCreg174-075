namespace Infrastructure.Repositories.SQLContext
{
    using Core.Entities.SQLContext;
    using Core.Interfaces.SQLContext;
    using Infrastructure.Data;

    public class MotivoProrrogaRepository : BaseRepository<MotivoProrroga>, IMotivoProrrogaRepository
    {
        public MotivoProrrogaRepository(DbSQLContext context) : base(context)
        {
        }

        public async Task<List<MotivoProrroga>> GetEntities()
        {
            return await GetAll();
        }      
    }
}
