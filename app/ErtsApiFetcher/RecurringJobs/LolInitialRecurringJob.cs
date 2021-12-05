using ErtsApiFetcher._Infrastructure.RecurringJobs;
using ErtsApiFetcher.Configurations;
using ErtsApiFetcher.Fetchers;
using ErtsModel;
using Hangfire;

namespace ErtsApiFetcher.RecurringJobs {
    [RecurringJobInfo(typeof(LolInitialRecurringJob), nameof(LolInitialRecurringJob), ErtsCron.Never)]
    public class LolInitialRecurringJob : RecurringJobBase, IRecurringJob {
        private readonly LolDataFetcher lolDataFetcher;

        public LolInitialRecurringJob(ErtsContext context, AppConfig appConfig) : base(context, appConfig) { }

        [AutomaticRetry(Attempts = 0)]
        public void Job() {
            context.Database.BeginTransaction();
            FetchAndSaveLolMatches();
            context.Database.CommitTransaction();

        }
    }
}
