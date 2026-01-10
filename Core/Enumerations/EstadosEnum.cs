namespace Core.Enumerations
{
    public enum EstadosEnum
    {
        // Usuario
        Pendiente_aprobar = 1,
        Activo = 2,
        Inactivo = 3,

        // Creg174
        Solicitud_registrada = 4,
        Revision_de_completitud_de_documentacion = 5,
        Documentacion_incompleta = 6,
        Desistimiento_de_solicitud = 7,
        Preparacion_de_insumos = 8,
        Insumos_entregados = 9,
        Verificacion_tecnica_de_la_documentacion = 10,
        Documentacion_tecnica_no_conforme = 11,
        Viabilidad_tecnica_conforme = 12,
        Revision_de_la_documentacion_para_la_visita_de_conexion = 13,
        Pendiente_de_documentacion_para_la_visita_de_conexion = 14,
        Conforme_para_solicitar_visita_de_conexion = 15,
        Visita_para_la_conexion = 16,
        Visita_para_la_conexion_no_conforme = 17,
        En_conexion = 18,
        Desconexion = 19,
        Suspendido = 20,
        Reconexion = 21,
        Anulacion_de_solicitud = 49,

        #region Prorroga
        Solicitud_de_prorroga = 22,
        Prorroga_validacion_de_la_garantía = 23,
        Prorroga_no_aprobada = 24,
        Prorroga_aprobada = 25,
        Prorroga_aprobada_GD_AGPE = 53,
        #endregion

        #region Flujo desconexion
        Usuario_notificado_para_revision = 26,
        Pendiente_subsanacion_de_hallazgo_grave = 27,
        Pendiente_subsanacion_de_hallazgo_no_grave = 28,
        Visita_realizada = 50,
        #endregion

        // Creg075
        Creg_075_Recepcion_solicitud = 29,
        Creg_075_Pendiente_documentacion = 30,
        Creg_075_Estudio_factibilidad = 31,
        Creg_075_Factibilidad_servicio_otorgada = 32,
        Creg_075_Revision_diseños = 33,
        Creg_075_Pendiente_documentacion_diseños = 34,
        Creg_075_Diseño_conforme = 35,
        Creg_075_Diseño_no_conforme = 36,
        Creg_075_Solicitud_de_seguimiento_a_la_obra = 37,
        Creg_075_Pendiente_documentacion_seguimiento_a_la_obra = 38,
        Creg_075_Seguimiento_a_la_obra_conforme = 39,
        Creg_075_Seguimiento_a_la_obra_no_conforme = 40,
        Creg_075_Solicitud_recibo_tecnico = 41,
        Creg_075_Pendiente_documentacion_recibo_tecnico = 42,
        Creg_075_Recibo_tecnico_aprobado = 43,
        Creg_075_Recibo_tecnico_rechazado = 44,
        Creg_075_Recibo_tecnico_aprobado_de_la_etapa = 45,
        Creg_075_Desistimiento_de_solicitud = 46,
        Creg_075_Anulacion_de_solicitud = 47,
        Creg_075_Solicitud_Sencilla_Aprobada = 51,
        Creg_075_Solicitud_Sencilla_Rechazada = 52,
    }
}