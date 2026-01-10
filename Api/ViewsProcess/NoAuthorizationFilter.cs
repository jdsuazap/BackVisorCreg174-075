using Hangfire.Dashboard;

namespace Api.ViewsProcess
{
    public class NoAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            // Permitir acceso sin restricciones
            return true;
        }
    }
}