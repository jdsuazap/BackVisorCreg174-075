using Core.Entities.SQLContext;
using Core.Interfaces.SQLContext;
using Infrastructure.Data;

namespace Infrastructure.Repositories.SQLContext
{
    public class TipoTecnologiaRepository : BaseRepository<TipoTecnologia>, ITipoTecnologiaRepository
    {
        public TipoTecnologiaRepository(DbSQLContext context) : base(context) { }

        public async Task<TipoTecnologia> CreateEntity(TipoTecnologia entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<bool> DeleteEntity(TipoTecnologia entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Estado = false;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return true;
        }

        public async Task<List<TipoTecnologia>> GetEntities()
        {
            return await GetAll();
        }

        public async Task<TipoTecnologia> GetEntity(int idEntity)
        {
            return await GetById(idEntity);
        }

        public async Task<TipoTecnologia> UpdateEntity(TipoTecnologia entity)
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
