namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle;
    public interface ISolConexionAutogenRepository
    {
        Task<Creg174Autogen> GetEntity(int idEntity, int? CodEmpresa);

        Task<List<Creg174TecnUtilizada>> GetTecnologiasUtilBySolicitud(int idEntity);
        Task<List<Creg174Anexo>> GetAnexosBySolicitud(int idEntity);
        //Task<List<PasosSolConexionAutogen>> GetPasosBySolicitud(int idEntity);
        //Task<List<PasosSolConexionAutogen>> GetPasosByRadicado(string numRadicado);

        //Task<List<SolConexionAutogenXvisita>> GetVisitaBySolicitud(int idEntity);
        //Task<List<SolConexionAutogenDocumentacionVisita>> GetDocVisitaBySolicitud(int idEntity);
        //Task<List<SolConexionAutogenComentario>> GetComentarioBySolicitud(int idEntity);
        //Task<List<SolConexionAutogenObservacion>> GetObservacionBySolicitud(int idEntity);
        
        Task<Creg174Autogen> GetEntitiesTrafo(int Empresa, string CodTransformador);
    }
}
