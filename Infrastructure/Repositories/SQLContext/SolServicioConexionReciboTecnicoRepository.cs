using Core.Entities.SQLContext;
using Core.Interfaces.SQLContext;
using Infrastructure.Data;

namespace Infrastructure.Repositories.SQLContext
{
    public class SolServicioConexionReciboTecnicoRepository : GenericBaseRepository<SolServicioConexionReciboTecnico>, ISolServicioConexionReciboTecnicoRepository
    {
        public SolServicioConexionReciboTecnicoRepository(DbSQLContext context) : base(context) { }

        public async Task<SolServicioConexionReciboTecnico> CreateEntity(SolServicioConexionReciboTecnico entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<bool> DeleteEntity(SolServicioConexionReciboTecnico entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Estado = false;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return true;
        }

        public async Task<List<SolServicioConexionReciboTecnico>> GetEntities()
        {
            return await GetAllAsync();
        }

        public async Task<SolServicioConexionReciboTecnico> GetEntity(long idEntity)
        {
            return await GetById(idEntity);
        }

        public async Task<SolServicioConexionReciboTecnico> UpdateEntity(SolServicioConexionReciboTecnico entity)
        {
            await Update(entity);

            return entity;
        }
    }
}
