namespace Infrastructure.Repositories.SQLContext
{
    using Core.Entities.SQLContext;
    using Core.Interfaces.SQLContext;
    using Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;

    public class SolConexionAutogenAnexoRepository
     : BaseRepository<SolConexionAutogenAnexo>, ISolConexionAutogenAnexoRepository
    {
        public SolConexionAutogenAnexoRepository(DbSQLContext context)
            : base(context)
        {
        }

        public async Task<SolConexionAutogenAnexo> CreateEntity(SolConexionAutogenAnexo entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<List<SolConexionAutogenAnexo>> CreateEntity_Range(List<SolConexionAutogenAnexo> entity)
        {
            await AddRange(entity);
            return entity;
        }

        public async Task<bool> DeleteEntity(SolConexionAutogenAnexo entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.EstadoDocumento = 0;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return true;
        }

        public async Task<List<SolConexionAutogenAnexo>> GetEntities()
        {
            return await GetAll();
        }

        public async Task<List<SolConexionAutogenAnexo>> GetEntitiesByCodSolConexionAutogen(int codSolicitud)
        {
            return await _context.SolConexionAutogenAnexos.Where(x => x.CodSolConexionAutogen == codSolicitud && x.EstadoDocumento == 1).ToListAsync();
        }

        public async Task<SolConexionAutogenAnexo> GetEntity(int idEntity)
        {
            return await GetById(idEntity);
        }

        public async Task<SolConexionAutogenAnexo> UpdateEntity(SolConexionAutogenAnexo entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.CodSolConexionAutogen = entity.CodSolConexionAutogen;
            entidad.CodDocumentosXformulario = entity.CodDocumentosXformulario;
            entidad.NameDocument = entity.NameDocument;
            entidad.ExtDocument = entity.ExtDocument;
            entidad.SizeDocument = entity.SizeDocument;
            entidad.UrlDocument = entity.UrlDocument;
            entidad.UrlRelDocument = entity.UrlRelDocument;
            entidad.OriginalNameDocument = entity.OriginalNameDocument;
            entidad.EstadoDocumento = entity.EstadoDocumento;
            entidad.Expedicion = entity.Expedicion;
            entidad.ValidationDocument = entity.ValidationDocument;
            entidad.SendNotification = entity.SendNotification;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return entidad;
        }
    }
}
