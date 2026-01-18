namespace Infrastructure.QueryStrings.SQLContext
{
    internal static class SolServicioConexionQuery
    {
        internal const string GetEntities = @"
            WITH CTE_SolConexion AS (
                SELECT *
                FROM [sol].[SolServicioConexion] (NOLOCK)
                ORDER BY IdSolServicioConexion ASC
                OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY
            )
            SELECT 
                a.IdSolServicioConexion						AS Id, a.*
                , es.parIdEstado							AS Id, es.*
                , tc.IdTipoConexion							AS Id, tc.*
	            , ds.IdSolServicioConexionDatosSolicitantes	AS Id, ds.*
	            , ds2.IdSolServicioConexionDatosSuscriptor	AS Id, ds2.*
            FROM CTE_SolConexion a
            INNER JOIN par.Estados es (NOLOCK) ON a.CodEstado = es.parIdEstado 
            INNER JOIN par.TipoConexion tc (NOLOCK) ON a.CodTipoConexion = tc.IdTipoConexion
            INNER JOIN sol.SolServicioConexionDatosSolicitantes ds (NOLOCK) ON a.IdSolServicioConexion = ds.CodSolServicioConexion
            INNER JOIN sol.SolServicioConexionDatosSuscriptor ds2 (NOLOCK) ON a.IdSolServicioConexion = ds2.CodSolServicioConexion
        ";

        internal const string GetEntities_Descending = @"
            WITH CTE_SolConexion AS (
                SELECT *
                FROM [sol].[SolServicioConexion] (NOLOCK)
                WHERE Empresa = @Empresa
                ORDER BY IdSolServicioConexion DESC
                OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY
            )
            SELECT 
                a.IdSolServicioConexion						AS Id, a.*
                , es.parIdEstado							AS Id, es.*
                , tc.IdTipoConexion							AS Id, tc.*
	            , ds.IdSolServicioConexionDatosSolicitantes	AS Id, ds.*
	            , ds2.IdSolServicioConexionDatosSuscriptor	AS Id, ds2.*
            FROM CTE_SolConexion a
            INNER JOIN par.Estados es (NOLOCK) ON a.CodEstado = es.parIdEstado 
            INNER JOIN par.TipoConexion tc (NOLOCK) ON a.CodTipoConexion = tc.IdTipoConexion
            INNER JOIN sol.SolServicioConexionDatosSolicitantes ds (NOLOCK) ON a.IdSolServicioConexion = ds.CodSolServicioConexion
            INNER JOIN sol.SolServicioConexionDatosSuscriptor ds2 (NOLOCK) ON a.IdSolServicioConexion = ds2.CodSolServicioConexion
        ";

        internal const string GetEntities_RangoFecha = @"
            WITH CTE_SolConexion AS (
                SELECT *
                FROM [sol].[SolServicioConexion] (NOLOCK)
                WHERE FechaRegistro >= @FechaIni AND FechaRegistro < @FechaFin
                    AND Empresa = @Empresa
            )
            select
                 a.IdSolServicioConexion						    AS Id, a.*
                , b.IdSolServicioConexionDatosSolicitantes	        AS Id, b.*
	            , d.IdSolServicioConexionDetalle                    AS Id, d.*
	            , f.IdTipoConexion                          	    AS Id, f.*
	            , g.IdTipoTension                           	    AS Id, g.*
	            , h.IdSolServicioConexionFactibilidad       	    AS Id, h.*
	            , j.IdSolServicioConexionFactibilidadObservaciones  AS Id, j.*
	            , m.IdSolServicioConexionReciboTecnico        	AS Id, m.*
                from
	                CTE_SolConexion a
                left join [sol].[SolServicioConexionDatosSolicitantes] b on a.IdSolServicioConexion = b.CodSolServicioConexion
                left join [sol].[SolServicioConexionDetalle] d on a.IdSolServicioConexion = d.CodSolServicioConexion
                left join [par].[TipoConexion] f on a.CodTipoConexion = f.IdTipoConexion
                left join [par].[TipoTension] g on d.CodNivelTension = g.IdTipoTension
                left join [sol].[SolServicioConexionFactibilidad] h on a.IdSolServicioConexion = h.CodSolServicioConexion
                left join [sol].[SolServicioConexionFactibilidadObservaciones] j on h.IdSolServicioConexionFactibilidad = j.CodSolServicioConexionFactibilidad                
                left join [sol].[SolServicioConexionReciboTecnico] m on a.IdSolServicioConexion = m.CodSolServicioConexion               
        ";

        internal const string GetEntity = @"
            SELECT IdSolServicioConexion AS Id, * FROM [sol].[SolServicioConexion] (NOLOCK) WHERE IdSolServicioConexion = @IdSolicitud;

            SELECT b.IdActividadEconomica AS Id, b.* 
            FROM sol.SolServicioConexion a (NOLOCK) 
            LEFT JOIN par.ActividadEconomica b (NOLOCK) ON a.CodActividadEconomica = b.IdActividadEconomica
            WHERE IdSolServicioConexion = @IdSolicitud;

            SELECT es.parIdEstado AS Id, es.* 
            FROM sol.SolServicioConexion a (NOLOCK) 
            INNER JOIN par.Estados es (NOLOCK) ON a.CodEstado = es.parIdEstado
            WHERE IdSolServicioConexion = @IdSolicitud;

            SELECT et.IdEtapa AS Id, et.* 
            FROM sol.SolServicioConexion a (NOLOCK) 
            INNER JOIN par.Estados es (NOLOCK) ON a.CodEstado = es.parIdEstado
            LEFT  JOIN par.Etapas et (NOLOCK) ON es.CodEtapa = et.IdEtapa
            WHERE IdSolServicioConexion = @IdSolicitud;

            SELECT est.IdEstratoSocioeconomico AS Id, est.* 
            FROM sol.SolServicioConexion a (NOLOCK) 
            LEFT JOIN par.EstratoSocioeconomico est (NOLOCK) ON a.CodEstrato = est.IdEstratoSocioeconomico 
            WHERE a.IdSolServicioConexion = @IdSolicitud;

            SELECT b.IdTipoConexion AS Id, b.* 
            FROM sol.SolServicioConexion a (NOLOCK) 
            INNER JOIN par.TipoConexion b (NOLOCK) ON a.CodTipoConexion = b.IdTipoConexion 
            WHERE a.IdSolServicioConexion = @IdSolicitud;

            SELECT b.IdTipoCliente AS Id, b.* 
            FROM sol.SolServicioConexion a (NOLOCK) 
            LEFT JOIN par.TipoCliente b (NOLOCK) ON a.CodTipoUso = b.IdTipoCliente 
            WHERE a.IdSolServicioConexion = @IdSolicitud;

            SELECT IdSolServicioConexionDatosSolicitantes AS Id, * 
            FROM sol.SolServicioConexionDatosSolicitantes (NOLOCK) 
            WHERE CodSolServicioConexion = @IdSolicitud;

            SELECT b.IdCiudad AS Id, b.* 
            FROM sol.SolServicioConexionDatosSolicitantes a (NOLOCK) 
            INNER JOIN par.Ciudad b (NOLOCK) ON a.CodMunicipio = b.IdCiudad 
            WHERE CodSolServicioConexion = @IdSolicitud;

            SELECT c.IdDepartamento AS Id, c.* 
            FROM sol.SolServicioConexionDatosSolicitantes a (NOLOCK) 
            INNER JOIN par.Ciudad b (NOLOCK) ON a.CodMunicipio = b.IdCiudad 
            INNER JOIN par.Departamento c (NOLOCK) ON b.CodDepartamento = c.IdDepartamento 
            WHERE CodSolServicioConexion = @IdSolicitud;

            SELECT b.IdTipoIdentificacion AS Id, b.* 
            FROM sol.SolServicioConexionDatosSolicitantes a (NOLOCK) 
            INNER JOIN par.TipoIdentificacion b (NOLOCK) ON a.CodTipoDocumento = b.IdTipoIdentificacion
            WHERE CodSolServicioConexion = @IdSolicitud;

            SELECT b.IdTipoPersona AS Id, b.* 
            FROM sol.SolServicioConexionDatosSolicitantes a (NOLOCK) 
            INNER JOIN par.TipoPersona b (NOLOCK) ON a.CodTipoPersona = b.IdTipoPersona
            WHERE CodSolServicioConexion = @IdSolicitud;
            
            SELECT IdSolServicioConexionDatosSuscriptor AS Id, * 
            FROM sol.SolServicioConexionDatosSuscriptor (NOLOCK) 
            WHERE CodSolServicioConexion = @IdSolicitud;
            
            SELECT b.IdCiudad AS Id, b.* 
            FROM sol.SolServicioConexionDatosSuscriptor a (NOLOCK) 
            INNER JOIN par.Ciudad b (NOLOCK) ON a.CodMunicipio = b.IdCiudad 
            WHERE CodSolServicioConexion = @IdSolicitud;
            
            SELECT c.IdDepartamento AS Id, c.* 
            FROM sol.SolServicioConexionDatosSuscriptor a (NOLOCK) 
            INNER JOIN par.Ciudad b (NOLOCK) ON a.CodMunicipio = b.IdCiudad 
            INNER JOIN par.Departamento c (NOLOCK) ON b.CodDepartamento = c.IdDepartamento 
            WHERE CodSolServicioConexion = @IdSolicitud;
            
            SELECT b.IdTipoIdentificacion AS Id, b.* 
            FROM sol.SolServicioConexionDatosSuscriptor a (NOLOCK) 
            INNER JOIN par.TipoIdentificacion b (NOLOCK) ON a.CodTipoDocumento = b.IdTipoIdentificacion
            WHERE CodSolServicioConexion = @IdSolicitud;
            
            SELECT b.IdTipoPersona AS Id, b.* 
            FROM sol.SolServicioConexionDatosSuscriptor a (NOLOCK) 
            INNER JOIN par.TipoPersona b (NOLOCK) ON a.CodTipoPersona = b.IdTipoPersona
            WHERE CodSolServicioConexion = @IdSolicitud;
            
            SELECT IdSolServicioConexionDetalle AS Id, * 
            FROM sol.SolServicioConexionDetalle (NOLOCK) 
            WHERE CodSolServicioConexion = @IdSolicitud;
            
            SELECT b.IdTipoTension AS Id, b.* 
            FROM sol.SolServicioConexionDetalle a (NOLOCK) 
            INNER JOIN par.TipoTension b (NOLOCK) ON a.CodNivelTension = b.IdTipoTension
            WHERE a.CodSolServicioConexion = @IdSolicitud;
            
            SELECT IdSolServicioConexionPredio AS Id, * 
            FROM sol.SolServicioConexionPredio (NOLOCK) 
            WHERE CodSolServicioConexion = @IdSolicitud;
            
            SELECT b.IdTipoConstruccion AS Id, b.* 
            FROM sol.SolServicioConexionPredio a (NOLOCK) 
            INNER JOIN par.TipoConstruccion b (NOLOCK) ON a.CodTipoConstruccion = b.IdTipoConstruccion
            WHERE a.CodSolServicioConexion = @IdSolicitud;

            SELECT b.IdTipoZona AS Id, b.* 
            FROM sol.SolServicioConexionPredio a (NOLOCK) 
            INNER JOIN par.TipoZona b (NOLOCK) ON a.CodTipoZona = b.IdTipoZona
            WHERE a.CodSolServicioConexion = @IdSolicitud;

            SELECT IdSolServicioConexionFactibilidad AS Id, * 
            FROM sol.SolServicioConexionFactibilidad (NOLOCK) 
            WHERE CodSolServicioConexion = @IdSolicitud;

            SELECT b.IdSolServicioConexionFactibilidadObservaciones AS Id, b.* 
            FROM sol.SolServicioConexionFactibilidad a (NOLOCK) 
            INNER JOIN [sol].[SolServicioConexionFactibilidadObservaciones] b (NOLOCK) ON b.CodSolServicioConexionFactibilidad = a.IdSolServicioConexionFactibilidad
            WHERE a.CodSolServicioConexion = @IdSolicitud;
        ";

        internal const string GetEntities_Estado = @"
            WITH CTE_SolConexion AS (
                SELECT *
                FROM [sol].[SolServicioConexion] (NOLOCK)
                WHERE CodEstado = @Estado [filtroSolicitud]
                ORDER BY IdSolServicioConexion DESC
                OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY
            )
            SELECT 
                a.IdSolServicioConexion						AS Id, a.*
                , es.parIdEstado							AS Id, es.*
                , tc.IdTipoConexion							AS Id, tc.*
	            , ds.IdSolServicioConexionDatosSolicitantes	AS Id, ds.*
	            , ds2.IdSolServicioConexionDatosSuscriptor	AS Id, ds2.*
            FROM CTE_SolConexion a
            INNER JOIN par.Estados es (NOLOCK) ON a.CodEstado = es.parIdEstado 
            INNER JOIN par.TipoConexion tc (NOLOCK) ON a.CodTipoConexion = tc.IdTipoConexion
            INNER JOIN sol.SolServicioConexionDatosSolicitantes ds (NOLOCK) ON a.IdSolServicioConexion = ds.CodSolServicioConexion
            INNER JOIN sol.SolServicioConexionDatosSuscriptor ds2 (NOLOCK) ON a.IdSolServicioConexion = ds2.CodSolServicioConexion
        ";

        internal static string GetEntities_Filtro = @"
            WITH CTE_SolConexion AS (
                SELECT *
                FROM [sol].[SolServicioConexion] (NOLOCK)
	            WHERE 1 = 1 [filtroSolicitud]
                ORDER BY IdSolServicioConexion DESC
                OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY
            )
            SELECT 
                a.IdSolServicioConexion						AS Id, a.*
                , es.parIdEstado							AS Id, es.*
                , tc.IdTipoConexion							AS Id, tc.*
	            , ds.IdSolServicioConexionDatosSolicitantes	AS Id, ds.*
	            , ds2.IdSolServicioConexionDatosSuscriptor	AS Id, ds2.*
            FROM CTE_SolConexion a
            INNER JOIN par.Estados es (NOLOCK) ON a.CodEstado = es.parIdEstado 
            INNER JOIN par.TipoConexion tc (NOLOCK) ON a.CodTipoConexion = tc.IdTipoConexion
            INNER JOIN sol.SolServicioConexionDatosSolicitantes ds (NOLOCK) ON a.IdSolServicioConexion = ds.CodSolServicioConexion
            INNER JOIN sol.SolServicioConexionDatosSuscriptor ds2 (NOLOCK) ON a.IdSolServicioConexion = ds2.CodSolServicioConexion
            WHERE 1 = 1 [filtroDatosSuscriptor]
        ";

        internal static string GetEntities_Filtro_Cliente_Status = @"
            WITH CTE_SolConexion AS (
                SELECT *
                FROM [sol].[SolServicioConexion] (NOLOCK)
	            WHERE CodUsuario = @CodUsuario [filtroSolicitud]                
            )
            SELECT 
                a.IdSolServicioConexion						AS Id, a.*
                , es.parIdEstado							AS Id, es.*
                , tc.IdTipoConexion							AS Id, tc.*
	            , ds.IdSolServicioConexionDatosSolicitantes	AS Id, ds.*
	            , ds2.IdSolServicioConexionDatosSuscriptor	AS Id, ds2.*
            FROM CTE_SolConexion a
            INNER JOIN par.Estados es (NOLOCK) ON a.CodEstado = es.parIdEstado 
            INNER JOIN par.TipoConexion tc (NOLOCK) ON a.CodTipoConexion = tc.IdTipoConexion
            INNER JOIN sol.SolServicioConexionDatosSolicitantes ds (NOLOCK) ON a.IdSolServicioConexion = ds.CodSolServicioConexion
            INNER JOIN sol.SolServicioConexionDatosSuscriptor ds2 (NOLOCK) ON a.IdSolServicioConexion = ds2.CodSolServicioConexion
            WHERE 1 = 1 [filtroDatosSuscriptor]
        ";

        internal static string GetEntities_Filtro_Cliente = @"
            WITH CTE_SolConexion AS (
                SELECT *
                FROM [sol].[SolServicioConexion] (NOLOCK)
	            WHERE CodUsuario = @CodUsuario [filtroSolicitud]
                ORDER BY IdSolServicioConexion DESC
                OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY
            )
            SELECT 
                a.IdSolServicioConexion						AS Id, a.*
                , es.parIdEstado							AS Id, es.*
                , tc.IdTipoConexion							AS Id, tc.*
	            , ds.IdSolServicioConexionDatosSolicitantes	AS Id, ds.*
	            , ds2.IdSolServicioConexionDatosSuscriptor	AS Id, ds2.*
            FROM CTE_SolConexion a
            INNER JOIN par.Estados es (NOLOCK) ON a.CodEstado = es.parIdEstado 
            INNER JOIN par.TipoConexion tc (NOLOCK) ON a.CodTipoConexion = tc.IdTipoConexion
            INNER JOIN sol.SolServicioConexionDatosSolicitantes ds (NOLOCK) ON a.IdSolServicioConexion = ds.CodSolServicioConexion
            INNER JOIN sol.SolServicioConexionDatosSuscriptor ds2 (NOLOCK) ON a.IdSolServicioConexion = ds2.CodSolServicioConexion
            WHERE 1 = 1 [filtroDatosSuscriptor]
        ";

        internal const string GetEntitiesByStatusAndStepsDate = @"
            WITH CTE_SolConexion AS (
                SELECT *
                        FROM [sol].[SolServicioConexion] (NOLOCK)
            )
            , CTE_PasosSolConexion AS (
                SELECT
                    h.*,
                    ROW_NUMBER() OVER (PARTITION BY h.CodSolServicioConexion ORDER BY h.FechaRegistroUpdate DESC) AS RowNum
                FROM sol.PasosSolServicioConexion h (NOLOCK)
                WHERE h.FechaRegistroUpdate <= @FechaRegistroLimite AND h.CodEstado = @CodigoEstadoActual
            )
            SELECT 
                a.IdSolServicioConexion AS Id, a.*,
                h.IdPasosSolServicioConexion AS Id, h.*,
                est2.parIdEstado AS Id, est2.* 
            FROM CTE_SolConexion a
            LEFT JOIN CTE_PasosSolConexion h ON a.IdSolServicioConexion = h.CodSolServicioConexion AND h.RowNum = 1
            INNER JOIN par.Estados est2 (NOLOCK) ON h.CodEstado = est2.parIdEstado
            WHERE a.CodEstado = @CodigoEstadoActual;
        ";

        internal const string GetEntitiesByOthersStatusAndStepsDate = @"
            WITH CTE_SolConexion AS (
                SELECT *
                        FROM [sol].[SolServicioConexion] (NOLOCK)
            )
            , CTE_PasosSolConexion AS (
                SELECT
                    h.*,
                    ROW_NUMBER() OVER (PARTITION BY h.CodSolServicioConexion ORDER BY h.FechaRegistroUpdate DESC) AS RowNum
                FROM sol.PasosSolServicioConexion h (NOLOCK)
                WHERE h.FechaRegistroUpdate <= @FechaRegistroLimite AND h.CodEstado = @CodigoEstadoValidacion
            )
            SELECT 
                a.IdSolServicioConexion AS Id, a.*,
                h.IdPasosSolServicioConexion AS Id, h.*,
                est2.parIdEstado AS Id, est2.* 
            FROM CTE_SolConexion a
            LEFT JOIN CTE_PasosSolConexion h ON a.IdSolServicioConexion = h.CodSolServicioConexion AND h.RowNum = 1
            INNER JOIN par.Estados est2 (NOLOCK) ON h.CodEstado = est2.parIdEstado
            WHERE a.CodEstado = @CodigoEstadoActual;
        ";

        internal const string GetAnexosBySolicitud = @"
            SELECT 
            ID                             AS Id,
            COD_075_CONEXION               AS Cod075Conexion,
            COD_DOCUMENTOS                 AS CodDocumentos,
            NAME_DOCUMENT                  AS NameDocument,
            EXT_DOCUMENT                   AS ExtDocument,
            SIZE_DOCUMENT                  AS SizeDocument,
            URL_DOCUMENT                   AS UrlDocument,
            URL_REL_DOCUMENT               AS UrlRelDocument,
            ORIGINAL_DOCUMENT              AS OriginalDocument,
            ESTADO_DOCUMENTO               AS EstadoDocumento,
            EXPEDICION                     AS Expedicion,
            VALIDATION_DOCUMENT            AS ValidationDocument,
            SEND_NOTIFICATION              AS SendNotification
            FROM CREG_075_ANEXOS
            WHERE COD_075_CONEXION = :IdSolicitud AND ESTADO_DOCUMENTO = 1
        ";

        internal static string GetPasosBySolicitud = @"
            SELECT 
                ps.IdPasosSolServicioConexion	AS Id, ps.*
                , es.parIdEstado				AS Id, es.*
                , et.IdEtapa					AS Id, et.*
            FROM sol.PasosSolServicioConexion ps (NOLOCK) 
            INNER JOIN par.Estados es (NOLOCK) ON ps.CodEstado = es.parIdEstado 
            LEFT  JOIN par.Etapas et (NOLOCK) ON es.CodEtapa = et.IdEtapa
            WHERE ps.CodSolServicioConexion = @IdSolicitud;
        ";

        internal static string GetPasosByRadicado = @"
            SELECT 
                ps.IdPasosSolServicioConexion   AS Id, ps.*
                , es2.parIdEstado               AS Id, es2.*
                , et2.IdEtapa					AS Id, et2.*
            FROM sol.PasosSolServicioConexion ps (NOLOCK) 
            INNER JOIN sol.SolServicioConexion a (NOLOCK) ON ps.CodSolServicioConexion = a.IdSolServicioConexion
            INNER JOIN par.Estados es2 (NOLOCK) ON ps.CodEstado = es2.parIdEstado 
            LEFT  JOIN par.Etapas et2 (NOLOCK) ON es2.CodEtapa = et2.IdEtapa
            WHERE a.NumeroRadicado = @Radicado;
        ";

        internal static string GetComentarioBySolicitud = @"
            SELECT IdSolServicioConexionComentario AS Id, *
            FROM sol.SolServicioConexionComentario (NOLOCK) 
            WHERE CodSolServicioConexion = @IdSolicitud;
        ";

        internal static string GetByDetalleCuentaSolicitud = @"
            SELECT 
	            SOL.*,
	            b.*,
	            c.*
            FROM CREG_075_SERVICIO_CONEXION A
            INNER JOIN CREG_075_DETALLES_CUENTAS SOL
                ON A.ID = SOL.COD_075_CONEXION
            INNER JOIN CREG_TIPO_CLIENTE b  ON SOL.COD_TIPO_CARGA = b.ID
            INNER JOIN CREG_TIPO_CLASE_CARGA c ON SOL.COD_TIPO_CLASE_CARGA = c.ID
            WHERE A.ID = :IdSolicitud
        ";

        internal const string GetEntitiesTrafo = @"
            WITH CTE_SolConexion AS (
                SELECT *
                FROM [sol].[SolServicioConexion] (NOLOCK)
                 WHERE 
                    Empresa = @Empresa
                    AND Transformador = @CodTransformador
            )
            SELECT 
                a.IdSolServicioConexion						AS Id, a.*
                , es.parIdEstado							AS Id, es.*
                , tc.IdTipoConexion							AS Id, tc.*
	            , condet.IdSolServicioConexionDetalle	    AS Id, condet.*
            FROM CTE_SolConexion a
            INNER JOIN par.Estados es (NOLOCK) ON a.CodEstado = es.parIdEstado 
            INNER JOIN par.TipoConexion tc (NOLOCK) ON a.CodTipoConexion = tc.IdTipoConexion
            INNER JOIN sol.SolServicioConexionDetalle condet (NOLOCK) ON a.IdSolServicioConexion = condet.CodSolServicioConexion
        ";
    }
}
