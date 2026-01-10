namespace Core.Services.SQLContext
{
    using Core.CustomEntities.SQLContext;
    using Core.Entities.SQLContext;
    using Core.Exceptions;
    using Core.Interfaces;
    using Core.Interfaces.SQLContext;
    using Core.ModelResponse;
    using Core.Options;
    using Microsoft.EntityFrameworkCore.Storage;
    using Microsoft.Extensions.Options;

    public class SolServicioConexionReviewsService
     : SolServicioConexionSubSanacionService, ISolServicioConexionReviewsService
    {
        public SolServicioConexionReviewsService(
            IUnitOfWork unitOfWork,
            IOptions<PathOptions> pathOptions)
            : base(unitOfWork, pathOptions)
        {
        }

        public async Task<ResponseAction> ReviewAsync(ReviewInput reviewInput, SolServicioConexion solConexion, bool useTransaction = true)
        {
            IDbContextTransaction transaction = null;
            if (useTransaction)
                transaction = await _unitOfWork.BeginTransactionAsync();

            try
            {
                //Obteniendo datos "SolConexionAutogen" para actualizar el estado de la solicitud
                if (solConexion != null)
                {
                    //Obteniendo el Estado para la solicitud
                    var newState = (int)(reviewInput.Entity.Aprobado ? reviewInput.ApprovedStatus : reviewInput.RejectedStatus);

                    solConexion.CodEstado = newState;
                    solConexion.CodUserUpdate = reviewInput.Entity.CodUserUpdate;
                    solConexion.FechaRegistroUpdate = DateTime.Now;

                    //Si es rechazada la documentación de la solicitud

                    reviewInput.Entity.CodUser = reviewInput.Entity.CodUserUpdate;
                    reviewInput.Entity.FechaRegistro = solConexion.FechaRegistroUpdate;
                    reviewInput.Entity.FechaRegistroUpdate = solConexion.FechaRegistroUpdate;

                    //Registrando el rechazo
                    var review = await _unitOfWork.SolServicioConexionReviewRepository.CreateEntity(reviewInput.Entity);
                 
                    //Mensaje
                    var mensaje = reviewInput.Entity.Aprobado ? reviewInput.ApprovedMessage : reviewInput.RejectedMessage;

                    //Generar Notificaciones
                    if (reviewInput.EnviaCorreo)
                    {
                        
                    }

                    //Terminando la transacción
                    if (useTransaction)
                        await transaction.CommitAsync();

                    return new()
                    {
                        estado = true,
                        mensaje = mensaje
                    };
                }
                else
                {
                    return new()
                    {
                        estado = false,
                        mensaje = "Entidad Nula"
                    };
                }
            }
            catch (Exception e)
            {
                //Cancelando la transacción
                if (useTransaction)
                    await transaction.RollbackAsync();
                throw new BusinessException(e.Message);
            }
            finally
            {
                if (useTransaction)
                    await transaction.DisposeAsync();
            }
        }
    }
}
