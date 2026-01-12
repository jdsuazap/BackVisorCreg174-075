namespace Infrastructure.QueryStrings.SQLContext
{
    internal static class SolConexionAutogenQuery
    {
        internal const string GetEntities = @"
            WITH CTE_SolConexion AS (
                SELECT *
                FROM [sol].[SolConexionAutogen] (NOLOCK)
                ORDER BY IdSolConexionAutogen ASC
                OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY
            )
            SELECT 
	            a.IdSolConexionAutogen	AS Id, a.*
	            , es.parIdEstado		AS Id, es.*
	            , tg.IdTipoGeneracion	AS Id, tg.*
                , xv.IdSolConexionAutogenXVisita	AS Id, xv.*
                , xp.IdSolConexionAutogenXProrroga	AS Id, xp.*
            FROM CTE_SolConexion a
            INNER JOIN par.Estados es (NOLOCK) ON a.Estado = es.parIdEstado 
            INNER JOIN par.TipoGeneracion tg (NOLOCK) ON a.CodTipoGeneracion = tg.IdTipoGeneracion
            LEFT JOIN sol.SolConexionAutogenXVisita xv (NOLOCK) ON a.IdSolConexionAutogen = xv.CodSolConexionAutogen 
            LEFT JOIN sol.SolConexionAutogenXProrroga xp (NOLOCK) ON a.IdSolConexionAutogen = xp.CodSolConexionAutogen
        ";

        internal const string GetEntities_Descending = @"
            WITH CTE_SolConexion AS (
                SELECT *
                FROM [sol].[SolConexionAutogen] (NOLOCK)
                WHERE Empresa = @Empresa
                ORDER BY IdSolConexionAutogen DESC
                OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY
            ),
            CTE_Hallazgos AS (
                SELECT
                    rh.*,
                    ROW_NUMBER() OVER (PARTITION BY rh.CodSolConexionAutogen ORDER BY rh.FechaRegistroUpdate DESC) AS RowNum
                FROM sol.SolConexionAutogenReporteHallazgo rh (NOLOCK)
	            INNER JOIN CTE_SolConexion b ON rh.CodSolConexionAutogen = b.IdSolConexionAutogen
	            WHERE rh.Estado = 1
            ),
            CTE_ContratosAnexos AS (
                SELECT
                    a.*,
                    ROW_NUMBER() OVER (PARTITION BY a.CodSolConexionAutogen ORDER BY a.FechaRegistroUpdate DESC) AS RowNum
                FROM sol.SolConexionAutogenContratoAnexo a (NOLOCK)
	            INNER JOIN CTE_SolConexion b ON a.CodSolConexionAutogen = b.IdSolConexionAutogen
            )
            SELECT 
                  s.IdSolConexionAutogen				AS Id, s.*,
                    CASE
                        WHEN 
                            ((s.DocumentacionRetieAprobada IS NULL OR s.DocumentacionRetieAprobada = 0) AND s.Estado = 13) OR 
                            (b.IdSolConexionAutogenAnexos IS NOT NULL AND (s.DocumentacionRetieAprobada IS NULL OR s.DocumentacionRetieAprobada = 0) AND s.Estado = 13) 
                            THEN CAST(1 AS BIT) 
                        ELSE CAST(0 AS BIT) 
                    END AS RequiereRETIE,
                    CASE
                        WHEN (b.IdSolConexionAutogenAnexos IS NOT NULL AND s.DocumentacionRetieAprobada IS NULL) AND s.Estado = 13
                            THEN 'OR. Debes aprobar la documentación RETIE para esta solicitud'
                        WHEN (s.DocumentacionRetieAprobada IS NULL OR s.DocumentacionRetieAprobada = 0) AND s.Estado = 13 
                            THEN 'El usuario cliente debe anexar documentación RETIE, para permitir continuar el proceso de esta solicitud'
                        ELSE NULL 
                    END AS MsgRequiereRETIE,
                    CASE
                        WHEN ((s.ContratoConexion IS NULL OR s.ContratoConexion = 0) AND s.Estado = 18 AND s.CodComercializador = 1) OR 
                            (ca.IdSolConexionAutogenContratoAnexo IS NOT NULL AND (s.ContratoConexionFirmado IS NULL OR s.ContratoConexionFirmado = 0) and s.Estado = 18 AND s.CodComercializador = 1) 
	                        THEN CAST(1 AS BIT) 
                        ELSE CAST(0 AS BIT) 
                    END AS RequiereContrato,
                    CASE
                        WHEN (s.ContratoConexion IS NULL OR s.ContratoConexion = 0) AND s.Estado = 18 AND s.CodComercializador = 1
                            THEN 'OR. Debes adjuntar contrato CCU para ser firmado por el usuario cliente'
                        WHEN (ca.IdSolConexionAutogenContratoAnexo IS NOT NULL AND s.ContratoConexionFirmado IS NULL) and s.Estado = 18 AND s.CodComercializador = 1
                            THEN 'El usuario cliente debe anexar contrato CCU firmado, para permitir continuar el proceso de esta solicitud'
                        ELSE NULL 
                    END AS MsgRequiereContrato,
                    CASE 
                        WHEN (SELECT COUNT (1) FROM [sol].[SolConexionAutogenConexionRechazo] (NOLOCK) WHERE CodSolConexionAutogen = s.IdSolConexionAutogen) > 1 THEN CAST(1 AS BIT)
                        ELSE CAST(0 AS BIT)
                    END AS ExcedeVisitaConexionRechazo
                , es.parIdEstado						AS Id, es.*
	            , esVisita.parIdEstado					AS Id, esVisita.*
                , tg.IdTipoGeneracion					AS Id, tg.*
                , cl.IdClasificacionProyecto			AS Id, cl.*
                , si.IdSolConexionAutogenInmueble		AS Id, si.*
                , a.IdAlertasSolConexionAutogen			AS Id, a.*
                , ca.IdSolConexionAutogenContratoAnexo	AS Id, ca.*
                , xv.IdSolConexionAutogenXVisita		AS Id, xv.*
                , xp.IdSolConexionAutogenXProrroga		AS Id, xp.*
                , h.IdSolConexionAutogenReporteHallazgo AS Id, h.*
                , esProrroga.parIdEstado			    AS Id, esProrroga.*
            FROM CTE_SolConexion s
            INNER JOIN par.Estados es (NOLOCK) ON s.Estado = es.parIdEstado 
            LEFT JOIN par.Estados esVisita (NOLOCK) ON s.EstadoVisita = esVisita.parIdEstado 
            INNER JOIN par.TipoGeneracion tg (NOLOCK) ON s.CodTipoGeneracion = tg.IdTipoGeneracion
            INNER JOIN par.ClasificacionProyecto cl (NOLOCK) ON s.CodClasificacionProyecto = cl.IdClasificacionProyecto
            INNER JOIN sol.SolConexionAutogenInmueble si (NOLOCK) ON s.IdSolConexionAutogen = si.CodSolConexionAutogen
            LEFT JOIN [sol].[SolConexionAutogenAnexos] b (NOLOCK) ON s.IdSolConexionAutogen = b.CodSolConexionAutogen 
                AND b.CodDocumentosXFormulario = 13
            LEFT JOIN sol.AlertaSolConexionAutogen a ON a.CodSolConexionAutogen = s.IdSolConexionAutogen AND a.Estado = 1
            LEFT JOIN CTE_Hallazgos h ON h.CodSolConexionAutogen = s.IdSolConexionAutogen AND h.RowNum = 1
            LEFT JOIN CTE_ContratosAnexos ca (NOLOCK) ON s.IdSolConexionAutogen = ca.CodSolConexionAutogen AND ca.RowNum = 1
            LEFT JOIN sol.SolConexionAutogenXVisita xv (NOLOCK) ON s.IdSolConexionAutogen = xv.CodSolConexionAutogen 
            LEFT JOIN sol.SolConexionAutogenXProrroga xp (NOLOCK) ON s.IdSolConexionAutogen = xp.CodSolConexionAutogen
            LEFT JOIN par.Estados esProrroga (NOLOCK) ON s.UltimoEstadoProrroga = esProrroga.parIdEstado 
        ";

        internal const string GetEntities_AGGE = @"
            WITH CTE_SolConexion AS (
                SELECT *
                FROM [sol].[SolConexionAutogen] (NOLOCK)
                WHERE CodTipoGeneracion = @CodTipoGeneracion
                ORDER BY IdSolConexionAutogen DESC
                OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY
            )
            SELECT 
	            a.IdSolConexionAutogen	AS Id, a.*
	            , es.parIdEstado		AS Id, es.*
	            , tg.IdTipoGeneracion	AS Id, tg.*
                , xv.IdSolConexionAutogenXVisita	AS Id, xv.*
                , xp.IdSolConexionAutogenXProrroga	AS Id, xp.*
            FROM CTE_SolConexion a
            INNER JOIN par.Estados es (NOLOCK) ON a.Estado = es.parIdEstado 
            INNER JOIN par.TipoGeneracion tg (NOLOCK) ON a.CodTipoGeneracion = tg.IdTipoGeneracion
            LEFT JOIN sol.SolConexionAutogenXVisita xv (NOLOCK) ON a.IdSolConexionAutogen = xv.CodSolConexionAutogen 
            LEFT JOIN sol.SolConexionAutogenXProrroga xp (NOLOCK) ON a.IdSolConexionAutogen = xp.CodSolConexionAutogen
        ";

        internal const string GetEntities_RangoFecha = @"
            WITH CTE_SolConexion AS (
                SELECT *
                FROM [sol].[SolConexionAutogen] (NOLOCK)
	            WHERE FechaRegistro >= @FechaIni AND FechaRegistro < @FechaFin
                    AND Empresa = @Empresa
            )
            SELECT 
	            a.IdSolConexionAutogen	        AS Id, a.*
	            , es.parIdEstado		        AS Id, es.*
	            , tg.IdTipoGeneracion	        AS Id, tg.*
                , cla.IdClasificacionProyecto   AS Id, cla.*
                , com.IdComercializador         AS Id, com.*
                , ti.IdTipoIdentificacion       AS Id, ti.*
                , ciu.IdCiudad                  AS Id, ciu.*
                , dp. IdDepartamento            AS Id, dp.*
                , tc.IdTipoCliente              AS Id, tc.*
                , est.IdEstratoSocioeconomico   AS Id, est.*
                , d.IdSolConexionAutogenInmueble AS Id, d.*
                , util.IdSolConexionAutogenTecnUtilizadas AS Id, util.*
                , esvisita.parIdEstado		     AS Id, esvisita.*
                , tecn.IdSolConexionAutogenTecnologias AS Id, tecn.*
                , basinv.IdSolConexionAutogenBasadaInv AS Id, basinv.*
                , nobasinv.IdSolConexionAutogenNoBasadaInv AS Id, nobasinv.*
                , infoeol.IdSolConexionAutogenInfoEolica AS Id, infoeol.*
                , anexos.IdSolConexionAutogenAnexos AS Id, anexos.*
                , visit.IdSolConexionAutogenXVisita AS Id, visit.*
            FROM CTE_SolConexion a
                INNER JOIN par.Estados es (NOLOCK) ON a.Estado = es.parIdEstado 
                INNER JOIN par.TipoGeneracion tg (NOLOCK) ON a.CodTipoGeneracion = tg.IdTipoGeneracion
                LEFT  JOIN par.ClasificacionProyecto cla (NOLOCK) ON a.CodClasificacionProyecto = cla.IdClasificacionProyecto  
                LEFT  JOIN par.Comercializador com (NOLOCK) ON a.CodComercializador = com.IdComercializador 
                INNER JOIN par.TipoIdentificacion ti (NOLOCK) ON a.CodTipoIdentificacionCliente = ti.IdTipoIdentificacion 
                INNER JOIN sol.SolConexionAutogenInmueble d (NOLOCK) on a.IdSolConexionAutogen = d.CodSolConexionAutogen 
                INNER JOIN par.Ciudad ciu (NOLOCK) ON d.Municipio = ciu.IdCiudad 
                INNER JOIN par.Departamento dp (NOLOCK) ON ciu.CodDepartamento = dp.IdDepartamento 
                INNER JOIN par.TipoCliente tc (NOLOCK) ON a.CodTipoCliente = tc.IdTipoCliente 
                LEFT  JOIN par.EstratoSocioeconomico est (NOLOCK) ON a.CodEstratoCliente = est.IdEstratoSocioeconomico 
                INNER JOIN sol.SolConexionAutogenTecnUtilizadas util (NOLOCK) on a.IdSolConexionAutogen = util.CodSolConexionAutogen 
                LEFT JOIN par.Estados esvisita (NOLOCK) ON a.EstadoVisita = esvisita.parIdEstado
                LEFT JOIN sol.SolConexionAutogenTecnologias tecn (NOLOCK) on a.IdSolConexionAutogen = tecn.CodSolConexionAutogen 
                LEFT JOIN sol.SolConexionAutogenBasadaInv basinv (NOLOCK) on a.IdSolConexionAutogen = basinv.CodSolConexionAutogen
                LEFT JOIN sol.SolConexionAutogenNoBasadaInv nobasinv (NOLOCK) on a.IdSolConexionAutogen = nobasinv.CodSolConexionAutogen 
                LEFT JOIN sol.SolConexionAutogenInfoEolica infoeol (NOLOCK) on a.IdSolConexionAutogen = infoeol.CodSolConexionAutogen 
                LEFT JOIN sol.SolConexionAutogenAnexos anexos (NOLOCK) on a.IdSolConexionAutogen = anexos.CodSolConexionAutogen 
                LEFT JOIN sol.SolConexionAutogenXVisita visit (NOLOCK) on a.IdSolConexionAutogen = visit.CodSolConexionAutogen 
            ORDER BY IdSolConexionAutogen DESC
        ";

        internal const string Reporte_Estados = @"
            WITH CTE_SolConexion AS (
                SELECT *
                FROM [sol].[SolConexionAutogen] (NOLOCK)
	            WHERE FechaRegistro >= @FechaIni AND FechaRegistro < @FechaFin
                    AND Empresa = @Empresa
            )
            SELECT 
                a.IdSolConexionAutogen	        AS Id, a.*
                , b.IdPasosConexionAutogen      AS Id, b.*
	            , es_old.parIdEstado		    AS Id, es_old.*
	            , es.parIdEstado		        AS Id, es.*
            FROM CTE_SolConexion a
                INNER JOIN [sol].[PasosSolConexionAutogen] b ON a.IdSolConexionAutogen = b.CodSolConexionAutogen
                INNER JOIN par.Estados es_old (NOLOCK) ON b.CodEstado = es_old.parIdEstado           
	            INNER JOIN par.Estados es ON a.Estado = es.parIdEstado
            ORDER BY b.IdPasosConexionAutogen ASC
        ";
        
        internal const string Reporte_Ingresos = @"
            WITH CTE_SolConexion AS (
                SELECT *
                FROM [LOG].[LogIngresosCreg] (NOLOCK)
	            WHERE FechaRegistro >= @FechaIni AND FechaRegistro < @FechaFin
            )
            SELECT 
                a.Id_LogIngresosCreg            AS Id, a.*                
            FROM CTE_SolConexion a
            ORDER BY a.Id_LogIngresosCreg ASC
        ";

        internal const string Reporte_Visitas = @"
            WITH CTE_SolConexion AS (
                SELECT *
                FROM [sol].[SolConexionAutogen] (NOLOCK)
	            WHERE FechaRegistro >= @FechaIni AND FechaRegistro < @FechaFin
                    AND Empresa = @Empresa
            )
            SELECT 
                a.IdSolConexionAutogen	        AS Id, a.*
                , b.IdSolConexionAutogenXVisita AS Id, b.*    
                , c.IdSolConexionAutogenXVisitaRechazo AS Id, c.*
            FROM CTE_SolConexion a
                INNER JOIN [sol].[SolConexionAutogenXVisita] b ON a.IdSolConexionAutogen = b.CodSolConexionAutogen
                LEFT JOIN [sol].[SolConexionAutogenXVisitaRechazo] c ON b.IdSolConexionAutogenXVisita = c.CodSolConexionAutogenXvisita
            ORDER BY b.IdSolConexionAutogenXVisita ASC
        ";

        internal const string GetEntity = @"
            SELECT *
            FROM CREG_174_AUTOGEN
            WHERE ID = :IdSolicitud

            SELECT CLA.*
            FROM CREG_174_AUTOGEN A
            LEFT JOIN CREG_CLASIFICACION_PROYECTO CLA
                   ON A.COD_CLASIFICACION_PROYECTO = CLA.ID
            WHERE A.ID = :IdSolicitud

            SELECT COM.*
            FROM CREG_174_AUTOGEN A
            LEFT JOIN CREG_COMERCIALIZADOR COM
                   ON A.COD_COMERCIALIZADOR = COM.ID
            WHERE A.ID = :IdSolicitud

            SELECT ES.*
            FROM CREG_174_AUTOGEN A
            INNER JOIN CREG_ESTADOS ES
                    ON A.COD_ESTADO = ES.ID
            WHERE A.ID = :IdSolicitud

            SELECT EST.*
            FROM CREG_174_AUTOGEN A
            LEFT JOIN CREG_ESTRATO_SOCIOECONOMICO EST
                   ON A.COD_ESTRATO_CLIENTE = EST.ID
            WHERE A.ID = :IdSolicitud

            SELECT TC.*
            FROM CREG_174_AUTOGEN A
            INNER JOIN CREG_TIPO_CLIENTE TC
                    ON A.COD_TIPO_CLIENTE = TC.ID
            WHERE A.ID = :IdSolicitud

            SELECT TG.*
            FROM CREG_174_AUTOGEN A
            INNER JOIN CREG_TIPO_GENERACION TG
                    ON A.COD_TIP_GENERACION = TG.ID
            WHERE A.ID = :IdSolicitud

            SELECT TI.*
            FROM CREG_174_AUTOGEN A
            INNER JOIN CREG_TIPO_IDENTIFICACION TI
                    ON A.COD_TIPO_IDENTIFICACION = TI.ID
            WHERE A.ID = :IdSolicitud

            SELECT *
            FROM CREG_174_BAS_INV
            WHERE COD_174_AUTOGEN = :IdSolicitud

            SELECT *
            FROM CREG_174_INFOEOLICA
            WHERE COD_174_AUTOGEN = :IdSolicitud

            SELECT *
            FROM CREG_174_INMUEBLE
            WHERE COD_174_AUTOGEN = :IdSolicitud

            SELECT CIU.*
            FROM CREG_174_AUTOGEN A
            INNER JOIN CREG_174_INMUEBLE D
                    ON A.ID = D.COD_174_AUTOGEN
            INNER JOIN CREG_CIUDAD CIU
                    ON D.MUNICIPIO = CIU.ID
            WHERE A.ID = :IdSolicitud

            SELECT DP.*
            FROM CREG_174_AUTOGEN A
            INNER JOIN CREG_174_INMUEBLE D
                    ON A.ID = D.COD_174_AUTOGEN
            INNER JOIN CREG_CIUDAD CIU
                    ON D.MUNICIPIO = CIU.ID
            INNER JOIN CREG_DEPARTAMENTO DP
                    ON CIU.COD_DEPARTAMENTO = DP.ID
            WHERE A.ID = :IdSolicitud

            SELECT *
            FROM CREG_174_NO_BAS_INV
            WHERE COD_174_AUTOGEN = :IdSolicitud

            SELECT *
            FROM CREG_174_TECNOLOGIAS
            WHERE COD_174_AUTOGEN = :IdSolicitud

            SELECT *
            FROM CREG_174_TECN_UTILIZADAS
            WHERE COD_174_AUTOGEN = :IdSolicitud

        ";

        internal const string GetValidationTipoProcConexion = @"EXEC [sol].[Creg174_ValidacionTipoProcedimientoConexion] @idSolConexionAutogen = @idSolConexionAutogen";

        internal const string GetEntities_Estado = @"
            WITH CTE_SolConexion AS (
                SELECT *
                FROM [sol].[SolConexionAutogen] (NOLOCK)
                WHERE Estado = @Estado [filtroSolicitud]
                ORDER BY IdSolConexionAutogen DESC
                OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY
            ),
            CTE_Hallazgos AS (
                SELECT
                    rh.*,
                    ROW_NUMBER() OVER (PARTITION BY rh.CodSolConexionAutogen ORDER BY rh.FechaRegistroUpdate DESC) AS RowNum
                FROM sol.SolConexionAutogenReporteHallazgo rh (NOLOCK)
	            INNER JOIN CTE_SolConexion b ON rh.CodSolConexionAutogen = b.IdSolConexionAutogen
	            WHERE rh.Estado = 1
            ),
            CTE_ContratosAnexos AS (
                SELECT
                    a.*,
                    ROW_NUMBER() OVER (PARTITION BY a.CodSolConexionAutogen ORDER BY a.FechaRegistroUpdate DESC) AS RowNum
                FROM sol.SolConexionAutogenContratoAnexo a (NOLOCK)
	            INNER JOIN CTE_SolConexion b ON a.CodSolConexionAutogen = b.IdSolConexionAutogen
            )
            SELECT 
                a.IdSolConexionAutogen	AS Id, a.*,
                CASE
                    WHEN 
	                    ((a.DocumentacionRetieAprobada IS NULL OR a.DocumentacionRetieAprobada = 0) AND a.Estado = 13) OR
                        (b.IdSolConexionAutogenAnexos IS NOT NULL AND (a.DocumentacionRetieAprobada IS NULL OR a.DocumentacionRetieAprobada = 0) AND a.Estado = 13) 
	                    THEN CAST(1 AS BIT) 
                    ELSE CAST(0 AS BIT) 
                END AS RequiereRETIE,
                CASE
                    WHEN (b.IdSolConexionAutogenAnexos IS NOT NULL AND a.DocumentacionRetieAprobada IS NULL) AND a.Estado = 13
	                    THEN 'En espera de que el OR apruebe la documentación RETIE para esta solicitud'
                    WHEN (a.DocumentacionRetieAprobada IS NULL OR a.DocumentacionRetieAprobada = 0) AND a.Estado = 13 
	                    THEN 'Debes anexar documentación RETIE, para permitir que el operador de red pueda continuar el trámite de tu solicitud'
                    ELSE NULL 
                END AS MsgRequiereRETIE,
                CASE
                    WHEN ((a.ContratoConexion IS NULL OR a.ContratoConexion = 0) AND a.Estado = 18 AND a.CodComercializador = 1) OR 
                        (ca.IdSolConexionAutogenContratoAnexo IS NOT NULL AND (a.ContratoConexionFirmado IS NULL OR a.ContratoConexionFirmado = 0) AND a.Estado = 18 AND a.CodComercializador = 1) 
	                    THEN CAST(1 AS BIT) 
                    ELSE CAST(0 AS BIT) 
                END AS RequiereContrato,
                CASE
                    WHEN (a.ContratoConexion IS NULL OR a.ContratoConexion = 0) AND a.Estado = 18 AND a.CodComercializador = 1
                        THEN 'En espera de que el OR adjunte contrato CCU para esta solicitud'
                    WHEN (ca.IdSolConexionAutogenContratoAnexo IS NOT NULL AND a.ContratoConexionFirmado IS NULL) AND a.Estado = 18 AND a.CodComercializador = 1
                        THEN 'Debes anexar contrato CCU firmado, para permitir que el operador de red pueda continuar el trámite de tu solicitud'
                    ELSE NULL 
                END AS MsgRequiereContrato
                , es.parIdEstado		                    AS Id, es.*
	            , esVisita.parIdEstado					    AS Id, esVisita.*
                , tg.IdTipoGeneracion	                    AS Id, tg.*
                , xv.IdSolConexionAutogenXVisita	        AS Id, xv.*
                , xp.IdSolConexionAutogenXProrroga	        AS Id, xp.*
                , rh.IdSolConexionAutogenReporteHallazgo	AS Id, rh.*
                , xpg.IdSolConexionAutogenXProrrogaGarantia	AS Id, xpg.*
                , ca.IdSolConexionAutogenContratoAnexo	    AS Id, ca.*
                , cl.IdClasificacionProyecto			    AS Id, cl.*
                , si.IdSolConexionAutogenInmueble		    AS Id, si.*
                , esProrroga.parIdEstado					AS Id, esProrroga.*
            FROM CTE_SolConexion a
            INNER JOIN par.Estados es (NOLOCK) ON a.Estado = es.parIdEstado 
            LEFT JOIN par.Estados esVisita (NOLOCK) ON a.EstadoVisita = esVisita.parIdEstado 
            INNER JOIN par.TipoGeneracion tg (NOLOCK) ON a.CodTipoGeneracion = tg.IdTipoGeneracion
            LEFT JOIN [sol].[SolConexionAutogenAnexos] b (NOLOCK) ON a.IdSolConexionAutogen = b.CodSolConexionAutogen 
                AND b.CodDocumentosXFormulario = 13
            LEFT JOIN sol.SolConexionAutogenXVisita xv (NOLOCK) ON a.IdSolConexionAutogen = xv.CodSolConexionAutogen 
            LEFT JOIN sol.SolConexionAutogenXProrroga xp (NOLOCK) ON a.IdSolConexionAutogen = xp.CodSolConexionAutogen
            LEFT JOIN CTE_Hallazgos rh ON rh.CodSolConexionAutogen = a.IdSolConexionAutogen AND rh.RowNum = 1
            LEFT JOIN sol.SolConexionAutogenXProrrogaGarantia xpg (NOLOCK) ON xp.IdSolConexionAutogenXProrroga = xpg.CodSolConexionAutogenXProrroga and xpg.Estado = 1
            LEFT JOIN CTE_ContratosAnexos ca (NOLOCK) ON a.IdSolConexionAutogen = ca.CodSolConexionAutogen AND ca.RowNum = 1
            INNER JOIN par.ClasificacionProyecto cl (NOLOCK) ON a.CodClasificacionProyecto = cl.IdClasificacionProyecto
            INNER JOIN sol.SolConexionAutogenInmueble si (NOLOCK) ON a.IdSolConexionAutogen = si.CodSolConexionAutogen
            LEFT JOIN par.Estados esProrroga (NOLOCK) ON a.UltimoEstadoProrroga = esProrroga.parIdEstado 
        ";

        internal static string GetEntities_Filtro = @"
            WITH CTE_SolConexion AS (
                SELECT *
                FROM [sol].[SolConexionAutogen] (NOLOCK)
                WHERE 1 = 1 
                [filtroSolicitud] 
                [filtroInmueble]
                ORDER BY IdSolConexionAutogen DESC
                OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY
            ),
            CTE_Hallazgos AS (
                SELECT
                    rh.*,
                    ROW_NUMBER() OVER (PARTITION BY rh.CodSolConexionAutogen ORDER BY rh.FechaRegistroUpdate DESC) AS RowNum
                FROM sol.SolConexionAutogenReporteHallazgo rh (NOLOCK)
	            INNER JOIN CTE_SolConexion b ON rh.CodSolConexionAutogen = b.IdSolConexionAutogen
	            WHERE rh.Estado = 1
            ),
            CTE_ContratosAnexos AS (
                SELECT
                    a.*,
                    ROW_NUMBER() OVER (PARTITION BY a.CodSolConexionAutogen ORDER BY a.FechaRegistroUpdate DESC) AS RowNum
                FROM sol.SolConexionAutogenContratoAnexo a (NOLOCK)
	            INNER JOIN CTE_SolConexion b ON a.CodSolConexionAutogen = b.IdSolConexionAutogen
            )
            SELECT 
                a.IdSolConexionAutogen	            AS Id, a.*,
	            CASE
		            WHEN 
			            ((a.DocumentacionRetieAprobada IS NULL OR a.DocumentacionRetieAprobada = 0) AND a.Estado = 13) OR 
			            (b.IdSolConexionAutogenAnexos IS NOT NULL AND (a.DocumentacionRetieAprobada IS NULL OR a.DocumentacionRetieAprobada = 0) AND a.Estado = 13) 
			            THEN CAST(1 AS BIT) 
		            ELSE CAST(0 AS BIT) 
	            END AS RequiereRETIE,
	            CASE
		            WHEN (b.IdSolConexionAutogenAnexos IS NOT NULL AND a.DocumentacionRetieAprobada IS NULL) AND a.Estado = 13
			            THEN 'OR. Debes aprobar la documentación RETIE para esta solicitud'
		            WHEN (a.DocumentacionRetieAprobada IS NULL OR a.DocumentacionRetieAprobada = 0) AND a.Estado = 13 
			            THEN 'El usuario cliente debe anexar documentación RETIE, para permitir continuar el proceso de esta solicitud'
		            ELSE NULL 
	            END AS MsgRequiereRETIE,
	            CASE
		            WHEN ((a.ContratoConexion IS NULL OR a.ContratoConexion = 0) AND a.Estado = 18 AND a.CodComercializador = 1) OR 
			            (ca.IdSolConexionAutogenContratoAnexo IS NOT NULL AND (a.ContratoConexionFirmado IS NULL OR a.ContratoConexionFirmado = 0) and a.Estado = 18 AND a.CodComercializador = 1) 
			            THEN CAST(1 AS BIT) 
		            ELSE CAST(0 AS BIT) 
	            END AS RequiereContrato,
	            CASE
		            WHEN (a.ContratoConexion IS NULL OR a.ContratoConexion = 0) AND a.Estado = 18 AND a.CodComercializador = 1
			            THEN 'OR. Debes adjuntar contrato CCU para ser firmado por el usuario cliente'
		            WHEN (ca.IdSolConexionAutogenContratoAnexo IS NOT NULL AND a.ContratoConexionFirmado IS NULL) and a.Estado = 18 AND a.CodComercializador = 1
			            THEN 'El usuario cliente debe anexar contrato CCU firmado, para permitir continuar el proceso de esta solicitud'
		            ELSE NULL 
	            END AS MsgRequiereContrato,
	            CASE 
		            WHEN (SELECT COUNT (1) FROM [sol].[SolConexionAutogenConexionRechazo] (NOLOCK) WHERE CodSolConexionAutogen = a.IdSolConexionAutogen) > 1 THEN CAST(1 AS BIT)
		            ELSE CAST(0 AS BIT)
	            END AS ExcedeVisitaConexionRechazo
                , es.parIdEstado		                AS Id, es.*
	            , esVisita.parIdEstado					AS Id, esVisita.*
                , tg.IdTipoGeneracion	                AS Id, tg.*
                , cl.IdClasificacionProyecto		    AS Id, cl.*
                , si.IdSolConexionAutogenInmueble	    AS Id, si.*
                , al.IdAlertasSolConexionAutogen        As Id, al.*
                , ca.IdSolConexionAutogenContratoAnexo	AS Id, ca.*
                , vi.IdSolConexionAutogenXVisita        As Id, vi.*
                , pr.IdSolConexionAutogenXProrroga      As Id, pr.*
                , h.IdSolConexionAutogenReporteHallazgo AS Id, h.*
                , esProrroga.parIdEstado				AS Id, esProrroga.*
            FROM CTE_SolConexion a
            INNER JOIN par.Estados es (NOLOCK) ON a.Estado = es.parIdEstado 
            LEFT JOIN par.Estados esVisita (NOLOCK) ON a.EstadoVisita = esVisita.parIdEstado 
            INNER JOIN par.TipoGeneracion tg (NOLOCK) ON a.CodTipoGeneracion = tg.IdTipoGeneracion
            INNER JOIN par.ClasificacionProyecto cl (NOLOCK) ON a.CodClasificacionProyecto = cl.IdClasificacionProyecto
            INNER JOIN sol.SolConexionAutogenInmueble si (NOLOCK) ON a.IdSolConexionAutogen = si.CodSolConexionAutogen
            LEFT JOIN [sol].[SolConexionAutogenAnexos] b (NOLOCK) ON a.IdSolConexionAutogen = b.CodSolConexionAutogen 
                AND b.CodDocumentosXFormulario = 13
            LEFT JOIN sol.AlertaSolConexionAutogen al ON al.CodSolConexionAutogen = a.IdSolConexionAutogen AND al.Estado = 1
            LEFT JOIN CTE_Hallazgos h ON h.CodSolConexionAutogen = a.IdSolConexionAutogen AND h.RowNum = 1
            LEFT JOIN CTE_ContratosAnexos ca (NOLOCK) ON a.IdSolConexionAutogen = ca.CodSolConexionAutogen AND ca.RowNum = 1
            LEFT JOIN sol.SolConexionAutogenXvisita vi ON vi.CodSolConexionAutogen = a.IdSolConexionAutogen AND vi.Estado = 1
            LEFT JOIN sol.SolConexionAutogenXprorroga pr ON pr.CodSolConexionAutogen = a.IdSolConexionAutogen AND pr.Estado = 1
            LEFT JOIN par.Estados esProrroga (NOLOCK) ON a.UltimoEstadoProrroga = esProrroga.parIdEstado 
            WHERE 1 = 1
        ";

        internal static string GetEntities_Filtro_Cliente = @"
            WITH CTE_SolConexion AS (
                SELECT *
                FROM [sol].[SolConexionAutogen] (NOLOCK)
                WHERE CodUsuario = @CodUsuario 
                [filtroSolicitud]
                [filtroInmueble]
	            ORDER BY IdSolConexionAutogen DESC
	            OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY
            ),
            CTE_Hallazgos AS (
                SELECT
                    rh.*,
                    ROW_NUMBER() OVER (PARTITION BY rh.CodSolConexionAutogen ORDER BY rh.FechaRegistroUpdate DESC) AS RowNum
                FROM sol.SolConexionAutogenReporteHallazgo rh (NOLOCK)
	            INNER JOIN CTE_SolConexion b ON rh.CodSolConexionAutogen = b.IdSolConexionAutogen
	            WHERE rh.Estado = 1
            ),
            CTE_ContratosAnexos AS (
                SELECT
                    a.*,
                    ROW_NUMBER() OVER (PARTITION BY a.CodSolConexionAutogen ORDER BY a.FechaRegistroUpdate DESC) AS RowNum
                FROM sol.SolConexionAutogenContratoAnexo a (NOLOCK)
	            INNER JOIN CTE_SolConexion b ON a.CodSolConexionAutogen = b.IdSolConexionAutogen
            )
            SELECT 
                a.IdSolConexionAutogen	AS Id, a.*,
                CASE
                    WHEN 
	                    ((a.DocumentacionRetieAprobada IS NULL OR a.DocumentacionRetieAprobada = 0) AND a.Estado = 13) OR
                        (b.IdSolConexionAutogenAnexos IS NOT NULL AND (a.DocumentacionRetieAprobada IS NULL OR a.DocumentacionRetieAprobada = 0) AND a.Estado = 13) 
	                    THEN CAST(1 AS BIT) 
                    ELSE CAST(0 AS BIT) 
                END AS RequiereRETIE,
                CASE
                    WHEN (b.IdSolConexionAutogenAnexos IS NOT NULL AND a.DocumentacionRetieAprobada IS NULL) AND a.Estado = 13
	                    THEN 'En espera de que el OR apruebe la documentación RETIE para esta solicitud'
                    WHEN (a.DocumentacionRetieAprobada IS NULL OR a.DocumentacionRetieAprobada = 0) AND a.Estado = 13 
	                    THEN 'Debes anexar documentación RETIE, para permitir que el operador de red pueda continuar el trámite de tu solicitud'
                    ELSE NULL 
                END AS MsgRequiereRETIE,
                CASE
                    WHEN ((a.ContratoConexion IS NULL OR a.ContratoConexion = 0) AND a.Estado = 18 AND a.CodComercializador = 1) OR 
                        (ca.IdSolConexionAutogenContratoAnexo IS NOT NULL AND (a.ContratoConexionFirmado IS NULL OR a.ContratoConexionFirmado = 0) AND a.Estado = 18 AND a.CodComercializador = 1) 
	                    THEN CAST(1 AS BIT) 
                    ELSE CAST(0 AS BIT) 
                END AS RequiereContrato,
                CASE
                    WHEN (a.ContratoConexion IS NULL OR a.ContratoConexion = 0) AND a.Estado = 18 AND a.CodComercializador = 1
                        THEN 'En espera de que el OR adjunte contrato CCU para esta solicitud'
                    WHEN (ca.IdSolConexionAutogenContratoAnexo IS NOT NULL AND a.ContratoConexionFirmado IS NULL) AND a.Estado = 18 AND a.CodComercializador = 1
                        THEN 'Debes anexar contrato CCU firmado, para permitir que el operador de red pueda continuar el trámite de tu solicitud'
                    ELSE NULL 
                END AS MsgRequiereContrato
                , es.parIdEstado		                    AS Id, es.*
	            , esVisita.parIdEstado					    AS Id, esVisita.*
                , tg.IdTipoGeneracion	                    AS Id, tg.*
                , xv.IdSolConexionAutogenXVisita	        AS Id, xv.*
                , xp.IdSolConexionAutogenXProrroga	        AS Id, xp.*
                , rh.IdSolConexionAutogenReporteHallazgo	AS Id, rh.*
                , xpg.IdSolConexionAutogenXProrrogaGarantia	AS Id, xpg.*
                , ca.IdSolConexionAutogenContratoAnexo	    AS Id, ca.*
                , cl.IdClasificacionProyecto			    AS Id, cl.*
                , si.IdSolConexionAutogenInmueble		    AS Id, si.*
                , esProrroga.parIdEstado					AS Id, esProrroga.*
            FROM CTE_SolConexion a
            INNER JOIN par.Estados es (NOLOCK) ON a.Estado = es.parIdEstado 
            LEFT JOIN par.Estados esVisita (NOLOCK) ON a.EstadoVisita = esVisita.parIdEstado 
            INNER JOIN par.TipoGeneracion tg (NOLOCK) ON a.CodTipoGeneracion = tg.IdTipoGeneracion
            LEFT JOIN [sol].[SolConexionAutogenAnexos] b (NOLOCK) ON a.IdSolConexionAutogen = b.CodSolConexionAutogen 
                AND b.CodDocumentosXFormulario = 13
            LEFT JOIN sol.SolConexionAutogenXVisita xv (NOLOCK) ON a.IdSolConexionAutogen = xv.CodSolConexionAutogen 
            LEFT JOIN sol.SolConexionAutogenXProrroga xp (NOLOCK) ON a.IdSolConexionAutogen = xp.CodSolConexionAutogen
            LEFT JOIN CTE_Hallazgos rh ON rh.CodSolConexionAutogen = a.IdSolConexionAutogen AND rh.RowNum = 1
            LEFT JOIN sol.SolConexionAutogenXProrrogaGarantia xpg (NOLOCK) ON xp.IdSolConexionAutogenXProrroga = xpg.CodSolConexionAutogenXProrroga and xpg.Estado = 1
            LEFT JOIN CTE_ContratosAnexos ca (NOLOCK) ON a.IdSolConexionAutogen = ca.CodSolConexionAutogen AND ca.RowNum = 1
            INNER JOIN par.ClasificacionProyecto cl (NOLOCK) ON a.CodClasificacionProyecto = cl.IdClasificacionProyecto
            INNER JOIN sol.SolConexionAutogenInmueble si (NOLOCK) ON a.IdSolConexionAutogen = si.CodSolConexionAutogen
            LEFT JOIN par.Estados esProrroga (NOLOCK) ON a.UltimoEstadoProrroga = esProrroga.parIdEstado 
            WHERE 1 = 1
        ";

        internal static string GetEntities_Filtro_Cliente_Status = @"
            WITH CTE_SolConexion AS (
                SELECT *
                FROM [sol].[SolConexionAutogen] (NOLOCK)
	            WHERE CodUsuario = @CodUsuario [filtroSolicitud]
            )
            SELECT 
                a.IdSolConexionAutogen	AS Id, a.*
                , es.parIdEstado		AS Id, es.*
                , tg.IdTipoGeneracion	AS Id, tg.*
                , xv.IdSolConexionAutogenXVisita	AS Id, xv.*
                , xp.IdSolConexionAutogenXProrroga	AS Id, xp.*
	            , ca.IdSolConexionAutogenContratoAnexo	AS Id, ca.*
            FROM CTE_SolConexion a
            INNER JOIN par.Estados es (NOLOCK) ON a.Estado = es.parIdEstado 
            INNER JOIN par.TipoGeneracion tg (NOLOCK) ON a.CodTipoGeneracion = tg.IdTipoGeneracion
            LEFT JOIN sol.SolConexionAutogenXVisita xv (NOLOCK) ON a.IdSolConexionAutogen = xv.CodSolConexionAutogen 
            LEFT JOIN sol.SolConexionAutogenXProrroga xp (NOLOCK) ON a.IdSolConexionAutogen = xp.CodSolConexionAutogen
            LEFT JOIN sol.SolConexionAutogenContratoAnexo ca (NOLOCK) ON a.IdSolConexionAutogen = ca.CodSolConexionAutogen 
            WHERE 1 = 1 [filtroInmueble]
        ";


        internal static string GetEntitiesByStatusAndStepsDate = @"
            WITH CTE_SolConexion AS (
                SELECT *
                FROM [sol].[SolConexionAutogen] (NOLOCK)
            )
            SELECT 
                a.IdSolConexionAutogen			AS Id, a.*
                , h.IdPasosConexionAutogen		AS Id, h.*
                , est2.parIdEstado              AS Id, est2.* 
            FROM CTE_SolConexion a
            LEFT JOIN sol.PasosSolConexionAutogen h (NOLOCK) ON a.IdSolConexionAutogen = h.CodSolConexionAutogen AND h.FechaRegistroUpdate <= [FechaRegistroLimite] AND h.CodEstado = [CodigoEstadoActual]
            LEFT JOIN par.Estados est2 (NOLOCK) ON h.CodEstado = est2.parIdEstado
            WHERE a.CodEstado = [CodigoEstadoActual]
        ";

        internal static string GetEntitiesByStatusAndDateValidation = @"
           WITH CTE_SolConexion AS (
                                        SELECT *
                                        FROM [sol].[SolConexionAutogen] (NOLOCK)
                                        WHERE Estado = @estado
                                   )
              , CTE_PasosSolConexion AS (
                                            SELECT
                                                h.*,
                                                ROW_NUMBER() OVER (PARTITION BY h.CodSolConexionAutogen ORDER BY h.FechaRegistroUpdate DESC) AS RowNum
                                            FROM sol.PasosSolConexionAutogen h (NOLOCK)
                                            WHERE h.CodEstado = @estado
                                        )
            SELECT	s.IdSolConexionAutogen AS Id, s.*,
		            h.IdPasosConexionAutogen AS Id, h.*,
                    e.parIdEstado AS Id, e.*
            FROM CTE_SolConexion s (NOLOCK)
            INNER JOIN CTE_PasosSolConexion h ON s.IdSolConexionAutogen = h.CodSolConexionAutogen AND h.RowNum = 1
            INNER JOIN par.Estados e ON h.CodEstado = e.parIdEstado 
            WHERE h.FechaRegistroUpdate <= @fechaRegistro
        ";

        internal static string GetEntitiesByNonConformingTechnicalDocumentationAnStepsDate = @"
            WITH CTE_SolConexion AS (
                                        SELECT *
                                        FROM [sol].[SolConexionAutogen] (NOLOCK)
                                        WHERE Estado = @estado AND 
                                                (
                                                    (@dias = 5  AND CodClasificacionProyecto IN (1,3)) OR 
                                                    (@dias = 10 AND CodClasificacionProyecto IN (2,4,5))
                                                )
                                    )
                , CTE_PasosSolConexion AS (
                                            SELECT
                                                h.*,
                                                ROW_NUMBER() OVER (PARTITION BY h.CodSolConexionAutogen ORDER BY h.FechaRegistroUpdate DESC) AS RowNum
                                            FROM sol.PasosSolConexionAutogen h (NOLOCK)
                                            WHERE h.CodEstado = @estado
                                        )
            SELECT	s.IdSolConexionAutogen AS Id, s.*,
                    h.IdPasosConexionAutogen AS Id, h.*,
                    e.parIdEstado AS Id, e.*
            FROM CTE_SolConexion s (NOLOCK)
            INNER JOIN CTE_PasosSolConexion h ON s.IdSolConexionAutogen = h.CodSolConexionAutogen AND h.RowNum = 1
            INNER JOIN par.Estados e ON h.CodEstado = e.parIdEstado   
            WHERE h.FechaRegistroUpdate <= @fechaRegistro
        ";

        internal static string GetEntitiesToDisconnectionByStatusAndStepsDate = @"
            WITH CTE_SolConexion AS (
                                        SELECT *
                                        FROM [sol].[SolConexionAutogen] (NOLOCK)
                                        WHERE Estado = @estado AND 
                                              (
                                                (CodTipoGeneracion IN(2,3) AND @idAlert =1743)  OR
                                                (CodTipoGeneracion = 1     AND @idAlert = 1742) OR
                                                (@idAlert = 1744)
                                              )
                                    )
              , CTE_PasosSolConexion AS (
                                            SELECT h.*,
                                                   ROW_NUMBER() OVER (PARTITION BY h.CodSolConexionAutogen ORDER BY h.FechaRegistroUpdate DESC) AS RowNum
                                            FROM sol.PasosSolConexionAutogen h (NOLOCK)
                                            WHERE h.CodEstado = @estado
                                        )
            SELECT	s.IdSolConexionAutogen AS Id, s.*,
		            h.IdPasosConexionAutogen AS Id, h.*,
                    e.parIdEstado AS Id, e.*
            FROM CTE_SolConexion s (NOLOCK)
            INNER JOIN CTE_PasosSolConexion h ON s.IdSolConexionAutogen = h.CodSolConexionAutogen AND h.RowNum = 1
            INNER JOIN sol.SolConexionAutogenReporteHallazgo rh ON rh.CodSolConexionAutogen = s.IdSolConexionAutogen AND rh.EnProceso = 1
            INNER JOIN par.Estados e ON h.CodEstado = e.parIdEstado 
            WHERE h.FechaRegistroUpdate <= @fechaRegistro AND rh.SubsanacionEnviada = 0
        ";

        internal static string GetEntitiesByVisitSchedule = @"
            WITH CTE_SolConexion AS (
                                        SELECT s.*
                                        FROM [sol].[SolConexionAutogen] (NOLOCK) s
							            LEFT JOIN sol.SolConexionAutogenTecnologias st on st.CodSolConexionAutogen = IdSolConexionAutogen
                                        WHERE s.Estado = @estado AND 
                                                (
                                                    (@dias = 180 AND CodTipoGeneracion IN (1,2)) OR 
                                                    (@dias = 720 AND CodTipoGeneracion IN (3) AND (EntregaExcedentes = 1 AND st.IdSolConexionAutogenTecnologias = 5) ) OR
                                                    (@dias = 360 AND CodTipoGeneracion IN (3) AND (EntregaExcedentes = 0  OR  (EntregaExcedentes = 1 AND st.IdSolConexionAutogenTecnologias != 5 )))
                                                )
                                    )
                , CTE_PasosSolConexion AS (
                                            SELECT
                                                h.*,
                                                ROW_NUMBER() OVER (PARTITION BY h.CodSolConexionAutogen ORDER BY h.FechaRegistroUpdate DESC) AS RowNum
                                            FROM sol.PasosSolConexionAutogen h (NOLOCK)
                                            WHERE h.CodEstado = @estado
                                        )   

            SELECT DISTINCT	s.IdSolConexionAutogen AS Id, s.*,
                            h.IdPasosConexionAutogen AS Id, h.*,
                            e.parIdEstado AS Id, e.*
            FROM CTE_SolConexion s (NOLOCK)
            INNER JOIN CTE_PasosSolConexion h ON s.IdSolConexionAutogen = h.CodSolConexionAutogen AND h.RowNum = 1
            INNER JOIN par.Estados e ON h.CodEstado = e.parIdEstado    
            WHERE h.FechaRegistroUpdate <= @fechaRegistro AND s.DocumentacionVisitaEntregada != 1
        ";

        internal static string GetEntitiesByOthersJobs = @"
            WITH CTE_SolConexion AS (
                                        SELECT s.*
                                        FROM [sol].[SolConexionAutogen] (NOLOCK) s
							            LEFT JOIN sol.SolConexionAutogenTecnologias st on st.CodSolConexionAutogen = IdSolConexionAutogen
                                        WHERE s.Estado = @estado AND 
                                                (
                                                    (@dias = 180 AND CodTipoGeneracion IN (1,2)) OR 
                                                    (@dias = 720 AND CodTipoGeneracion IN (3) AND (EntregaExcedentes = 1 AND st.IdSolConexionAutogenTecnologias = 5) ) OR
                                                    (@dias = 360 AND CodTipoGeneracion IN (3) AND (EntregaExcedentes = 0  OR  (EntregaExcedentes = 1 AND st.IdSolConexionAutogenTecnologias != 5 )))
                                                )
                                    )
                , CTE_PasosSolConexion AS (
                                            SELECT
                                                h.*,
                                                ROW_NUMBER() OVER (PARTITION BY h.CodSolConexionAutogen ORDER BY h.FechaRegistroUpdate DESC) AS RowNum
                                            FROM sol.PasosSolConexionAutogen h (NOLOCK)
                                            WHERE h.CodEstado = @estado
                                        )   

            SELECT DISTINCT	s.IdSolConexionAutogen AS Id, s.*,
                            h.IdPasosConexionAutogen AS Id, h.*,
                            e.parIdEstado AS Id, e.*
            FROM CTE_SolConexion s (NOLOCK)
            INNER JOIN CTE_PasosSolConexion h ON s.IdSolConexionAutogen = h.CodSolConexionAutogen AND h.RowNum = 1
            INNER JOIN par.Estados e ON h.CodEstado = e.parIdEstado    
            WHERE h.FechaRegistroUpdate <= @fechaRegistro
        ";

        internal static string GetEntitiesByProrrogaJob = @"
            WITH CTE_SolConexion AS (
                                        SELECT s.*
                                        FROM [sol].[SolConexionAutogen] (NOLOCK) s
							            LEFT JOIN sol.SolConexionAutogenTecnologias st on st.CodSolConexionAutogen = IdSolConexionAutogen
                                        WHERE s.Estado = @estado AND 
                                              (
                                                (
                                                    @dias = 720 AND s.CodClasificacionProyecto IN (3) AND 
                                                    (s.EntregaExcedentes = 1 AND st.IdSolConexionAutogenTecnologias = 5)
                                                ) OR
	                                            (
                                                    @dias = 360 AND s.CodClasificacionProyecto IN (3) AND 
                                                    (s.EntregaExcedentes = 1 AND st.IdSolConexionAutogenTecnologias != 5)
                                                )
                                              )
                                    )
                , CTE_PasosSolConexion AS (
                                            SELECT
                                                h.*,
                                                ROW_NUMBER() OVER (PARTITION BY h.CodSolConexionAutogen ORDER BY h.FechaRegistroUpdate DESC) AS RowNum
                                            FROM sol.PasosSolConexionAutogen h (NOLOCK)
                                            WHERE h.CodEstado = @estado
                                        ) 
            SELECT DISTINCT s.IdSolConexionAutogen AS Id, s.*,
                            h.IdPasosConexionAutogen AS Id, h.*,
				            e.parIdEstado AS Id, e.*
            FROM CTE_SolConexion s 
            INNER JOIN CTE_PasosSolConexion h ON s.IdSolConexionAutogen = h.CodSolConexionAutogen AND h.RowNum = 1
            INNER JOIN par.Estados e ON h.CodEstado = e.parIdEstado    
            WHERE h.FechaRegistroUpdate <= @fechaRegistro	              
        ";

        internal static string GetTecnologiasUtilBySolicitud = @"
            SELECT IdSolConexionAutogenTecnUtilizadas AS Id, * 
            FROM sol.SolConexionAutogenTecnUtilizadas (NOLOCK) 
            WHERE CodSolConexionAutogen = @IdSolicitud;
        ";

        internal static string GetAnexosBySolicitud = @"
            SELECT IdSolConexionAutogenAnexos AS Id, *
            FROM sol.SolConexionAutogenAnexos (NOLOCK)
            WHERE CodSolConexionAutogen = @IdSolicitud AND EstadoDocumento = 1
            ORDER BY IdSolConexionAutogenAnexos DESC;
        ";

        internal static string GetContratoConexionAnexosBySolicitud = @"
            SELECT IdSolConexionAutogenContratoAnexo AS Id, *
            FROM sol.SolConexionAutogenContratoAnexo (NOLOCK)
            WHERE CodSolConexionAutogen = @IdSolicitud
            ORDER BY IdSolConexionAutogenContratoAnexo DESC;
        ";

        internal static string GetAnexoRechazosBySolicitud = @"
            SELECT IdSolConexionAutogenAnexoRechazo AS Id, AR.*,
                   IdSolConexionAutogenAnexoRechazoAnexos AS Id, ARA.*
            FROM sol.SolConexionAutogenAnexoRechazo AR (NOLOCK) 
            LEFT JOIN sol.SolConexionAutogenAnexoRechazoAnexos ARA (NOLOCK)  ON AR.IdSolConexionAutogenAnexoRechazo = ARA.CodSolConexionAutogenAnexoRechazo
            WHERE CodSolConexionAutogen = @IdSolicitud
            ORDER BY IdSolConexionAutogenAnexoRechazo DESC;
        ";

        internal static string GetViabilidadTecnicaRechazos = @"
             SELECT IdSolConexionAutogenViabilidadTecnicaRechazo		AS Id, R.*,
                    IdSolConexionAutogenViabilidadTecnicaRechazoAnexos	AS Id, RA.*
             FROM sol.SolConexionAutogenViabilidadTecnicaRechazo R (NOLOCK) 
             LEFT JOIN sol.SolConexionAutogenViabilidadTecnicaRechazoAnexos RA (NOLOCK)  ON R.IdSolConexionAutogenViabilidadTecnicaRechazo = RA.CodSolConexionAutogenViabilidadTecnicaRechazo
             WHERE CodSolConexionAutogen = @IdSolicitud
             ORDER BY IdSolConexionAutogenViabilidadTecnicaRechazo DESC;
        ";

        internal static string GetConexionRechazosBySolicitud = @"
             SELECT 
	            IdSolConexionAutogenConexionRechazo AS Id, 
	            CONCAT('Visita #', ROW_NUMBER() over(order by IdSolConexionAutogenConexionRechazo asc)) AS NumVisita, r.*,
                IdSolConexionAutogenConexionRechazoAnexos AS Id, ra.*
            FROM sol.SolConexionAutogenConexionRechazo r (NOLOCK) 
            LEFT JOIN sol.SolConexionAutogenConexionRechazoAnexos ra (NOLOCK)  ON R.IdSolConexionAutogenConexionRechazo = RA.CodSolConexionAutogenConexionRechazo
            WHERE CodSolConexionAutogen = @IdSolicitud
            ORDER BY IdSolConexionAutogenConexionRechazo DESC;
        ";

        internal static string GetDesistimientosBySolicitud = @"
            SELECT IdSolConexionAutogenDesistimiento AS Id, D.*,
                   IdSolConexionAutogenDesistimientoAnexos AS Id, DA.*
            FROM sol.SolConexionAutogenDesistimiento D (NOLOCK) 
            LEFT JOIN sol.SolConexionAutogenDesistimientoAnexos DA (NOLOCK)  ON D.IdSolConexionAutogenDesistimiento = DA.CodSolConexionAutogenDesistimiento
            WHERE CodSolConexionAutogen = @IdSolicitud
            ORDER BY IdSolConexionAutogenDesistimiento DESC;
        ";

        internal static string GetDocumentacionRetieRechazoBySolicitud = @"
            SELECT IdSolConexionAutogenDocumentacionRetieRechazo AS Id, R.*,
                   IdSolConexionAutogenDocumentacionRetieRechazoAnexos AS Id, RA.*
            FROM sol.SolConexionAutogenDocumentacionRetieRechazo R (NOLOCK) 
            LEFT JOIN sol.SolConexionAutogenDocumentacionRetieRechazoAnexos RA (NOLOCK)  ON R.IdSolConexionAutogenDocumentacionRetieRechazo = RA.CodSolConexionAutogenDocumentacionRetieRechazo
            WHERE CodSolConexionAutogen = @IdSolicitud
            ORDER BY IdSolConexionAutogenDocumentacionRetieRechazo DESC;
        ";

        internal static string GetPasosBySolicitud = @"
            SELECT 
	            ps.IdPasosConexionAutogen					AS Id, ps.*
                , es2.parIdEstado							AS Id, es2.*
                , et2.IdEtapa								AS Id, et2.*
	            , rh.IdSolConexionAutogenReporteHallazgo	AS Id, rh.*
            FROM sol.PasosSolConexionAutogen ps (NOLOCK) 
            INNER JOIN par.Estados es2 (NOLOCK) ON ps.CodEstado = es2.parIdEstado 
            LEFT  JOIN par.Etapas et2 (NOLOCK) ON es2.CodEtapa = et2.IdEtapa
            LEFT  JOIN sol.SolconexionAutogenReporteHallazgo rh (NOLOCK) ON ps.CodSolconexionAutogenReporteHallazgo = rh.IdSolConexionAutogenReporteHallazgo
            WHERE ps.CodSolConexionAutogen = @IdSolicitud
            ORDER BY ps.IdPasosConexionAutogen DESC;
        ";

        internal static string GetPasosByRadicado = @"
            SELECT 
                ps.IdPasosConexionAutogen	    AS Id, ps.*
                , es2.parIdEstado               AS Id, es2.*
                , et2.IdEtapa					AS Id, et2.*
            FROM sol.PasosSolConexionAutogen ps (NOLOCK) 
            INNER JOIN sol.SolConexionAutogen a (NOLOCK) ON ps.CodSolConexionAutogen = a.IdSolConexionAutogen
            INNER JOIN par.Estados es2 (NOLOCK) ON ps.CodEstado = es2.parIdEstado 
            LEFT  JOIN par.Etapas et2 (NOLOCK) ON es2.CodEtapa = et2.IdEtapa
            WHERE a.NumeroRadicado = @Radicado
            ORDER BY ps.IdPasosConexionAutogen DESC;
        ";

        internal static string GetProrrogaBySolicitud = @"
            SELECT 
	            pr.IdSolConexionAutogenXProrroga			AS Id, pr.*
	            , pra.IdSolConexionAutogenXProrrogaAnexos	AS Id, pra.*
            FROM sol.SolConexionAutogenXProrroga pr (NOLOCK) 
            LEFT  JOIN sol.SolConexionAutogenXProrrogaAnexos pra (NOLOCK) ON pr.IdSolConexionAutogenXProrroga = pra.CodSolConexionAutogenXProrroga 
            WHERE pr.CodSolConexionAutogen = @IdSolicitud;
        ";

        internal static string GetVisitaBySolicitud = @"
            SELECT 
	            vi.IdSolConexionAutogenXVisita					AS Id, vi.*
	            , via.IdSolConexionAutogenXVisitaAnexos			AS Id, via.*
	            , b.IdSolConexionAutogenXVisitaRechazo			AS Id, b.*
	            , c.IdSolConexionAutogenXVisitaRechazoAnexos	AS Id, c.*
            FROM sol.SolConexionAutogenXVisita vi (NOLOCK)
            LEFT JOIN sol.SolConexionAutogenXVisitaAnexos via (NOLOCK) ON vi.IdSolConexionAutogenXVisita = via.CodSolConexionAutogenXVisita 
            LEFT JOIN sol.SolConexionAutogenXVisitaRechazo b (NOLOCK) ON vi.IdSolConexionAutogenXVisita = b.CodSolConexionAutogenXVisita
            LEFT JOIN sol.SolConexionAutogenXVisitaRechazoAnexos c (NOLOCK) ON b.IdSolConexionAutogenXVisitaRechazo = c.CodSolConexionAutogenXVisitaRechazo
            WHERE vi.CodSolConexionAutogen = @IdSolicitud;
        ";

        internal static string GetDocVisitaBySolicitud = @"
            SELECT dv.IdSolConexionAutogenDocumentacionVisita AS Id, dv.* 
            FROM sol.SolConexionAutogenDocumentacionVisita dv (NOLOCK)
            WHERE dv.CodSolConexionAutogen = @IdSolicitud

            SELECT dva.IdSolConexionAutogenDocumentacionVisitaAnexos AS Id, dva.* 
            FROM sol.SolConexionAutogenDocumentacionVisita dv (NOLOCK)
            LEFT JOIN sol.SolConexionAutogenDocumentacionVisitaAnexos dva (NOLOCK) ON dv.IdSolConexionAutogenDocumentacionVisita = dva.CodSolConexionAutogenDocumentacionVisita
            WHERE dv.CodSolConexionAutogen = @IdSolicitud
            ORDER BY dva.IdSolConexionAutogenDocumentacionVisitaAnexos DESC

            SELECT b.IdSolConexionAutogenDocumentacionVisitaRechazo AS Id, b.* 
            FROM sol.SolConexionAutogenDocumentacionVisita dv (NOLOCK)
            INNER JOIN sol.SolConexionAutogenDocumentacionVisitaRechazo b (NOLOCK) ON dv.IdSolConexionAutogenDocumentacionVisita = b.CodSolConexionAutogenDocumentacionVisita
            WHERE dv.CodSolConexionAutogen = @IdSolicitud

            SELECT c.IdSolConexionAutogenDocumentacionVisitaRechazoAnexos AS Id, c.* 
            FROM sol.SolConexionAutogenDocumentacionVisita dv (NOLOCK)
            INNER JOIN sol.SolConexionAutogenDocumentacionVisitaRechazo b (NOLOCK) ON dv.IdSolConexionAutogenDocumentacionVisita = b.CodSolConexionAutogenDocumentacionVisita
            LEFT JOIN sol.SolConexionAutogenDocumentacionVisitaRechazoAnexos c (NOLOCK) ON b.IdSolConexionAutogenDocumentacionVisitaRechazo = c.CodSolConexionAutogenDocumentacionVisitaRechazo
            WHERE dv.CodSolConexionAutogen = @IdSolicitud
        ";

        /*
        internal static string GetDocVisitaBySolicitud = @"
            SELECT 
	            dv.IdSolConexionAutogenDocumentacionVisita			        AS Id, dv.*
	            , dva.IdSolConexionAutogenDocumentacionVisitaAnexos	        AS Id, dva.*
	            , b.IdSolConexionAutogenDocumentacionVisitaRechazo	        AS Id, b.*
                , c.IdSolConexionAutogenDocumentacionVisitaRechazoAnexos    AS Id, c.*
            FROM sol.SolConexionAutogenDocumentacionVisita dv (NOLOCK)
            LEFT JOIN sol.SolConexionAutogenDocumentacionVisitaAnexos dva (NOLOCK) ON dv.IdSolConexionAutogenDocumentacionVisita = dva.CodSolConexionAutogenDocumentacionVisita
            LEFT JOIN sol.SolConexionAutogenDocumentacionVisitaRechazo b (NOLOCK) ON dv.IdSolConexionAutogenDocumentacionVisita = b.CodSolConexionAutogenDocumentacionVisita
            LEFT JOIN sol.SolConexionAutogenDocumentacionVisitaRechazoAnexos c (NOLOCK) ON b.IdSolConexionAutogenDocumentacionVisitaRechazo = c.CodSolConexionAutogenDocumentacionVisitaRechazo
            WHERE dv.CodSolConexionAutogen = @IdSolicitud;
        ";
        */

        internal static string GetComentarioBySolicitud = @"
            SELECT 
	            sc.IdSolConexionAutogenComentario			AS Id, sc.*
	            , sca.IdSolConexionAutogenComentarioAnexos	AS Id, sca.*
            FROM sol.SolConexionAutogenComentario sc (NOLOCK) 
            LEFT JOIN sol.SolConexionAutogenComentarioAnexos sca (NOLOCK) ON sc.IdSolConexionAutogenComentario = sca.CodSolConexionAutogenComentario 
            WHERE sc.CodSolConexionAutogen = @IdSolicitud
            ORDER BY sc.IdSolConexionAutogenComentario DESC;
        ";

        internal static string GetObservacionBySolicitud = @"
            SELECT 
	            ob.IdSolConexionAutogenObservacion			AS Id, ob.*
	            , oba.IdSolConexionAutogenObservacionAnexos	AS Id, oba.*
            FROM sol.SolConexionAutogenObservacion ob (NOLOCK)
            LEFT JOIN sol.SolConexionAutogenObservacionAnexos oba (NOLOCK) ON ob.IdSolConexionAutogenObservacion = oba.CodSolConexionAutogenObservacion
            WHERE ob.CodSolConexionAutogen = @IdSolicitud;
        ";

        internal static string GetInsumosBySolicitud = @"
            SELECT 
                si.IdSolConexionAutogenInsumos			AS Id, si.*
                , sia.IdSolConexionAutogenInsumosAnexos AS Id, sia.*
            FROM sol.SolConexionAutogenInsumos si (NOLOCK) 
            LEFT JOIN sol.SolConexionAutogenInsumosAnexos sia (NOLOCK) ON si.IdSolConexionAutogenInsumos = sia.CodSolConexionAutogenInsumos AND sia.EstadoDocumento = 1
            WHERE si.CodSolConexionAutogen = @IdSolicitud AND si.Estado = 1
            ORDER BY si.IdSolConexionAutogenInsumos DESC;
        ";

        internal static string GetReporteHallazgosBySolicitud = @"
            SELECT 
                rh.IdSolConexionAutogenReporteHallazgo AS Id, rh.*,
                rha.IdSolConexionAutogenReporteHallazgoAnexos AS Id, rha.*
            FROM sol.SolConexionAutogenReporteHallazgo rh (NOLOCK) 
            LEFT JOIN sol.SolConexionAutogenReporteHallazgoAnexos rha (NOLOCK) ON rh.IdSolConexionAutogenReporteHallazgo = rha.CodSolConexionAutogenReporteHallazgo 
            WHERE rh.CodSolConexionAutogen = @IdSolicitud AND rh.Estado = 1
            ORDER BY rh.IdSolConexionAutogenReporteHallazgo DESC
        ";

        internal const string GetEntitiesTrafo = @"
            WITH CTE_SolConexion AS (
                SELECT *
                FROM [sol].[SolConexionAutogen] (NOLOCK)
                WHERE 
                    Empresa = @Empresa
                    AND CodTransformador = @CodTransformador
            )
            SELECT 
	            a.IdSolConexionAutogen	AS Id, a.*
	            , es.parIdEstado		AS Id, es.*
	            , tg.IdTipoGeneracion	AS Id, tg.*
                , xv.IdSolConexionAutogenXVisita	AS Id, xv.*
                , xp.IdSolConexionAutogenXProrroga	AS Id, xp.*
            FROM CTE_SolConexion a
            INNER JOIN par.Estados es (NOLOCK) ON a.Estado = es.parIdEstado 
            INNER JOIN par.TipoGeneracion tg (NOLOCK) ON a.CodTipoGeneracion = tg.IdTipoGeneracion
            LEFT JOIN sol.SolConexionAutogenXVisita xv (NOLOCK) ON a.IdSolConexionAutogen = xv.CodSolConexionAutogen 
            LEFT JOIN sol.SolConexionAutogenXProrroga xp (NOLOCK) ON a.IdSolConexionAutogen = xp.CodSolConexionAutogen
        ";
    }
}
