namespace Infrastructure.Repositories.EEP
{
    using Core.CustomEntities;
    using Core.Entities.Oracle;
    using Core.Enumerations;
    using Core.Exceptions;
    using Core.Interfaces.Oracle;
    using Infrastructure.Data;
    using Infrastructure.Interfaces;

    public class Creg_TransformadorRepositoryEEP : BaseRepositoryDapperOracleSpard<Transfor>, ICreg_TransformadorRepository
    {
        private readonly DbSpardContext _context;
        private readonly IDbConnectionFactory _dapperContext;

        public Creg_TransformadorRepositoryEEP(
            DbSpardContext context,
            IDbConnectionFactory dapperContext
        ) : base(context, _inPutParameterName, _outPutParameterName, dapperContext)
        {
            _context = context;
            _dapperContext = dapperContext;
        }

        static readonly string _inPutParameterName = "s_json_nueva_registro";
        static readonly string _outPutParameterName = "s_json_respuesta";

        public async Task<Transfor> GetEntityByCodigo(string codigo)
        {
            try
            {
                var resultado = await GetAll(filter: x => x.Code == codigo);
                return resultado.First();                
            }
            catch (Exception e)
            {
                throw new BusinessException($"Error: {e.Message}");
            }
        }       

        public async Task<TransformadorCircuitoDto> GetEntityByCodigoInfo(string codigo)
        {
            try
            {
                string sql = $@"SELECT 
                                -- TRANSFORMADOR
                                TRANSFOR.ADDRESS AS DIRECCION,
                                TRANSFOR.LATITUD AS LATITUD ,
                                TRANSFOR.LONGITUD AS LONGITUD,
                                TRANSFOR.CODE AS CODIGO,
                                TRANSFOR.UIA AS UIA,
                                TRANSFOR.OWNER AS PROPIETARIO,
                                (TRFTYPES.KV2 * (1000)) AS VOLT_NOMINAL,
                                TRFTYPES.KVA AS CAP_KVA,    
                                ROUND(TRANSFOR.PG,3) AS GEN_INSTALADA,
                                ROUND(TRANSFOR.CMP,3) AS CAP_MAX_DISPONIBLE,    
                                ROUND(TRANSFOR.SP,3) AS TOT_CAP_OCUPADA,
                                ROUND(TRANSFOR.EG,3) AS ENERGIA_TRAFO,
                                ROUND(TRANSFOR.EGV,3) AS ENER_GEN_NO_FV,
                                ROUND(TRANSFOR.SE,3) AS TOT_ENER_HOR_OCUPADA,    
                                ROUND(TRANSFOR.CME,3) AS CAP_MAX_ENER_HOR_DISPONIBLE,
                                ROUND(TRANSFOR.EG,3) AS ENERGIA_FV,    
                                ROUND(TRANSFOR.SE_12,3) AS ENER_HOR_OCUP_FV,
                                ROUND(TRANSFOR.CME_12,3) AS ENER_HOR_DISPO_FV,    
    
                                -- CIRCUITO
                                TRANSFOR.FPARENT AS CIRCUITO,    
                                ROUND(SRCBUSES.KV,2) AS VOLT_NOMINAL_CIRC,
                                ROUND((SRCBUSES.KV * FEEDERS.AMP*SQRT(3)),2) AS CAP_KVA_CIRC,    
                                ROUND(FEEDERS.PG,3) AS GENERACION_INST,    
                                ROUND(FEEDERS.CMP,3) AS CAP_MAX_DISPONIBLE_CIRC,    
                                ROUND(FEEDERS.SP,3) AS TOT_CAP_OCUPADA_CIRC,    
                                ROUND(FEEDERS.PROMEDIO_MINIMO_HORA,3) AS ENERGIA_CIRC,
                                ROUND(TRANSFOR.PROMEDIO_MINIMO_HORA_12,3) AS ENER_GENER_NO_FV_CIRC,
                                ROUND(TRANSFOR.PROMEDIO_MINIMO_HORA,3) AS TOT_ENER_HOR_OCUP_CIRC,        
                                ROUND(FEEDERS.CME,3) AS CAP_MAX_ENE_CIRC,
                                ROUND(FEEDERS.PROMEDIO_MINIMO_HORA_12,3) AS ENERGIA_FV_CIRC,
                                ROUND(FEEDERS.EGV,3) AS ENER_GENER_FV_CIRC,
                                ROUND(FEEDERS.SE_12,3) AS ENER_HOR_OCUP_FV_CIRC,    
                                ROUND(FEEDERS.CME_12,3) AS ENER_HOR_DISPO_FV_CIRC
                            FROM SPARD.TRANSFOR,
                                SPARD.TRFTYPES,
                                SPARD.FEEDERS,
                                SPARD.SRCBUSES
                            WHERE 
                                TRANSFOR.TRFTYPE = TRFTYPES.CODE 
                                AND TRANSFOR.FPARENT = FEEDERS.CODE 
                                AND FEEDERS.SOURCEBUS = SRCBUSES.CODE 
                                AND TRANSFOR.DELETED = 0 
                                AND TRANSFOR.CODE= '{codigo}'";

                var datos = await EjecutarConsultaListAsync<TransformadorCircuitoDto>(sql);
                return datos.First();
            }
            catch (Exception e)
            {
                throw new BusinessException($"Error: {e.Message}");
            }
        }


        public async Task<Transfor> GetCargabilidadTransformador(int ciudad, string codtrafo)
        {
            try
            {
                string TablaSpard = ciudad == (int)EmpresaEnum.Pereira
                 ? "TRANSFOR"
                 : $"SPARDPRU.TRANSFOR{SpardCTG.DBLINK}";

                string sql = @"
                WITH DATA AS (
                    SELECT
                        CL.TRANSFORMADOR_SIG AS CODE_T,
                        CASE WHEN CL.TIPO_USUARIO IN (9)
                                THEN CL.CONSUMO ELSE 0 END AS CONSUMO_T,

                        CASE WHEN CL.TIPO_USUARIO IN (1,4,10,8,17,5)
                                THEN CL.CONSUMO ELSE 0 END AS CONSUMO_360,

                        CASE WHEN CL.TIPO_USUARIO IN (2,3,7,0)
                                THEN CL.CONSUMO ELSE 0 END AS CONSUMO_240
                    FROM CLS_CLIENTES_SPARD@SAC CL
                    INNER JOIN CLIENTES@SAC CI
                        ON CI.CLIENTE_ID = CL.NUMERO_CLIENTE
                    WHERE CL.CICLO < 100
                        AND CI.MUNICIPIO != 147
                ),
                AGG AS (
                    SELECT
                        CODE_T,
                        SUM(CONSUMO_T)   AS CONSUMO_T,
                        SUM(CONSUMO_360) AS CONSUMO_360,
                        SUM(CONSUMO_240) AS CONSUMO_240
                    FROM DATA
                    GROUP BY CODE_T
                )
                SELECT
                    ROUND( ((A.CONSUMO_360 / 360) * 100 / T.KVA)
                            + ((A.CONSUMO_240 / 240) * 100 / T.KVA), 2
                    ) AS Impedance
                FROM AGG A
                JOIN (
                        SELECT CODE,
                                CASE
                                    WHEN TRFTYPE LIKE '%37.5%'  THEN 37.5
                                    WHEN TRFTYPE LIKE '%112.5%' THEN 112.5
                                    WHEN TRFTYPE LIKE '%II' THEN
                                        TO_NUMBER(
                                            SUBSTR(SUBSTR(TRFTYPE,4), 1,
                                                    LENGTH(SUBSTR(TRFTYPE,4)) - 6)
                                        )
                                    ELSE
                                        TO_NUMBER(
                                            SUBSTR(SUBSTR(TRFTYPE,4), 1,
                                                    LENGTH(SUBSTR(TRFTYPE,4)) - 3)
                                        )
                                END AS KVA
                        FROM " + TablaSpard + @" 
                        WHERE DELETED = 0
                        ) T
                    ON T.CODE = A.CODE_T
                WHERE A.CODE_T LIKE '%" + codtrafo + "%'";

                var datos = await EjecutarConsultaAsync<Transfor>(sql,null);
                return datos;
            }
            catch (Exception e)
            {
                throw new BusinessException($"Error: {e.Message}");
            }
        }


        public async Task<Transfor> GetEntityByCodigoCTG(string codigo)
        {
            try
            {
                string sql = $@"
                                SELECT 
                                    A.CODE,
                                    A.DESCRIPTIO,
                                    A.ADDRESS,
                                    A.PROJECT,
                                    A.ASSEMBLY,
                                    A.PICTURE,
                                    A.SYMBOL,
                                    A.PHASES,
                                    A.METERCODE,
                                    A.CUSTOMERS,
                                    A.CUSTOMER_0 AS CUSTOMER0,
                                    A.CUSTOMER_1 AS CUSTOMER1,
                                    A.CUSTOMER_2 AS CUSTOMER2,
                                    A.FPARENT,
                                    A.XPOS,
                                    A.YPOS,
                                    A.Z,
                                    A.XSIZE,
                                    A.YSIZE,
                                    A.INVNUMBER,
                                    A.DATUM,
                                    A.OWNER,
                                    A.OWNER1,
                                    A.ISON,
                                    A.R,
                                    A.G,
                                    A.B,
                                    A.TRFTYPE,
                                    A.FLAG,
                                    A.ELNODE,
                                    A.LVELNODE,
                                    A.PHNODE,
                                    A.MVA3PH_SCC AS MVA3PHSCC,
                                    A.MVA1PH_SCC AS MVA1PHSCC,
                                    A.CULOSSES,
                                    A.FELOSSES,
                                    A.IMPEDANCE,
                                    A.CODEBANK,
                                    A.ISOPEN,
                                    A.MUNICIPIO,
                                    A.DPTO,
                                    A.SERIAL,
                                    A.POBLACION,
                                    A.DATE_FAB AS DATEFAB,
                                    A.DATE_INST AS DATEINST,
                                    A.TYPE,
                                    A.IS_BANK AS ISBANK,
                                    A.NUM_TRFS AS NUMTRFS,
                                    A.ENEG,
                                    A.MARCA,
                                    A.DATE_REM AS DATEREM,
                                    A.LATITUD,
                                    A.TIPO_RED AS TIPORED,
                                    A.LONGITUD,
                                    A.PRSTATE,
                                    A.ESTADO,
                                    A.CLASE,
                                    A.ZONE,
                                    A.POWERDRAW,
                                    A.HEALTH,
                                    A.XOFFSET,
                                    A.YOFFSET,
                                    A.DEMANDA,
                                    A.LTOTAL,
                                    A.TIPOSUB,
                                    A.ZONAE,
                                    A.IDMERCADO,
                                    A.ISLIGHT,
                                    A.DELETED,
                                    A.TFILE,
                                    A.VALVULA,
                                    A.CASO,
                                    A.NCALIDAD,
                                    A.CALITAD,
                                    A.GRUPO,
                                    A.OWNER2,
                                    A.FLAG5,
                                    A.PCV,
                                    A.PROTOCOLO,
                                    A.DEP_ID AS DEPID,
                                    A.SEQUENCE,
                                    A.X,
                                    A.Y,
                                    A.COD_SIC AS CODSIC,
                                    A.ESTADOP,
                                    A.OWNERID,
                                    A.OWNERNAME,
                                    A.OWNERTEL,
                                    A.LIFESPAN,
                                    A.CODETAXO,
                                    A.GRUPO015,
                                    A.UIA,
                                    A.CONSECU015,
                                    A.DATE_RET AS DATERET,
                                    A.RPP,
                                    A.ISCRI,
                                    A.ISCRIN,
                                    A.ISCRINR,
                                    A.UCCAP14,
                                    A.XMAG,
                                    A.YMAG,
                                    A.PEND_REMUNERA AS PENDREMUNERA,
                                    A.EG,
                                    A.PG,
                                    A.EGV,
                                    A.CMP,
                                    A.CME,
                                    A.SP,
                                    A.SE,
                                    A.PROMEDIO_MINIMO_HORA AS PROMEDIOMINIMOHORA,
                                    A.CME_12 AS CME12,
                                    A.SE_12 AS SE12,
                                    A.PROMEDIO_MINIMO_HORA_12 AS PROMEDIOMINIMOHORA12,
                                    A.VSEC1,
                                    A.VSEC2
                                FROM SPARDPRU.TRANSFOR{SpardCTG.DBLINK} A                                
                                WHERE 
                                    A.CODE = '{codigo}'
                                    AND A.DELETED = 0";

                var datos = await EjecutarConsultaListAsync<Transfor>(sql);
                return datos.First();
            }
            catch (Exception e)
            {
                throw new BusinessException($"Error: {e.Message}");
            }
        }       

        public async Task<TransformadorCircuitoDto> GetEntityByCodigoInfoCTG(string codigo)
        {
            string sql = $@"SELECT 
                                -- TRANSFORMADOR
                                TRANSFOR.ADDRESS AS DIRECCION,
                                TRANSFOR.LATITUD AS LATITUD ,
                                TRANSFOR.LONGITUD AS LONGITUD,
                                TRANSFOR.CODE AS CODIGO,
                                TRANSFOR.UIA AS UIA,
                                TRANSFOR.OWNER AS PROPIETARIO,
                                (TRFTYPES.KV2 * (1000)) AS VOLT_NOMINAL,
                                TRFTYPES.KVA AS CAP_KVA,    
                                ROUND(TRANSFOR.PG,3) AS GEN_INSTALADA,
                                ROUND(TRANSFOR.CMP,3) AS CAP_MAX_DISPONIBLE,    
                                ROUND(TRANSFOR.SP,3) AS TOT_CAP_OCUPADA,
                                ROUND(TRANSFOR.EG,3) AS ENERGIA_TRAFO,
                                ROUND(TRANSFOR.EGV,3) AS ENER_GEN_NO_FV,
                                ROUND(TRANSFOR.SE,3) AS TOT_ENER_HOR_OCUPADA,    
                                ROUND(TRANSFOR.CME,3) AS CAP_MAX_ENER_HOR_DISPONIBLE,
                                ROUND(TRANSFOR.EG,3) AS ENERGIA_FV,    
                                ROUND(TRANSFOR.SE_12,3) AS ENER_HOR_OCUP_FV,
                                ROUND(TRANSFOR.CME_12,3) AS ENER_HOR_DISPO_FV,    
    
                                -- CIRCUITO
                                TRANSFOR.FPARENT AS CIRCUITO,    
                                ROUND(SRCBUSES.KV,2) AS VOLT_NOMINAL_CIRC,
                                ROUND((SRCBUSES.KV * FEEDERS.AMP*SQRT(3)),2) AS CAP_KVA_CIRC,    
                                ROUND(FEEDERS.PG,3) AS GENERACION_INST,    
                                ROUND(FEEDERS.CMP,3) AS CAP_MAX_DISPONIBLE_CIRC,    
                                ROUND(FEEDERS.SP,3) AS TOT_CAP_OCUPADA_CIRC,    
                                ROUND(FEEDERS.PROMEDIO_MINIMO_HORA,3) AS ENERGIA_CIRC,
                                ROUND(TRANSFOR.PROMEDIO_MINIMO_HORA_12,3) AS ENER_GENER_NO_FV_CIRC,
                                ROUND(TRANSFOR.PROMEDIO_MINIMO_HORA,3) AS TOT_ENER_HOR_OCUP_CIRC,        
                                ROUND(FEEDERS.CME,3) AS CAP_MAX_ENE_CIRC,
                                ROUND(FEEDERS.PROMEDIO_MINIMO_HORA_12,3) AS ENERGIA_FV_CIRC,
                                ROUND(FEEDERS.EGV,3) AS ENER_GENER_FV_CIRC,
                                ROUND(FEEDERS.SE_12,3) AS ENER_HOR_OCUP_FV_CIRC,    
                                ROUND(FEEDERS.CME_12,3) AS ENER_HOR_DISPO_FV_CIRC
                            FROM SPARDPRU.TRANSFOR{SpardCTG.DBLINK},
                                SPARDPRU.TRFTYPES{SpardCTG.DBLINK},
                                SPARDPRU.FEEDERS{SpardCTG.DBLINK},
                                SPARDPRU.SRCBUSES{SpardCTG.DBLINK}
                            WHERE 
                                TRANSFOR.TRFTYPE = TRFTYPES.CODE 
                                AND TRANSFOR.FPARENT = FEEDERS.CODE 
                                AND FEEDERS.SOURCEBUS = SRCBUSES.CODE 
                                AND TRANSFOR.DELETED = 0 
                                AND TRANSFOR.CODE= '{codigo}'";

            var datos = await EjecutarConsultaListAsync<TransformadorCircuitoDto>(sql);
            return datos.First();
        }
    }
}
