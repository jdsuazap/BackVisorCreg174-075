using Core.Entities.SQLContext;
using Core.Interfaces.SQLContext;
using Infrastructure.Data;

namespace Infrastructure.Repositories.SQLContext
{
    public class EstratoSocioeconomicoRepository : BaseRepository<EstratoSocioeconomico>, IEstratoSocioeconomicoRepository
    {
        public EstratoSocioeconomicoRepository(DbSQLContext context) : base(context)
        {
        }

        public async Task<EstratoSocioeconomico> CreateEntity(EstratoSocioeconomico entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<bool> DeleteEntity(EstratoSocioeconomico entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Estado = false;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return true;
        }

        public async Task<List<EstratoSocioeconomico>> GetEntities()
        {
            return await GetAll();
        }

        public async Task<EstratoSocioeconomico> GetEntity(int idEntity)
        {
            return await GetById(idEntity);
        }

        public async Task<EstratoSocioeconomico> UpdateEntity(EstratoSocioeconomico entity)
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
