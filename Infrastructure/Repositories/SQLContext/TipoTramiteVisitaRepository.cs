using Core.Entities.SQLContext;
using Core.Interfaces.SQLContext;
using Infrastructure.Data;

namespace Infrastructure.Repositories.SQLContext
{
    public class TipoTramiteVisitaRepository : BaseRepository<TipoTramiteVisita>, ITipoTramiteVisitaRepository
    {
        public TipoTramiteVisitaRepository(DbSQLContext context) : base(context) { }

        public async Task<TipoTramiteVisita> CreateEntity(TipoTramiteVisita entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<bool> DeleteEntity(TipoTramiteVisita entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Estado = false;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return true;
        }

        public async Task<List<TipoTramiteVisita>> GetEntities()
        {
            return await GetAll();
        }

        public async Task<TipoTramiteVisita> GetEntity(int idEntity)
        {
            return await GetById(idEntity);
        }

        public async Task<TipoTramiteVisita> UpdateEntity(TipoTramiteVisita entity)
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
