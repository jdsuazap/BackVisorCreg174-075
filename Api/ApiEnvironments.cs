namespace Api
{
    /// <summary>
    /// Clase para manejo de nombres de variables de entorno
    /// NOTA:: revisar archivo launchSettings.json (ASPNETCORE_ENVIRONMENT)
    /// </summary>
    public static class ApiEnvironments
    {
        public static readonly string Development = "Development";
        public static readonly string Production = "Production";
    }
}