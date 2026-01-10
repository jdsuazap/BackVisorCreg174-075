namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle;
    public interface ITipoClaseCargaRepository
    {
        Task<CregTipoClaseCarga> CreateEntity(CregTipoClaseCarga entity);
        Task<bool> DeleteEntity(CregTipoClaseCarga entity);
        Task<List<CregTipoClaseCarga>> GetEntities();
        Task<CregTipoClaseCarga> GetEntity(int idEntity);
        Task<CregTipoClaseCarga> UpdateEntity(CregTipoClaseCarga entity);
    }
}
