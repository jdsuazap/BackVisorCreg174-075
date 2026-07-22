namespace Infrastructure.QueryStrings.SQLContext
{
    internal static class SolServicioConexionQuery
    {

        internal const string GetAnexosBySolicitud = @"
            SELECT 
                A.ID                             AS Id,
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
            FROM CREG_075_ANEXOS A
            INNER JOIN CREG_075_SERVICIO_CONEXION  B
                ON A.COD_075_CONEXION = B.ID
            WHERE B.NUMERO_RADICADO = :IdSolicitud AND ESTADO_DOCUMENTO = 1
        ";

        internal static string GetPasosBySolicitud = @"
            SELECT 
                PS.ID
                ,PS.COD_075_CONEXION
                ,PS.COD_ESTADO
                ,PS.ETAPA
                ,PS.ESTADO
                ,PS.FECHA_REGISTRO AS FechaRegistro
                ,ES.ID
                ,ES.COD_TIPO_ESTADO
                ,ES.COD_ETAPA
                ,ES.DESCRIPCION
                ,ES.ESTADO
                ,ES.HOMOLOGACION
                ,ET.ID
                ,ET.COD_TIPO_ETAPA
                ,ET.DESCRIPCION
                ,ET.ESTADO
            FROM CREG_075_PASOS PS
            INNER JOIN CREG_075_SERVICIO_CONEXION A
                ON PS.COD_075_CONEXION = A.ID
            INNER JOIN CREG_ESTADOS ES ON PS.COD_ESTADO = ES.ID 
            LEFT  JOIN CREG_ETAPAS ET ON ES.COD_ETAPA = ET.ID
            WHERE A.NUMERO_RADICADO = :IdSolicitud
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
            WHERE A.NUMERO_RADICADO = :IdSolicitud
        ";
    }
}
