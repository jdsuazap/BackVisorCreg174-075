namespace Core.Interfaces.Oracle
{
    public interface ICodigoVerificacionService
    {
        Task<string> GenerarCodigoVerificacion(string contacto, string titulo, string mensaje);

        bool ValidarCodigoVerificacion(string email, string codigoIngresado);
    }
}
