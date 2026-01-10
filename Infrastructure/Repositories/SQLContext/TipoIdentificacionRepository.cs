using Core.Entities.SQLContext;
using Core.Interfaces.SQLContext;
using Infrastructure.Data;

namespace Infrastructure.Repositories.SQLContext
{
    public class TipoIdentificacionRepository : BaseRepository<TipoIdentificacion>, ITipoIdentificacionRepository
    {
        public TipoIdentificacionRepository(DbSQLContext context) : base(context)
        {
        }

        public async Task<TipoIdentificacion> CreateEntity(TipoIdentificacion entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<bool> DeleteEntity(TipoIdentificacion entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Estado = false;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return true;
        }

        public async Task<List<TipoIdentificacion>> GetEntities()
        {
            return await GetAll();
        }

        public async Task<TipoIdentificacion> GetEntity(int idEntity)
        {
            return await GetById(idEntity);
        }

        public async Task<TipoIdentificacion> UpdateEntity(TipoIdentificacion entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Descripcion = entity.Descripcion;
            entidad.Abreviatura = entity.Abreviatura;
            entidad.Estado = entity.Estado;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return entidad;
        }
    }
}
