namespace Infrastructure.Repositories.SQLContext
{
    using Core.Entities.SQLContext;
    using Core.Enumerations;
    using Core.Interfaces.SQLContext;
    using Infrastructure.Data;
    using Infrastructure.QueryStrings.SQLContext;
    using System.Data;

    public class SolConexionAutogenComentarioRepository : BaseRepository<SolConexionAutogenComentario>, ISolConexionAutogenComentarioRepository
    {
        private readonly Type[] RelationatedEntities = new[] {
            typeof(SolConexionAutogenComentario),
        };

        public SolConexionAutogenComentarioRepository(DbSQLContext context, IDbConnection dapperContext)
            : base(context, dapperContext) { }

        public async Task<List<SolConexionAutogenComentario>> GetEntitiesByRequest(int idRequest)
        {

            string query = SolConexionAutogenComentarioQuery.GetEntities_ByRequesto.Replace("{IdSolConexionAutogenComentario}", idRequest.ToString())
                                                                                   .Replace("{idPerilUsuarioCliente}", ((int)PerfilesEnum.Usuario_CREG).ToString());
            var comentarios = (await Dapper_GetEntities(query, RelationatedEntities, SetRelacionEntidad, SetGroupByEntity)).ToList();

            return comentarios;
        }     

        private static SolConexionAutogenComentario SetRelacionEntidad(object[] objetos)
        {
            SolConexionAutogenComentario solicitud = objetos[0] as SolConexionAutogenComentario;          
            return solicitud;
        }

        private static IEnumerable<SolConexionAutogenComentario> SetGroupByEntity(IEnumerable<SolConexionAutogenComentario> comentarios)
        {
            var t = comentarios.GroupBy(s => s.Id)
                .Select(g =>
                {
                    SolConexionAutogenComentario entity = g.First();
                    return entity;
                });

            return t;
        }

    }
}
