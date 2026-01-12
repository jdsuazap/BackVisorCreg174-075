namespace Infrastructure.Repositories.Oracle
{
    using Core.Entities.Oracle;
    using Core.Interfaces.Oracle;
    using Dapper;
    using Dapper.Oracle;
    using Infrastructure.Data;
    using Infrastructure.Interfaces;
    using Infrastructure.QueryStrings.SQLContext;
    using System.Data;

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

        public async Task<Creg174Autogen?> GetEntity(int idSolicitud, int? CodEmpresa)
        {
            var parameters = new OracleDynamicParameters();

            parameters.Add("P_ID_SOLICITUD",idSolicitud,OracleMappingType.Int32,ParameterDirection.Input);
            parameters.Add("P_ID_EMPRESA", CodEmpresa, OracleMappingType.Int32,ParameterDirection.Input);

            parameters.Add("O_SOLICITUD", null, OracleMappingType.RefCursor,ParameterDirection.Output);
            parameters.Add("O_CLASIFICACION", null, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.Add("O_COMERCIALIZADOR", null, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.Add("O_ESTADO", null, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.Add("O_ESTRATO", null, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.Add("O_TIPO_CLIENTE", null, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.Add("O_TIPO_GENERACION", null, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.Add("O_TIPO_IDENTIFICACION", null, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.Add("O_BAS_INV", null, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.Add("O_INFO_EOLICA", null, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.Add("O_INMUEBLE", null, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.Add("O_CIUDAD", null, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.Add("O_DEPARTAMENTO", null, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.Add("O_NO_BAS_INV", null, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.Add("O_TECNOLOGIAS", null, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.Add("O_TECN_UTILIZADAS", null, OracleMappingType.RefCursor, ParameterDirection.Output);

            using var multi = await EjecutarProcedimientoMultipleAsync(
                "PKG_GET.CREG_174_AUTOGEN",
                parameters
            );

            var solicitud = await multi.ReadFirstOrDefaultAsync<Creg174Autogen>();
            if (solicitud == null)
                return null;

            solicitud.CregClasificacionProyecto =
                (await multi.ReadAsync<CregClasificacionProyecto>()).FirstOrDefault();

            solicitud.CregComercializador =
                (await multi.ReadAsync<CregComercializador>()).FirstOrDefault();

            solicitud.CregEstado =
                (await multi.ReadAsync<CregEstado>()).FirstOrDefault();

            solicitud.CregEstratoSocioeconomico =
                (await multi.ReadAsync<CregEstratoSocioeconomico>()).FirstOrDefault();

            solicitud.CregTipoCliente =
                (await multi.ReadAsync<CregTipoCliente>()).FirstOrDefault();

            solicitud.CregTipoGeneracion =
                (await multi.ReadAsync<CregTipoGeneracion>()).FirstOrDefault();

            solicitud.CregTipoIdentificacion =
                (await multi.ReadAsync<CregTipoIdentificacion>()).FirstOrDefault();

            solicitud.Creg174BasInv =
                (await multi.ReadAsync<Creg174BasInv>()).FirstOrDefault();

            solicitud.Creg174Infoeolica =
                (await multi.ReadAsync<Creg174Infoeolica>()).FirstOrDefault();

            solicitud.Creg174Inmueble =
                (await multi.ReadAsync<Creg174Inmueble>()).FirstOrDefault();

            solicitud.CregCiudad =
                (await multi.ReadAsync<CregCiudad>()).FirstOrDefault();

            solicitud.CregDepartamento =
                (await multi.ReadAsync<CregDepartamento>()).FirstOrDefault();

            solicitud.Creg174NoBasInv =
                (await multi.ReadAsync<Creg174NoBasInv>()).FirstOrDefault();

            solicitud.Creg174Tecnologia =
                (await multi.ReadAsync<Creg174Tecnologia>()).FirstOrDefault();

            solicitud.Creg174TecnUtilizada =
                (await multi.ReadAsync<Creg174TecnUtilizada>()).ToList();

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
