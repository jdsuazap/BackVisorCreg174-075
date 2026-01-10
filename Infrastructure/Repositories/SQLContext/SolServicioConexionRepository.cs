namespace Infrastructure.Repositories.SQLContext
{
    using Core.Entities.SQLContext;
    using Core.Interfaces.SQLContext;
    using Dapper;
    using Infrastructure.Data;
    using Infrastructure.QueryStrings.SQLContext;
    using System.Data;
    using System.Linq.Expressions;

    public class SolServicioConexionRepository : BaseRepository<SolServicioConexion>, ISolServicioConexionRepository
    {
        private readonly Type[] RelationatedEntities_GetList = new[] {
            typeof(SolServicioConexion),
            typeof(TipoConexion),
            typeof(SolServicioConexionDatosSolicitante),
            typeof(SolServicioConexionDatosSuscriptor),
        };

        private readonly Type[] RelationatedEntities_GetListTrafo = new[] {
            typeof(SolServicioConexion),
            typeof(TipoConexion),
            typeof(SolServicioConexionDetalle),
        };

        private readonly Type[] RelationatedEntities = new[] {
            typeof(SolServicioConexion),
            typeof(TipoConexion),
            typeof(SolServicioConexionDatosSolicitante),
            typeof(Ciudad),
            typeof(Departamento),
            typeof(TipoIdentificacion),
            typeof(TipoPersona),
            typeof(SolServicioConexionDatosSuscriptor),
            typeof(Ciudad),
            typeof(Departamento),
            typeof(TipoIdentificacion),
            typeof(TipoPersona),
            typeof(SolServicioConexionDetalle),
            typeof(TipoTension),
            typeof(SolServicioConexionDetalleCuenta),
            typeof(TipoClaseCarga),
            typeof(SolServicioConexionPredio),
            typeof(TipoConstruccion),
            typeof(SolServicioConexionAnexo),
            typeof(PasosSolServicioConexion),
            typeof(SolServicioConexionComentario),
        };

        private readonly Type[] RelationatedEntities_Range = new[] {
            typeof(SolServicioConexion),
            typeof(SolServicioConexionDetalle),
            typeof(TipoConexion),
            typeof(TipoTension),
            typeof(SolServicioConexionFactibilidad),
            typeof(SolServicioConexionDisenio),
            typeof(SolServicioConexionReciboTecnico),
        };

        private readonly Type[] RelationatedEntitiesligth = new[] {
            typeof(SolServicioConexion),
            typeof(PasosSolServicioConexion),
        };

        private readonly Expression<Func<SolServicioConexion, object>>[] IncludeProperties = new Expression<Func<SolServicioConexion, object>>[]
        {
            // Agrega aquí las propiedades de navegación que deseas incluir
            entity => entity.SolServicioConexionDatosSolicitante,
            entity => entity.SolServicioConexionDatosSuscriptor,
            entity => entity.SolServicioConexionDetalle,
            entity => entity.SolServicioConexionDetalleCuenta,
            entity => entity.SolServicioConexionPredio,
            entity => entity.PasosSolServicioConexions,
        };

        public SolServicioConexionRepository(
            DbSQLContext context,
            IDbConnection dapperContext
        ) : base(context, dapperContext) { }

        

        public async Task<SolServicioConexion> GetEntity(int idEntity)
        {
            var param = new { IdSolicitud = idEntity };

            string query = SolServicioConexionQuery.GetEntity;

            var multi = await _dapperContext.QueryMultipleAsync(query, param);

            var solicitud = await multi.ReadFirstAsync<SolServicioConexion>();
            //var actividadEconomica = (await multi.ReadAsync<ActividadEconomica>()).FirstOrDefault();
            //var estadoSol = (await multi.ReadAsync<Estado>()).FirstOrDefault();
            //var etapaSol = (await multi.ReadAsync<Etapa>()).FirstOrDefault();
            //var estrato = (await multi.ReadAsync<EstratoSocioeconomico>()).FirstOrDefault();
            var tipoConexion = (await multi.ReadAsync<TipoConexion>()).FirstOrDefault();
            //var tipoCliente = (await multi.ReadAsync<TipoCliente>()).FirstOrDefault();

            var datosSolicitante = (await multi.ReadAsync<SolServicioConexionDatosSolicitante>()).FirstOrDefault();
            var datosSolicitanteCiudad = (await multi.ReadAsync<Ciudad>()).FirstOrDefault();
            var datosSolicitanteDepartamento = (await multi.ReadAsync<Departamento>()).FirstOrDefault();
            var datosSolicitanteTipoIdent = (await multi.ReadAsync<TipoIdentificacion>()).FirstOrDefault();
            var datosSolicitanteTipoPersona = (await multi.ReadAsync<TipoPersona>()).FirstOrDefault();

            var datosSuscriptor = (await multi.ReadAsync<SolServicioConexionDatosSuscriptor>()).FirstOrDefault();
            var datosSuscriptorCiudad = (await multi.ReadAsync<Ciudad>()).FirstOrDefault();
            var datosSuscriptorDepartamento = (await multi.ReadAsync<Departamento>()).FirstOrDefault();
            var datosSuscriptorTipoIdent = (await multi.ReadAsync<TipoIdentificacion>()).FirstOrDefault();
            var datosSuscriptorTipoPersona = (await multi.ReadAsync<TipoPersona>()).FirstOrDefault();

            var detalle = (await multi.ReadAsync<SolServicioConexionDetalle>()).FirstOrDefault();
            var detalleTipoTension = (await multi.ReadAsync<TipoTension>()).FirstOrDefault();

            var predio = (await multi.ReadAsync<SolServicioConexionPredio>()).FirstOrDefault();
            var predioTipoConstr = (await multi.ReadAsync<TipoConstruccion>()).FirstOrDefault();
            //var predioTipoZona = (await multi.ReadAsync<TipoZona>()).FirstOrDefault();

            var factibilidad = (await multi.ReadAsync<SolServicioConexionFactibilidad>()).ToList();

            //solicitud.CodActividadEconomicaNavigation = actividadEconomica;
            //solicitud.CodEstadoNavigation = estadoSol;
            //solicitud.CodEstadoNavigation.CodEtapaNavigation = etapaSol;
            //solicitud.CodEstratoNavigation = estrato;
            //solicitud.CodTipoConexionNavigation = tipoConexion;
            //solicitud.CodTipoUsoNavigation = tipoCliente;

            solicitud.SolServicioConexionDatosSolicitante = datosSolicitante;
            solicitud.SolServicioConexionDatosSolicitante.CodMunicipioNavigation = datosSolicitanteCiudad;
            solicitud.SolServicioConexionDatosSolicitante.CodDepartamentoNavigation = datosSolicitanteDepartamento;
            //solicitud.SolServicioConexionDatosSolicitante.CodTipoDocumentoNavigation = datosSolicitanteTipoIdent;
            //solicitud.SolServicioConexionDatosSolicitante.CodTipoPersonaNavigation = datosSolicitanteTipoPersona;

            solicitud.SolServicioConexionDatosSuscriptor = datosSuscriptor;
            solicitud.SolServicioConexionDatosSuscriptor.CodMunicipioNavigation = datosSuscriptorCiudad;
            solicitud.SolServicioConexionDatosSuscriptor.CodDepartamentoNavigation = datosSuscriptorDepartamento;
            //solicitud.SolServicioConexionDatosSuscriptor.CodTipoDocumentoNavigation = datosSuscriptorTipoIdent;
            //solicitud.SolServicioConexionDatosSuscriptor.CodTipoPersonaNavigation = datosSuscriptorTipoPersona;

            solicitud.SolServicioConexionDetalle = detalle;
            //solicitud.SolServicioConexionDetalle.CodNivelTensionNavigation = detalleTipoTension;

            solicitud.SolServicioConexionPredio = predio;
            //solicitud.SolServicioConexionPredio.CodTipoConstruccionNavigation = predioTipoConstr;
            //solicitud.SolServicioConexionPredio.CodTipoZonaNavigation = predioTipoZona;

            solicitud.SolServicioConexionFactibilidades = factibilidad;

            if (factibilidad.Count != 0)
            {
                //solicitud.SolServicioConexionFactibilidades.First().SolServicioConexionFactibilidadObservaciones = factibilidadObs;
            }

            return solicitud;
        }

        public async Task<List<SolServicioConexionAnexo>> GetAnexosBySolicitud(int idEntity)
        {
            var param = new { IdSolicitud = idEntity };

            var query = SolServicioConexionQuery.GetAnexosBySolicitud;
            return (await _dapperContext.QueryAsync<SolServicioConexionAnexo>(query, param)).ToList();
        }

        public async Task<List<SolServicioConexionDetalleCuenta>> GetDetalleCuentaBySolicitud(int idEntity)
        {
            var param = new { IdSolicitud = idEntity };

            var query = SolServicioConexionQuery.GetByDetalleCuentaSolicitud;
            return (await _dapperContext.QueryAsync<SolServicioConexionDetalleCuenta, TipoClaseCarga, SolServicioConexionDetalleCuenta>(query,
                (pasosSolServicioConexion, tipoClase) =>
                {
        
                    return pasosSolServicioConexion;
                }, param)).ToList();
        }

        public async Task<List<PasosSolServicioConexion>> GetPasosBySolicitud(int idEntity)
        {
            var param = new { IdSolicitud = idEntity };

            //var query = SolServicioConexionQuery.GetPasosBySolicitud;
            //return (await _dapperContext.QueryAsync<PasosSolServicioConexion, PasosSolServicioConexion>(query,
            //    (pasosSolServicioConexion) =>
            //    {
            //        pasosSolServicioConexion.CodEstadoNavigation = estado;
            //        pasosSolServicioConexion.CodEstadoNavigation.CodEtapaNavigation = etapa;
            //        return pasosSolServicioConexion;
            //    }, param)).ToList();

            return null;
        }

        public async Task<List<PasosSolServicioConexion>> GetPasosByRadicado(string numRadicado)
        {
            var param = new { Radicado = numRadicado };

            var query = SolServicioConexionQuery.GetPasosByRadicado;
            //return (await _dapperContext.QueryAsync<PasosSolServicioConexion, PasosSolServicioConexion>(query,
            //    (pasosSolServicioConexion) =>
            //    {
            //        pasosSolServicioConexion.CodEstadoNavigation = estado;
            //        pasosSolServicioConexion.CodEstadoNavigation.CodEtapaNavigation = etapa;
            //        return pasosSolServicioConexion;
            //    }, param)).ToList();

            return null;
        }
    }
}
