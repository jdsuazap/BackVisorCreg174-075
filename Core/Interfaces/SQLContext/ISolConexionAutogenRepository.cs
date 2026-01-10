namespace Core.Interfaces.SQLContext
{
    using Core.Entities.SQLContext;
    public interface ISolConexionAutogenRepository
    {
        Task<SolConexionAutogen> GetEntity(int idEntity);
        
        Task<List<SolConexionAutogenTecnUtilizada>> GetTecnologiasUtilBySolicitud(int idEntity);
        Task<List<SolConexionAutogenAnexo>> GetAnexosBySolicitud(int idEntity);
        //Task<List<SolConexionAutogenContratoAnexo>> GetContratoConexionAnexosBySolicitud(int idEntity);
        Task<List<PasosSolConexionAutogen>> GetPasosBySolicitud(int idEntity);
        Task<List<PasosSolConexionAutogen>> GetPasosByRadicado(string numRadicado);
        //Task<List<SolConexionAutogenXprorroga>> GetProrrogaBySolicitud(int idEntity);
        //Task<List<SolConexionAutogenXvisita>> GetVisitaBySolicitud(int idEntity);
        //Task<List<SolConexionAutogenDocumentacionVisita>> GetDocVisitaBySolicitud(int idEntity);
        //Task<List<SolConexionAutogenComentario>> GetComentarioBySolicitud(int idEntity);
        Task<List<SolConexionAutogenObservacion>> GetObservacionBySolicitud(int idEntity);
        Task<List<SolConexionAutogenInsumo>> GetInsumosBySolicitud(int idEntity);
        //Task<List<SolConexionAutogenReporteHallazgo>> GetReporteHallazgosBySolicitud(int idEntity);
        //Task<List<SolConexionAutogenAnexoRechazo>> GetAnexoRechazosBySolicitud(int idEntity);
        //Task<List<SolConexionAutogenViabilidadTecnicaRechazo>> GetViabilidadTecnicaRechazos(int idEntity);
        //Task<List<SolConexionAutogenConexionRechazo>> GetConexionRechazosBySolicitud(int idEntity);
        //Task<List<SolConexionAutogenDocumentacionRetieRechazo>> GetDocumentacionRetieRechazoBySolicitud(int idEntity);
        //Task<List<SolConexionAutogenDesistimiento>> GetDesistimientosBySolicitud(int idEntity);
    }
}
