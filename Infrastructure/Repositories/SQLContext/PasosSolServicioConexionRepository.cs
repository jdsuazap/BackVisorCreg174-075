using Core.Entities.SQLContext;
using Core.Interfaces.SQLContext;
using Infrastructure.Data;

namespace Infrastructure.Repositories.SQLContext
{
    public class PasosSolServicioConexionRepository : BaseRepository<PasosSolServicioConexion>, IPasosSolServicioConexionRepository
    {
        public PasosSolServicioConexionRepository(DbSQLContext context) : base(context) { }

        public async Task<PasosSolServicioConexion> CreateEntity(PasosSolServicioConexion entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<bool> DeleteEntity(PasosSolServicioConexion entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Estado = false;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return true;
        }

        public async Task<List<PasosSolServicioConexion>> GetEntities()
        {
            return await GetAll();
        }

        public async Task<PasosSolServicioConexion> GetEntity(int idEntity)
        {
            return await GetById(idEntity);
        }

        public async Task<PasosSolServicioConexion> UpdateEntity(PasosSolServicioConexion entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.CodSolServicioConexion = entity.CodSolServicioConexion;
            entidad.CodEstado = entity.CodEstado;
            entidad.Estado = entity.Estado;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return entidad;
        }
    }
}
