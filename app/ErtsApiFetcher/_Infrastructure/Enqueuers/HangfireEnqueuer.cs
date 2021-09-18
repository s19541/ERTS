using ErtsApiFetcher._Infrastructure.RecurringJobs;
using Hangfire;
using Hangfire.States;
using Hangfire.Storage;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;

namespace ErtsApiFetcher._Infrastructure.Enqueuers
{
    public class HangfireEnqueuer : IEnqueuer
    {
        private BackgroundJobClient _backgroundJobClient;
        private JobStorage _jobStorage;

        public HangfireEnqueuer(BackgroundJobClient backgroundJobClient, JobStorage jobStorage)
        {
            _backgroundJobClient = backgroundJobClient;
            _jobStorage = jobStorage;
        }

        public string Enqueue(Expression<Func<Task>> func)
        {
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            return _backgroundJobClient.Enqueue(func);
        }

        public string Enqueue<T>(Expression<Func<T, Task>> func)
        {
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            return _backgroundJobClient.Enqueue(func);
        }

        public string Enqueue<T>(Expression<Action<T>> func)
        {
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            return _backgroundJobClient.Enqueue(func);
        }

        public string Schedule(Expression<Func<Task>> func, DateTime executionTime)
        {
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            return _backgroundJobClient.Schedule(func, new DateTimeOffset(executionTime));
        }

        public void DeleteScheduledJob(string jobId)
        {
            if (string.IsNullOrEmpty(jobId))
            {
                throw new ArgumentNullException(nameof(jobId));
            }

            if (IsInScheduledState(jobId))
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
                {
                    _backgroundJobClient.Delete(jobId);
                }
            }
        }

        private bool IsInScheduledState(string jobId)
        {
            using (var storageConnection = _jobStorage.GetConnection())
            {
                JobData jobData = storageConnection.GetJobData(jobId);
                return jobData.State == ScheduledState.StateName;
            }
        }

        public void AddRecurringJob(IRecurringJob recurringJob)
        {
            RecurringJob.AddOrUpdate(recurringJob.JobName, () => recurringJob.Job(), recurringJob.CronTime);
        }
    }
}
