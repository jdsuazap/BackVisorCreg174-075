using Hangfire;
using Hangfire.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class HangFireExtension
    {
        public static void AddHangFire(this IServiceCollection services, IConfiguration configuration)
        {
            string sgdConnString = configuration.GetConnectionString("AppEntities");

            services.AddHangfire(configuration => configuration
                       .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                       .UseSimpleAssemblyNameTypeSerializer()
                       .UseDefaultTypeSerializer()
                       //.UseRecommendedSerializerSettings()
                       //.UseDefaultCulture(CultureInfo.CurrentCulture)
                       .UseSqlServerStorage(sgdConnString, new SqlServerStorageOptions
                       {
                           PrepareSchemaIfNecessary = true,
                           //SchemaName = "hng",
                           CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                           SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                           QueuePollInterval = TimeSpan.Zero,
                           UseRecommendedIsolationLevel = true,
                           DisableGlobalLocks = true // Migration to Schema 7 is required
                       }));

            services.AddHangfireServer((sp, conf) =>
            {
                //#if DEBUG
                //                conf.Queues = new string[] { "default" };
                //#else
                //                conf.Queues = new string[] { Environment.MachineName.ToLower() };
                //#endif
                conf.Queues = new string[] { "default" };

                conf.ServerName = "ApiServer";
                conf.TimeZoneResolver = new TimeZoneConverterResolver();
                //conf.SchedulePollingInterval = TimeSpan.FromSeconds(15);
            });
        }
    }

    public sealed class TimeZoneConverterResolver : ITimeZoneResolver
    {
        public TimeZoneInfo GetTimeZoneById(string timeZoneId)
        {
            return TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
        }
    }
}
