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
        private readonly BackgroundJobClient backgroundJobClient;
        private readonly JobStorage jobStorage;
        public HangfireEnqueuer(BackgroundJobClient backgroundJobClient, JobStorage jobStorage)
        {
            this.backgroundJobClient = backgroundJobClient;
            this.jobStorage = jobStorage;
        }

        public string Enqueue(Expression<Func<Task>> func)
        {
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            return backgroundJobClient.Enqueue(func);
        }

        public string Enqueue<T>(Expression<Func<T, Task>> func)
        {
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            return backgroundJobClient.Enqueue(func);
        }

        public string Enqueue<T>(Expression<Action<T>> func)
        {
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            return backgroundJobClient.Enqueue(func);
        }

        public string Schedule(Expression<Func<Task>> func, DateTime executionTime)
        {
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            return backgroundJobClient.Schedule(func, new DateTimeOffset(executionTime));
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
                    backgroundJobClient.Delete(jobId);
                }
            }
        }

        private bool IsInScheduledState(string jobId)
        {
            using (var storageConnection = jobStorage.GetConnection())
            {
                JobData jobData = storageConnection.GetJobData(jobId);
                return jobData.State == ScheduledState.StateName;
            }
        }

        public void AddRecurringJob(RecurringJobInfoAttribute recurringJobInfo)
        {
            RecurringJob.AddOrUpdate<RecurringJobActivator>(recurringJobInfo.JobName, (jobActivator) => jobActivator.CreateScopeAndActivate(recurringJobInfo.JobType), recurringJobInfo.CronTime);
        }
    }
}
