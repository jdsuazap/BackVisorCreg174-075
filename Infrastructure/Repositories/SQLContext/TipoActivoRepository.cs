using Core.Entities.SQLContext;
using Core.Interfaces.SQLContext;
using Infrastructure.Data;

namespace Infrastructure.Repositories.SQLContext
{
    public class TipoActivoRepository : StringBaseRepository<TipoActivo>, ITipoActivoRepository
    {
        public TipoActivoRepository(DbSQLContext context) : base(context) { }

        public async Task<TipoActivo> CreateEntity(TipoActivo entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<bool> DeleteEntity(TipoActivo entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Estado = false;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return true;
        }

        public async Task<List<TipoActivo>> GetEntities()
        {
            return await GetAll();
        }

        public async Task<TipoActivo> GetEntity(string idEntity)
        {
            return await GetById(idEntity);
        }

        public async Task<TipoActivo> UpdateEntity(TipoActivo entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Descripcion = entity.Descripcion;
            entidad.UrlIconoMapa = entity.UrlIconoMapa;
            entidad.AltoIconoMapa = entity.AltoIconoMapa;
            entidad.AnchoIconoMapa = entity.AnchoIconoMapa;
            entidad.Estado = entity.Estado;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return entidad;
        }
    }
}
