using Core.Entities.SQLContext;

namespace Core.Interfaces.SQLContext
{
    public interface ITipoClaseCargaRepository
    {
        Task<TipoClaseCarga> CreateEntity(TipoClaseCarga entity);
        Task<bool> DeleteEntity(TipoClaseCarga entity);
        Task<List<TipoClaseCarga>> GetEntities();
        Task<TipoClaseCarga> GetEntity(int idEntity);
        Task<TipoClaseCarga> UpdateEntity(TipoClaseCarga entity);
    }
}
