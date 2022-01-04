using ErtsApiFetcher._Infrastructure.RecurringJobs;

namespace ErtsApiFetcher._Infrastructure.Enqueuers {
    public interface IEnqueuer {
        public void AddRecurringJob(RecurringJobInfoAttribute recurringJobInfo);
    }
}
