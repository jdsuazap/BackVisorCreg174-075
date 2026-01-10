namespace Core.Enumerations
{
    /// <summary>
    /// Ids cuerpos de correos parametrizables
    /// </summary>
    /// 
    //TODO:
    // agregar asunto tabla cuerpo correo

    public enum CuerpoCorreoEnum
    {
        //CREG 174
        Documentacion_completa = 1,
        Solicitud_nueva_autogeneracion = 2,
        Solicitud_nueva_autogeneracion_gestor = 56,
        Actualizacion_Solicitud_Autogeneracion = 3,
        Solicitud_nueva_prorroga = 4,
        Solicitud_nueva_prorroga_gestor = 57,
        Creg174_Solicitud_nueva_visita = 6,
        Documentacion_pendiente = 8,
        Preparacion_Insumos = 9,
        Envio_Insumos = 10,
        Visita_tecnica_No_Conforme = 24,
        Programacion_Visita_Conexion = 25,
        Conforme_Visita_Conexion = 44,
        Anulacion_solicitud_gestor = 58,
        Anulacion_solicitud = 59,
        Entrega_Subsanacion= 60,
        Entrega_Estudio_Conexion_Cliente = 61,
        Retie_Conforme = 62,
        Retie_no_Conforme = 63,
        Entrega_documentacion_visita_conexion = 64,
        No_Conforme_Visita_Conexion = 65,
        Conforme_Visita_Tecnica = 66,
        No_Conforme_Visita_Tecnica = 67,
        Visita_Conexion_Conforme = 68,


        // cre 075//
        Creg075_Solicitud_nueva = 5,
        Creg075_Solicitud_Actualizacion_Estado_Solicitud = 7,
        Creg075_Notificacion_Factibilidad_Servicio_Otorgada = 27,
        Creg075_Notificacion_Documentacion_Pendiente_Diseños = 28,
        Creg075_Notificacion_Documentacion_Pendiente_Seguimiento_Obra = 29,
        Creg075_Notificacion_Documentacion_Pendiente_Recibo_Tecnico = 30,
        Creg075_Notificacion_Documentacion_Pendiente_Registro_Solicitud = 31,
        Creg075_Notificacion_Recibo_Tecnico_parcial = 34,
        Creg075_Notificacion_Revision_Diseños = 32,
        Creg075_Notificacion_Seguimiento_Obra = 33,
        Creg075_Recibo_Tecnico_Aprobado = 35,
        Creg075_Recibo_Tecnico_Rechazado = 36,
        Creg075_Desistimiento_Solicitud = 37,
        Creg075_Anulacion_Solicitud = 38,
        Creg075_Notificacion_Desistimiento= 54,
        Creg075_Subsanacion_Documentacion_Pendiente = 55,
        Creg075_Aprobacion_Solicitud_Sencilla = 69,
        Creg075_Rechazo_Solicitud_Sencilla = 70
    }
}
