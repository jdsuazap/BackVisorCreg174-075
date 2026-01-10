using Core.Entities.SQLContext;
using Core.Interfaces.SQLContext;
using Infrastructure.Data;

namespace Infrastructure.Repositories.SQLContext
{
    public class TipoAerogeneradorRepository : BaseRepository<TipoAerogenerador>, ITipoAerogeneradorRepository
    {
        public TipoAerogeneradorRepository(DbSQLContext context) : base(context)
        {
        }

        public async Task<TipoAerogenerador> CreateEntity(TipoAerogenerador entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<bool> DeleteEntity(TipoAerogenerador entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Estado = false;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return true;
        }

        public async Task<List<TipoAerogenerador>> GetEntities()
        {
            return await GetAll();
        }

        public async Task<TipoAerogenerador> GetEntity(int idEntity)
        {
            return await GetById(idEntity);
        }

        public async Task<TipoAerogenerador> UpdateEntity(TipoAerogenerador entity)
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
