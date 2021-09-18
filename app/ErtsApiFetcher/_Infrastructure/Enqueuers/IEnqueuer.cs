using ErtsApiFetcher._Infrastructure.RecurringJobs;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ErtsApiFetcher._Infrastructure.Enqueuers
{
    public interface IEnqueuer
    {
        string Enqueue(Expression<Func<Task>> func);

        string Enqueue<T>(Expression<Func<T, Task>> func);

        string Enqueue<T>(Expression<Action<T>> func);

        string Schedule(Expression<Func<Task>> func, DateTime executionTime);

        public void AddRecurringJob(IRecurringJob recurringJob);

        void DeleteScheduledJob(string jobId);
    }
}
