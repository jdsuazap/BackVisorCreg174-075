using Core.Entities.SQLContext;
using Core.Interfaces.SQLContext;
using Infrastructure.Data;

namespace Infrastructure.Repositories.SQLContext
{
    public class TipoClienteRepository : BaseRepository<TipoCliente>, ITipoClienteRepository
    {
        public TipoClienteRepository(DbSQLContext context) : base(context)
        {
        }

        public async Task<TipoCliente> CreateEntity(TipoCliente entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<bool> DeleteEntity(TipoCliente entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Estado = false;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return true;
        }

        public async Task<List<TipoCliente>> GetEntities()
        {
            return await GetAll();
        }

        public async Task<TipoCliente> GetEntity(int idEntity)
        {
            return await GetById(idEntity);
        }

        public async Task<TipoCliente> UpdateEntity(TipoCliente entity)
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
