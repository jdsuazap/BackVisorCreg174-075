namespace Core.Interfaces.Oracle
{
    using Core.CustomEntities;
    using Core.Entities.Oracle;

    public interface ICreg_TransformadorService
    {
        #region Pereira        
        Task<Transfor> GetEntityByCodigo(string codigo);               

        Task<TransformadorCircuitoDto> GetEntityByCodigoInfo(string codigo);
        #endregion

        #region Cartago
        Task<Transfor> GetEntityByCodigoCTG(string codigo);       
        Task<TransformadorCircuitoDto> GetEntityByCodigoInfoCTG(string codigo);

        Task<(double CapTotalKw, double CapDisponibleKw, double PorcentajeInstalado, decimal factorPotencia, decimal potencia_reservada)>
            CalcularCapacidadTransformador(string codigo, int empresa, double capKva);
        #endregion

    }
}
