namespace Infrastructure.Repositories.SQLContext
{
    using Core.Entities.SQLContext;
    using Core.Interfaces;
    using Core.Interfaces.SQLContext;
    using Dapper;
    using Infrastructure.Data;
    using Infrastructure.QueryStrings.SQLContext;
    using System.Data;
    using static Dapper.SqlMapper;

    public class SolConexionAutogenRepository
    : BaseRepository<SolConexionAutogen>, ISolConexionAutogenRepository
    {
        public SolConexionAutogenRepository(
            DbSQLContext context,
            IDbConnection dapperContext
        ) : base(context, dapperContext)
        {
        }

        public async Task<SolConexionAutogen> GetEntity(int id)
        {
            var param = new { IdSolicitud = id };

            string query = SolConexionAutogenQuery.GetEntity;

            var multi = await _dapperContext.QueryMultipleAsync(query, param);

            var solicitud = await multi.ReadFirstAsync<SolConexionAutogen>();
            //var clasificacion = (await multi.ReadAsync<ClasificacionProyecto>()).FirstOrDefault();
            //var comercializador = (await multi.ReadAsync<Comercializador>()).FirstOrDefault();
            var estadoSol = (await multi.ReadAsync<Estado>()).FirstOrDefault();
            var estadoVisita = (await multi.ReadAsync<Estado>()).FirstOrDefault();
            var estadoProrroga = (await multi.ReadAsync<Estado>()).FirstOrDefault();
            //var etapaSol = (await multi.ReadAsync<Etapa>()).FirstOrDefault();
            //var estrato = (await multi.ReadAsync<EstratoSocioeconomico>()).FirstOrDefault();
            //var tipoCliente = (await multi.ReadAsync<TipoCliente>()).FirstOrDefault();
            var tipoGeneracion = (await multi.ReadAsync<TipoGeneracion>()).FirstOrDefault();
            var tipoIdentificacion = (await multi.ReadAsync<TipoIdentificacion>()).FirstOrDefault();
            var solConexionAutogenBasadaInv = (await multi.ReadAsync<SolConexionAutogenBasadaInv>()).FirstOrDefault();
            var solConexionAutogenInfoEolica = (await multi.ReadAsync<SolConexionAutogenInfoEolica>()).FirstOrDefault();
            var solConexionAutogenInmueble = (await multi.ReadAsync<SolConexionAutogenInmueble>()).FirstOrDefault();
            var ciudad = (await multi.ReadAsync<Ciudad>()).FirstOrDefault();
            var departamento = (await multi.ReadAsync<Departamento>()).FirstOrDefault();
            var solConexionAutogenNoBasadaInv = (await multi.ReadAsync<SolConexionAutogenNoBasadaInv>()).FirstOrDefault();
            var solConexionAutogenTecnologias = (await multi.ReadAsync<SolConexionAutogenTecnologia>()).FirstOrDefault();
            var solConexionAutogenTecnologiasUtil = (await multi.ReadAsync<SolConexionAutogenTecnUtilizada>());

            //solicitud.CodClasificacionProyectoNavigation = clasificacion;
            //solicitud.CodComercializadorNavigation = comercializador;
            //solicitud.EstadoNavigation = estadoSol;
            //solicitud.EstadoVisitaNavigation = estadoVisita;
            //solicitud.UltimoEstadoProrrogaNavigation = estadoProrroga;
            //solicitud.EstadoNavigation.CodEtapaNavigation = etapaSol;
            //solicitud.CodEstratoClienteNavigation = estrato;
            //solicitud.CodTipoClienteNavigation = tipoCliente;
            //solicitud.CodTipoGeneracionNavigation = tipoGeneracion;
            //solicitud.CodTipoIdentificacionClienteNavigation = tipoIdentificacion;
            //solicitud.SolConexionAutogenBasadaInv = solConexionAutogenBasadaInv;
            //solicitud.SolConexionAutogenInfoEolica = solConexionAutogenInfoEolica;
            //solicitud.SolConexionAutogenInmueble = solConexionAutogenInmueble;
            solicitud.CodMunicipioClienteNavigation = ciudad;
            solicitud.CodDepartamentoClienteNavigation = departamento;
            //solicitud.SolConexionAutogenNoBasadaInv = solConexionAutogenNoBasadaInv;
            //solicitud.SolConexionAutogenTecnologia = solConexionAutogenTecnologias;
            solicitud.SolConexionAutogenTecnUtilizada = (ICollection<SolConexionAutogenTecnUtilizada>)solConexionAutogenTecnologiasUtil;

            return solicitud;
        }


        public async Task<List<SolConexionAutogenTecnUtilizada>> GetTecnologiasUtilBySolicitud(int idEntity)
        {
            var param = new { IdSolicitud = idEntity };

            var query = SolConexionAutogenQuery.GetTecnologiasUtilBySolicitud;
            return (await _dapperContext.QueryAsync<SolConexionAutogenTecnUtilizada>(query, param)).ToList();
        }

        public async Task<List<SolConexionAutogenAnexo>> GetAnexosBySolicitud(int idEntity)
        {
            var param = new { IdSolicitud = idEntity };

            var query = SolConexionAutogenQuery.GetAnexosBySolicitud;
            return (await _dapperContext.QueryAsync<SolConexionAutogenAnexo>(query, param)).ToList();
        }

        public async Task<List<PasosSolConexionAutogen>> GetPasosBySolicitud(int idEntity)
        {
            var param = new { IdSolicitud = idEntity };

            var query = SolConexionAutogenQuery.GetPasosBySolicitud;
            var result = await _dapperContext.QueryAsync<
                PasosSolConexionAutogen,
                Estado,
                PasosSolConexionAutogen
            >(
                query,
                (pasosSolConexionAutogen, estado) =>
                {
                    pasosSolConexionAutogen.CodEstadoNavigation = estado;
                    return pasosSolConexionAutogen;
                },
                param
            );

            return result.ToList();
        }

        public async Task<List<PasosSolConexionAutogen>> GetPasosByRadicado(string numRadicado)
        {
            var param = new { Radicado = numRadicado };

            var query = SolConexionAutogenQuery.GetPasosByRadicado;
            return (await _dapperContext.QueryAsync<PasosSolConexionAutogen, Estado, PasosSolConexionAutogen>(query,
                (pasosSolConexionAutogen, estado) =>
                {
                    pasosSolConexionAutogen.CodEstadoNavigation = estado;
                    return pasosSolConexionAutogen;
                }, param)).ToList();
        }
        

        public async Task<List<SolConexionAutogenObservacion>> GetObservacionBySolicitud(int idEntity)
        {
            var param = new { IdSolicitud = idEntity };

            var query = SolConexionAutogenQuery.GetObservacionBySolicitud;
            //return (await _dapperContext.QueryAsync<SolConexionAutogenObservacion, SolConexionAutogenObservacion>(query,
            //    (observacion, anexos) =>
            //    {
            //        if (anexos != null)
            //        {
            //            observacion.SolConexionAutogenObservacionAnexos.Add(anexos);
            //        }
            //        return observacion;
            //    }, param)).ToList();

            return null;
        }

        public async Task<List<SolConexionAutogenInsumo>> GetInsumosBySolicitud(int idEntity)
        {
            var param = new { IdSolicitud = idEntity };

            var query = SolConexionAutogenQuery.GetInsumosBySolicitud;

            //return (await _dapperContext.QueryAsync<SolConexionAutogenInsumo, SolConexionAutogenInsumosAnexo, SolConexionAutogenInsumo>(query,
            //    (insumo, anexos) =>
            //    {
            //        if (anexos != null)
            //        {
            //            insumo.SolConexionAutogenInsumosAnexos.Add(anexos);
            //        }
            //        return insumo;
            //    }, param)).ToList();

            return null;
        }
      
    }
}
