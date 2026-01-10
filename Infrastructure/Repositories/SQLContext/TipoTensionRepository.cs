using Core.Entities.SQLContext;
using Core.Interfaces.SQLContext;
using Infrastructure.Data;

namespace Infrastructure.Repositories.SQLContext
{
    public class TipoTensionRepository : BaseRepository<TipoTension>, ITipoTensionRepository
    {
        public TipoTensionRepository(DbSQLContext context) : base(context) { }

        public async Task<TipoTension> CreateEntity(TipoTension entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<bool> DeleteEntity(TipoTension entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Estado = false;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return true;
        }

        public async Task<List<TipoTension>> GetEntities()
        {
            return await GetAll(x=> x.Estado == true);
        }

        public async Task<TipoTension> GetEntity(int idEntity)
        {
            return await GetById(idEntity);
        }

        public async Task<TipoTension> UpdateEntity(TipoTension entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Nivel = entity.Nivel;
            entidad.Descripcion = entity.Descripcion;
            entidad.Estado = entity.Estado;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return entidad;
        }
    }
}
