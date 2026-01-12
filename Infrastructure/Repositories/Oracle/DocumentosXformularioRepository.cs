namespace Infrastructure.Repositories.Oracle
{
    using Core.Entities.Oracle;
    using Core.Interfaces.Oracle;
    using Infrastructure.Data;
    using Infrastructure.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class DocumentosXformularioRepository : BaseRepositoryDapperOracle<CregDocumentosFormulario>, IDocumentosXformularioRepository
    {
        private readonly DbOracleContext _context;
        private readonly IDbConnectionFactory _dapperContext;

        public DocumentosXformularioRepository(
            DbOracleContext context,
            IDbConnectionFactory dapperContext
        ) : base(context, _inPutParameterName, _outPutParameterName, dapperContext)
        {
            _context = context;
            _dapperContext = dapperContext;
        }

        static readonly string _inPutParameterName = "s_json_nueva_registro";
        static readonly string _outPutParameterName = "s_json_respuesta";


        public async Task<List<CregDocumentosFormulario>> GetEntities()
        {
            return await GetAll();
        }

        public async Task<List<CregDocumentosFormulario>> GetEntitiesByCodFormulario(int codFormularioPrincipal)
        {
            return await _context.CregDocumentosFormulario
                .Where(x => x.CodFormulario == codFormularioPrincipal && x.IsCampo == true)
                .ToListAsync();
        }
    }
}
