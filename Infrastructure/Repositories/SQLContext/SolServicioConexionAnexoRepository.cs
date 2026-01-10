using Core.Entities.SQLContext;
using Core.Interfaces;
using Core.Interfaces.SQLContext;
using Infrastructure.Data;
using System.Data;

namespace Infrastructure.Repositories.SQLContext
{
    public class SolServicioConexionAnexoRepository : BaseRepository<SolServicioConexionAnexo>, ISolServicioConexionAnexoRepository
    {
        public SolServicioConexionAnexoRepository(DbSQLContext context, IDbConnection dapperContext)
            : base(context, dapperContext) { }

        public async Task<SolServicioConexionAnexo> CreateEntity(SolServicioConexionAnexo entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<List<SolServicioConexionAnexo>> CreateEntity_Range(List<SolServicioConexionAnexo> entity)
        {
            await AddRange(entity);
            return entity;
        }

        public async Task<bool> DeleteEntity(SolServicioConexionAnexo entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.EstadoDocumento = 0;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return true;
        }

        public async Task<List<SolServicioConexionAnexo>> GetEntities()
        {
            return await GetAll();
        }

        public async Task<SolServicioConexionAnexo> GetEntity(int idEntity)
        {
            return await GetById(idEntity);
        }

        public async Task<SolServicioConexionAnexo> UpdateEntity(SolServicioConexionAnexo entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.CodSolServicioConexion = entity.CodSolServicioConexion;
            entidad.CodDocumentosXFormulario = entity.CodDocumentosXFormulario;
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
