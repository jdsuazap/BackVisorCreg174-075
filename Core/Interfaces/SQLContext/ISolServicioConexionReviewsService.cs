using Core.CustomEntities.SQLContext;
using Core.Entities.SQLContext;
using Core.ModelResponse;

namespace Core.Interfaces.SQLContext
{
    public interface ISolServicioConexionReviewsService
    {
        Task<ResponseAction> ReviewAsync(ReviewInput reviewInput, SolServicioConexion solConexion , bool useTransaction = true);
    }
}
