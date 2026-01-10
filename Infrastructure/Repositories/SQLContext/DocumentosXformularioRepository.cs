namespace Infrastructure.Repositories.SQLContext
{
    using Core.Entities.SQLContext;
    using Core.Interfaces.SQLContext;
    using Infrastructure.Data;   

    public class DocumentosXformularioRepository : BaseRepository<DocumentosXformulario>, IDocumentosXformularioRepository
    {
        public DocumentosXformularioRepository(DbSQLContext context) : base(context)
        {
        }

        public async Task<List<DocumentosXformulario>> GetEntities()
        {
            return await GetAll();
        }
    }
}
