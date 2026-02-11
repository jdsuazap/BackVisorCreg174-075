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
    using System.Linq.Expressions;

    public class SolServicioConexionRepository : BaseRepositoryDapperOracle<Creg075ServicioConexion>, ISolServicioConexionRepository
    {
        private readonly DbOracleContext _context;
        private readonly IDbConnectionFactory _dapperContext;

        public SolServicioConexionRepository(
            DbOracleContext context,
            IDbConnectionFactory dapperContext
        ) : base(context, _inPutParameterName, _outPutParameterName, dapperContext)
        {
            _context = context;
            _dapperContext = dapperContext;
        }

        static readonly string _inPutParameterName = "s_json_nueva_registro";
        static readonly string _outPutParameterName = "s_json_respuesta";

        private readonly Expression<Func<Creg075ServicioConexion, object>>[] IncludeProperties = new Expression<Func<Creg075ServicioConexion, object>>[]
        {
            // Agrega aquí las propiedades de navegación que deseas incluir
            entity => entity.Creg075Solicitantes,
            entity => entity.Creg075Suscriptors,
            entity => entity.Creg075Detalles,
            entity => entity.Creg075DetallesCuentas,
            entity => entity.Creg075Predios,
            //entity => entity.PasosSolServicioConexions,
        };

        public async Task<Creg075ServicioConexion> GetEntity(int idEntity, int Empresa)
        {
            var parameters = new OracleDynamicParameters();

            parameters.Add("P_ID_SOLICITUD", idEntity, OracleMappingType.Int32, ParameterDirection.Input);
            parameters.Add("P_ID_EMPRESA", Empresa, OracleMappingType.Int32, ParameterDirection.Input);

            parameters.Add("O_SOLICITUD", null, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.Add("O_ACT_ECONOMICA", null, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.Add("O_ESTADO", null, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.Add("O_ETAPA", null, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.Add("O_ESTRATO", null, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.Add("O_TIPO_CONEXION", null, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.Add("O_TIPO_CLIENTE", null, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.Add("O_SOLICITANTE", null, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.Add("O_SOLICITANTE_CIUDAD", null, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.Add("O_SOLICITANTE_DEPTO", null, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.Add("O_SOLICITANTE_TIPO_IDEN", null, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.Add("O_SOLICITANTE_TIPO_PERS", null, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.Add("O_SUSCRIPTOR", null, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.Add("O_SUSCRIPTOR_CIUDAD", null, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.Add("O_SUSCRIPTOR_DEPTO", null, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.Add("O_SUSCRIPTOR_TIPO_IDEN", null, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.Add("O_SUSCRIPTOR_TIPO_PERS", null, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.Add("O_DETALLE", null, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.Add("O_TIPO_TENSION", null, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.Add("O_PREDIO", null, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.Add("O_TIPO_CONSTRUCCION", null, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.Add("O_TIPO_ZONA", null, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.Add("O_FACTIBILIDAD", null, OracleMappingType.RefCursor, ParameterDirection.Output);
            //parameters.Add("O_FACTIBILIDAD_OBS", null, OracleMappingType.RefCursor, ParameterDirection.Output);

            //string query = SolServicioConexionQuery.GetEntity;

            using var multi = await EjecutarProcedimientoMultipleAsync(
                "PKG_GET.CREG_075_SERVICIO",
                parameters
            );

            var solicitud = await multi.ReadFirstOrDefaultAsync<Creg075ServicioConexion>();
            if (solicitud == null)
                return null;

            var actividadEconomica = (await multi.ReadAsync<CregActividadEconomica>()).FirstOrDefault();
            var estadoSol = (await multi.ReadAsync<CregEstado>()).FirstOrDefault();
            var etapaSol = (await multi.ReadAsync<CregEtapa>()).FirstOrDefault();
            var estrato = (await multi.ReadAsync<CregEstratoSocioeconomico>()).FirstOrDefault();
            var tipoConexion = (await multi.ReadAsync<CregTipoConexion>()).FirstOrDefault();
            var tipoCliente = (await multi.ReadAsync<CregTipoCliente>()).FirstOrDefault();

            var datosSolicitante = (await multi.ReadAsync<Creg075Solicitante>()).FirstOrDefault();
            var datosSolicitanteCiudad = (await multi.ReadAsync<CregCiudad>()).FirstOrDefault();
            var datosSolicitanteDepartamento = (await multi.ReadAsync<CregDepartamento>()).FirstOrDefault();
            var datosSolicitanteTipoIdent = (await multi.ReadAsync<CregTipoIdentificacion>()).FirstOrDefault();
            var datosSolicitanteTipoPersona = (await multi.ReadAsync<CregTipoPersona>()).FirstOrDefault();

            var datosSuscriptor = (await multi.ReadAsync<Creg075Suscriptor>()).FirstOrDefault();
            var datosSuscriptorCiudad = (await multi.ReadAsync<CregCiudad>()).FirstOrDefault();
            var datosSuscriptorDepartamento = (await multi.ReadAsync<CregDepartamento>()).FirstOrDefault();
            var datosSuscriptorTipoIdent = (await multi.ReadAsync<CregTipoIdentificacion>()).FirstOrDefault();
            var datosSuscriptorTipoPersona = (await multi.ReadAsync<CregTipoPersona>()).FirstOrDefault();

            var detalle = (await multi.ReadAsync<Creg075Detalle>()).FirstOrDefault();
            var detalleTipoTension = (await multi.ReadAsync<CregTipoTension>()).FirstOrDefault();

            var predio = (await multi.ReadAsync<Creg075Predio>()).FirstOrDefault();
            var predioTipoConstr = (await multi.ReadAsync<CregTipoConstruccion>()).FirstOrDefault();
            var predioTipoZona = (await multi.ReadAsync<CregTipoZona>()).FirstOrDefault();

            var factibilidad = (await multi.ReadAsync<Creg075Factibilidad>()).ToList();

            solicitud.CodActividadEconomicaNavigation = actividadEconomica;
            solicitud.CodEstadoNavigation = estadoSol;
            //solicitud.CodEstadoNavigation.CodEtapaNavigation = etapaSol;
            solicitud.CodEstratoNavigation = estrato;
            solicitud.CodTipoConexionNavigation = tipoConexion;
            //solicitud.CodTipoUso = tipoCliente;

            solicitud.Creg075Solicitantes = new List<Creg075Solicitante> { datosSolicitante };
            solicitud.Creg075Solicitantes.First().CodMunicipioNavigation = datosSolicitanteCiudad;
            solicitud.Creg075Solicitantes.First().CodDepartamentoNavigation = datosSolicitanteDepartamento;
            solicitud.Creg075Solicitantes.First().CodTipoDocumentoNavigation = datosSolicitanteTipoIdent;
            solicitud.Creg075Solicitantes.First().CodTipoPersonaNavigation = datosSolicitanteTipoPersona;

            solicitud.Creg075Suscriptors = datosSuscriptor;
            solicitud.Creg075Suscriptors.CodMunicipioNavigation = datosSuscriptorCiudad;
            solicitud.Creg075Suscriptors.CodDepartamentoNavigation = datosSuscriptorDepartamento;
            solicitud.Creg075Suscriptors.CodTipoDocumentoNavigation = datosSuscriptorTipoIdent;
            solicitud.Creg075Suscriptors.CodTipoPersonaNavigation = datosSuscriptorTipoPersona;

            solicitud.Creg075Detalles = detalle;
            solicitud.Creg075Detalles.CodTensionNavigation = detalleTipoTension;

            solicitud.Creg075Predios = predio;
            solicitud.Creg075Predios.CodTipoConstruccionNavigation = predioTipoConstr;
            solicitud.Creg075Predios.CodZonaNavigation = predioTipoZona;

            solicitud.Creg075Factibilidads = factibilidad;

            if (factibilidad.Count != 0)
            {
                //solicitud.Creg075Factibilidads.First().SolServicioConexionFactibilidadObservaciones = factibilidadObs;
            }

            return solicitud;
        }

        public async Task<List<Creg075Anexo>> GetAnexosBySolicitud(int idEntity)
        {
            var param = new { IdSolicitud = idEntity };

            var query = SolServicioConexionQuery.GetAnexosBySolicitud;
            return (await _dapperContext.QueryAsync<Creg075Anexo>(query, param)).ToList();
        }

        public async Task<List<Creg075DetallesCuenta>> GetDetalleCuentaBySolicitud(int idEntity)
        {
            var param = new { IdSolicitud = idEntity };

            var query = SolServicioConexionQuery.GetByDetalleCuentaSolicitud;
            var result = await _dapperContext.QueryAsync<Creg075DetallesCuenta, CregTipoCliente, CregTipoClaseCarga, Creg075DetallesCuenta>(query,
                (DetallesCuenta, tipoCliente, tipoClase) =>
                {
                    //DetallesCuenta.CodTipoCargaNavigation = tipoCliente;
                    DetallesCuenta.CodTipoClaseCargaNavigation = tipoClase;

                    return DetallesCuenta;
                }, param);

            return result.ToList();
        }

        public async Task<List<Creg075Pasos>> GetPasosBySolicitud(int idEntity)
        {
            var param = new { IdSolicitud = idEntity };

            var query = SolServicioConexionQuery.GetPasosBySolicitud;
            return (await _dapperContext.QueryAsync<Creg075Pasos, CregEstado, CregEtapa, Creg075Pasos>(query,
                (pasosSolServicioConexion, estado, etapa) =>
                {
                    pasosSolServicioConexion.CregEstado = estado;
                    pasosSolServicioConexion.CregEstado.CregEtapa = etapa;
                    return pasosSolServicioConexion;
                }, param)).ToList();
        }

        //public async Task<List<PasosSolServicioConexion>> GetPasosByRadicado(string numRadicado)
        //{
        //    var param = new { Radicado = numRadicado };

        //    var query = SolServicioConexionQuery.GetPasosByRadicado;
        //    //return (await _dapperContext.QueryAsync<PasosSolServicioConexion, PasosSolServicioConexion>(query,
        //    //    (pasosSolServicioConexion) =>
        //    //    {
        //    //        pasosSolServicioConexion.CodEstadoNavigation = estado;
        //    //        pasosSolServicioConexion.CodEstadoNavigation.CodEtapaNavigation = etapa;
        //    //        return pasosSolServicioConexion;
        //    //    }, param)).ToList();

        //    return null;
        //}
    }
}
