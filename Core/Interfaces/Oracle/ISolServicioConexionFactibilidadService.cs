namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle;
    public interface ISolServicioConexionFactibilidadService
    {        
        Task<Creg075Factibilidad> GetEntityByIdSolicitud(long idEntity, int empresa);        
    }
}
