using ErtsApiFetcher._Infrastructure.RecurringJobs;
using ErtsApiFetcher.Configurations;
using ErtsApiFetcher.Fetchers;
using ErtsModel;
using Hangfire;

namespace ErtsApiFetcher.RecurringJobs {
    [RecurringJobInfo(typeof(OwInitialRecurringJob), nameof(OwInitialRecurringJob), ErtsCron.Never)]
    public class OwInitialRecurringJob : RecurringJobBase, IRecurringJob {
        private readonly OwDataFetcher owDataFetcher;
        public OwInitialRecurringJob(ErtsContext context, AppConfig appConfig) : base(context, appConfig) { }

        [AutomaticRetry(Attempts = 0)]
        public void Job() {
            context.Database.BeginTransaction();
            FetchAndSaveOwMatches();
            context.Database.CommitTransaction();
        }
    }
}