using Core.Entities.SQLContext;
using Core.Interfaces.SQLContext;
using Infrastructure.Data;

namespace Infrastructure.Repositories.SQLContext
{
    public class ActividadEconomicaRepository : BaseRepository<ActividadEconomica>, IActividadEconomicaRepository
    {
        public ActividadEconomicaRepository(DbSQLContext context) : base(context) { }

        public async Task<ActividadEconomica> CreateEntity(ActividadEconomica entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<bool> DeleteEntity(ActividadEconomica entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Estado = false;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return true;
        }

        public async Task<List<ActividadEconomica>> GetEntities()
        {
            return await GetAll();
        }

        public async Task<ActividadEconomica> GetEntity(int idEntity)
        {
            return await GetById(idEntity);
        }

        public async Task<ActividadEconomica> UpdateEntity(ActividadEconomica entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Descripcion = entity.Descripcion;
            entidad.Estado = entity.Estado;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return entidad;
        }
    }
}
