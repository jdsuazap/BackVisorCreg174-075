using System.Linq.Expressions;

namespace Core.Interfaces
{
    public interface IHangfireJobRepository
    {
        void EnqueueJob<T>(Expression<Action<T>> methodCall);
        void ScheduleJob<T>(Expression<Action<T>> methodCall, DateTimeOffset delay);
        void ScheduleRecurringJob<T>( Expression<Action<T>> methodCall, string cronExpression);
        void UpdateScheduleRecurringJob<T>(string jobId, Expression<Action<T>> methodCall, string cronExpression);
        void RemoveJob(string jobId);
    }
}
