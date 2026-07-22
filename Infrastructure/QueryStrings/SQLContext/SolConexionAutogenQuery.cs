namespace Infrastructure.QueryStrings.SQLContext
{
    internal static class SolConexionAutogenQuery
    {
        
        internal static string GetTecnologiasUtilBySolicitud = @"            
            SELECT 
                B.ID,
                B.COD_174_AUTOGEN AS Cod174Autogen,
                B.COD_TIPO_TECNOLOGIA AS CodTipoTecnologia,
                B.OTRO_TIPO_TECNOLOGIA AS OtroTipoTecnologia,
                B.CAPACIDAD_KW_POR_TECNOLOGIA AS CapacidadKwPorTecnologia,
                B.FECHA_REGISTRO AS FechaRegistro
            FROM CREG_174_TECN_UTILIZADAS B
            INNER JOIN CREG_174_AUTOGEN A
                ON A.NUMERO_RADICADO = :IdSolicitud
            WHERE B.COD_174_AUTOGEN = A.ID            
        ";

        internal static string GetAnexosBySolicitud = @"
            SELECT 
                B.ID,
                B.COD_174_AUTOGEN              AS Cod174Autogen,
                B.COD_DOCUMENTOS_XFORMULARIO   AS CodDocumentosXformulario,
                B.NAME_DOCUMENT                AS NameDocument,
                B.EXT_DOCUMENT                 AS ExtDocument,
                B.SIZE_DOCUMENT                AS SizeDocument,
                B.URL_DOCUMENT                 AS UrlDocument,
                B.URL_REL_DOCUMENT             AS UrlRelDocument,
                B.ORIGINAL_NAMEDO_CUMENT       AS OriginalNamedoCument,
                B.ESTADO_DOCUMENTO             AS EstadoDocumento,
                B.EXPEDICION                   AS Expedicion,
                B.VALIDATION_DOCUMENT          AS ValidationDocument,
                B.SEND_NOTIFICATION             AS SendNotification
            FROM CREG_174_ANEXOS B
            INNER JOIN CREG_174_AUTOGEN A
                ON A.NUMERO_RADICADO = :IdSolicitud
            WHERE B.COD_174_AUTOGEN = A.ID AND Estado_Documento = 1
            ORDER BY ID DESC
        ";

        internal static string GetPasosBySolicitud = @"
            SELECT 
	            ps.ID
                ,ps.ID_EMPRESA
                ,ps.COD_174_AUTOGEN
                ,ps.COD_ESTADO
                ,ps.FECHA_REGISTRO AS FechaRegistro
                ,ps.ESTADO
                ,es2.ID
                ,es2.COD_TIPO_ESTADO
                ,es2.COD_ETAPA
                ,es2.DESCRIPCION
                ,es2.ESTADO                
            FROM CREG_174_PASOS ps 
            INNER JOIN CREG_174_AUTOGEN A
                ON A.NUMERO_RADICADO = :IdSolicitud
            INNER JOIN CREG_Estados es2 ON ps.Cod_Estado = es2.Id             
            WHERE ps.COD_174_AUTOGEN = A.ID
            ORDER BY ps.Id ASC";

        internal const string GetEntitiesTrafo = @"
            SELECT
                SUM(POTENCIA_MAXIMA_DECLARADA) AS PotenciaMaximaDeclarada
            FROM CREG_174_AUTOGEN
            WHERE 
                COD_EMPRESA = :Empresa
                AND COD_TRANSFORMADOR = :CodTransformador
                AND COD_ESTADO = 18";
    }
}
