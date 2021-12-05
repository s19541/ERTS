using ErtsApiFetcher._Infrastructure.RecurringJobs;
using ErtsApiFetcher.Configurations;
using ErtsApiFetcher.Fetchers;
using ErtsModel;
using Hangfire;

namespace ErtsApiFetcher.RecurringJobs {
    [RecurringJobInfo(typeof(ValorantInitialRecurringJob), nameof(ValorantInitialRecurringJob), ErtsCron.Never)]
    public class ValorantInitialRecurringJob : RecurringJobBase, IRecurringJob {
        private readonly ValorantDataFetcher valorantDataFetcher;
        public ValorantInitialRecurringJob(ErtsContext context, AppConfig appConfig) : base(context, appConfig) { }

        [AutomaticRetry(Attempts = 0)]
        public void Job() {
            context.Database.BeginTransaction();
            FetchAndSaveValorantMatches();
            context.Database.CommitTransaction();
        }
    }
}
