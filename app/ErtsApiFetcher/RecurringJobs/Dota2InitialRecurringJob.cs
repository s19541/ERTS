using ErtsApiFetcher._Infrastructure.RecurringJobs;
using ErtsApiFetcher.Configurations;
using ErtsApiFetcher.Fetchers;
using ErtsModel;
using Hangfire;

namespace ErtsApiFetcher.RecurringJobs {
    [RecurringJobInfo(typeof(Dota2InitialRecurringJob), nameof(Dota2InitialRecurringJob), ErtsCron.Never)]
    public class Dota2InitialRecurringJob : RecurringJobBase, IRecurringJob {
        private readonly Dota2DataFetcher dota2DataFetcher;
        public Dota2InitialRecurringJob(ErtsContext context, AppConfig appConfig) : base(context, appConfig) { }

        [AutomaticRetry(Attempts = 0)]
        public void Job() {
            context.Database.BeginTransaction();
            FetchAndSaveDota2Matches();
            context.Database.CommitTransaction();
        }
    }
}