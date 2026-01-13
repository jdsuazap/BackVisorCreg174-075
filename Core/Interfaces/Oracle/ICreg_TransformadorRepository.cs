namespace Core.Interfaces.Oracle
{
    using Core.CustomEntities;
    using Core.Entities.Oracle;
    using System.Threading.Tasks;

    public interface ICreg_TransformadorRepository
    {
        #region Pereira
        Task<Transfor> GetEntityByCodigo(string codigo);
        Task<TransformadorCircuitoDto> GetEntityByCodigoInfo(string codigo);
        #endregion

        #region Ambos
        Task<Transfor> GetCargabilidadTransformador(int ciudad, string codtrafo);
        #endregion

        #region Cartago
        Task<Transfor> GetEntityByCodigoCTG(string codigo);    
        Task<TransformadorCircuitoDto> GetEntityByCodigoInfoCTG(string codigo);
        #endregion
    }
}
