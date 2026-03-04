namespace Core.Interfaces
{
    public interface IEmailService
    {
        public bool EnviaMail(string receptor, string mensaje, string asunto, 
            string? alias = null, List<string>? ListadoAdjuntos_URL = null);
    }
}
