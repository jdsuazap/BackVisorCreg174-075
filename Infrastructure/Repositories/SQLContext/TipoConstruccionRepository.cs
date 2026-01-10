using Core.Entities.SQLContext;
using Core.Interfaces;
using Core.Interfaces.SQLContext;
using Infrastructure.Data;
using System.Data;

namespace Infrastructure.Repositories.SQLContext
{
    public class TipoConstruccionRepository : BaseRepository<TipoConstruccion>, ITipoConstruccionRepository
    {
        public TipoConstruccionRepository(DbSQLContext context, IDbConnection dapperContext)
            : base(context, dapperContext) { }

        public async Task<TipoConstruccion> CreateEntity(TipoConstruccion entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<bool> DeleteEntity(TipoConstruccion entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Estado = false;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return true;
        }

        public async Task<List<TipoConstruccion>> GetEntities()
        {
            return await GetAll();
        }

        public async Task<TipoConstruccion> GetEntity(int idTipoConstruccion)
        {
            return await GetById(idTipoConstruccion);
        }

        public async Task<TipoConstruccion> UpdateEntity(TipoConstruccion entity)
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
