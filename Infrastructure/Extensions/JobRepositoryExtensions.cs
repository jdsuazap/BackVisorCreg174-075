
using Core.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class JobRepositoryExtensions
    {
        public static void AddJob(this IServiceCollection svc)
        {
            svc.AddSingleton<IHangfireJobRepository, HangfireJobRepository>();
        }
    }
}
