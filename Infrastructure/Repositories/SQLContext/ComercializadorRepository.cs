using Core.Entities.SQLContext;
using Core.Interfaces.SQLContext;
using Infrastructure.Data;

namespace Infrastructure.Repositories.SQLContext
{
    public class ComercializadorRepository : BaseRepository<Comercializador>, IComercializadorRepository
    {
        public ComercializadorRepository(DbSQLContext context) : base(context)
        {
        }

        public async Task<Comercializador> CreateEntity(Comercializador entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<bool> DeleteEntity(Comercializador entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Estado = false;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return true;
        }

        public async Task<List<Comercializador>> GetEntities()
        {
            return await GetAll();
        }

        public async Task<Comercializador> GetEntity(int idEntity)
        {
            return await GetById(idEntity);
        }

        public async Task<Comercializador> UpdateEntity(Comercializador entity)
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
