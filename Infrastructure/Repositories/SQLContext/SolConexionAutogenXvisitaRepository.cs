namespace Infrastructure.Repositories.SQLContext
{
    using Core.Entities.SQLContext;
    using Core.Interfaces.SQLContext;
    using Infrastructure.Data;

    public class SolConexionAutogenXvisitaRepository : BaseRepository<SolConexionAutogenXvisita>, ISolConexionAutogenXvisitaRepository
    {
        public SolConexionAutogenXvisitaRepository(DbSQLContext context) : base(context) { }

        public async Task<SolConexionAutogenXvisita> CreateEntity(SolConexionAutogenXvisita entity)
        {
            entity.Estado = 1;
            await Add(entity);
            return entity;
        }

        public async Task<bool> DeleteEntity(SolConexionAutogenXvisita entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Estado = 0;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return true;
        }

        public async Task<List<SolConexionAutogenXvisita>> GetEntities()
        {
            return await GetAll();
        }

        public async Task<SolConexionAutogenXvisita> GetEntity(int idEntity)
        {
            return await GetById(idEntity);
        }

        public async Task<SolConexionAutogenXvisita> UpdateEntity(SolConexionAutogenXvisita entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.CodSolConexionAutogen = entity.CodSolConexionAutogen;
            entidad.Fecha = entity.Fecha;
            entidad.NombreAtiendeVisita = entity.NombreAtiendeVisita;
            entidad.Telefono = entity.Telefono;
            entidad.Email = entity.Email;
            entidad.EquiposCumplen = entity.EquiposCumplen;
            entidad.CodTipoTramiteVisita = entity.CodTipoTramiteVisita;
            entidad.Observaciones = entity.Observaciones;
            entidad.Estado = entity.Estado;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;
            entity.EsAprobado = entity.EsAprobado;

            await Update(entidad);

            return entidad;
        }
    }
}
