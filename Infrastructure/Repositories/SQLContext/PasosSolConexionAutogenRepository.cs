using Core.Entities.SQLContext;
using Core.Interfaces.SQLContext;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.SQLContext
{
    public class PasosSolConexionAutogenRepository : BaseRepository<PasosSolConexionAutogen>, IPasosSolConexionAutogenRepository
    {
        public PasosSolConexionAutogenRepository(DbSQLContext context) : base(context) { }

        public async Task<PasosSolConexionAutogen> CreateEntity(PasosSolConexionAutogen entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<bool> DeleteEntity(PasosSolConexionAutogen entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Estado = false;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return true;
        }

        public async Task<List<PasosSolConexionAutogen>> GetEntities()
        {
            return await GetAll();
        }

        public async Task<PasosSolConexionAutogen> GetEntity(int idEntity)
        {
            return await GetById(idEntity);
        }

        public async Task<PasosSolConexionAutogen> GetLastEntityBySolConexion(int idSolConexion)
        {
            var pasoSolConexion = await _context.PasosSolConexionAutogens.Where(paso => paso.CodSolConexionAutogen == idSolConexion)
                                                                         .OrderByDescending(paso => paso.Id)
                                                                         .FirstOrDefaultAsync();

            return pasoSolConexion;
        }

        public async Task<PasosSolConexionAutogen> UpdateEntity(PasosSolConexionAutogen entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.CodSolConexionAutogen = entity.CodSolConexionAutogen;
            entidad.CodEstado = entity.CodEstado;
            entidad.Estado = entity.Estado;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return entidad;
        }
    }
}
