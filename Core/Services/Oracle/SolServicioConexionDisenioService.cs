namespace Core.Services.Oracle
{
    using Core.Entities.Oracle;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;
    using System.Linq.Expressions;

    public class SolServicioConexionDisenioService : ISolServicioConexionDisenioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SolServicioConexionDisenioService(
            IUnitOfWork unitOfWork
        )
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Creg075Disenio>> GetAll(Expression<Func<Creg075Disenio, bool>> filter = null, Func<IQueryable<Creg075Disenio>, IOrderedQueryable<Creg075Disenio>>? orderBy = null, bool isTracking = false, params Expression<Func<Creg075Disenio, object>>[] includeObjectProperties)
        {            
            return await _unitOfWork.SolServicioConexionDisenioRepository.GetAll(filter, orderBy, null, isTracking, includeObjectProperties);
        }

        //public async Task<List<SolServicioConexionDisenio>> GetEntities()
        //{
        //    return await _unitOfWork.SolServicioConexionDisenioRepository.GetEntities();
        //}

        //public async Task<SolServicioConexionDisenio> GetEntity(long idEntity)
        //{
        //    return await _unitOfWork.SolServicioConexionDisenioRepository.GetEntity(idEntity);
        //}

        //public async Task<SolServicioConexionDisenio> UpdateEntity(SolServicioConexionDisenio entity)
        //{
        //    return await _unitOfWork.SolServicioConexionDisenioRepository.UpdateEntity(entity);
        //}

        //private static CorreosEnum GetCorreoEnum(SolServicioConexion entity)
        //{
        //    var toMailId = CorreosEnum.Notificacion_Creg075;

        //    if (entity.CodTipoConexion == (int)TipoConexionEnum.Sencilla)
        //    {
        //        toMailId = CorreosEnum.Notificacion_Creg075_SolSencillas;
        //    }
        //    else if (entity.CodTipoConexion == (int)TipoConexionEnum.Compleja)
        //    {
        //        toMailId = CorreosEnum.Notificacion_Creg075_SolComplejas;
        //    }

        //    return toMailId;
        //}

        //public async Task<List<string>> GetOtherMails()
        //{
        //    /*var listGestores = await _unitOfWork.PerfilesXusuarioRepository.GetListadoCodUsuarioNotificaciones(
        //        new List<int> {
        //            (int)PerfilesEnum.SuperAdministrador,
        //            (int)PerfilesEnum.Administrador_CREG_075,
        //            (int)PerfilesEnum.Operativo_CREG_075
        //        }
        //    );

        //    List<string> mailList = new();

        //    foreach (var item in listGestores)
        //    {
        //        var user = (await _unitOfWork.UsuarioRepository.GetUsuarioPorId(item.Id)).FirstOrDefault();
        //        if (user != null)
        //        {
        //            string gestMail = user.UsrEmail;
        //            mailList.Add(gestMail);
        //        }
        //    }

        //    return mailList.Distinct().ToList();*/

        //    return null;
        //}

        //private async Task<List<string>> GetNotificationUsers(SolServicioConexion entity)
        //{
        //    // Consultamos email del propetario de la cuenta en el portal, consultando por codigo de usuario
        //    _ = int.TryParse(entity.CodUser, out int codUsuarioPortal);
        //    var user = (await _unitOfWork.UsuarioRepository.GetUsuarioPorId(codUsuarioPortal)).FirstOrDefault();

        //    var emailList = new List<string> { };

        //    if (entity.SolServicioConexionDatosSolicitante != null)
        //    {
        //        emailList.Add(entity.SolServicioConexionDatosSolicitante.Email);
        //    }

        //    if (entity.SolServicioConexionDatosSuscriptor != null)
        //    {
        //        emailList.Add(entity.SolServicioConexionDatosSuscriptor.Email);
        //    }

        //    if (user != null)
        //    {
        //        emailList.Add(user.UsrEmail);
        //    }

        //    return [.. emailList.Distinct()];
        //}

        //private async Task UpdateAlerts(int codSolServicioConexion)
        //{
        //    var alertasSolServcioConexion = await _unitOfWork.AlertaSolServicioConexionRepository.GetAllAsync(filter: x => x.CodServicioConexion == codSolServicioConexion && x.Estado.HasValue && x.Estado.Value);
        //    foreach (var item in alertasSolServcioConexion)
        //    {
        //        item.Estado = false;
        //        await _unitOfWork.AlertaSolServicioConexionRepository.UpdateEntity(item);
        //    }
        //}
    }
}
