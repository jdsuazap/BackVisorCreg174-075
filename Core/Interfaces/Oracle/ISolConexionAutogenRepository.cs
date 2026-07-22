namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle;
    public interface ISolConexionAutogenRepository
    {
        Task<Creg174Autogen> GetEntity(int idEntity, int? CodEmpresa);

        Task<List<Creg174TecnUtilizada>> GetTecnologiasUtilBySolicitud(int idEntity);
        Task<List<Creg174Anexo>> GetAnexosBySolicitud(int idEntity);
        Task<List<Creg174Pasos>> GetPasosBySolicitud(int idEntity);
        Task<Creg174Autogen> GetEntitiesTrafo(int Empresa, string CodTransformador);
    }
}
