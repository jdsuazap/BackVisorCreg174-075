using Core.Entities.SQLContext;
using Core.Interfaces.SQLContext;
using Infrastructure.Data;
using System.Linq.Expressions;

namespace Infrastructure.Repositories.SQLContext
{
    public class EstadoRepository : BaseRepository<Estado>, IEstadoRepository
    {
        private readonly Expression<Func<Estado, object>>[] IncludeProperties = new Expression<Func<Estado, object>>[]
        {
            // Agrega aquí las propiedades de navegación que deseas incluir
            entity => entity.CodTipoEstadoNavigation,      
        };

        public EstadoRepository(DbSQLContext context) : base(context) { }

        public async Task<Estado> CreateEntity(Estado entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<bool> DeleteEntity(Estado entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.ParvEstado = false;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return true;
        }

        public async Task<List<Estado>> GetEntities()
        {
            return await GetAll(includeObjectProperties: IncludeProperties);
        }

        public async Task<List<Estado>> GetEntitiesByIdTipoEstado(int idTipoEstado)
        {
            return await GetAll(filter: x => x.CodTipoEstado == idTipoEstado, includeObjectProperties: IncludeProperties);
        }

        public async Task<Estado> GetEntity(int idEntity)
        {
            return (await GetAll(filter: x => x.Id == idEntity, includeObjectProperties: IncludeProperties)).FirstOrDefault();
        }

        public async Task<Estado> UpdateEntity(Estado entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.CodTipoEstado = entity.CodTipoEstado;
            entidad.ParDescripcion = entity.ParDescripcion;
            entidad.ParvEstado = entity.ParvEstado;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return entidad;
        }
    }
}
