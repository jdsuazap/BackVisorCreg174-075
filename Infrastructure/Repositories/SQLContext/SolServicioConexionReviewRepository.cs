using Core.Entities.SQLContext;
using Core.Interfaces.SQLContext;
using Infrastructure.Data;

namespace Infrastructure.Repositories.SQLContext
{
    public class SolServicioConexionReviewRepository : GenericBaseRepository<SolServicioConexionReview>, ISolServicioConexionReviewRepository
    {
        public SolServicioConexionReviewRepository(DbSQLContext context) : base(context) { }
        public async Task<SolServicioConexionReview> CreateEntity(SolServicioConexionReview entity)
        {
            await Add(entity);
            return entity;
        }

        public Task<SolServicioConexionReview> GetEntity(int idEntity)
        {
            var result = GetById(idEntity);
            return result;
        }

        public async Task<SolServicioConexionReview> GetEntityBySolServcioConexionId(int idEntity)
        {
            return (await GetAllAsync(filter: x => x.CodSolServicioConexion == idEntity)).FirstOrDefault();
        }

        public async Task<SolServicioConexionReview> UpdateEntity(SolServicioConexionReview entity)
        {
            await Update(entity);
            return entity;
        }
    }
}
