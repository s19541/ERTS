using ErtsApiFetcher._Infrastructure.RecurringJobs;
using ErtsApiFetcher.Configurations;
using ErtsApiFetcher.Fetchers;
using ErtsModel;
using Hangfire;

namespace ErtsApiFetcher.RecurringJobs {
    [RecurringJobInfo(typeof(CsgoInitialRecurringJob), nameof(CsgoInitialRecurringJob), ErtsCron.Never)]
    public class CsgoInitialRecurringJob : RecurringJobBase, IRecurringJob {
        private readonly CsgoDataFetcher csgoDataFetcher;
        public CsgoInitialRecurringJob(ErtsContext context, AppConfig appConfig) : base(context, appConfig) { }

        [AutomaticRetry(Attempts = 0)]
        public void Job() {
            context.Database.BeginTransaction();
            FetchAndSaveCsgoMatches();
            context.Database.CommitTransaction();
        }
    }
}
