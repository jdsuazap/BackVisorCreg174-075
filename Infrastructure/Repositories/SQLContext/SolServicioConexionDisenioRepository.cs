using Core.Entities.SQLContext;
using Core.Interfaces.SQLContext;
using Infrastructure.Data;

namespace Infrastructure.Repositories.SQLContext
{
    public class SolServicioConexionDisenioRepository : GenericBaseRepository<SolServicioConexionDisenio>, ISolServicioConexionDisenioRepository
    {
        public SolServicioConexionDisenioRepository(DbSQLContext context) : base(context) { }

        public async Task<SolServicioConexionDisenio> CreateEntity(SolServicioConexionDisenio entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<bool> DeleteEntity(SolServicioConexionDisenio entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Estado = false;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return true;
        }

        public async Task<List<SolServicioConexionDisenio>> GetEntities()
        {
            return await GetAllAsync();
        }

        public async Task<SolServicioConexionDisenio> GetEntity(long idEntity)
        {
            return await GetById(idEntity);
        }

        public async Task<SolServicioConexionDisenio> UpdateEntity(SolServicioConexionDisenio entity)
        {
            await Update(entity);
            return entity;
        }
    }
}
