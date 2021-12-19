using ErtsApiFetcher._Infrastructure.RecurringJobs;
using Hangfire;

namespace ErtsApiFetcher._Infrastructure.Enqueuers {
    public class HangfireEnqueuer : IEnqueuer {
        private readonly BackgroundJobClient backgroundJobClient;
        private readonly JobStorage jobStorage;
        public HangfireEnqueuer(BackgroundJobClient backgroundJobClient, JobStorage jobStorage) {
            this.backgroundJobClient = backgroundJobClient;
            this.jobStorage = jobStorage;
        }

        public void AddRecurringJob(RecurringJobInfoAttribute recurringJobInfo) {
            RecurringJob.AddOrUpdate<RecurringJobActivator>(recurringJobInfo.JobName, (jobActivator) => jobActivator.CreateScopeAndActivate(recurringJobInfo.JobType), recurringJobInfo.CronTime);
        }
    }
}
