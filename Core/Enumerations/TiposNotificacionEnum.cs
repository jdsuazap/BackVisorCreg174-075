namespace Core.Enumerations
{
    /// <summary>
    /// Ids Tipos de Notificaciones
    /// </summary>
    public enum TiposNotificacionEnum
    {
        #region CREG 075
        Creg075_NuevaSolicitud = 4,
        Creg075_ActualizacionSolicitud = 6,
        #endregion

        #region CREG 174
        Creg174_NuevaSolicitud = 1,
        Creg174_ActualizacionSolicitud = 2,
        Creg174_NuevaSolicitudProrroga = 3,
        Creg174_NuevaSolicitudVisita = 5,
        Creg174_Documentacion_Completa = 1741,
        Creg174_Documentacion_Pendiente = 1742,
        Creg174_En_conexion = 1743,
        Creg174_Visita_para_la_conexion_no_conforme = 1744,
        Creg174_Desistimiento_de_solicitud = 1745,
        Creg174_Supendido = 1746,
        Creg174_RetiroVoluntario = 1747,
        Creg174_Desconexion = 1748,
        Creg174_Reconexion = 1749,
        Creg174_Prorroga_Aprobada = 1750,
        Creg174_Prorroga_No_Aprobada = 1751,
        Creg174_Entrega_Garantia = 1752,
        Creg174_Tiempo_Prorroga_Expirado = 1753,
        Creg174_Solicitud_Visita_Aprobada = 1754,
        Creg174_Solicitud_Visita_No_Aprobada = 1755,
        Creg174_Hallazgo_Encontrado = 1756,
        Creg174_Subsanacion_Rechazada = 1757,
        Creg174_Pendiente_Documentacion_Visita = 1758,
        Creg174_Conforme_Solicitar_Visita = 1759,
        Creg174_Documentacion_RETIE_Aprobada = 1760,
        Creg174_Documentacion_RETIE_No_Aprobada = 1761,
        Creg174_AnulacionSolicitud = 1762,
        Creg174_Entrega_RETIE = 1763,
        Creg174_Envio_Contrato_conexion = 1764,
        Creg174_Entrega_Contrato_conexion = 1765,
        #endregion
    }
}
