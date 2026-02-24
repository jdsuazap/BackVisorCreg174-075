namespace Core.Interfaces.Oracle
{
    using Core.Entities.Oracle;
    public interface ISolServicioConexionFactibilidadService
    {        
        Task<Creg075Factibilidad> GetEntityByIdSolicitud(long Id, long idEntity, int empresa);        
    }
}
