using ErtsApiFetcher._Infrastructure.RecurringJobs;
using ErtsApiFetcher.Configurations;
using ErtsModel;
using Hangfire;

namespace ErtsApiFetcher.RecurringJobs {
    [RecurringJobInfo(typeof(MinutelyRecurringJob), nameof(MinutelyRecurringJob), ErtsCron.Never)]
    public class MinutelyRecurringJob : RecurringJobBase, IRecurringJob {
        public MinutelyRecurringJob(ErtsContext context, AppConfig appConfig) : base(context, appConfig) { }

        [AutomaticRetry(Attempts = 0)]
        public void Job() {
            context.Database.BeginTransaction();
            FetchAndSaveAllMatches();
            context.Database.CommitTransaction();
        }

    }
}