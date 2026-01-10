namespace Infrastructure.Repositories
{
    using Core.Interfaces;
    using Hangfire;
    using System.Linq.Expressions;

    public class HangfireJobRepository : IHangfireJobRepository
    {
        private readonly RecurringJobOptions JobOptions = new()
        {
            TimeZone = TimeZoneInfo.Local
        };

        public void EnqueueJob<T>(Expression<Action<T>> methodCall)
        {
            BackgroundJob.Enqueue(methodCall);
        }

        public void ScheduleJob<T>(Expression<Action<T>> methodCall, DateTimeOffset delay)
        {
            BackgroundJob.Schedule(methodCall, delay);
        }

        public void ScheduleRecurringJob<T>(Expression<Action<T>> methodCall, string cronExpression)
        {
            RecurringJob.AddOrUpdate(Guid.NewGuid().ToString(), methodCall, cronExpression, JobOptions);
        }
        public void UpdateScheduleRecurringJob<T>(string jobId, Expression<Action<T>> methodCall, string cronExpression)
        {
            RecurringJob.AddOrUpdate(jobId, methodCall, cronExpression, JobOptions);
        }

        public void RemoveJob(string jobId)
        {
            BackgroundJob.Delete(jobId);
        }
    }
}
