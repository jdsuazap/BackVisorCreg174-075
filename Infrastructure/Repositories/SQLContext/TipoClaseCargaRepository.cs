using Core.Entities.SQLContext;
using Core.Interfaces.SQLContext;
using Infrastructure.Data;

namespace Infrastructure.Repositories.SQLContext
{
    public class TipoClaseCargaRepository : BaseRepository<TipoClaseCarga>, ITipoClaseCargaRepository
    {
        public TipoClaseCargaRepository(DbSQLContext context) : base(context)
        {
        }

        public async Task<TipoClaseCarga> CreateEntity(TipoClaseCarga entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<bool> DeleteEntity(TipoClaseCarga entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Estado = false;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return true;
        }

        public async Task<List<TipoClaseCarga>> GetEntities()
        {
            return await GetAll();
        }

        public async Task<TipoClaseCarga> GetEntity(int idEntity)
        {
            return await GetById(idEntity);
        }

        public async Task<TipoClaseCarga> UpdateEntity(TipoClaseCarga entity)
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
