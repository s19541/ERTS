using Hangfire;

namespace ErtsApiFetcher._Infrastructure.RecurringJobs {
    public interface IRecurringJob {

        void Job();
    }
}
