using Core.Entities.SQLContext;
using Core.Enumerations;
using Core.Interfaces;
using Core.Interfaces.SQLContext;
using Infrastructure.Data;
using Infrastructure.QueryStrings.SQLContext;
using System.Data;

namespace Infrastructure.Repositories.SQLContext
{
    public class SolServicioConexionComentarioRepository : BaseRepository<SolServicioConexionComentario>, ISolServicioConexionComentarioRepository
    {
        private readonly Type[] RelationatedEntities = new[] {
            typeof(SolServicioConexionComentario)
        };

        public SolServicioConexionComentarioRepository(DbSQLContext context, IDbConnection dapperContext)
            : base(context, dapperContext) { }

        public async Task<SolServicioConexionComentario> CreateEntity(SolServicioConexionComentario entity)
        {
            await Add(entity);
            return entity;
        }

        public async Task<SolServicioConexionComentario> DeleteEntity(SolServicioConexionComentario entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.Estado = false;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return entidad;
        }

        public async Task<List<SolServicioConexionComentario>> GetEntities()
        {
            return await GetAll();
        }

        public async Task<SolServicioConexionComentario> GetEntity(int idEntity)
        {
            return await GetById(idEntity);
        }

        public async Task<List<SolServicioConexionComentario>> GetEntitiesByRequest( int idRequest)
        {

            string query = SolServicioConexionComentarioQuery.GetEntities_ByRequesto.Replace("{IdSolServicioConexionComentario}", idRequest.ToString())
                                                                                   .Replace("{idPerilUsuarioCliente}", ((int)PerfilesEnum.Usuario_CREG).ToString());
            var comentarios = (await Dapper_GetEntities(query, RelationatedEntities, SetRelacionEntidad, SetGroupByEntity)).ToList();

            return comentarios;
        }

        public async Task<List<SolServicioConexionComentario>> GetEntitiesRequestDetailsById(int idRequest)
        {

            string query = SolServicioConexionComentarioQuery.GetEntities_ByComment.Replace("{codSolServicioConexionComentario}", idRequest.ToString());
            var comentarios = (await Dapper_GetEntities(query, RelationatedEntities, SetRelacionEntidad, SetGroupByEntity)).ToList();

            return comentarios;
        }

        public async Task<SolServicioConexionComentario> UpdateEntity(SolServicioConexionComentario entity)
        {
            var entidad = await GetById(entity.Id);

            entidad.CodEstadoSolicitud = entity.CodEstadoSolicitud;
            entidad.CodPerfil = entity.CodPerfil;
            entidad.CodSolServicioConexion = entity.CodSolServicioConexion;
            entidad.CodSolServicioConexionComentario = entity.CodSolServicioConexionComentario;
            entidad.CodUsuario = entity.CodUsuario;
            entidad.DescripcionComentario = entity.DescripcionComentario;
            entidad.IsGestor = entity.IsGestor;
            entidad.IsPrivate = entity.IsPrivate;
            //entidad.SolServicioConexionComentarioAnexos = entity.SolServicioConexionComentarioAnexos;
            entidad.TituloComentario = entity.TituloComentario;
            entidad.Estado = entity.Estado;
            entidad.CodUserUpdate = entity.CodUserUpdate;
            entidad.FechaRegistroUpdate = entity.FechaRegistroUpdate;

            await Update(entidad);

            return entidad;
        }

        private static SolServicioConexionComentario SetRelacionEntidad(object[] objetos)
        {
            SolServicioConexionComentario solicitud = objetos[0] as SolServicioConexionComentario;
          

            //solicitud.CodUsuarioNavigation = usuario;
            //solicitud.CodPerfilNavigation = perfil;

            //if (anexos != null)
            //{
            //    solicitud.SolServicioConexionComentarioAnexos = new List<SolServicioConexionComentarioAnexo> { anexos };
            //}

            return solicitud;
        }

        private static IEnumerable<SolServicioConexionComentario> SetGroupByEntity(IEnumerable<SolServicioConexionComentario> comentarios)
        {
            var t = comentarios.GroupBy(s => s.Id)
                .Select(g =>
                {
                    SolServicioConexionComentario entity = g.First();
                    return entity;
                });

            return t;
        }
    }
}
