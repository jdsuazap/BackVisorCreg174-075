namespace Infrastructure.Repositories.Oracle
{
    using Core.Entities.Oracle;
    using Core.Interfaces.Oracle;
    using Dapper;
    using Infrastructure.Data;
    using Infrastructure.Interfaces;
    using Infrastructure.QueryStrings.SQLContext;

    public class SolConexionAutogenRepository
    : BaseRepositoryDapperOracle<Creg174Autogen>, ISolConexionAutogenRepository
    {
        private readonly DbOracleContext _context;
        private readonly IDbConnectionFactory _dapperContext;

        public SolConexionAutogenRepository(
            DbOracleContext context,
            IDbConnectionFactory dapperContext
        ) : base(context, _inPutParameterName, _outPutParameterName, dapperContext)
        {
            _context = context;
            _dapperContext = dapperContext;
        }

        static readonly string _inPutParameterName = "s_json_nueva_registro";
        static readonly string _outPutParameterName = "s_json_respuesta";

        public async Task<Creg174Autogen> GetEntity(int id)
        {
            var param = new { IdSolicitud = id };

            string query = SolConexionAutogenQuery.GetEntity;

            var multi = await EjecutarConsultaMultipleAsync(query, param);

            var solicitud = await multi.ReadFirstAsync<Creg174Autogen>();
            var clasificacion = (await multi.ReadAsync<CregClasificacionProyecto>()).FirstOrDefault();
            var comercializador = (await multi.ReadAsync<CregComercializador>()).FirstOrDefault();
            var estadoSol = (await multi.ReadAsync<CregEstado>()).FirstOrDefault();
            var estrato = (await multi.ReadAsync<CregEstratoSocioeconomico>()).FirstOrDefault();
            var tipoCliente = (await multi.ReadAsync<CregTipoCliente>()).FirstOrDefault();
            var tipoGeneracion = (await multi.ReadAsync<CregTipoGeneracion>()).FirstOrDefault();
            var tipoIdentificacion = (await multi.ReadAsync<CregTipoIdentificacion>()).FirstOrDefault();
            var solConexionAutogenBasadaInv = (await multi.ReadAsync<Creg174BasInv>()).FirstOrDefault();
            var solConexionAutogenInfoEolica = (await multi.ReadAsync<Creg174Infoeolica>()).FirstOrDefault();
            var solConexionAutogenInmueble = (await multi.ReadAsync<Creg174Inmueble>()).FirstOrDefault();
            var ciudad = (await multi.ReadAsync<CregCiudad>()).FirstOrDefault();
            var departamento = (await multi.ReadAsync<CregDepartamento>()).FirstOrDefault();
            var solConexionAutogenNoBasadaInv = (await multi.ReadAsync<Creg174NoBasInv>()).FirstOrDefault();
            var solConexionAutogenTecnologias = (await multi.ReadAsync<Creg174Tecnologia>()).FirstOrDefault();
            var solConexionAutogenTecnologiasUtil = await multi.ReadAsync<Creg174TecnUtilizada>();

            solicitud.CodClasificacionProyectoNavigation = clasificacion;
            solicitud.CodComercializadorNavigation = comercializador;
            solicitud.CodEstadoNavigation = estadoSol;
            solicitud.CodEstratoClienteNavigation = estrato;
            solicitud.CodTipoClienteNavigation = tipoCliente;
            solicitud.CodTipGeneracionNavigation = tipoGeneracion;
            solicitud.CodTipoIdentificacionNavigation = tipoIdentificacion;
            solicitud.Creg174BasInvs = solConexionAutogenBasadaInv;
            solicitud.Creg174Infoeolica = solConexionAutogenInfoEolica;
            solicitud.Creg174Inmuebles = solConexionAutogenInmueble;
            solicitud.CodMunicipioClienteNavigation = ciudad;
            solicitud.CodDepartamentoClienteNavigation = departamento;
            solicitud.Creg174NoBasInvs = solConexionAutogenNoBasadaInv;
            solicitud.Creg174Tecnologia = solConexionAutogenTecnologias;
            solicitud.Creg174TecnUtilizada = (ICollection<Creg174TecnUtilizada>)solConexionAutogenTecnologiasUtil;

            return solicitud;
        }


        public async Task<List<Creg174TecnUtilizada>> GetTecnologiasUtilBySolicitud(int idEntity)
        {
            var param = new { IdSolicitud = idEntity };

            var query = SolConexionAutogenQuery.GetTecnologiasUtilBySolicitud;
            var result = await EjecutarConsultaListAsync<Creg174TecnUtilizada>(query, param);

            return result.ToList();
        }

        public async Task<List<Creg174Anexo>> GetAnexosBySolicitud(int idEntity)
        {
            var param = new { IdSolicitud = idEntity };

            var query = SolConexionAutogenQuery.GetAnexosBySolicitud;

            var result = await EjecutarConsultaListAsync<Creg174Anexo>(query, param);

            return result.ToList();
        }


        //public async Task<List<PasosSolConexionAutogen>> GetPasosBySolicitud(int idEntity)
        //{
        //    var param = new { IdSolicitud = idEntity };

        //    var query = SolConexionAutogenQuery.GetPasosBySolicitud;
        //    var result = await _dapperContext.QueryAsync<
        //        PasosSolConexionAutogen,
        //        Estado,
        //        PasosSolConexionAutogen
        //    >(
        //        query,
        //        (pasosSolConexionAutogen, estado) =>
        //        {
        //            pasosSolConexionAutogen.CodEstadoNavigation = estado;
        //            return pasosSolConexionAutogen;
        //        },
        //        param
        //    );

        //    return result.ToList();
        //}

        //public async Task<List<PasosSolConexionAutogen>> GetPasosByRadicado(string numRadicado)
        //{
        //    var param = new { Radicado = numRadicado };

        //    var query = SolConexionAutogenQuery.GetPasosByRadicado;
        //    return (await _dapperContext.QueryAsync<PasosSolConexionAutogen, Estado, PasosSolConexionAutogen>(query,
        //        (pasosSolConexionAutogen, estado) =>
        //        {
        //            pasosSolConexionAutogen.CodEstadoNavigation = estado;
        //            return pasosSolConexionAutogen;
        //        }, param)).ToList();
        //}


        //public async Task<List<SolConexionAutogenObservacion>> GetObservacionBySolicitud(int idEntity)
        //{
        //    var param = new { IdSolicitud = idEntity };

        //    var query = SolConexionAutogenQuery.GetObservacionBySolicitud;
        //    //return (await _dapperContext.QueryAsync<SolConexionAutogenObservacion, SolConexionAutogenObservacion>(query,
        //    //    (observacion, anexos) =>
        //    //    {
        //    //        if (anexos != null)
        //    //        {
        //    //            observacion.SolConexionAutogenObservacionAnexos.Add(anexos);
        //    //        }
        //    //        return observacion;
        //    //    }, param)).ToList();

        //    return null;
        //}
    }
}
